/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2021 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;
using System.Reflection;
using System.Threading;

using thZero.Services;

namespace thZero
{
    public abstract class Factory : FactoryBase
    {
        #region Public Methods
        /// <summary>
        /// Initializes a specific factory by type.
        /// </summary>
        public static void Initialize<TFactory>() where TFactory : Factory
        {
            if (_instance != null)
                return;

            lock (Lock)
            {
                if (_instance != null)
                    return;

                _instance = Utilities.Activator.CreateInstance<TFactory>();

                _instance.InitializeInstance();
            }
        }

        public static void Initialize(Type type)
        {
            if (_instance != null)
                return;

            lock (Lock)
            {
                if (_instance != null)
                    return;

                if (type != null)
                    _instance = Utilities.Activator.CreateInstance<Factory>(type);

                if (_instance == null)
                    throw new UninitializedFactoryException("Factory has not be initialized.");

                _instance.InitializeInstance();
            }
        }

        public static void InitializeByAttribute(object root)
        {
            if (_instance != null)
                return;

            lock (Lock)
            {
                if (_instance != null)
                    return;

                if (root != null)
                {
                    FactoryAttribute attribute = null;

                    if (root is Assembly assembly)
                        attribute = Utilities.Attributes.GetCustomAttribute<FactoryAttribute>(assembly);
                    else
                        attribute = Utilities.Attributes.GetCustomAttribute<FactoryAttribute>(root);

                    if (attribute != null)
                    {
                        if (attribute.FactoryType == null)
                            throw new InvalidTypeInversionContainerException("Invalid FactoryAttribute value found on the Factory attribute.");

                        _instance = Utilities.Activator.CreateInstance<Factory>(attribute.FactoryType);
                    }
                }

                if (_instance == null)
                    throw new UninitializedFactoryException("Factory has not be initialized.");

                _instance.InitializeInstance();
            }
        }

        public static void InitializeByAttribute(Type type)
        {
            if (_instance != null)
                return;

            lock (Lock)
            {
                if (_instance != null)
                    return;

                if (type != null)
                {
                    FactoryAttribute attribute = Utilities.Attributes.GetCustomAttribute<FactoryAttribute>(type);
                    if (attribute != null)
                    {
                        if (attribute.FactoryType == null)
                            throw new InvalidTypeInversionContainerException("Invalid FactoryAttribute value found on the Factory attribute.");

                        _instance = Utilities.Activator.CreateInstance<Factory>(attribute.FactoryType);
                    }
                }

                if (_instance == null)
                    throw new UninitializedFactoryException("Factory has not be initialized.");

                _instance.InitializeInstance();
            }
        }

        /// <summary>
        /// Initializes the logging factory. If not specified the logging factory defaults to ProviderLogFactoryNull.
        /// </summary>
        public static void InitializeProviderLogFactory(string type)
        {
            Enforce.AgainstNullOrEmpty(() => type);

            object result = Activator.CreateInstance(Type.GetType(type));
            if (result == null)
                return;

            if (result.GetType().GetTypeInfo().IsAssignableFrom(typeof(IServiceLogFactory)))
                throw new InvalidFactoryException("Invalid IServiceLogFactory type.");

            _instance.AddSingleton<IServiceLogFactory>((IServiceLogFactory)result);
        }

        /// <summary>
        /// Initializes the logging factory. If not specified the logging factory defaults to ProviderLogFactoryNull.
        /// </summary>
        public static void InitializeProviderLogFactory(Type type)
        {
            Enforce.AgainstNull(() => type);

            if (type.GetTypeInfo().IsAssignableFrom(typeof(IServiceLogFactory)))
                throw new InvalidFactoryException("Invalid IServiceLogFactory type.");

            _instance.AddSingleton(typeof(IServiceLogFactory), type);
        }

        /// <summary>
        /// Initializes the log factory. If not specified the log factory defaults to ProviderLogFactoryNull.
        /// </summary>
        public static void InitializeProviderLogFactory<TLogFactory>()
                where TLogFactory : class, IServiceLogFactory
        {
            _instance.AddSingleton<IServiceLogFactory, TLogFactory>();
        }

        public static void Reset()
        {
            Reset(null);
        }

        public static void Reset(object root)
        {
            _instance = null;

            InitializeByAttribute(root);
        }

        public static void Reset<TFactory>() where TFactory : Factory
        {
            _instance = null;

            Initialize<TFactory>();
        }

#pragma warning disable CA1822 // Mark members as static
        public IServiceLog RetrieveLogger(Type type)
#pragma warning restore CA1822 // Mark members as static
        {
            Enforce.AgainstNull(() => type);

            return LogFactory.RetrieveLogger(type);
        }

#pragma warning disable CA1822 // Mark members as static
        public IServiceLog RetrieveLogger(string typeName)
#pragma warning restore CA1822 // Mark members as static
        {
            Enforce.AgainstNull(() => typeName);

            return LogFactory.RetrieveLogger(typeName);
        }
        #endregion

        #region Public Properties
        public static Factory Instance
        {
            get
            {
                if (_instance == null)
                    throw new UninitializedFactoryException("Factory has not be initialized.");

                return _instance;
            }
        }
        #endregion

        #region Private Properties
        private static IServiceLogFactory LogFactory
        {
            get
            {
                IServiceLogFactory factory = null;
                try
                {
                    // Enter the read lock, many threads can get through the read lock
                    LockLog.EnterReadLock();

                    factory = (IServiceLogFactory)Instance.Retrieve<IServiceLogFactory>();
                    // If we have a factory instance, return the instance.
                    if (factory != null)
                        return factory;
                }
                finally
                {
                    LockLog.ExitReadLock();
                }

                try
                {
                    // Enter write lock so that we can create the factory instance.
                    LockLog.EnterWriteLock();

                    // If we have a factory instance, return the instance.
                    if (factory != null)
                        return factory;

                    // Double check to see if the factory is still null, if it is another
                    // thread hasn't already beat us to the punch.
                    if (factory == null)
                        //factory = new Services.Log.ServiceLogFactoryNull();
                        factory = new Services.Log.ServiceLogFactoryDefault();
                }
                finally
                {
                    LockLog.ExitWriteLock();
                }

                return factory;
            }
        }
        #endregion

        #region Fields
        private static volatile Factory _instance;
        public static readonly object Lock = new();
        private static readonly ReaderWriterLockSlim LockLog = new();
        #endregion
    }
}
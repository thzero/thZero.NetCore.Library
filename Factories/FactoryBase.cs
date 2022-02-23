/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2022 thZero.com

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
using System.Collections.Generic;

namespace thZero
{
    public abstract class FactoryBase
    {
        #region Public Methods
        public abstract void Add(Type type, Type typeInstance, params FactoryConstructorArgument[] parameters);
        public abstract void Add(Type type, Type typeInstance, string named, params FactoryConstructorArgument[] parameters);

        public abstract void Add<TProviderType>(Type typeInstance, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;
        public abstract void Add<TProviderType>(Type typeInstance, string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;

        public abstract void Add<TProviderType, TInstanceType>(params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;
        public abstract void Add<TProviderType, TInstanceType>(string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;

        public abstract void AddContext<TProviderType, TInstanceType>(params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;
        public abstract void AddContext<TProviderType, TInstanceType>(string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;

        public abstract void AddSingleton(Type providerType, object provider, params FactoryConstructorArgument[] parameters);
        public abstract void AddSingleton(Type providerType, object provider, string named, params FactoryConstructorArgument[] parameters);

        public abstract void AddSingleton(Type providerType, Type typeInstance, params FactoryConstructorArgument[] parameters);
        public abstract void AddSingleton(Type providerType, Type typeInstance, string named, params FactoryConstructorArgument[] parameters);

        public abstract void AddSingleton<TProviderType>(string type, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;
        public abstract void AddSingleton<TProviderType>(string type, string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;

        public abstract void AddSingleton<TProviderType>(Type typeInstance, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;
        public abstract void AddSingleton<TProviderType>(Type typeInstance, string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;

        public abstract void AddSingleton<TProviderType>(TProviderType instanceType, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;
        public abstract void AddSingleton<TProviderType>(TProviderType instanceType, string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class;

        public abstract void AddSingleton<TProviderType, TInstanceType>(params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;
        public abstract void AddSingleton<TProviderType, TInstanceType>(string named, params FactoryConstructorArgument[] parameters)
                where TProviderType : class
                where TInstanceType : class, TProviderType;

        public abstract TProviderType Retrieve<TProviderType>();
        public abstract TProviderType Retrieve<TProviderType>(params FactoryConstructorArgument[] args);
        public abstract TProviderType Retrieve<TProviderType>(string named);
        public abstract TProviderType Retrieve<TProviderType>(string named, params FactoryConstructorArgument[] args);

        public abstract object Retrieve(Type providerType);
        public abstract object Retrieve(Type providerType, params FactoryConstructorArgument[] args);
        public abstract object Retrieve(Type providerType, string named);
        public abstract object Retrieve(Type providerType, string named, params FactoryConstructorArgument[] args);

        public abstract IEnumerable<TProviderType> Retrieves<TProviderType>();

        public abstract IEnumerable<object> Retrieves(Type providerType);
        #endregion

        #region Protected Methods
        protected internal abstract void InitializeInstance();
        #endregion
    }
}
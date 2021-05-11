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
using System.Globalization;

using Microsoft.Extensions.Logging;

namespace thZero.Services
{
	public sealed class ServiceLocalizationBasicFactory : Internal.ServiceLocalizationBasicBase<ServiceLocalizationBasicFactory>, IServiceLocalization
    {
		private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceLocalizationBasicFactory() : base(log, null)
        {
        }
    }

    public class ServiceLocalizationBasic : ServiceLoggableBase<ServiceLocalizationBasic>, IServiceLocalization
    {
        public ServiceLocalizationBasic(ILogger<ServiceLocalizationBasic> logger) : base(logger)
        {
            _instance = new Internal.ServiceLocalizationBasicBase<ServiceLocalizationBasic>(null, logger);
        }

        #region Public Methods
        public void Initialize(IServiceLocalizationIntializer initializer, Type type)
        {
            _instance.Initialize(initializer, type);
        }

        #region Add Cultures
        public void AddCultureResource(string resourceName)
        {
            _instance.AddCultureResource(resourceName);
        }

        public void AddCultureResource(System.Reflection.Assembly assembly)
        {
            _instance.AddCultureResource(assembly);
        }

        public void AddCultureResourceType(CultureInfo culture, string name)
        {
            _instance.AddCultureResourceType(culture, name);
        }
        #endregion

        #region Get Localized Strings
        public string GetLocalizedString(string abbreviation, params object[] args)
        {
            return _instance.GetLocalizedString(abbreviation, args);
        }

        public string GetLocalizedStringDefault(string abbreviation, string defaultValue, params object[] args)
        {
            return _instance.GetLocalizedString(abbreviation, defaultValue, args);
        }

        public string GetLocalizedStringWithResource(string abbreviation, string resource, params object[] args)
        {
            return _instance.GetLocalizedString(abbreviation, resource, args);
        }

        public string GetLocalizedStringWithResourceDefault(string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return _instance.GetLocalizedString(abbreviation, resource, defaultValue, args);
        }

        public string GetLocalizedString(CultureInfo culture, string abbreviation, params object[] args)
        {
            return _instance.GetLocalizedString(culture, abbreviation, args);
        }

        public string GetLocalizedStringDefault(CultureInfo culture, string abbreviation, string defaultValue, params object[] args)
        {
            return _instance.GetLocalizedString(culture, abbreviation, defaultValue, args);
        }

        public string GetLocalizedStringWithResource(CultureInfo culture, string abbreviation, string resource, params object[] args)
        {
            return _instance.GetLocalizedString(culture, abbreviation, resource, args);
        }

        public string GetLocalizedStringWithResourceDefault(CultureInfo culture, string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return _instance.GetLocalizedString(culture, abbreviation, resource, defaultValue, args);
        }
        #endregion

        #region Load
        public void LoadCultureResources(string rootPath)
        {
            _instance.LoadCultureResources(rootPath);
        }

        public void LoadCultureResources(string rootPath, string resourceFolder)
        {
            _instance.LoadCultureResources(rootPath, resourceFolder);
        }

        public void LoadCultureResourcesClient()
        {
            _instance.LoadCultureResourcesClient();
        }

        public void LoadCultureResourcesAll(string rootPath, string resourceFolder)
        {
            _instance.LoadCultureResourcesAll(rootPath, resourceFolder);
        }

        public void LoadCultureResourcesAll(string rootPath, string resourceFolder, CultureInfo defaultCulture)
        {
            _instance.LoadCultureResourcesAll(rootPath, resourceFolder, defaultCulture);
        }

        public void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder)
        {
            _instance.LoadCultureResources(culture, rootPath, resourceFolder);
        }

        public void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder, CultureInfo defaultCulture)
        {
            _instance.LoadCultureResources(culture, rootPath, resourceFolder, defaultCulture);
        }
        #endregion

        #endregion

        #region Public Properties
        public CultureInfo DefaultCulture
        {
            get { return _instance.DefaultCulture; }
            set { _instance.DefaultCulture = value; }
        }

        public string DefaultResource
        {
            get { return _instance.DefaultResource; }
            set { _instance.DefaultResource = value; }
        }

        public string ResourceFolder
        {
            get { return _instance.ResourceFolder; }
            set { _instance.ResourceFolder = value; }
        }

        public string RootPath
        {
            get { return _instance.RootPath; }
            set { _instance.RootPath = value; }
        }
        #endregion

        #region Fields
        private static Internal.ServiceLocalizationBasicBase<ServiceLocalizationBasic> _instance;
        #endregion
    }
}

namespace thZero.Services.Internal
{
    public class ServiceLocalizationBasicBase<TService> : IntermediaryServiceBase<TService>
    {
        public ServiceLocalizationBasicBase(thZero.Services.IServiceLog log, ILogger<TService> logger) : base(log, logger)
        {
        }

        #region Public Methods
        public void Initialize(IServiceLocalizationIntializer value, Type type)
        {
        }

        #region Add Cultures
        public void AddCultureResource(string resourceName)
        {
        }

        public void AddCultureResource(System.Reflection.Assembly assembly)
        {
        }

        public void AddCultureResourceType(CultureInfo culture, string name)
        {
        }
        #endregion

        #region Get Localized Strings
        public string GetLocalizedString(string abbreviation, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringDefault(string abbreviation, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResource(string abbreviation, string resource, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResourceDefault(string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedString(CultureInfo culture, string abbreviation, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringDefault(CultureInfo culture, string abbreviation, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResource(CultureInfo culture, string abbreviation, string resource, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResourceDefault(CultureInfo culture, string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedString(Type type, string abbreviation, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringDefault(Type type, string abbreviation, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResource(Type type, string abbreviation, string resource, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResourceDefault(Type type, string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedString(CultureInfo culture, Type type, string abbreviation, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringDefault(CultureInfo culture, Type type, string abbreviation, string defaultValue, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResource(CultureInfo culture, Type type, string abbreviation, string resource, params object[] args)
        {
            return abbreviation;
        }

        public string GetLocalizedStringWithResourceDefault(CultureInfo culture, Type type, string abbreviation, string resource, string defaultValue, params object[] args)
        {
            return abbreviation;
        }
        #endregion

        #region Load
        public void LoadCultureResources(string rootPath)
        {
        }

        public void LoadCultureResources(string rootPath, string resourceFolder)
        {
        }

        public void LoadCultureResourcesClient()
        {
        }

        public void LoadCultureResourcesAll(string rootPath, string resourceFolder)
        {
        }

        public void LoadCultureResourcesAll(string rootPath, string resourceFolder, CultureInfo defaultCulture)
        {
        }

        public void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder)
        {
        }

        public void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder, CultureInfo defaultCulture)
        {
        }
        #endregion

        #endregion

        #region Public Properties
        public CultureInfo DefaultCulture { get; set; } = CultureInfo.CurrentCulture;

        public string DefaultResource
        {
            get { return _defaultResource; }
            set { _defaultResource = value; }
        }

        public string ResourceFolder
        {
            get;
            set;
        }

        public string RootPath
        {
            get;
            set;
        }
        #endregion

        #region Fields
        private static string _defaultResource = "strings";
        #endregion
    }
}
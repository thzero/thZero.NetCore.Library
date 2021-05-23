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

namespace thZero.Services
{
    public interface IServiceLocalization : IService
    {
        #region Methods
        void AddCultureResource(string resourceName);
        void AddCultureResource(System.Reflection.Assembly assembly);
        void AddCultureResourceType(CultureInfo culture, string name);

        string GetLocalizedString(string abbreviation, params object[] args);
        string GetLocalizedStringDefault(string abbreviation, string defaultValue, params object[] args);
        string GetLocalizedStringWithResource(string abbreviation, string resource, params object[] args);
        string GetLocalizedStringWithResourceDefault(string abbreviation, string resource, string defaultValue, params object[] args);
        string GetLocalizedString(CultureInfo culture, string abbreviation, params object[] args);
        string GetLocalizedStringDefault(CultureInfo culture, string abbreviation, string defaultValue, params object[] args);
        string GetLocalizedStringWithResource(CultureInfo culture, string abbreviation, string resource, params object[] args);
        string GetLocalizedStringWithResourceDefault(CultureInfo culture, string abbreviation, string resource, string defaultValue, params object[] args);

        void Initialize(IServiceLocalizationIntializer initializer, Type type);

        void LoadCultureResources(string rootPath);
        void LoadCultureResources(string rootPath, string resourceFolder);
        void LoadCultureResourcesClient();
        void LoadCultureResourcesAll(string rootPath, string resourceFolder);
        void LoadCultureResourcesAll(string rootPath, string resourceFolder, CultureInfo defaultCulture);
        void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder);
        void LoadCultureResources(CultureInfo culture, string rootPath, string resourceFolder, CultureInfo defaultCulture);
        #endregion

        #region Properties
        CultureInfo DefaultCulture { get; set; }
        string DefaultResource { get; set; }
        string ResourceFolder { get; set; }
        string RootPath { get; set; }
        #endregion
    }

    public interface IServiceLocalizationIntializer
    {
    }
}
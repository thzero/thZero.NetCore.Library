/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2018 thZero.com

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

namespace thZero.Services
{
	public sealed class ServiceVersionInformation : IServiceVersionInformation
	{
		#region Public Properties
		public string ApplicationName { get; set; }

		public DateTime BuildDate { get; set; }
		public string BuildDateFormatted { get { return string.Format(BuildDateFormat, BuildDate); } }

		public Version Version { get; set; }
		public string VersionFormatted
		{
			get
			{
				if (!string.IsNullOrEmpty(_versionFormatted))
					return _versionFormatted;

				lock (_lock)
				{
					if (!string.IsNullOrEmpty(_versionFormatted))
						return _versionFormatted;

					_versionFormatted = Unknown;
					if (Version == null)
						return _versionFormatted;

					_versionFormatted = string.Concat(Version.Major, Separator, Version.Minor, Separator, Version.Build);
				}

				return _versionFormatted;
			}
		}
		#endregion

		#region Fields
		private static volatile Version _version;
		private static string _versionFormatted;
		private static readonly object _lock = new object();
		#endregion

		#region Constants
		private const string BuildDateFormat = "F";
		private const string Separator = ".";
		private const string Unknown = "<unknown>";
		#endregion
	}
}
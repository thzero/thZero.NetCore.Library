/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2019 thZero.com

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

namespace thZero.Configuration
{
	public class ApplicationEmail
	{
        public ApplicationEmail()
        {
            Smtp = new ApplicationEmailSmtp();
        }

		public bool Enabled { get; set; }
		public string AddressCopyright { get; set; }
		public string AddressCopyrightDisplayName { get; set; }
		public string AddressFrom { get; set; }
		public string AddressFromDisplayName { get; set; }
		public string AddressInfo { get; set; }
		public string AddressInfoDisplayName { get; set; }
		public string AddressPrivacy { get; set; }
		public string AddressPrivacyDisplayName { get; set; }
		public string AddressTerms { get; set; }
		public string AddressTermsDisplayName { get; set; }
        public ApplicationEmailSmtp Smtp { get; set; }
    }

    public class ApplicationEmailSmtp
    {
        public string Port { get; set; }
        public string Server { get; set; }
        public bool Ssl { get; set; }
        public string User { get; set; }
        public string UserPassword { get; set; }
    }
}
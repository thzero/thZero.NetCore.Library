﻿/* ------------------------------------------------------------------------- *
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

namespace thZero.Responses
{
	public class DurationResponseResultItem : IDurationResponseResultItem
	{
		#region Public Properties
		public long Duration { get; set; }
		public long DurationEnd { get; set; }
		public long DurationFrequency { get; set; }
		public long DurationMilliseconds { get; set; }
		public long DurationStart { get; set; }
		public int? Index { get; set; }
		public string Name { get; set; }
		#endregion
	}
}
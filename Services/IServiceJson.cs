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
using System.IO;

namespace thZero.Services
{
	public interface IServiceJson : IService
	{
		#region Methods
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		T Deserialize<T>(string data);
		object Deserialize(string data, Type type);
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		T Deserialize<T>(Stream stream);
		object Deserialize(Stream stream, Type type);
		object DeserializeObject(string data);
		string Serialize(object data);
		void Serialize(object data, Stream stream);
		#endregion

		#region Properties
		IServiceJsonSettings Settings { get; }
		#endregion
	}
}
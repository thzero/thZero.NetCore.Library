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

namespace thZero
{
	public sealed class InvalidFactoryException : InvalidOperationException
	{
		public InvalidFactoryException() : base() { }
		public InvalidFactoryException(string message) : base(message) { }
		public InvalidFactoryException(string message, Exception inner) : base(message, inner) { }
	}

	public sealed class InvalidTypeInversionContainerException : InvalidOperationException
	{
		public InvalidTypeInversionContainerException() : base() { }
		public InvalidTypeInversionContainerException(string message) : base(message) { }
		public InvalidTypeInversionContainerException(string message, Exception inner) : base(message, inner) { }
	}

	public sealed class UninitializedFactoryException : InvalidOperationException
	{
		public UninitializedFactoryException() : base() { }
		public UninitializedFactoryException(string message) : base(message) { }
		public UninitializedFactoryException(string message, Exception inner) : base(message, inner) { }
	}
}
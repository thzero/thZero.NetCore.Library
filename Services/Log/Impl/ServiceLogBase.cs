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

namespace thZero.Services.Log
{
	public abstract class ServiceLogBase
	{
		#region Public Properties
		public bool IsDebugEnabled
		{
			get { return _isDebug; }
			set { _isDebug = value; }
		}

		public bool IsDiagnosticEnabled
		{
			get { return _isDiagnostic; }
			set { _isDiagnostic = value; }
		}

		public bool IsErrorEnabled
		{
			get { return _isError; }
			set { _isError = value; }
		}

		public bool IsFatalEnabled
		{
			get { return _isFatal; }
			set { _isFatal = value; }
		}

		public bool IsInfoEnabled
		{
			get { return _isInfo; }
			set { _isInfo = value; }
		}

		public bool IsQueryEnabled
		{
			get { return _isQuery; }
			set { _isQuery = value; }
		}

		public bool IsSecurityEnabled
		{
			get { return _isSecurity; }
			set { _isSecurity = value; }
		}

		public bool IsTimingEnabled
		{
			get { return _isTiming; }
			set { _isTiming = value; }
		}

		public bool IsTraceEnabled
		{
			get { return _isTrace; }
			set { _isTrace = value; }
		}

		public bool IsVerboseEnabled
		{
			get { return _isVerbose; }
			set { _isVerbose = value; }
		}

		public bool IsWarnEnabled
		{
			get { return _isWarn; }
			set { _isWarn = value; }
		}
		#endregion

		#region Fields
		private static bool _isDebug = true;
		private static bool _isDiagnostic = true;
		private static bool _isError = true;
		private static bool _isFatal = true;
		private static bool _isInfo = true;
		private static bool _isQuery = true;
		private static bool _isSecurity = true;
		private static bool _isTiming = true;
		private static bool _isTrace = true;
		private static bool _isVerbose = true;
		private static bool _isWarn = true;
		#endregion

		#region Constants
		protected const string LevelDebug = "DEBUG";
		protected const string LevelDiagnostic = "DIAGNOSTIC";
		protected const string LevelError = "ERROR";
		protected const string LevelFatal = "FATAL";
		protected const string LevelInfo = "INFO";
		protected const string LevelQuery = "QUERY";
		protected const string LevelSecurity = "SECURITY";
		protected const string LevelTiming = "TIMING";
		protected const string LevelTrace = "TRACE";
		protected const string LevelVerbose = "VERBOSE";
		protected const string LevelWarn = "WARN";
		#endregion
	}
}
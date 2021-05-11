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

namespace thZero.Services
{
	public interface IServiceLog : IService
	{
		#region Methods
		void Debug(object message);
		void Debug(string method, object message);
		void Debug(string method, object message, Exception ex);
		void Debug(string method, object message, object value);
		void Diagnostic(object message);
		void Diagnostic(string method, object message);
		void Diagnostic(string method, object message, Exception ex);
		void Diagnostic(string method, object message, object value);
		void Error(string method, object message);
		void Error(string method, Exception ex);
		void Error(string method, Exception ex, params string[] additional);
		void Error(string method, object message, Exception ex, params string[] additional);
		void Fatal(string method, object message);
		void Fatal(string method, Exception ex);
		void Fatal(string method, object message, Exception ex);
		void Info(object message);
		void Info(string method, object message);
		void Info(string method, object message, Exception ex);
		void Query(object message);
		void Query(string method, object message, object value);
		void Security(object message);
		void Timing(object message);
		void Timing(string method, object message);
		void Timing(string method, object message, Exception ex);
		void Timing(string method, object message, object value);
		void Trace(string method, object message);
		void Trace(string method, object message, Exception ex);
		void Trace(string method, object message, object value);
		void TraceFinish(string method);
		void TraceStart(string method);
		void Verbose(object message);
		void Verbose(string method, object message);
		void Verbose(string method, object message, Exception ex);
		void Verbose(string method, object message, object value);
		void Warn(string method, object message);
		void Warn(string method, object message, Exception ex);
		#endregion

		#region Properties
		bool IsDebugEnabled { get; set; }
		bool IsDiagnosticEnabled { get; set; }
		bool IsErrorEnabled { get; set; }
		bool IsFatalEnabled { get; set; }
		bool IsInfoEnabled { get; set; }
		bool IsQueryEnabled { get; set; }
		bool IsSecurityEnabled { get; set; }
		bool IsTimingEnabled { get; set; }
		bool IsTraceEnabled { get; set; }
		bool IsVerboseEnabled { get; set; }
		bool IsWarnEnabled { get; set; }
		#endregion
	}
}
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
using System.Text;

using Microsoft.Extensions.Logging;

namespace thZero.Services.Log
{
    /// <summary>
    /// Creates a logger, that logs all messages to: ILogger
    /// </summary>
    public class ServiceLogFactoryDefault : IServiceLogFactory
    {
        public void Initialize(params object[] args)
        {
        }

        public IServiceLog RetrieveLogger(Type type)
        {
            Enforce.AgainstNull(() => type);

            return new ProviderLogDefault(Utilities.Services.LoggerFactory.Instance.CreateLogger(type.Name));
        }

        public IServiceLog RetrieveLogger(string typeName)
        {
            Enforce.AgainstNullOrEmpty(() => typeName);

            return new ProviderLogDefault(Utilities.Services.LoggerFactory.Instance.CreateLogger(typeName));
        }
    }

    /// <summary>
    /// Default logger is to the ILogger
    /// </summary>
    public class ProviderLogDefault : ServiceLogBase, IServiceLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public ProviderLogDefault(ILogger logger)
        {
            _logger = logger;
        }

        #region IServiceLog Members
        public void Debug(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(message));
        }

        public void Debug(string method)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method));
        }

        public void Debug(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message));
        }

        public void Debug(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, ex));
        }

        public void Debug(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, value));
        }

        public void Diagnostic(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(message));
        }

        public void Diagnostic(string method)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method));
        }

        public void Diagnostic(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message));
        }

        public void Diagnostic(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, ex));
        }

        public void Diagnostic(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, value));
        }

        public void Error(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Error))
                return;

            _logger.LogError(Format(message));
        }

        public void Error(string method, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Error))
                return;

            _logger.LogError(Format(method, ex));
        }

        public void Error(string method, Exception ex, params string[] additional)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Error))
                return;

            _logger.LogError(Format(method, ex));
        }

        public void Error(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Error))
                return;

            _logger.LogError(Format(method, message, ex));
        }

        public void Error(string method, object message, Exception ex, params string[] additional)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Error))
                return;

            _logger.LogError(Format(method, message, ex));
        }

        public void Fatal(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Critical))
                return;

            _logger.LogCritical(Format(method, message));
        }

        public void Fatal(string method, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Critical))
                return;

            _logger.LogCritical(Format(method, null, ex));
        }

        public void Fatal(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Critical))
                return;

            _logger.LogCritical(Format(method, message, ex));
        }

        public void Info(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(message));
        }

        public void Info(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(method, message));
        }

        public void Info(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(method, message, ex));
        }

        public void Query(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(message));
        }

        public void Query(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, message, value));
        }

        public void Security(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(message));
        }

        public void Timing(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(message));
        }

        public void Timing(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(method, message));
        }

        public void Timing(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(method, message, ex));
        }

        public void Timing(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Information))
                return;

            _logger.LogInformation(Format(method, message, value));
        }

        public void Trace(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, message));
        }

        public void Trace(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, message, ex));
        }

        public void Trace(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, message, value));
        }

        public void TraceFinish(string method)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, "Finish"));
        }

        public void TraceStart(string method)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Trace))
                return;

            _logger.LogTrace(Format(method, "Start"));
        }

        public void Verbose(object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(message));
        }

        public void Verbose(string method)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method));
        }

        public void Verbose(string method, object message, object value)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, value));
        }

        public void Verbose(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message));
        }

        public void Verbose(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Debug))
                return;

            _logger.LogDebug(Format(method, message, ex));
        }

        public void Warn(string method, object message)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Warning))
                return;

            _logger.LogWarning(Format(method, message));
        }

        public void Warn(string method, object message, Exception ex)
        {
            if (_logger == null)
                return;
            if (!_logger.IsEnabled(LogLevel.Warning))
                return;

            _logger.LogWarning(Format(method, message, ex));
        }
        #endregion

        #region Private Methods
        private static string Format(object message)
        {
            return (message != null ? message.ToString() : Null);
        }

        private static string Format(string method, object message)
        {
            message = (message != null ? message.ToString() : Null);
            return string.Concat(method, SpacerSpace, message);
        }

        private static string Format(string method, object message, object value)
        {
            message = (message != null ? message.ToString() : Null);
            value = (value != null ? value.ToString() : Null);
            return string.Concat(method, SpacerSpace, message, SpacerColon, SpacerSpace, value);
        }

        private static string Format(string method, Exception ex)
        {
            string exS = Format(ex);
            return string.Concat(method, SpacerSpace, (!string.IsNullOrEmpty(exS) ? Environment.NewLine : string.Empty), exS);
        }

        private static string Format(string method, object message, Exception ex)
        {
            message = (message != null ? message.ToString() : Null);
            string exS = Format(ex);
            return string.Concat(method, SpacerSpace, message, (!string.IsNullOrEmpty(exS) ? Environment.NewLine : string.Empty), exS);
        }

        private static string Format(Exception ex)
        {
            StringBuilder builder = new();
            while (ex != null)
            {
                builder.AppendLine(ex.Message);
                ex = ex.InnerException;
            }
            return builder.ToString();
        }
        #endregion

        #region Fields
        private readonly ILogger _logger = null;
        #endregion

        #region Constants
        private const string Null = "<null>";
        private const string SpacerColon = ":";
        private const string SpacerSpace = " ";
        #endregion
    }
}
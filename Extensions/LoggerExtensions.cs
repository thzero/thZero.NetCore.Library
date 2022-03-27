/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2022 thZero.com

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

namespace thZero
{
    public static class LoggerExtensions
    {
        #region Public Methods
        public static string LogFormat(this ILogger logger, string method, string message)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);
            return string.Concat(method, message);
        }
        public static string LogFormat(this ILogger logger, string method, string message, string correlationId)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);

            string log = string.Concat(method, message);
            if (!String.IsNullOrEmpty(correlationId))
                log = string.Concat(correlationId, SeparatorColon, log);

            return log;
        }

        public static string LogFormat(this ILogger logger, string method, Func<object> func)
        {
            return string.Concat(method, SeparatorColon, (func != null ? func() : null));
        }

        public static string LogFormat(this ILogger logger, string method, Func<object> func, string message)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);
            return string.Concat(method, message, (func != null ? func() : null));
        }

        public static string LogFormat(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);

            string log = string.Concat(method, message, (func != null ? func() : null));
            if (!String.IsNullOrEmpty(correlationId))
                log = string.Concat(correlationId, SeparatorColon, log);

            return log;
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, object value)
        {
            return string.Concat(method, SeparatorColon, attribute, SeparatorColon, (value != null ? value.ToString() : Null));
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, object value, string message)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);
            return string.Concat(method, message, SeparatorColon, attribute, SeparatorColon, (value != null ? value.ToString() : Null));
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, object value, string message, string correlationId)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);

            string log = string.Concat(method, message, SeparatorColon, attribute, SeparatorColon, (value != null ? value.ToString() : Null));
            if (!String.IsNullOrEmpty(correlationId))
                log = string.Concat(correlationId, SeparatorColon, log);

            return log;
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, Func<object> func)
        {
            return string.Concat(method, SeparatorColon, attribute, SeparatorColon, (func != null ? func() : null));
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, Func<object> func, string message)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);
            return string.Concat(method, message, SeparatorColon, attribute, SeparatorColon, (func != null ? func() : null));
        }

        public static string LogFormat(this ILogger logger, string method, string attribute, Func<object> func, string message, string correlationId)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);

            string log = string.Concat(method, message, SeparatorColon, attribute, SeparatorColon, (func != null ? func() : null));
            if (!String.IsNullOrEmpty(correlationId))
                log = string.Concat(correlationId, SeparatorColon, log);

            return log;
        }

        public static string LogFormat(this ILogger logger, string method, Exception ex)
        {
            return string.Concat(method, SeparatorColon, FormatException(ex));
        }

        public static string LogFormat(this ILogger logger, string method, Exception ex, string message)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);
            return string.Concat(method, message, SeparatorComma, FormatException(ex));
        }

        public static string LogFormat(this ILogger logger, string method, Exception ex, string message, string correlationId)
        {
            if (!String.IsNullOrEmpty(message))
                message = string.Concat(SeparatorColon, message);

            string log = string.Concat(method, message, SeparatorComma, FormatException(ex));
            if (!String.IsNullOrEmpty(correlationId))
                log = string.Concat(correlationId, SeparatorColon, log);

            return log;
        }

        public static void LogDebug2(this ILogger logger, string method, Func<object> func)
        {
            logger?.LogDebug(LogFormat(logger, method, func));
        }

        public static void LogDebug2(this ILogger logger, string method, Func<object> func, string message)
        {
            logger?.LogDebug(LogFormat(logger, method, func, message));
        }

        public static void LogDebug2(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            logger?.LogDebug(LogFormat(logger, method, func, message, correlationId));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, object value)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, value));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, object value, string message)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, value, message));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, object value, string message, string correlationId)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, value, message, correlationId));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, Func<object> func)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, func));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, Func<object> func, string message)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, func, message));
        }

        public static void LogDebug2(this ILogger logger, string method, string attribute, Func<object> func, string message, string correlationId)
        {
            logger?.LogDebug(LogFormat(logger, method, attribute, func, message, correlationId));
        }

        public static void LogError2(this ILogger logger, string method, Exception ex)
        {
            logger?.LogError(LogFormat(logger, method, ex));
        }

        public static void LogError2(this ILogger logger, string method, Exception ex, string message)
        {
            logger?.LogError(LogFormat(logger, method, ex, message));
        }

        public static void LogError2(this ILogger logger, string method, Exception ex, string message, string correlationId)
        {
            logger?.LogError(LogFormat(logger, method, ex, message, correlationId));
        }

        public static void LogError2(this ILogger logger, string method, string message)
        {
            logger?.LogError(LogFormat(logger, method, message));
        }

        public static void LogError2(this ILogger logger, string method, string message, string correlationId)
        {
            logger?.LogError(LogFormat(logger, method, message, correlationId));
        }

        public static void LogError2(this ILogger logger, string method, Func<object> func)
        {
            logger?.LogWarning(LogFormat(logger, method, func));
        }

        public static void LogError2(this ILogger logger, string method, Func<object> func, string message)
        {
            logger?.LogWarning(LogFormat(logger, method, func, message));
        }

        public static void LogError2(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            logger?.LogWarning(LogFormat(logger, method, func, message, correlationId));
        }

        public static void LogInformation2(this ILogger logger, string method, string message)
        {
            logger?.LogInformation(LogFormat(logger, method, message));
        }

        public static void LogInformation2(this ILogger logger, string method, string message, string correlationId)
        {
            logger?.LogInformation(LogFormat(logger, method, message, correlationId));
        }

        public static void LogInformation2(this ILogger logger, string method, Func<object> func)
        {
            logger?.LogInformation(LogFormat(logger, method, func));
        }

        public static void LogInformation2(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            logger?.LogInformation(LogFormat(logger, method, func, message, correlationId));
        }

        public static void LogTrace2(this ILogger logger, string method, Func<object> func)
        {
            logger?.LogTrace(LogFormat(logger, method, func));
        }

        public static void LogTrace2(this ILogger logger, string method, Func<object> func, string message)
        {
            logger?.LogTrace(LogFormat(logger, method, func, message));
        }

        public static void LogTrace2(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            logger?.LogTrace(LogFormat(logger, method, func, message, correlationId));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, object value)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, value));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, object value, string message)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, value, message));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, object value, string message, string correlationId)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, value, message, correlationId));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, Func<object> func)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, func));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, Func<object> func, string message)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, func, message));
        }

        public static void LogTrace2(this ILogger logger, string method, string attribute, Func<object> func, string message, string correlationId)
        {
            logger?.LogTrace(LogFormat(logger, method, attribute, func, message, correlationId));
        }

        public static void LogWarning2(this ILogger logger, string method, string message)
        {
            logger?.LogWarning(LogFormat(logger, method, message));
        }

        public static void LogWarning2(this ILogger logger, string method, string message, string correlationId)
        {
            logger?.LogWarning(LogFormat(logger, method, message, correlationId));
        }

        public static void LogWarning2(this ILogger logger, string method, Exception ex)
        {
            logger?.LogWarning(LogFormat(logger, method, ex));
        }

        public static void LogWarning2(this ILogger logger, string method, Exception ex, string message)
        {
            logger?.LogWarning(LogFormat(logger, method, ex, message));
        }

        public static void LogWarning2(this ILogger logger, string method, Exception ex, string message, string correlationId)
        {
            logger?.LogWarning(LogFormat(logger, method, ex, message, correlationId));
        }

        public static void LogWarning2(this ILogger logger, string method, Func<object> func)
        {
            logger?.LogWarning(LogFormat(logger, method, func));
        }

        public static void LogWarning2(this ILogger logger, string method, Func<object> func, string message)
        {
            logger?.LogWarning(LogFormat(logger, method, func, message));
        }

        public static void LogWarning2(this ILogger logger, string method, Func<object> func, string message, string correlationId)
        {
            logger?.LogWarning(LogFormat(logger, method, func, message, correlationId));
        }
        #endregion

        #region Private Methods
        private static string FormatException(Exception ex)
        {
            if (ex == null)
                return string.Empty;

            StringBuilder builder = new();

            builder.Append(ex.ToString()).AppendLine();
            builder.AppendLine(ex.StackTrace);

            ex = ex.InnerException;
            while (ex != null)
            {
                builder.Append(InnerMessage).Append(ex.ToString()).AppendLine();
                ex = ex.InnerException;
            }

            return builder.ToString();
        }
        #endregion

        #region Constants
        private const string InnerMessage = "\tInner Message: ";
        private const string Null = "null ";
        private const string SeparatorColon = ": ";
        private const string SeparatorComma = ", ";
        #endregion
    }
}
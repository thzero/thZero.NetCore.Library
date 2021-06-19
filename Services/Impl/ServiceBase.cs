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

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using thZero.Instrumentation;
using thZero.Responses;

namespace thZero.Services
{
    public abstract class ServiceBase : IService
    {
        #region Protected Methods
        protected static ErrorResponse Error()
        {
            return new ErrorResponse();
        }

        protected static ErrorResponse Error(string message, params object[] args)
        {
            ErrorResponse error = new();
            error.AddError(message, args);
            return error;
        }

        protected static TResult Error<TResult>(TResult result)
             where TResult : SuccessResponse
        {
            result.Success = false;
            return result;
        }

        protected static TResult Error<TResult>(TResult result, string message, params object[] args)
             where TResult : SuccessResponse
        {
            result.AddError(message, args);
            result.Success = false;
            return result;
        }

        /// <summary>
        /// Get the instrumentation packet via service locator; this is an anti-pattern so use with caution.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static IInstrumentationPacket GetInstrumentationPacket(IServiceProvider provider)
        {
            return provider != null ? (IInstrumentationPacket)GetService(provider, typeof(IInstrumentationPacket)) : null;
        }

        /// <summary>
        /// Get a service via service locator; this is an anti-pattern so use with caution.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static object GetService(IServiceProvider provider, Type type)
        {
            return provider?.GetService(type);
        }

        protected static bool IsSuccess(SuccessResponse response)
        {
            return (response != null) && response.Success;
        }

        protected static SuccessResponse Success()
        {
            return new SuccessResponse();
        }

        protected static SuccessResponse Success(bool success)
        {
            return new SuccessResponse(success);
        }

        protected static SuccessResponse Success(bool success, string message)
        {
            SuccessResponse response = new SuccessResponse(success);
            response.AddError(message);
            return response;
        }
        #endregion
    }

    public abstract class ServiceBase<TService> : ServiceBase, IService
    {
        public ServiceBase(ILogger<TService> logger)
        {
            Logger = logger;
        }

        #region Protected Properties
        protected ILogger<TService> Logger { get; private set; }
        #endregion
    }

    public abstract class ConfigServiceBase<TService, TConfig> : ServiceBase<TService>, IService
        where TConfig: class
    {
        public ConfigServiceBase(IOptions<TConfig> config, ILogger<TService> logger) : base(logger)
        {
            Config = config.Value;
        }

        #region Protected Properties
        protected TConfig Config { get; private set; }
        #endregion
    }
}

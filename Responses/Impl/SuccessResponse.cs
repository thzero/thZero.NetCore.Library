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
using System.Collections.Generic;
using System.Text.Json.Serialization;

using thZero.Instrumentation;

namespace thZero.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse() { }
        public SuccessResponse(IInstrumentationPacket instrumentation) 
        {
            Instrumentation = instrumentation;
        }
        public SuccessResponse(bool success)
        {
            _success = success;
        }
        public SuccessResponse(IInstrumentationPacket instrumentation, bool success)
        {
            Instrumentation = instrumentation;
            _success = success;
        }

        #region Public Methods
        public SuccessResponse AddError(string message, params object[] args)
        {
            if ((args != null) && (args.Length > 0))
                message = string.Format(message, args);
            _messages.Add(new ErrorMessage() { Message = message });
            _success = false;
            return this;
        }

        public SuccessResponse AddError(string inputElement, string message, params object[] args)
        {
            if ((args != null) && (args.Length > 0))
                message = string.Format(message, args);
            _messages.Add(new ErrorMessage() { InputElement = inputElement, Message = message });
            _success = false;
            return this;
        }

        public SuccessResponse AddErrors(IEnumerable<string> messages)
        {
            foreach (var message in messages)
                _messages.Add(new ErrorMessage() { Message = message });
            _success = false;
            return this;
        }

        public SuccessResponse AddErrors(IEnumerable<ErrorMessage> messages)
        {
            foreach (var message in messages)
                _messages.Add(message);
            _success = false;
            return this;
        }
        #endregion

        #region Public Properties
        public string CorrelationId
        {
            get
            {
                return Instrumentation != null ? Instrumentation.Correlation.ToString() : null;
            }
        }

        [JsonIgnore]
        public IInstrumentationPacket Instrumentation { get; set; }

        public IEnumerable<ErrorMessage> Messages => _messages;

        public bool Success
        {
            get => (_messages.Count == 0) || _success;
            set => _success = value;
        }
        #endregion

        #region Fields
        private readonly ICollection<ErrorMessage> _messages = new List<ErrorMessage>();
        private bool _success = true;
        #endregion
    }

    public class SuccessResponse<T> : SuccessResponse
    {
        public SuccessResponse() : base() { }
        public SuccessResponse(IInstrumentationPacket instrumentation) : base(instrumentation) { }
        public SuccessResponse(bool success) : base(success) { }
        public SuccessResponse(IInstrumentationPacket instrumentation, bool success) : base(instrumentation, success) { }

        #region Public Properties
        public T Results { get; set; }
        #endregion
    }

    public class SearchSuccessResponse<T> : SuccessResponse
    {
        #region Public Properties
        public IEnumerable<T> Data { get; set; }
        #endregion
    }
}

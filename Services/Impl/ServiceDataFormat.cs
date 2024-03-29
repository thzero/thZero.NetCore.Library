﻿/* ------------------------------------------------------------------------- *
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

using Microsoft.Extensions.Logging;

namespace thZero.Services
{
    public class ServiceDataFormatFactory : Internal.ServiceDataFormatBase<ServiceDataFormatFactory>, IServiceDataFormat
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServiceDataFormatFactory() : base(log, null)
        {
        }
    }

    public class ServiceDataFormat : ServiceBase<ServiceDataFormat>, IServiceDataFormat
    {
        public ServiceDataFormat(ILogger<ServiceDataFormat> logger) : base(logger)
        {
            _instance = new Internal.ServiceDataFormatBase<ServiceDataFormat>(null, logger);
        }

        #region Public Methods
        public virtual string DisplayBool(object value)
        {
            return _instance.DisplayBool(value);
        }

        public virtual int DisplayBoolAsBit(object value)
        {
            return _instance.DisplayBoolAsBit(value);
        }

        public virtual string DisplayCurrency(object value)
        {
            return _instance.DisplayCurrency(value);
        }

        public virtual string DisplayDate(object value)
        {
            return _instance.DisplayDate(value);
        }

        public virtual string DisplayDate(object value1, object value2)
        {
            return _instance.DisplayDate(value1, value2);
        }

        public virtual string DisplayDateLong(object value)
        {
            return _instance.DisplayDateLong(value);
        }

        public virtual string DisplayDateLong(object value1, object value2)
        {
            return _instance.DisplayDateLong(value1, value2);
        }

        public virtual string DisplayDateTime(object value)
        {
            return _instance.DisplayDateTime(value, false);
        }

        public virtual string DisplayDateTime(object value1, object value2)
        {
            return _instance.DisplayDateTime(value1, value2);
        }

        public virtual string DisplayDateTimeWithSeconds(object value)
        {
            return _instance.DisplayDateTime(value, true);
        }

        public virtual string DisplayDecimal(decimal? value, int places)
        {
            return _instance.DisplayDecimal(value, places, DisplayRoundDirection.Normal);
        }

        public virtual string DisplayDecimal(decimal? value, int places, decimal defaultValue)
        {
            return _instance.DisplayDecimal(value, places, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round)
        {
            return _instance.DisplayDecimal(value, places, round);
        }

        public virtual string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round, decimal defaultValue)
        {
            return _instance.DisplayDecimal(value, places, round, defaultValue);
        }

        public virtual string DisplayDecimalDebug(decimal? value)
        {
            return _instance.DisplayDecimalDebug(value, DisplayRoundDirection.Normal);
        }

        public virtual string DisplayDecimalDebug(decimal? value, decimal defaultValue)
        {
            return _instance.DisplayDecimalDebug(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round)
        {
            return _instance.DisplayDecimalDebug(value, round);
        }

        public virtual string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalDebug(value, round, defaultValue);
        }

        public virtual string DisplayDecimalHundreds(decimal? value)
        {
            return _instance.DisplayDecimalHundreds(value);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, decimal defaultValue)
        {
            return _instance.DisplayDecimalHundreds(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round)
        {
            return _instance.DisplayDecimalHundreds(value, round);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return _instance.DisplayDecimalHundreds(value, round, defaultValue);
        }

        public virtual string DisplayDecimalTens(decimal? value)
        {
            return _instance.DisplayDecimalTens(value);
        }

        public virtual string DisplayDecimalTens(decimal? value, decimal defaultValue)
        {
            return _instance.DisplayDecimalTens(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalTens(decimal? value, DisplayRoundDirection round)
        {
            return _instance.DisplayDecimalTens(value, round);
        }

        public virtual string DisplayDecimalTens(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return _instance.DisplayDecimalTens(value, round, defaultValue);
        }

        public virtual string DisplayDecimalThousands(decimal? value)
        {
            return _instance.DisplayDecimalThousands(value);
        }

        public virtual string DisplayDecimalThousands(decimal? value, decimal defaultValue)
        {
            return _instance.DisplayDecimalThousands(value, defaultValue);
        }

        public virtual string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round)
        {
            return _instance.DisplayDecimalThousands(value, round);
        }

        public virtual string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return _instance.DisplayDecimalThousands(value, round, defaultValue);
        }

        public virtual string DisplayIf(object value, string result)
        {
            return _instance.DisplayIf(value, result);
        }

        public virtual string DisplayInches(object value)
        {
            return _instance.DisplayInches(value);
        }

        public virtual string DisplayInteger(object value)
        {
            return _instance.DisplayInteger(value);
        }

        public virtual string DisplayInteger(object value, int defaultValue)
        {
            return _instance.DisplayInteger(value, defaultValue);
        }

        public virtual string DisplayInteger(int? value)
        {
            return _instance.DisplayInteger(value);
        }

        public virtual string DisplayInteger(int? value, int defaultValue)
        {
            return _instance.DisplayInteger(value, defaultValue);
        }

        public virtual string DisplayListingDescription(object value)
        {
            return _instance.DisplayTextWithEllipse(value);
        }

        public virtual string DisplayListingDescription(object value, int maxLength)
        {
            return _instance.DisplayTextWithEllipse(value, maxLength);
        }

        public virtual string DisplayPercent(object value)
        {
            return _instance.DisplayPercent(value);
        }

        public virtual string DisplayPercentDecimal(decimal? value)
        {
            return _instance.DisplayPercentDecimal(value);
        }

        public virtual string DisplayPercentDecimal(decimal? value, decimal defaultValue)
        {
            return _instance.DisplayPercentDecimal(value, defaultValue);
        }

        public virtual string DisplayPlace(object value)
        {
            return _instance.DisplayPlace(value);
        }

        public virtual string DisplayQuantity(object value)
        {
            return _instance.DisplayQuantity(value);
        }

        public virtual string DisplayText(object value)
        {
            return _instance.DisplayText(value);
        }

        public virtual string DisplayTextAsEmail(object value)
        {
            return _instance.DisplayTextAsEmail(value);
        }

        public virtual string DisplayTextWithEllipse(object value)
        {
            return _instance.DisplayTextWithEllipse(value);
        }

        public virtual string DisplayTextWithEllipse(object value, int maxLength)
        {
            return _instance.DisplayTextWithEllipse(value, maxLength);
        }

        public virtual string DisplayTime(object value)
        {
            return _instance.DisplayTime(value);
        }
        #endregion

        #region Public Properties
        public bool PerformEncoding { get { return _instance.PerformEncoding; } set { _instance.PerformEncoding = value; } }
        #endregion

        #region Fields
        private static Internal.ServiceDataFormatBase<ServiceDataFormat> _instance;
        #endregion
    }
}

namespace thZero.Services.Internal
{
    public class ServiceDataFormatBase<TService> : IntermediaryServiceBase<TService>
    {
        public ServiceDataFormatBase(thZero.Services.IServiceLog log, ILogger<TService> logger) : base(log, logger)
        {
        }

        #region Public Methods
        public virtual string DisplayBool(object value)
        {
            return DisplayBoolCore(value);
        }

        public virtual int DisplayBoolAsBit(object value)
        {
            if (!(value is bool))
                return 0;

            return ((bool)value ? 1 : 0);
        }

        public virtual string DisplayCurrency(object value)
        {
            return DisplayCurrencyCore(value);
        }

        public virtual string DisplayDate(object value)
        {
            return DisplayDateCore(value);
        }

        public virtual string DisplayDate(object value1, object value2)
        {
            return DisplayDateCore(value1, value2);
        }

        public virtual string DisplayDateLong(object value)
        {
            return DisplayDateLongCore(value);
        }

        public virtual string DisplayDateLong(object value1, object value2)
        {
            return DisplayDateLongCore(value1, value2);
        }

        public virtual string DisplayDateTime(object value)
        {
            return DisplayDateTimeCore(value, false);
        }

        public virtual string DisplayDateTime(object value1, object value2)
        {
            return DisplayDateTimeCore(value1, value2);
        }

        public virtual string DisplayDateTimeWithSeconds(object value)
        {
            return DisplayDateTimeCore(value, true);
        }

        public virtual string DisplayDecimal(decimal? value, int places)
        {
            return DisplayDecimalCore(value, places, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayDecimal(decimal? value, int places, decimal defaultValue)
        {
            return DisplayDecimalCore(value, places, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round)
        {
            return DisplayDecimalCore(value, places, round, null);
        }

        public virtual string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalCore(value, places, round, defaultValue);
        }

        public virtual string DisplayDecimalDebug(decimal? value)
        {
            return DisplayDecimalDebugCore(value, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayDecimalDebug(decimal? value, decimal defaultValue)
        {
            return DisplayDecimalDebugCore(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round)
        {
            return DisplayDecimalDebugCore(value, round, null);
        }

        public virtual string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalDebugCore(value, round, defaultValue);
        }

        public virtual string DisplayDecimalHundreds(decimal? value)
        {
            return DisplayDecimalHundredthsCore(value, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, decimal defaultValue)
        {
            return DisplayDecimalHundredthsCore(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round)
        {
            return DisplayDecimalHundredthsCore(value, round, null);
        }

        public virtual string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalHundredthsCore(value, round, defaultValue);
        }

        public virtual string DisplayDecimalTens(decimal? value)
        {
            return DisplayDecimalTensCore(value, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayDecimalTens(decimal? value, decimal defaultValue)
        {
            return DisplayDecimalTensCore(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalTens(decimal? value, DisplayRoundDirection round)
        {
            return DisplayDecimalTensCore(value, round, null);
        }

        public virtual string DisplayDecimalTens(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalTensCore(value, round, defaultValue);
        }

        public virtual string DisplayDecimalThousands(decimal? value)
        {
            return DisplayDecimalThousandthsCore(value, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayDecimalThousands(decimal? value, decimal defaultValue)
        {
            return DisplayDecimalThousandthsCore(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round)
        {
            return DisplayDecimalThousandthsCore(value, round, null);
        }

        public virtual string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round, decimal defaultValue)
        {
            return DisplayDecimalThousandthsCore(value, round, defaultValue);
        }

        public virtual string DisplayIf(object value, string result)
        {
            return DisplayIfCore(value, result);
        }

        public virtual string DisplayInches(object value)
        {
            return DisplayInchesCore(value);
        }

        public virtual string DisplayInteger(object value)
        {
            return DisplayIntegerCore(value, null);
        }

        public virtual string DisplayInteger(object value, int defaultValue)
        {
            return DisplayIntegerCore(value, defaultValue);
        }

        public virtual string DisplayInteger(int? value)
        {
            return DisplayIntegerCore(value, null);
        }

        public virtual string DisplayInteger(int? value, int defaultValue)
        {
            return DisplayIntegerCore(value, defaultValue);
        }

        public virtual string DisplayListingDescription(object value)
        {
            return DisplayTextWithEllipseCore(value);
        }

        public virtual string DisplayListingDescription(object value, int maxLength)
        {
            return DisplayTextWithEllipseCore(value, maxLength);
        }

        public virtual string DisplayPercent(object value)
        {
            return DisplayPercentCore(value);
        }

        public virtual string DisplayPercentDecimal(decimal? value)
        {
            return DisplayDecimalPercentCore(value, DisplayRoundDirection.Normal, null);
        }

        public virtual string DisplayPercentDecimal(decimal? value, decimal defaultValue)
        {
            return DisplayDecimalPercentCore(value, DisplayRoundDirection.Normal, defaultValue);
        }

        public virtual string DisplayPlace(object value)
        {
            return DisplayPlaceCore(value);
        }

        public virtual string DisplayQuantity(object value)
        {
            return DisplayQuantityCore(value);
        }

        public virtual string DisplayText(object value)
        {
            return DisplayTextCore(value);
        }

        public virtual string DisplayTextAsEmail(object value)
        {
            return DisplayTextAsEmailCore(value);
        }

        public virtual string DisplayTextWithEllipse(object value)
        {
            return DisplayTextWithEllipseCore(value);
        }

        public virtual string DisplayTextWithEllipse(object value, int maxLength)
        {
            return DisplayTextWithEllipseCore(value, maxLength);
        }

        public virtual string DisplayTime(object value)
        {
            return DisplayTimeCore(value, false);
        }
        #endregion

        #region Public Properties
        public bool PerformEncoding { get; set; } = true;
        #endregion

        #region Protected Methods
        protected virtual string DisplayBoolCore(object value)
        {
            if (!(value is bool))
                return string.Empty;

            return ((bool)value ? Yes : No);
        }

        protected virtual string DisplayCurrencyCore(object value)
        {
            if (value is decimal)
            {
                if (Utilities.Nullable.Is(value))
                    value = 0;
                return string.Format(CurrencyFormat, value);
            }

            return string.Empty;
        }

        protected virtual string DisplayDateCore(object value)
        {
            if (!(value is DateTime) || Utilities.Nullable.Is(value))
                return string.Empty;

            return ((DateTime)value).ToString(DateFormat);
        }

        protected virtual string DisplayDateCore(object value1, object value2)
        {
            if (!(value1 is DateTime) || Utilities.Nullable.Is(value1))
                return string.Empty;
            if (!(value2 is DateTime) || Utilities.Nullable.Is(value2))
                return string.Empty;

            return string.Concat(DisplayDateCore(value1), To, DisplayDateCore(value2));
        }

        protected virtual string DisplayDateLongCore(object value)
        {
            if (!(value is DateTime) || Utilities.Nullable.Is(value))
                return string.Empty;

            return ((DateTime)value).ToString(DateFormat);
        }

        protected virtual string DisplayDateLongCore(object value1, object value2)
        {
            if (!(value1 is DateTime) || Utilities.Nullable.Is(value1))
                return string.Empty;
            if (!(value2 is DateTime) || Utilities.Nullable.Is(value2))
                return string.Empty;

            return string.Concat(DisplayDateLongCore(value1), To, DisplayDateLongCore(value2));
        }

        protected virtual string DisplayDateTimeCore(object value, bool seconds)
        {
            if (!(value is DateTime) || Utilities.Nullable.Is(value))
                return string.Empty;

            return string.Concat(((DateTime)value).ToString(DateFormat), Spacer, DisplayTimeCore(value, false));
        }

        protected virtual string DisplayDateTimeCore(object value1, object value2)
        {
            if (!(value1 is DateTime) || Utilities.Nullable.Is(value1))
                return string.Empty;
            if (!(value2 is DateTime) || Utilities.Nullable.Is(value2))
                return string.Empty;

            return string.Concat(DisplayDateTimeCore(value1, false), To, DisplayDateTimeCore(value2, false));
        }

        protected virtual string DisplayDecimalDebugCore(decimal? value, DisplayRoundDirection round, decimal? defaultValue)
        {
            return DisplayDecimalCore(value, 10, round, defaultValue);
        }

        protected virtual string DisplayDecimalHundredthsCore(decimal? value, DisplayRoundDirection round, decimal? defaultValue)
        {
            return DisplayDecimalCore(value, DecimalHundredthsPlaces, round, defaultValue);
        }

        protected virtual string DisplayDecimalPercentCore(decimal? value, DisplayRoundDirection round, decimal? defaultValue)
        {
            if (!value.HasValue)
            {
                if (!defaultValue.HasValue)
                    return string.Empty;
                value = defaultValue;
            }

            decimal temp = value.Value;
            if (round == DisplayRoundDirection.Down)
                temp = Utilities.Math.RoundDown(temp, 2);
            if (round == DisplayRoundDirection.Up)
                temp = Utilities.Math.RoundUp(temp, 2);

            return string.Concat(temp.ToString(DecimalPercentFormat), Percent);
        }

        protected virtual string DisplayDecimalTensCore(decimal? value, DisplayRoundDirection round, decimal? defaultValue)
        {
            return DisplayDecimalCore(value, DecimalTensPlaces, round, defaultValue);
        }

        protected virtual string DisplayDecimalThousandthsCore(decimal? value, DisplayRoundDirection round, decimal? defaultValue)
        {
            return DisplayDecimalCore(value, DecimalThousandthsPlaces, round, defaultValue);
        }

        protected virtual string DisplayDecimalCore(decimal? value, int places, DisplayRoundDirection round, decimal? defaultValue)
        {
            if (!value.HasValue)
            {
                if (!defaultValue.HasValue)
                    return string.Empty;
                value = defaultValue;
            }

            decimal temp = value.Value;
            if (round == DisplayRoundDirection.Down)
                temp = Utilities.Math.RoundDown(temp, places);
            if (round == DisplayRoundDirection.Up)
                temp = Utilities.Math.RoundUp(temp, places);

            return temp.ToString(string.Concat(DecimalFormat, new string(DecimalChar, places)));
        }

        protected virtual string DisplayIfCore(object value, string result)
        {
            if (!(value is bool))
                return string.Empty;

            return ((bool)value ? result : string.Empty);
        }

        protected virtual string DisplayInchesCore(object value)
        {
            string temp = string.Empty;
            if ((value is int) || (value is decimal))
            {
                if ((value is int @int) && Utilities.Nullable.Is(@int))
                    return string.Empty;
                if ((value is decimal @decimal) && Utilities.Nullable.Is(@decimal))
                    return string.Empty;

                temp = DisplayQuantityCore(value);
            }
            if (!string.IsNullOrEmpty(temp))
                return DisplayInchesSuffix(temp);

            if (!(value is string))
                return string.Empty;
            if (string.IsNullOrEmpty((string)value))
                return string.Empty;

            temp = (string)value;



            string[] values = temp.Split(new char[] { SpacerChar });
            if (values.Length > 1)
            {
                values[0] = DisplayQuantityCore(values[0]);
                temp = string.Join(Spacer, values);
            }
            else
            {
                values = temp.Split(new char[] { SlashChar });
                if (values.Length == 1)
                    temp = DisplayQuantityCore(temp);
            }

            return DisplayInchesSuffix(temp);
        }

        protected virtual string DisplayQuantityCore(object value)
        {
            if (value is string temp)
            {
                bool success = int.TryParse(temp, out int outputInt);
                if (success)
                    value = outputInt;
                else
                {
                    success = decimal.TryParse(temp, out decimal outputDecimal);
                    if (success)
                        value = outputDecimal;
                }

                if (!success)
                    return string.Empty;
            }

            if (value is decimal @decimal)
                value = Convert.ToInt32(Math.Round(@decimal));

            if (value is int)
                return DisplayIntCore(value, null);

            return string.Empty;
        }

        protected virtual string DisplayInchesSuffix(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (value.EndsWith(Slash))
                return value;

            return string.Concat(value, Slash);
        }

        protected virtual string DisplayIntCore(object value, int? defaultValue)
        {
            if (!(value is int))
            {
                if (!defaultValue.HasValue)
                    return string.Empty;

                value = defaultValue.Value;
            }

            int temp = (int)value;
            if (Utilities.Nullable.Is(temp))
            {
                if (!defaultValue.HasValue)
                    return string.Empty;

                temp = defaultValue.Value;
            }

            return temp.ToString(IntFormat);
        }

        protected virtual string DisplayPercentCore(object value)
        {
            if ((value is decimal @decimal) && !Utilities.Nullable.Is(value))
                return string.Concat((@decimal * 100).ToString(DecimalPercentHundredsFormat), Percent);

            return string.Empty;
        }

        protected virtual string DisplayMillimeterSuffix(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (value.EndsWith(Millimeter))
                return value;

            return string.Concat(value, Millimeter);
        }

        protected virtual string DisplayPlaceCore(object value)
        {
            if (value is int @int)
                return Number.ToSentence(@int);

            return string.Empty;
        }

        protected virtual string DisplayIntegerCore(object value, int? defaultValue)
        {
            if (value is string temp)
            {
                bool success = int.TryParse(temp, out int outputInt);
                if (success)
                    value = outputInt;
                else
                {
                    success = decimal.TryParse(temp, out decimal outputDecimal);
                    if (success)
                        value = outputDecimal;
                }

                if (!success)
                    return string.Empty;
            }

            if (value is decimal)
                return DisplayIntCore(null, defaultValue);

            if (value is int)
                return DisplayIntCore(value, defaultValue);

            return DisplayIntCore(null, defaultValue);
        }

        protected virtual string DisplayIntegerCore(int? value, int? defaultValue)
        {
            return DisplayIntCore(value, defaultValue);
        }

        protected virtual string DisplayTextCore(object value)
        {
            string valueEx;
            if (value is not string @string)
            {
                if (value == null)
                    return string.Empty;

                valueEx = value.ToString();
            }
            else
                valueEx = @string;

            if (string.IsNullOrEmpty(valueEx))
                return string.Empty;

            if (PerformEncoding)
                valueEx = System.Net.WebUtility.HtmlEncode(valueEx);
            valueEx = valueEx.Replace(Environment.NewLine.ToString(), Break);

            return valueEx;
        }

        protected virtual string DisplayTextAsEmailCore(object value)
        {
            string text = DisplayTextCore(value);
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return string.Format(MailToFormat, text, text);
        }

        protected virtual string DisplayTextWithEllipseCore(object value)
        {
            return DisplayTextWithEllipseCore(value, ListingDescriptionMaxLength);
        }

        protected virtual string DisplayTextWithEllipseCore(object value, int maxLength)
        {
            string valueEx;
            if (value is not string @string)
            {
                if (value == null)
                    return string.Empty;

                valueEx = value.ToString();
            }
            else
                valueEx = @string;

            if (string.IsNullOrEmpty(valueEx))
                return string.Empty;

            if (valueEx.Length > maxLength)
                valueEx = string.Concat(valueEx.Substring(0, maxLength), Ellipse);

            return DisplayTextCore(valueEx);
        }

        protected virtual string DisplayTimeCore(object value, bool seconds)
        {
            if (!(value is DateTime) || Utilities.Nullable.Is(value))
                return string.Empty;

            if (!seconds)
                return ((DateTime)value).ToString(TimeFormat);

            return ((DateTime)value).ToString(string.Concat(TimeFormat, (seconds ? TimeSecondsFormat : string.Empty), TimeAMPMFormat));
        }
        #endregion

        #region Protected Properties
        protected virtual int DecimalTensPlaces
        {
            get { return 1; }
        }
        protected virtual int DecimalHundredthsPlaces
        {
            get { return 2; }
        }
        protected virtual int DecimalThousandthsPlaces
        {
            get { return 3; }
        }

        protected virtual int ListingDescriptionMaxLength
        {
            get { return 97; }
        }

        #endregion

        #region Constants
        private const string Blank = "_blank";
        private const string Break = "<br/>";
        private const string CurrencyFormat = "{0:C}";
        private const char DecimalChar = '#';
        private const string DecimalFormat = "###,###,###,###,###,###,###,##0.";
        private const string DecimalPercentFormat = "#.0#";
        private const string DecimalPercentHundredsFormat = "##0.##";
        private const string DateFormat = "mm/dd/yy";
        private const string Ellipse = "...";
        private const string IntFormat = "#,###,###,##0";
        private const string MailToFormat = "<a href=\"mailto:{0}\">{1}</a>";
        private const string Millimeter = "mil";
        private const string No = "No";
        private const string Percent = "%";
        private const string Slash = "\"";
        private const char SlashChar = '/';
        private const string Spacer = " ";
        private const char SpacerChar = ' ';
        private const string To = " to ";
        private const string TimeFormat = "hh:mm";
        private const string TimeSecondsFormat = ":ss";
        private const string TimeAMPMFormat = " tt";
        private const string Yes = "Yes";
        #endregion

        protected static class Number
        {
            static readonly string[] first = { "th", "st", "nd", "rd", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "th", "st" };

            /// <summary>
            /// Converts the given number to an english sentence.
            /// </summary>
            /// <param name="value">The number to convert.</param>
            /// <returns>The string representation of the number.</returns>
            public static string ToSentence(int value)
            {
                return string.Concat(value.ToString(), Step(value));
            }

            // traverse the number recursively
            public static string Step(int value)
            {
                return value <= 21 ? first[value] :
                                        value <= 99 ? Step(value % 10) :
                                        value <= 199 ? Step(value % 100) :
                                        value <= 999 ? Step(value % 100) :
                                        value <= 1999 ? Step(value % 1000) :
                                        value <= 999999 ? Step(value % 1000) :
                                        value <= 1999999 ? Step(value % 1000000) :
                                        value <= 999999999 ? Step(value % 1000000) :
                                        value <= 1999999999 ? Step(value % 1000000000) :
                                        Step(value % 1000000000);
            }
        }
    }
}
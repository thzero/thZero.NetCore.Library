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

namespace thZero.Services
{
	public interface IServiceDataFormat : IService
	{
		#region Methods
		string DisplayBool(object value);
		int DisplayBoolAsBit(object value);
		string DisplayCurrency(object value);
		string DisplayDate(object value);
		string DisplayDate(object value1, object value2);
		string DisplayDateLong(object value);
		string DisplayDateLong(object value1, object value2);
		string DisplayDateTime(object value);
		string DisplayDateTime(object value1, object value2);
		string DisplayDateTimeWithSeconds(object value);
		string DisplayDecimal(decimal? value, int places);
		string DisplayDecimal(decimal? value, int places, decimal defaultValue);
		string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round);
		string DisplayDecimal(decimal? value, int places, DisplayRoundDirection round, decimal defaultValue);
		string DisplayDecimalDebug(decimal? value);
		string DisplayDecimalDebug(decimal? value, decimal defaultValue);
		string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round);
		string DisplayDecimalDebug(decimal? value, DisplayRoundDirection round, decimal defaultValue);
		string DisplayDecimalHundreds(decimal? value);
		string DisplayDecimalHundreds(decimal? value, decimal defaultValue);
		string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round);
		string DisplayDecimalHundreds(decimal? value, DisplayRoundDirection round, decimal defaultValue);
		string DisplayDecimalTens(decimal? value);
		string DisplayDecimalTens(decimal? value, decimal defaultValue);
		string DisplayDecimalTens(decimal? value, DisplayRoundDirection round);
		string DisplayDecimalTens(decimal? value, DisplayRoundDirection round, decimal defaultValue);
		string DisplayDecimalThousands(decimal? value);
		string DisplayDecimalThousands(decimal? value, decimal defaultValue);
		string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round);
		string DisplayDecimalThousands(decimal? value, DisplayRoundDirection round, decimal defaultValue);
		string DisplayIf(object value, string result);
		string DisplayInches(object value);
		string DisplayInteger(object value);
		string DisplayInteger(object value, int defaultValue);
		string DisplayInteger(int? value);
		string DisplayInteger(int? value, int defaultValue);
		string DisplayListingDescription(object value);
		string DisplayListingDescription(object value, int maxLength);
		string DisplayPercent(object value);
		string DisplayPercentDecimal(decimal? value);
		string DisplayPercentDecimal(decimal? value, decimal defaultValue);
		string DisplayPlace(object value);
		string DisplayQuantity(object value);
		string DisplayText(object value);
		string DisplayTextAsEmail(object value);
		string DisplayTextWithEllipse(object value);
		string DisplayTextWithEllipse(object value, int maxLength);
		string DisplayTime(object value);
		bool PerformEncoding { get; set; }
		#endregion
	}

	public enum DisplayRoundDirection
	{
		Normal,
		Up,
		Down
	}
}
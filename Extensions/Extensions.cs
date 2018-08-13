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
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace thZero
{
	public static class Extensions
	{
		#region Guid
		public static bool IsNullOrEmpty(this Guid? guid)
		{
			if (!guid.HasValue)
				return false;

			return (guid.Value == Guid.Empty);
		}
		#endregion

		#region String
		public static bool EndsWithIgnore(this string value, string compare)
		{
			return (!string.IsNullOrEmpty(value) ? value.EndsWith(compare, StringComparison.OrdinalIgnoreCase) : false);
		}

		public static bool EqualsIgnore(this string value, string compare)
		{
			return (!string.IsNullOrEmpty(value) ? value.Equals(compare, StringComparison.OrdinalIgnoreCase) : false);
		}

		public static string Format(this string format, params object[] args)
		{
			return string.Format(format, args);
		}

		public static string FormatInvariant(this string format, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture, format, args);
		}

		public static string RemoveWhiteSpace(this string value)
		{
			Enforce.AgainstNull(() => value);

			string newString = value;
			foreach (char character in WhiteSpaceChars)
				newString = value.Replace(new String(new char[] { character }), String.Empty);

			//string newString = s.Replace("&nbsp;", "").Replace("&#160;", "").Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace(Environment.NewLine, "");
			return newString;
		}

		public static bool StartsWithIgnore(this string value, string compare)
		{
			return (value != null ? value.StartsWith(compare, StringComparison.OrdinalIgnoreCase) : false);
		}

		public static string ToCapital(this string value)
		{
			if (string.IsNullOrEmpty(value))
				return value;

			return value.Substring(0, 1).ToUpper() + value.Substring(1);
		}

		public static string Truncate(this object value, int max)
		{
			return Truncate((string)value, max, true);
		}

		public static string Truncate(this object value, int max, bool ellipses)
		{
			return Truncate((string)value, max, ellipses);
		}

		public static string Truncate(this string value, int max)
		{
			return Truncate(value, max, true);
		}

		public static string Truncate(this string value, int max, bool ellipses)
		{
			string truncate = value as string;
			if (string.IsNullOrEmpty(truncate))
				return string.Empty;

			if (ellipses && (max > 3) && (truncate.Length > max))
				max = max - 3;
			else
				ellipses = false;

			if (max > truncate.Length)
				max = truncate.Length;

			return string.Concat(truncate.Substring(0, max), (ellipses ? "..." : string.Empty));
		}

		public static IEnumerable<char> WhiteSpaceChars
		{
			get
			{
				if (_whitespaceCharacter != null)
					return _whitespaceCharacter;

				lock (_lock)
				{
					if (_whitespaceCharacter != null)
						return _whitespaceCharacter;

					char[] method = typeof(string).GetTypeInfo().GetField("WhitespaceChars", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null) as char[];
					_whitespaceCharacter = new List<char>();
					_whitespaceCharacter.AddRange(method);
				}

				return _whitespaceCharacter;
			}
		}
		#endregion

		#region Fields
		private static volatile List<char> _whitespaceCharacter;
		private static readonly object _lock = new object();
		#endregion
	}
}
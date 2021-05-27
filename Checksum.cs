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
using System.Linq;

using Force.Crc32;

namespace thZero.Utilities
{
    public static class Checksum
    {
        #region Protected Methods
        public static long Compute(Action<List<byte>> func)
        {
            Enforce.AgainstNull(() => func);

            List<byte> bytesComputed = new();
            func(bytesComputed);

            byte[] bytes = bytesComputed.ToArray();
            if (bytes == null)
                return 0;

            return Crc32Algorithm.Compute(bytes);
        }

        public static byte[] Generate(Action<List<byte>> func)
        {
            Enforce.AgainstNull(() => func);

            List<byte> bytesComputed = new();
            func(bytesComputed);

            byte[] bytes = bytesComputed.ToArray();
            return bytes;
        }

        public static byte[] ToBytes(bool value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, bool value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(bool? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return BitConverter.GetBytes(value.Value);
        }

        public static byte[] ToBytes(string name, bool? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(byte value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, byte value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(string name, byte[] value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            Initialize();

            byte[] output = CombineBytes(ToBytes(name), _seperator1, value, _seperator2);
            return output;
        }

        public static byte[] ToBytes(byte? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(System.DateTime value)
        {
            return BitConverter.GetBytes(value.Ticks);
        }

        public static byte[] ToBytes(string name, System.DateTime value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(System.DateTime? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value.Ticks);
        }

        public static byte[] ToBytes(string name, System.DateTime? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(DateTimeOffset value)
        {
            return BitConverter.GetBytes(value.Ticks);
        }

        public static byte[] ToBytes(string name, DateTimeOffset value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(DateTimeOffset? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value.Ticks);
        }

        public static byte[] ToBytes(string name, DateTimeOffset? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(decimal value)
        {
            // Load four 32 bit integers from the Decimal.GetBits function
            Int32[] bits = decimal.GetBits(value);
            // Create a temporary buffer to hold the bytes
            byte[] buffer = new byte[4 * 4];
            int offset = 0;
            byte[] temp = BitConverter.GetBytes(bits[0]);
            Buffer.BlockCopy(temp, 0, buffer, offset, temp.Length);
            offset += temp.Length;
            temp = BitConverter.GetBytes(bits[1]);
            Buffer.BlockCopy(temp, 0, buffer, offset, temp.Length);
            offset += temp.Length;
            temp = BitConverter.GetBytes(bits[2]);
            Buffer.BlockCopy(temp, 0, buffer, offset, temp.Length);
            offset += temp.Length;
            temp = BitConverter.GetBytes(bits[3]);
            Buffer.BlockCopy(temp, 0, buffer, offset, temp.Length);

            return buffer.ToArray();
        }

        public static byte[] ToBytes(string name, decimal value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(decimal? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, decimal? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, double value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(double? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, double? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(float value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, float value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(float? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, float? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(Guid value)
        {
            if (value == Guid.Empty)
                return Array.Empty<byte>();

            return ToBytes(value.ToString());
        }

        public static byte[] ToBytes(string name, Guid value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (value == Guid.Empty)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(Guid? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, Guid? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, int value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(int? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, int? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, long value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(long? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, long? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(short value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, short value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(short? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, short? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Array.Empty<byte>();

            return System.Text.Encoding.Unicode.GetBytes(value);
        }

        public static byte[] ToBytes(string name, string value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (string.IsNullOrEmpty(value))
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, uint value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(uint? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, uint? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, ulong value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(ulong? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, ulong? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }

        public static byte[] ToBytes(ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToBytes(string name, ushort value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            return ToBytes(name, ToBytes(value));
        }

        public static byte[] ToBytes(ushort? value)
        {
            if (!value.HasValue)
                return Array.Empty<byte>();

            return ToBytes(value.Value);
        }

        public static byte[] ToBytes(string name, ushort? value)
        {
            Enforce.AgainstNullOrEmpty(() => name);

            if (!value.HasValue)
                return ToBytesNone(name);

            return ToBytes(name, ToBytes(value.Value));
        }
        #endregion

        #region Private Methods
        private static byte[] CombineBytes(params byte[][] arrays)
        {
            byte[] buffer = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, buffer, offset, array.Length);
                offset += array.Length;
            }
            return buffer;
        }

        private static void Initialize()
        {
            if (_seperator1 != null)
                return;

            lock (_lock)
            {
                if (_seperator1 != null)
                    return;

                _seperator1 = ToBytes(Seperator1);
                _seperator2 = ToBytes(Seperator2);
            }
        }

        private static byte[] ToBytesNone(string name)
        {
            return ToBytes(name, _none);
        }
        #endregion

        #region Fields
        private static readonly byte[] _none = Array.Empty<byte>();
        private static volatile byte[] _seperator1 = null;
        private static volatile byte[] _seperator2 = null;
        private static readonly object _lock = new();
        #endregion

        #region Constants
        private const string Seperator1 = ":";
        private const string Seperator2 = ";";
        #endregion
    }
}
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
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using thZero.Services;

namespace thZero.Utilities
{
    public static class Activator
    {
        #region Public Methods
        public static object CreateInstance(string type)
        {
            if (string.IsNullOrEmpty(type))
                return null;

            var obj = System.Activator.CreateInstance(Type.GetType(type));
            return obj ?? null;
        }

        public static object CreateInstance(string assemblyName, string type)
        {
            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(type))
                return null;

            type = string.Concat(assemblyName, ",", type);

            var obj = System.Activator.CreateInstance(Type.GetType(type));
            return obj ?? null;
        }

        public static object CreateInstance(string assemblyName, string type, object[] args)
        {
            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(type))
                return null;

            type = string.Concat(assemblyName, ",", type);

            var obj = System.Activator.CreateInstance(Type.GetType(type));
            return obj ?? null;
        }

        public static object CreateInstance(Type typeRequested)
        {
            if (typeRequested == null)
                return null;

            return System.Activator.CreateInstance(typeRequested, true);
        }

        public static object CreateInstance(Type typeRequested, object[] args)
        {
            if (typeRequested == null)
                return null;

            return System.Activator.CreateInstance(typeRequested, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, null, args, null);
        }

        public static T CreateInstanceEx<T>()
        {
            return System.Activator.CreateInstance<T>();
        }

        public static T CreateInstanceEx<T>(object[] args)
        {
            return (T)System.Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, null, args, null);
        }

        public static T CreateInstance<T>(string assemblyName, string type, params object[] args)
        {
            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(type))
                return default;

            type = string.Concat(assemblyName, ",", type);

            return (T)System.Activator.CreateInstance(Type.GetType(type), args);
        }

        public static T CreateInstance<T>(Assembly assembly, string type, params object[] args)
        {
            if ((assembly == null) || string.IsNullOrEmpty(type))
                return default;

            return CreateInstance<T>(assembly.FullName, type, args);
        }

        public static T CreateInstance<T>(Type type, params object[] args)
        {
            if (type == null)
                return default;

            return (T)System.Activator.CreateInstance(type);
        }

        public static T CreateInstance<T>()
        {
            return (T)System.Activator.CreateInstance<T>();
        }
        #endregion
    }

    public static class Attributes
    {
        #region Public Methods
        public static T GetCustomAttribute<T>(Type type) where T : Attribute
        {
            return GetCustomAttribute<T>(type, false);
        }

        public static T GetCustomAttribute<T>(Type type, bool inherited) where T : Attribute
        {
            if (type == null)
                return null;

            IEnumerable<T> attributes = type.GetTypeInfo().GetCustomAttributes<T>(inherited);
            if (attributes == null)
                return null;

            return attributes.SingleOrDefault();
        }

        public static T GetCustomAttribute<T>(object value) where T : Attribute
        {
            return GetCustomAttribute<T>(value, false);
        }

        public static T GetCustomAttribute<T>(object value, bool inherited)
            where T : Attribute
        {
            if (value == null)
                return null;

            return GetCustomAttribute<T>(value.GetType(), inherited);
        }

        public static bool MethodHasAttribute<T>(Expression<System.Action> expression)
            where T : Attribute
        {
            var method = MethodOf(expression);

            const bool includeInherited = false;
            bool result = method.GetCustomAttributes(typeof(T), includeInherited).Any();
            return result;
        }

        public static MethodInfo MethodOf(Expression<System.Action> expression)
        {
            MethodCallExpression body = (MethodCallExpression)expression.Body;
            return body.Method;
        }
        #endregion
    }
    public static class Background
    {
        #region Public Methods
        public static void Run(Action action, Action<Exception> handler = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Task task = Task.Run(action);  // Adapt as necessary for .NET 4.0.
            if (handler != null)
            {
                task.ContinueWith(
                    t => handler(t.Exception.GetBaseException()),
                    TaskContinuationOptions.ExecuteSynchronously |
                    TaskContinuationOptions.OnlyOnFaulted);
                return;
            }

            task.ContinueWith(
                DefaultErrorContinuation,
                TaskContinuationOptions.ExecuteSynchronously |
                TaskContinuationOptions.OnlyOnFaulted);
        }
        #endregion

        #region Private Methods
        private static readonly Action<Task> DefaultErrorContinuation =
            t =>
            {
                try { t.Wait(); }
                catch { }
            };
        #endregion
    }

    public class DateTime
    {
        #region Public Methods
        public static long Timestamp
        {
            get { return TimestampFromDateTime(System.DateTime.UtcNow);  }
        }

        public static long TimestampFromDateTime(System.DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        }
        #endregion
    }

    public static class General
    {
        #region Public Methods
        public static int GetHashCode(params object[] args)
        {
            Enforce.AgainstNull(args, General.GetMemberName(() => args));

            unchecked
            {
                int result = 0;
                foreach (var o in args)
                    result = (result * 397) ^ (o != null ? o.GetHashCode() : 0);
                return result;
            }
        }

        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null)
                return string.Empty;

            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }

        public static Guid ParseGuidSafe(string guid)
        {
            Enforce.AgainstNullOrEmpty(guid, General.GetMemberName(() => guid));

            try
            {
                return Guid.Parse(guid);
            }
            catch (FormatException) { }

            return Guid.Empty;
        }
        #endregion
    }

    public static class Math
    {
        #region Public Methods
        public static decimal RoundDown(decimal number, int decimalPlaces)
        {
            double value = (double)number;
            return (decimal)(System.Math.Floor(value * System.Math.Pow(10, decimalPlaces)) / System.Math.Pow(10, decimalPlaces));
        }

        public static double RoundDown(double number, int decimalPlaces)
        {
            return System.Math.Floor(number * System.Math.Pow(10, decimalPlaces)) / System.Math.Pow(10, decimalPlaces);
        }

        public static decimal RoundUp(decimal number, int decimalPlaces)
        {
            double value = (double)number;
            return (decimal)(System.Math.Ceiling(value * System.Math.Pow(10, decimalPlaces)) / System.Math.Pow(10, decimalPlaces));
        }

        public static double RoundUp(double number, int decimalPlaces)
        {
            return System.Math.Ceiling(number * System.Math.Pow(10, decimalPlaces)) / System.Math.Pow(10, decimalPlaces);
        }
        #endregion
    }

    public static class Network
    {
        #region Public Methods
        public static ICollection<IPAddress> GetAllLocal(NetworkInterfaceType _type)
        {
            UnicastIPAddressInformation mostSuitableIp = null;
            ICollection<IPAddress> ipAddrList = new List<IPAddress>();
            NetworkInterface[] items = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface item in items)
            {
                if (!(item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up))
                    continue;

                var properties = item.GetIPProperties();
                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(ip.Address))
                        continue;

                    // If address is not a DNS Eligible, it is a reserved internal IP. It is not the internet provider host.
                    if (!ip.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = ip;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    // And if PrefixOrigin was suplied by a DHCP server, possible this is the best address choice.
                    if (ip.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = ip;
                        continue;
                    }

                    ipAddrList.Add(ip.Address);
                }
            }

            return ipAddrList;
        }

        public static ICollection<IPAddress> GetAllLocalEthernet()
        {
            return GetAllLocal(NetworkInterfaceType.Ethernet);
        }

        public static ICollection<IPAddress> GetAllLocalWireless()
        {
            return GetAllLocal(NetworkInterfaceType.Wireless80211);
        }

        public static IPAddress GetLocal()
        {
            IPAddress address = Network.GetAllLocalEthernet()?.FirstOrDefault();
            if (address == null)
                address = Network.GetAllLocalWireless()?.FirstOrDefault();
            if (address == null)
                throw new Exception("Invalid location IP address!");

            return address;
        }
        #endregion
    }

    public static class Nullable
    {
        #region Public Methods
        public static bool Is(object value)
        {
            if (value == null)
                return true;

            if (value is byte @byte)
                return @byte == byte.MinValue;

            if (value is byte?)
                return ((value == null) || !((byte?)value).HasValue);

            if (value is System.DateTime time)
                return time == System.DateTime.MinValue;

            if (value is System.DateTime?)
                return ((value == null) || !((System.DateTime?)value).HasValue);

            if (value is decimal @decimal)
                return @decimal == decimal.MinValue;

            if (value is decimal?)
                return ((value == null) || !((decimal?)value).HasValue);

            if (value is double @double)
                return @double == double.MinValue;

            if (value is double?)
                return ((value == null) || !((double?)value).HasValue);

            if (value is float single)
                return single == float.MinValue;

            if (value is float?)
                return ((value == null) || !((float?)value).HasValue);

            if (value is int @int)
                return @int == int.MinValue;

            if (value is int?)
                return ((value == null) || !((int?)value).HasValue);

            if (value is long int1)
                return int1 == long.MinValue;

            if (value is long?)
                return ((value == null) || !((long?)value).HasValue);

            if (value is short int2)
                return int2 == short.MinValue;

            if (value is short?)
                return ((value == null) || !((short?)value).HasValue);

            if (value is uint int3)
                return int3 == uint.MinValue;

            if (value is uint?)
                return ((value == null) || !((uint?)value).HasValue);

            if (value is ulong int4)
                return int4 == ulong.MinValue;

            if (value is ulong?)
                return ((value == null) || !((ulong?)value).HasValue);

            if (value is ushort int5)
                return int5 == ushort.MinValue;

            if (value is ushort?)
                return ((value == null) || !((ushort?)value).HasValue);

            return false;
        }

        public static bool IsId(object value)
        {
            if (value == null)
                return true;

            if (value is int @int)
                return ((@int == int.MinValue) || (@int <= 0));

            if (value is int?)
                return ((value == null) || !((int?)value).HasValue);

            return false;
        }
        #endregion
    }

    public static class ServiceProvider
    {
        #region Public Properties
        public static IServiceProvider Instance { get; set; }
        #endregion
    }

    public static class String
    {
        #region Constants
        public const string Empty = "";
        #endregion
    }

    public static class Stopwatch
    {
        private static readonly thZero.Services.IServiceLog log = thZero.Factory.Instance.RetrieveLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Public Methods
        public static void Log(StopwatchTiming data, string type, string name, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic, StopwatchLogTypesOutput logTypeOutput = StopwatchLogTypesOutput.Elapsed, Func<string> additionalFunction = null)
        {
            if (!log.IsDiagnosticEnabled)
                return;

            if (data == null)
                return;

            if (string.IsNullOrEmpty(type))
                type = data.TimingType;
            if (string.IsNullOrEmpty(name))
                name = data.Name;

            string output = string.Concat(FormatOutputPrefix, type, FormatSeparatorTab, name, FormatOutput);

            string additional = string.Empty;
            if (additionalFunction != null)
                additional = additionalFunction();

            if (logTypeOutput == StopwatchLogTypesOutput.Elapsed)
                log.Diagnostic(string.Format(output, logTypeLocation.ToString(), logTypeSpecific.ToString(), string.Empty, string.Empty, FormatElapsed, data.ElapsedTimeDisplay, additional));
            else if (logTypeOutput == StopwatchLogTypesOutput.Start)
                log.Diagnostic(string.Format(output, logTypeLocation.ToString(), logTypeSpecific.ToString(), FormatStart, string.Concat(data.StartTime.ToString(FormatTime), FormatTimeSeparator, data.StartTime.Ticks), string.Empty, string.Empty, string.Empty, string.Empty, additional));
            else
                log.Diagnostic(string.Format(output, logTypeLocation.ToString(), logTypeSpecific.ToString(), FormatStart, string.Concat(data.StartTime.ToString(FormatTime), FormatTimeSeparator, data.StartTime.Ticks), "End", string.Concat(data.EndTime.ToString(FormatTime), FormatTimeSeparator, data.EndTime.Ticks), "Elapsed", data.ElapsedTimeDisplay, additional));
        }

        public static StopwatchTiming Start(string type = Utilities.String.Empty, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypesLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            Guid id = Guid.NewGuid();
            return Start(id, null, type, name, logTypesLocation, logTypeSpecific);
        }

        public static StopwatchTiming Start(StopwatchDurationIndex index, string type = Utilities.String.Empty, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            Guid id = Guid.NewGuid();
            return Start(id, index, type, name, logTypeLocation, logTypeSpecific);
        }

        public static StopwatchTiming Start(Guid id, string type = Utilities.String.Empty, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic)
        {
            return Start(id, null, type, name, logTypeLocation, logTypeSpecific);
        }

        public static StopwatchTiming Start(Guid id, StopwatchDurationIndex index, string type = Utilities.String.Empty, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            StopwatchTiming data;
            if (!_list.ContainsKey(id))
            {
                data = new StopwatchTiming
                {
                    Id = id
                };
                _list.Add(id, data);
            }
            else
                data = _list[id];

            if (data != null)
            {
                data.Name = name;
                data.Index = index != null ? (int?)index.Counter : null;
                data.TimingType = type;
                data.LogTypeLocation = logTypeLocation;
                data.LogTypeSpecific = logTypeSpecific;
                data.EndTime = System.DateTime.MinValue;
                data.StartTime = System.DateTime.UtcNow;
                if (data.Watch.IsRunning)
                    data.Watch.Restart();
                else
                    data.Watch.Start();
            }

            return data;
        }

        public static StopwatchTiming StartLog(string type, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic, Func<string> additionalFunction = null)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            StopwatchTiming data = Start(Guid.NewGuid());
            data.TimingType = type;
            data.LogTypeLocation = logTypeLocation;
            data.LogTypeSpecific = logTypeSpecific;
            data.Name = name;
            if (string.IsNullOrEmpty(name))
                data.Name = data.Id.ToString();

            Log(data, type, data.Name, logTypeLocation, logTypeSpecific, StopwatchLogTypesOutput.Start, additionalFunction: additionalFunction);
            return data;
        }

        public static StopwatchTiming StartLog(Guid id, string type, string name = Utilities.String.Empty, StopwatchLogTypesLocation logTypeLocation = StopwatchLogTypesLocation.Server, StopwatchLogTypesSpecific logTypeSpecific = StopwatchLogTypesSpecific.Generic, Func<string> additionalFunction = null)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            StopwatchTiming data = Start(id);
            data.TimingType = type;
            data.LogTypeLocation = logTypeLocation;
            data.LogTypeSpecific = logTypeSpecific;
            data.Name = name;
            if (string.IsNullOrEmpty(name))
                data.Name = data.Id.ToString();

            Log(data, type, data.Name, logTypeLocation, logTypeSpecific, StopwatchLogTypesOutput.Start, additionalFunction: additionalFunction);
            return data;
        }

        public static StopwatchTiming Stop(Guid id)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            if (!_list.ContainsKey(id))
                return null;

            return Stop(_list[id]);
        }

        public static StopwatchTiming Stop(StopwatchTiming data)
        {
            if (!log.IsDiagnosticEnabled)
                return data;

            if (data != null)
            {
                data.Watch.Stop();
                data.EndTime = System.DateTime.UtcNow;
            }

            return data;
        }

        public static void StopLog(Guid id, Func<string> additionalFunction = null)
        {
            if (!log.IsDiagnosticEnabled)
                return;

            StopwatchTiming data = Stop(id);
            if (data == null)
                return;

            Log(data, data.TimingType, data.Name, data.LogTypeLocation, data.LogTypeSpecific, StopwatchLogTypesOutput.End, additionalFunction: additionalFunction);
        }

        public static void StopLog(StopwatchTiming data, Func<string> additionalFunction = null)
        {
            if (!log.IsDiagnosticEnabled)
                return;

            if (data == null)
                return;

            Stop(data);

            Log(data, data.TimingType, data.Name, data.LogTypeLocation, data.LogTypeSpecific, StopwatchLogTypesOutput.End, additionalFunction: additionalFunction);
        }

        public static string Time(Guid id)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            if (!_list.ContainsKey(id))
                return string.Empty;

            return Time(_list[id]);
        }

        public static string Time(StopwatchTiming data)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            if (data == null)
                return string.Empty;

            TimeSpan timespan = data.Watch.Elapsed;

            string elapsedTime = string.Format(FormatTimeElapsed,
                string.Concat(data.Name, !string.IsNullOrEmpty(data.TimingType) ? FormatSeparatorSpace : string.Empty, data.TimingType).PadRight(50),
                timespan.Hours,
                timespan.Minutes,
                timespan.Seconds,
                timespan.Milliseconds,
                timespan.Ticks);
            return elapsedTime;
        }

        public static string Time(ILogger logger = null)
        {
            if (!log.IsDiagnosticEnabled)
                return null;

            StringBuilder output = new();

            foreach (KeyValuePair<Guid, StopwatchTiming> pair in _list)
            {
                StopwatchTiming data = pair.Value;
                if (data == null)
                    continue;

                output.AppendLine(Time(data));
                logger?.LogInformation(Time(data));
            }

            return output.ToString();
        }
        #endregion

        #region Fields
        private static readonly Dictionary<Guid, StopwatchTiming> _list = new();
        #endregion

        #region Constants
        private const string FormatElapsed = "Elapsed";
        private const string FormatOutputPrefix = "{0}\t{1}\t";
        private const string FormatOutput = "\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}";
        private const string FormatSeparatorSpace = " ";
        private const string FormatSeparatorTab = "\t";
        private const string FormatStart = "Start";

        private const string FormatTime = "MM/dd/yy hh:mm:ss"; // :fffffff
        private const string FormatTimeElapsed = "{0} {1:D2}:{2:D2}:{3:D2}:{4:D4}-{5:D5}";
        private const string FormatTimeSeparator = "-";
        #endregion
    }

    public class StopwatchTiming
    {
        public StopwatchTiming()
        {
            EndTime = System.DateTime.MinValue;
            StartTime = System.DateTime.MinValue;
            Watch = new System.Diagnostics.Stopwatch();
        }

        #region Public Properties
        public long ElpasedTicks => Watch.ElapsedTicks;

        public static long ElapsedTicksFrequencyMilliseconds => System.Diagnostics.Stopwatch.Frequency / 1000;

        public static long ElapsedTicksFrequencySeconds => System.Diagnostics.Stopwatch.Frequency;

        public long ElapsedMilliseconds => Watch.ElapsedMilliseconds;

        public TimeSpan ElapsedTime => Watch.Elapsed;

        public static long ElapsedTimeTicks => TimeSpan.TicksPerMillisecond;

        public string ElapsedTimeDisplay
        {
            get
            {
                TimeSpan timespan = ElapsedTime;

                string elapsedTime = string.Format(FormatElapsedTime,
                    timespan.Hours,
                    timespan.Minutes,
                    timespan.Seconds,
                    timespan.Milliseconds,
                    timespan.Ticks);
                return elapsedTime;
            }
        }

        public System.DateTime EndTime
        {
            get;
            protected internal set;
        }

        public Guid Id
        {
            get;
            protected internal set;
        }

        public int? Index
        {
            get;
            protected internal set;
        }

        public StopwatchLogTypesLocation LogTypeLocation
        {
            get;
            protected internal set;
        }

        public StopwatchLogTypesSpecific LogTypeSpecific
        {
            get;
            protected internal set;
        }

        public string Name
        {
            get;
            protected internal set;
        }

        public System.DateTime StartTime
        {
            get;
            protected internal set;
        }

        public string TimingType
        {
            get;
            protected internal set;
        }

        public System.Diagnostics.Stopwatch Watch
        {
            get;
            protected internal set;
        }
        #endregion

        #region Constants
        private const string FormatElapsedTime = "{0:00}:{1:00}:{2:00}.{3:00}.{4:00}";
        #endregion
    }

    public class StopwatchDurationIndex
    {
        public StopwatchDurationIndex()
        {
            Counter = 0;
        }

        #region Public Methods
        public StopwatchDurationIndex Increment()
        {
            Counter++;
            return this;
        }
        #endregion

        #region Public Properties
        public int Counter { get; private set; }
        #endregion
    }

    public enum StopwatchLogTypesOutput
    {
        Elapsed,
        End,
        Start
    }

    public enum StopwatchLogTypesLocation
    {
        Client,
        Server
    }

    public enum StopwatchLogTypesSpecific
    {
        Data,
        Display,
        Generic,
        Events,
        EventsLoad,
        EventsInit
    }
}

namespace thZero.Utilities.Services
{
    public static class LoggerFactory
    {
        #region Public Properties
        public static ILoggerFactory Instance => Factory.Instance.Retrieve<ILoggerFactory>();
        #endregion
    }

    public static class Json
    {
        #region Public Properties
        public static IServiceJson Instance => Factory.Instance.Retrieve<IServiceJson>();
        #endregion
    }

    public static class Version
    {
        #region Public Properties
        public static IServiceVersionInformation Instance => Factory.Instance.Retrieve<IServiceVersionInformation>();
        #endregion
    }
}
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
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace thZero
{
    public static class Enforce
    {
        #region Public Methods
        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>false</c>.</exception>
        /// <remarks><typeparamref name="TArgument"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        [DebuggerStepThrough]
        public static void Against<TArgument>([ValidatedNotNull] Expression<Func<TArgument>> memberExpression, [ValidatedNotNull] Expression<Func<bool>> checkExpression)
        {
            Func<TArgument> compiledExpression = memberExpression.Compile();
            Func<bool> compiledExpressionCheck = checkExpression.Compile();
            TArgument result = compiledExpression();
            bool resultCheck = compiledExpressionCheck();
            if (resultCheck == false)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is false.", argumentName));
            }

        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TArgument"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        [DebuggerStepThrough]
        public static void AgainstNull<TArgument>([ValidatedNotNull] TArgument argument, string argumentName) where TArgument : class
        {
#if DEBUG
            if (argument == null)
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
#endif
        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TArgument"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        [DebuggerStepThrough]
        public static void AgainstNull<TArgument>([ValidatedNotNull] Expression<Func<TArgument>> memberExpression) where TArgument : class
        {
#if DEBUG
            Func<TArgument> compiledExpression = memberExpression.Compile();
            TArgument result = compiledExpression();
            if (result == null)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
            }
#endif
        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TArgument"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        [DebuggerStepThrough]
        public static void AgainstNull<TArgument>([ValidatedNotNull] Expression<Func<TArgument>> memberExpression, string message) where TArgument : class
        {
#if DEBUG
            if (memberExpression == null)
                return;

            Func<TArgument> compiledExpression = memberExpression.Compile();
            TArgument result = compiledExpression();
            if (result == null)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, message, argumentName));
            }
#endif
        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public static void AgainstNullEx([ValidatedNotNull] object argument, string argumentName)
        {
#if DEBUG
            if (argument == null)
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
#endif
        }

        /// <summary>
        /// Guards against a null or empty string argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public static void AgainstNullOrEmpty([ValidatedNotNull] string argument, string argumentName)
        {
#if DEBUG
            if (argument == null)
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is empty.", argumentName));
#endif
        }

        /// <summary>
        /// Guards against a null or empty string argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public static void AgainstNullOrEmpty([ValidatedNotNull] Expression<Func<string>> memberExpression)
        {
#if DEBUG
            Func<string> compiledExpression = memberExpression.Compile();
            string result = compiledExpression();
            if (result == null)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
            }
            if (string.IsNullOrEmpty(result))
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is empty.", argumentName));
            }
#endif
        }

        /// <summary>
        /// Guards against an empty Guid argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public static void AgainstNullOrEmpty([ValidatedNotNull] Guid argument, string argumentName)
        {
#if DEBUG
            if (Guid.Empty == argument)
                throw new ArgumentException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is empty.", argumentName));
#endif
        }

        /// <summary>
        /// Guards against a null or empty string argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        public static void AgainstNullOrEmpty([ValidatedNotNull] Expression<Func<Guid>> memberExpression)
        {
#if DEBUG
            Func<Guid> compiledExpression = memberExpression.Compile();
            Guid result = compiledExpression();
            if (Guid.Empty == result)
            {
                MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
                string argumentName = expressionBody.Member.Name;
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is empty.", argumentName));
            }
#endif
        }

        /// <summary>
        /// Guards against a null argument if <typeparamref name="TArgument" /> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        [DebuggerStepThrough]
        public static void AgainstNullIfNullable<TArgument>([ValidatedNotNull] TArgument argument, string argumentName)
        {
            if (typeof(TArgument).IsNullableType() && argument == null)
                throw new ArgumentNullException(argumentName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", argumentName));
        }

        /// <summary>
        /// Guards against a null argument property value.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="argumentProperty">The argument property.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TProperty"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        [DebuggerStepThrough]
        public static void AgainstNullProperty<TProperty>([ValidatedNotNull] TProperty argumentProperty, string argumentName, string propertyName)
                where TProperty : class
        {
            if (argumentProperty == null)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0}.{1} is null.", argumentName, propertyName), argumentName);
        }

        /// <summary>
        /// Guards against a null argument property value if <typeparamref name="TProperty"/> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="argumentProperty">The argument property.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        [DebuggerStepThrough]
        public static void AgainstNullArgumentIfNullable<TProperty>([ValidatedNotNull] TProperty argumentProperty, string argumentName, string propertyName)
        {
            if (typeof(TProperty).IsNullableType() && argumentProperty == null)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0}.{1} is null.", argumentName, propertyName), argumentName);

        }

        [DebuggerStepThrough]
        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            return Utilities.General.GetMemberName(memberExpression);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Determines whether the specified type is a nullable type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///	<c>true</c> if the specified type is a nullable type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsNullableType(this Type type)
        {
            return !type.GetTypeInfo().IsValueType || (type.GetTypeInfo().IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }
        #endregion
    }

    /// <summary>
    /// When applied to a parameter, this attribute provides an indication to code analysis that the argument has been null checked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
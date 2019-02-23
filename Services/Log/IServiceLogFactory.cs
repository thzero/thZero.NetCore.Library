/* ------------------------------------------------------------------------- *
thZero.NetCore.Library
Copyright (C) 2016-2019 thZero.com

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
	/// <summary>
	/// Factory to create IServiceLogger instances
	/// </summary>
	//[System.Diagnostics.Contracts.ContractClass(typeof(ProviderLogFactoryContract))]
	public interface IServiceLogFactory : IService
	{
		#region Methods
		/// <summary>
		/// Initialize the logger
		/// </summary>
		/// <param name="log4NetConfigurationFile">File name of the configuration.</param>
		/// <returns></returns>
		void Initialize(params object[] args);

		/// <summary>
		/// Gets the logger.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		IServiceLog RetrieveLogger(Type type);

		/// <summary>
		/// Gets the logger.
		/// </summary>
		/// <param name="typeName">Name of the type.</param>
		/// <returns></returns>
		IServiceLog RetrieveLogger(string typeName);
		#endregion
	}

	/// <summary>
	/// Factory to create IServiceLogConfigurableFactory instances
	/// </summary>
	//[System.Diagnostics.Contracts.ContractClass(typeof(ProviderLogFactoryContract))]
	public interface IServiceLogConfigurableFactory : IServiceLogFactory
	{
		#region Methods
		/// <summary>
		/// Initialize the logger
		/// </summary>
		/// <param name="log4NetConfigurationFile">File name of the configuration.</param>
		/// <returns></returns>
		void Initialize(string configurationFile);
		#endregion
	}
}
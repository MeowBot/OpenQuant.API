using OpenQuant.ObjectMap;
using SmartQuant.Providers;
using System;
using System.Reflection;
namespace OpenQuant.API
{
	public class Provider
	{
		internal IProvider provider;
		public bool IsMarketDataProvider
		{
			get
			{
				return this.provider is IMarketDataProvider;
			}
		}
		public bool IsExecutionProvider
		{
			get
			{
				return this.provider is IExecutionProvider;
			}
		}
		public bool IsHistoricalDataProvider
		{
			get
			{
				return this.provider is IHistoricalDataProvider;
			}
		}
		public bool IsInstrumentProvider
		{
			get
			{
				return this.provider is IInstrumentProvider;
			}
		}
		public ProviderPropertyList Properties
		{
			get;
			private set;
		}
		public byte Id
		{
			get
			{
				return this.provider.Id;
			}
		}
		public string Name
		{
			get
			{
				return this.provider.Name;
			}
		}
		public bool IsConnected
		{
			get
			{
				return this.provider.IsConnected;
			}
		}
		internal Provider(IProvider provider)
		{
			this.provider = provider;
			this.Properties = new ProviderPropertyList();
			PropertyInfo[] properties = provider.GetType().GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				PropertyInfo propertyInfo = properties[i];
				if (propertyInfo.CanRead && propertyInfo.CanWrite && (propertyInfo.PropertyType.IsValueType || propertyInfo.PropertyType == typeof(string)))
				{
					this.Properties.Add(new ProviderProperty(propertyInfo, provider));
				}
			}
		}
		public void Connect()
		{
			Map.RequestProviderConnect(this.provider);
		}
		public void Disconnect()
		{
			Map.RequestProviderDisconnect(this.provider);
		}
	}
}

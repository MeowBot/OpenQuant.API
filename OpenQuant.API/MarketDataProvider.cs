using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	public class MarketDataProvider : Provider
	{
		public BarFactory BarFactory
		{
			get;
			private set;
		}
		public MarketDataFilter Filter
		{
			set
			{
				(this.provider as IMarketDataProvider).MarketDataFilter = value.SQfilter;
			}
		}
		internal MarketDataProvider(IMarketDataProvider provider) : base(provider)
		{
			this.provider = provider;
			this.BarFactory = new BarFactory(provider.BarFactory);
		}
	}
}

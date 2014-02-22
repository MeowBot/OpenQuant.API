using OpenQuant.ObjectMap;
using SmartQuant.Data;
using SmartQuant.Execution;
using SmartQuant.Instruments;
using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	internal class ObjectConverter : IObjectConverter
	{
		public object Convert(SmartQuant.Data.Bar bar)
		{
			return new Bar(bar);
		}
		public object Convert(SmartQuant.Instruments.Portfolio portfolio)
		{
			return new Portfolio(portfolio);
		}
		public object Convert(SingleOrder order)
		{
			return new Order(order);
		}
		public object Convert(SmartQuant.Data.Trade trade)
		{
			return new Trade(trade);
		}
		public object Convert(SmartQuant.Data.Quote quote)
		{
			return new Quote(quote);
		}
		public object Convert(SmartQuant.Providers.ProviderError error)
		{
			return new ProviderError(error);
		}
		public object Convert(MarketDepth marketDepth)
		{
			return new OrderBookUpdate(marketDepth);
		}
	}
}

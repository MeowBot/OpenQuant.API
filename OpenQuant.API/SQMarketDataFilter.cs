using SmartQuant.Data;
using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	internal class SQMarketDataFilter : IMarketDataFilter
	{
		private MarketDataFilter oqFilter;
		internal SQMarketDataFilter(MarketDataFilter oqFilter)
		{
			this.oqFilter = oqFilter;
		}
		public SmartQuant.Data.Quote FilterQuote(SmartQuant.Data.Quote quote, string symbol)
		{
			Quote quote2 = this.oqFilter.FilterQuote(new Quote(quote), symbol);
			if (quote2 == null)
			{
				return null;
			}
			return quote2.quote;
		}
		public SmartQuant.Data.Trade FilterTrade(SmartQuant.Data.Trade trade, string symbol)
		{
			Trade trade2 = this.oqFilter.FilterTrade(new Trade(trade), symbol);
			if (trade2 == null)
			{
				return null;
			}
			return trade2.trade;
		}
		public SmartQuant.Data.Bar FilterBar(SmartQuant.Data.Bar bar, string symbol)
		{
			Bar bar2 = this.oqFilter.FilterBar(new Bar(bar), symbol);
			if (bar2 != null)
			{
				return bar2.bar;
			}
			return null;
		}
		public SmartQuant.Data.Bar FilterBarOpen(SmartQuant.Data.Bar bar, string symbol)
		{
			Bar bar2 = this.oqFilter.FilterBarOpen(new Bar(bar), symbol);
			if (bar2 != null)
			{
				return bar2.bar;
			}
			return null;
		}
	}
}

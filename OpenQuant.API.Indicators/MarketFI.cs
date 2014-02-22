using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MarketFI : global::OpenQuant.API.Indicator
	{
		private MarketFI()
		{
			this.indicator = new SmartQuant.Indicators.MarketFI();
		}
		public MarketFI(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.MarketFI(series.series);
		}
		public MarketFI(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.MarketFI(indicator.indicator);
		}
		public MarketFI(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MarketFI(series.series, color);
		}
		public MarketFI(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MarketFI(indicator.indicator, color);
		}
	}
}

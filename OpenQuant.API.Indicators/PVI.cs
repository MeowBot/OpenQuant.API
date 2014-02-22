using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PVI : OpenQuant.API.Indicator
	{
		private PVI()
		{
			this.indicator = new SmartQuant.Indicators.PVI();
		}
		public PVI(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.PVI(series.series);
		}
		public PVI(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.PVI(indicator.indicator);
		}
		public PVI(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PVI(series.series, color);
		}
		public PVI(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PVI(indicator.indicator, color);
		}
	}
}

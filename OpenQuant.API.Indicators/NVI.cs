using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class NVI : global::OpenQuant.API.Indicator
	{
		private NVI()
		{
			this.indicator = new SmartQuant.Indicators.NVI();
		}
		public NVI(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.NVI(series.series);
		}
		public NVI(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.NVI(indicator.indicator);
		}
		public NVI(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.NVI(series.series, color);
		}
		public NVI(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.NVI(indicator.indicator, color);
		}
	}
}

using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class TR : OpenQuant.API.Indicator
	{
		private TR()
		{
			this.indicator = new SmartQuant.Indicators.TR();
		}
		public TR(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.TR(series.series);
		}
		public TR(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.TR(indicator.indicator);
		}
		public TR(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TR(series.series, color);
		}
		public TR(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TR(indicator.indicator, color);
		}
	}
}

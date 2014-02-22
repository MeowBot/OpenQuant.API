using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class WAD : OpenQuant.API.Indicator
	{
		private WAD()
		{
			this.indicator = new SmartQuant.Indicators.WAD();
		}
		public WAD(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.WAD(series.series);
		}
		public WAD(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.WAD(indicator.indicator);
		}
		public WAD(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WAD(series.series, color);
		}
		public WAD(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.WAD(indicator.indicator, color);
		}
	}
}

using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class EMV : OpenQuant.API.Indicator
	{
		private EMV()
		{
			this.indicator = new SmartQuant.Indicators.EMV();
		}
		public EMV(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.EMV(series.series);
		}
		public EMV(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.EMV(indicator.indicator);
		}
		public EMV(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMV(series.series, color);
		}
		public EMV(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.EMV(indicator.indicator, color);
		}
	}
}

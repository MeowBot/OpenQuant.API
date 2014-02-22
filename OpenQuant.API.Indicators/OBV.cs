using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class OBV : global::OpenQuant.API.Indicator
	{
		private OBV()
		{
			this.indicator = new SmartQuant.Indicators.OBV();
		}
		public OBV(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.OBV(series.series);
		}
		public OBV(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.OBV(indicator.indicator);
		}
		public OBV(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OBV(series.series, color);
		}
		public OBV(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.OBV(indicator.indicator, color);
		}
	}
}

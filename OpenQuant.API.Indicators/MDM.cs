using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MDM : global::OpenQuant.API.Indicator
	{
		private MDM()
		{
			this.indicator = new SmartQuant.Indicators.MDM();
		}
		public MDM(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.MDM(series.series);
		}
		public MDM(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.MDM(indicator.indicator);
		}
		public MDM(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MDM(series.series, color);
		}
		public MDM(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MDM(indicator.indicator, color);
		}
	}
}

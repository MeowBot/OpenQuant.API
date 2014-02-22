using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class AD : global::OpenQuant.API.Indicator
	{
		private AD()
		{
			this.indicator = new SmartQuant.Indicators.AD();
		}
		public AD(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.AD(series.series);
		}
		public AD(global::OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.AD(indicator.indicator);
		}
		public AD(TimeSeries series)
		{
			this.indicator = new SmartQuant.Indicators.AD(series.series);
		}
		public AD(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AD(series.series, color);
		}
		public AD(global::OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AD(indicator.indicator, color);
		}
		public AD(TimeSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.AD(series.series, color);
		}
	}
}

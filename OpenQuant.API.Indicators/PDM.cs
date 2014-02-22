using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class PDM : OpenQuant.API.Indicator
	{
		private PDM()
		{
			this.indicator = new SmartQuant.Indicators.PDM();
		}
		public PDM(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.PDM(series.series);
		}
		public PDM(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.PDM(indicator.indicator);
		}
		public PDM(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PDM(series.series, color);
		}
		public PDM(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.PDM(indicator.indicator, color);
		}
	}
}

using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class TH : OpenQuant.API.Indicator
	{
		private TH()
		{
			this.indicator = new SmartQuant.Indicators.TH();
		}
		public TH(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.TH(series.series);
		}
		public TH(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.TH(indicator.indicator);
		}
		public TH(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TH(series.series, color);
		}
		public TH(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TH(indicator.indicator, color);
		}
	}
}

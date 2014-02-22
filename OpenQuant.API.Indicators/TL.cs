using SmartQuant.Indicators;
using System;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class TL : OpenQuant.API.Indicator
	{
		private TL()
		{
			this.indicator = new SmartQuant.Indicators.TL();
		}
		public TL(BarSeries series)
		{
			this.indicator = new SmartQuant.Indicators.TL(series.series);
		}
		public TL(OpenQuant.API.Indicator indicator)
		{
			this.indicator = new SmartQuant.Indicators.TL(indicator.indicator);
		}
		public TL(BarSeries series, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TL(series.series, color);
		}
		public TL(OpenQuant.API.Indicator indicator, Color color)
		{
			this.indicator = new SmartQuant.Indicators.TL(indicator.indicator, color);
		}
	}
}

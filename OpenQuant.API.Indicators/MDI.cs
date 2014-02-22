using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MDI : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MDI).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MDI).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.MDI).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MDI).Style = OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private MDI()
		{
			this.indicator = new SmartQuant.Indicators.MDI();
		}
		public MDI(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.MDI(series.series, length);
		}
		public MDI(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.MDI(indicator.indicator, length);
		}
		public MDI(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MDI(series.series, length, color);
		}
		public MDI(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MDI(indicator.indicator, length, color);
		}
	}
}

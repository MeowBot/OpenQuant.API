using SmartQuant.Indicators;
using System;
using System.ComponentModel;
namespace OpenQuant.API.Indicators
{
	public class SMV : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SMV).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SMV).Length = value;
			}
		}
		private SMV()
		{
			this.indicator = new SmartQuant.Indicators.SMV();
		}
		public SMV(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMV(series.series, length);
		}
		public SMV(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMV(indicator.indicator, length);
		}
		public SMV(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMV(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMV(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMV(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
	}
}

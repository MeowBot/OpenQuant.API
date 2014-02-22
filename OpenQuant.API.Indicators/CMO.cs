using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class CMO : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.CMO).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.CMO).Length = value;
			}
		}
		private CMO()
		{
			this.indicator = new SmartQuant.Indicators.CMO();
		}
		public CMO(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.CMO(series.series, length);
		}
		public CMO(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.CMO(indicator.indicator, length);
		}
		public CMO(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.CMO(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public CMO(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.CMO(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public CMO(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CMO(series.series, length, color);
		}
		public CMO(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CMO(indicator.indicator, length, color);
		}
		public CMO(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CMO(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public CMO(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.CMO(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}

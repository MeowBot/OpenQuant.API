using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class SMD : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.SMD).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.SMD).Length = value;
			}
		}
		private SMD()
		{
			this.indicator = new SmartQuant.Indicators.SMD();
		}
		public SMD(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length);
		}
		public SMD(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMD(indicator.indicator, length);
		}
		public SMD(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMD(global::OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMD(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMD(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, color);
		}
		public SMD(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(indicator.indicator, length, color);
		}
		public SMD(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public SMD(global::OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(indicator.indicator, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public SMD(TimeSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length);
		}
		public SMD(TimeSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public SMD(TimeSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, color);
		}
		public SMD(TimeSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.SMD(series.series, length, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}

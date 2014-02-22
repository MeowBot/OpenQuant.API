using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MACD : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length1")]
		public int Length1
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MACD).Length1;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MACD).Length1 = value;
			}
		}
		[Category("Parameters"), Description("Length2")]
		public int Length2
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MACD).Length2;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MACD).Length2 = value;
			}
		}
		private MACD()
		{
			this.indicator = new SmartQuant.Indicators.MACD();
		}
		public MACD(BarSeries series, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2);
		}
		public MACD(global::OpenQuant.API.Indicator indicator, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.MACD(indicator.indicator, length1, length2);
		}
		public MACD(TimeSeries series, int length1, int length2)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2);
		}
		public MACD(BarSeries series, int length1, int length2, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public MACD(global::OpenQuant.API.Indicator indicator, int length1, int length2, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.MACD(indicator.indicator, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option));
		}
		public MACD(BarSeries series, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2, color);
		}
		public MACD(global::OpenQuant.API.Indicator indicator, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MACD(indicator.indicator, length1, length2, color);
		}
		public MACD(TimeSeries series, int length1, int length2, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2, color);
		}
		public MACD(BarSeries series, int length1, int length2, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MACD(series.series, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public MACD(global::OpenQuant.API.Indicator indicator, int length1, int length2, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MACD(indicator.indicator, length1, length2, global::OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}

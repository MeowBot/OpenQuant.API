using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class DX : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.DX).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.DX).Length = value;
			}
		}
		public IndicatorStyle Style
		{
			get
			{
				return global::OpenQuant.API.EnumConverter.Convert((this.indicator as SmartQuant.Indicators.DX).Style);
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.DX).Style = global::OpenQuant.API.EnumConverter.Convert(value);
			}
		}
		private DX()
		{
			this.indicator = new SmartQuant.Indicators.DX();
		}
		public DX(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.DX(series.series, length);
		}
		public DX(global::OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.DX(indicator.indicator, length);
		}
		public DX(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DX(series.series, length, color);
		}
		public DX(global::OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.DX(indicator.indicator, length, color);
		}
	}
}

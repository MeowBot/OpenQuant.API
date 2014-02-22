using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class VHF : OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.VHF).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.VHF).Length = value;
			}
		}
		private VHF()
		{
			this.indicator = new SmartQuant.Indicators.VHF();
		}
		public VHF(BarSeries series, int length)
		{
			this.indicator = new SmartQuant.Indicators.VHF(series.series, length);
		}
		public VHF(OpenQuant.API.Indicator indicator, int length)
		{
			this.indicator = new SmartQuant.Indicators.VHF(indicator.indicator, length);
		}
		public VHF(BarSeries series, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.VHF(series.series, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public VHF(OpenQuant.API.Indicator indicator, int length, BarData option)
		{
			this.indicator = new SmartQuant.Indicators.VHF(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option));
		}
		public VHF(BarSeries series, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VHF(series.series, length, color);
		}
		public VHF(OpenQuant.API.Indicator indicator, int length, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VHF(indicator.indicator, length, color);
		}
		public VHF(BarSeries series, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VHF(series.series, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
		public VHF(OpenQuant.API.Indicator indicator, int length, BarData option, Color color)
		{
			this.indicator = new SmartQuant.Indicators.VHF(indicator.indicator, length, OpenQuant.API.EnumConverter.Convert(option), color);
		}
	}
}

using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class MASS : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MASS).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MASS).Length = value;
			}
		}
		[Category("Parameters"), Description("Order")]
		public int Order
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.MASS).Order;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.MASS).Order = value;
			}
		}
		private MASS()
		{
			this.indicator = new SmartQuant.Indicators.MASS();
		}
		public MASS(BarSeries series, int length, int order)
		{
			this.indicator = new SmartQuant.Indicators.MASS(series.series, length, order);
		}
		public MASS(global::OpenQuant.API.Indicator indicator, int length, int order)
		{
			this.indicator = new SmartQuant.Indicators.MASS(indicator.indicator, length, order);
		}
		public MASS(BarSeries series, int length, int order, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MASS(series.series, length, order, color);
		}
		public MASS(global::OpenQuant.API.Indicator indicator, int length, int order, Color color)
		{
			this.indicator = new SmartQuant.Indicators.MASS(indicator.indicator, length, order, color);
		}
	}
}

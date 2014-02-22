using SmartQuant.Indicators;
using System;
using System.ComponentModel;
using System.Drawing;
namespace OpenQuant.API.Indicators
{
	public class K_Slow : global::OpenQuant.API.Indicator
	{
		[Category("Parameters"), Description("Length")]
		public int Length
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.K_Slow).Length;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.K_Slow).Length = value;
			}
		}
		[Category("Parameters"), Description("Order")]
		public int Order
		{
			get
			{
				return (this.indicator as SmartQuant.Indicators.K_Slow).Order;
			}
			set
			{
				(this.indicator as SmartQuant.Indicators.K_Slow).Order = value;
			}
		}
		private K_Slow()
		{
			this.indicator = new SmartQuant.Indicators.K_Slow();
		}
		public K_Slow(BarSeries series, int length, int order)
		{
			this.indicator = new SmartQuant.Indicators.K_Slow(series.series, length, order);
		}
		public K_Slow(global::OpenQuant.API.Indicator indicator, int length, int order)
		{
			this.indicator = new SmartQuant.Indicators.K_Slow(indicator.indicator, length, order);
		}
		public K_Slow(BarSeries series, int length, int order, Color color)
		{
			this.indicator = new SmartQuant.Indicators.K_Slow(series.series, length, order, color);
		}
		public K_Slow(global::OpenQuant.API.Indicator indicator, int length, int order, Color color)
		{
			this.indicator = new SmartQuant.Indicators.K_Slow(indicator.indicator, length, order, color);
		}
	}
}

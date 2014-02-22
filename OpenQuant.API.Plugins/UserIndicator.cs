using SmartQuant.Indicators;
using SmartQuant.Series;
using System;
using System.ComponentModel;
namespace OpenQuant.API.Plugins
{
	public class UserIndicator : global::OpenQuant.API.Indicator
	{
		private ISeries input;
		private SmartQuant.Series.TimeSeries series;
		private bool isInitialized;
		public ISeries Input
		{
			get
			{
				return this.input;
			}
		}
		[Browsable(false)]
		public new string Name
		{
			get
			{
				this.Init();
				return this.indicator.Name;
			}
			set
			{
				this.Init();
				this.indicator.Name = value;
			}
		}
		public override double this[int index]
		{
			get
			{
				this.Init();
				return base[index];
			}
		}
		public override double this[DateTime dateTime]
		{
			get
			{
				this.Init();
				return base[dateTime];
			}
		}
		[Browsable(false)]
		public override int Count
		{
			get
			{
				this.Init();
				return base.Count;
			}
		}
		public override double this[Bar bar]
		{
			get
			{
				this.Init();
				return base[bar];
			}
		}
		[Browsable(false)]
		public override double Last
		{
			get
			{
				this.Init();
				return base.Last;
			}
		}
		[Browsable(false)]
		public override DateTime FirstDateTime
		{
			get
			{
				this.Init();
				return base.FirstDateTime;
			}
		}
		[Browsable(false)]
		public override DateTime LastDateTime
		{
			get
			{
				this.Init();
				return base.LastDateTime;
			}
		}
		public override double this[DateTime dateTime, BarData barData]
		{
			get
			{
				this.Init();
				return base[dateTime, barData];
			}
		}
		public override double this[int index, BarData barData]
		{
			get
			{
				this.Init();
				return base[index, barData];
			}
		}
		public UserIndicator(ISeries input)
		{
			this.input = input;
			if (input is global::OpenQuant.API.TimeSeries)
			{
				this.series = (input as global::OpenQuant.API.TimeSeries).series;
			}
			if (input is global::OpenQuant.API.BarSeries)
			{
				this.series = (input as global::OpenQuant.API.BarSeries).series;
			}
			if (input is global::OpenQuant.API.Indicator)
			{
				this.series = (input as global::OpenQuant.API.Indicator).indicator;
			}
			this.indicator = new SmartQuant.Indicators.Indicator(this.series);
		}
		public void Init()
		{
			if (!this.isInitialized)
			{
				this.series.ItemAdded += new ItemAddedEventHandler(this.OnInputItemAdded);
				for (int i = 0; i < this.series.Count; i++)
				{
					double num = this.Calculate(i);
					if (!double.IsNaN(num))
					{
						this.indicator.Add(this.series.GetDateTime(i), num);
					}
				}
				this.isInitialized = true;
			}
		}
		public virtual double Calculate(int index)
		{
			return double.NaN;
		}
		private void OnInputItemAdded(object sender, DateTimeEventArgs args)
		{
			double num = this.Calculate(this.series.GetIndex(args.DateTime));
			if (!double.IsNaN(num))
			{
				this.indicator.Add(args.DateTime, num);
			}
		}
		public override double Ago(int n)
		{
			this.Init();
			return base.Ago(n);
		}
		public override bool Contains(DateTime dateTime)
		{
			this.Init();
			return base.Contains(dateTime);
		}
		public override bool Contains(Bar bar)
		{
			this.Init();
			return base.Contains(bar);
		}
		public override bool CrossesBelow(global::OpenQuant.API.BarSeries series, Bar bar)
		{
			this.Init();
			return base.CrossesBelow(series, bar);
		}
		public override bool CrossesAbove(global::OpenQuant.API.BarSeries series, Bar bar)
		{
			this.Init();
			return base.CrossesAbove(series, bar);
		}
		public override bool CrossesBelow(global::OpenQuant.API.Indicator indicator, Bar bar)
		{
			this.Init();
			return base.CrossesBelow(indicator, bar);
		}
		public override bool CrossesAbove(global::OpenQuant.API.Indicator indicator, Bar bar)
		{
			this.Init();
			return base.CrossesAbove(indicator, bar);
		}
		public override Cross Crosses(global::OpenQuant.API.Indicator indicator, Bar bar)
		{
			this.Init();
			return base.Crosses(indicator, bar);
		}
		public override Cross Crosses(global::OpenQuant.API.BarSeries series, Bar bar)
		{
			this.Init();
			return base.Crosses(series, bar);
		}
		public override DateTime GetDateTime(int index)
		{
			this.Init();
			return base.GetDateTime(index);
		}
	}
}

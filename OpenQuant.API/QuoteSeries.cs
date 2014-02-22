using SmartQuant.Data;
using SmartQuant.Series;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class QuoteSeries : IEnumerable
	{
		private class QuoteSeriesEnumerator : IEnumerator
		{
			private QuoteArray series;
			private IEnumerator enumerator;
			public object Current
			{
				get
				{
					SmartQuant.Data.Quote quote = this.enumerator.Current as SmartQuant.Data.Quote;
					return new Quote(quote);
				}
			}
			internal QuoteSeriesEnumerator(QuoteArray series)
			{
				this.series = series;
				this.enumerator = series.GetEnumerator();
			}
			public bool MoveNext()
			{
				return this.enumerator.MoveNext();
			}
			public void Reset()
			{
				this.enumerator.Reset();
			}
		}
		internal QuoteArray series;
		public int Count
		{
			get
			{
				return this.series.Count;
			}
		}
		public Quote Last
		{
			get
			{
				if (this.series.Count > 0)
				{
					return new Quote(this.series[this.series.Count - 1]);
				}
				return null;
			}
		}
		public Quote this[int index]
		{
			get
			{
				return new Quote(this.series[index]);
			}
		}
		internal QuoteSeries(QuoteArray series)
		{
			this.series = series;
		}
		public QuoteSeries()
		{
			this.series = new QuoteArray();
		}
		public void Add(Quote quote)
		{
			this.series.Add(quote.quote);
		}
		public BarSeries CompressBars(QuoteData input, BarType barType, long barSize)
		{
			return DataManager.CompressBars(this, input, barType, barSize);
		}
		public IEnumerator GetEnumerator()
		{
			return new QuoteSeries.QuoteSeriesEnumerator(this.series);
		}
		public void Clear()
		{
			this.series.Clear();
		}
	}
}

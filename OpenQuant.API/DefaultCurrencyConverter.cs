using SmartQuant.Instruments;
using System;
namespace OpenQuant.API
{
	internal class DefaultCurrencyConverter : CurrencyConverter
	{
		public override double Convert(double amount, Currency fromCurrency, Currency toCurrency)
		{
			if (fromCurrency == toCurrency)
			{
				return amount;
			}
			Instrument instrument = InstrumentManager.Instruments[fromCurrency.Code + "_" + toCurrency.Code];
			if (instrument != null)
			{
				return amount * this.GetAmount(instrument, amount);
			}
			instrument = InstrumentManager.Instruments[toCurrency.Code + "_" + fromCurrency.Code];
			if (instrument == null)
			{
				return amount;
			}
			return amount / this.GetAmount(instrument, amount);
		}
		private double GetAmount(Instrument instrument, double amount)
		{
			if (instrument.Quote.DateTime != DateTime.MinValue)
			{
				return (instrument.Quote.Ask + instrument.Quote.Bid) / 2.0;
			}
			if (instrument.Trade.DateTime != DateTime.MinValue && instrument.Trade.DateTime >= instrument.Bar.DateTime)
			{
				return instrument.Trade.Price;
			}
			if (instrument.Bar.DateTime != DateTime.MinValue)
			{
				return instrument.Bar.Close;
			}
			return 1.0;
		}
	}
}

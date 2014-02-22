using SmartQuant.FIX;
using SmartQuant.Instruments;
using System;
namespace OpenQuant.API
{
	public class Transaction
	{
		internal SmartQuant.Instruments.Transaction transaction;
		public Instrument Instrument
		{
			get
			{
				return OpenQuant.Instruments[this.transaction.Instrument.Symbol];
			}
		}
		public DateTime DateTime
		{
			get
			{
				return this.transaction.DateTime;
			}
		}
		public TransactionSide Side
		{
			get
			{
				switch (this.transaction.Side)
				{
				case SmartQuant.FIX.Side.Buy:
					return TransactionSide.Buy;
				case SmartQuant.FIX.Side.Sell:
				case SmartQuant.FIX.Side.SellShort:
					return TransactionSide.Sell;
				}
				throw new NotImplementedException("Unknown TransactionSide : " + this.transaction.Side);
			}
		}
		public double Price
		{
			get
			{
				return this.transaction.Price;
			}
		}
		public double Qty
		{
			get
			{
				return this.transaction.Qty;
			}
		}
		public double Cost
		{
			get
			{
				return this.transaction.Cost;
			}
		}
		public string Text
		{
			get
			{
				return this.transaction.Text;
			}
		}
		public double PnL
		{
			get
			{
				return this.transaction.PnL;
			}
		}
		internal Transaction(SmartQuant.Instruments.Transaction transaction)
		{
			this.transaction = transaction;
		}
		public override string ToString()
		{
			return this.transaction.ToString();
		}
	}
}

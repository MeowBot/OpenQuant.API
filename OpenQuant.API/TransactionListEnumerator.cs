using SmartQuant.Instruments;
using System;
using System.Collections;
namespace OpenQuant.API
{
	internal class TransactionListEnumerator : IEnumerator
	{
		private SmartQuant.Instruments.TransactionList transactionList;
		private IEnumerator enumerator;
		public object Current
		{
			get
			{
				SmartQuant.Instruments.Transaction transaction = this.enumerator.Current as SmartQuant.Instruments.Transaction;
				return new Transaction(transaction);
			}
		}
		internal TransactionListEnumerator(SmartQuant.Instruments.TransactionList transactionList)
		{
			this.transactionList = transactionList;
			this.enumerator = transactionList.GetEnumerator();
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
}

using SmartQuant.Instruments;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class TransactionList : IEnumerable
	{
		private SmartQuant.Instruments.TransactionList transactionList;
		public int Count
		{
			get
			{
				return this.transactionList.Count;
			}
		}
		public Transaction this[int index]
		{
			get
			{
				SmartQuant.Instruments.Transaction transaction = this.transactionList[index];
				return new Transaction(transaction);
			}
		}
		internal TransactionList(SmartQuant.Instruments.TransactionList transactionList)
		{
			this.transactionList = transactionList;
		}
		public IEnumerator GetEnumerator()
		{
			return new TransactionListEnumerator(this.transactionList);
		}
	}
}

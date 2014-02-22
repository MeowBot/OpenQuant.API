using SmartQuant.Providers;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class BrokerOrderList : ICollection, IEnumerable
	{
		private SmartQuant.Providers.BrokerOrder[] orders;
		public int Count
		{
			get
			{
				return this.orders.Length;
			}
		}
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}
		public object SyncRoot
		{
			get
			{
				return null;
			}
		}
		public BrokerOrder this[int index]
		{
			get
			{
				if (index < 0 || index >= this.orders.Length)
				{
					return null;
				}
				return new BrokerOrder(this.orders[index]);
			}
		}
		internal BrokerOrderList(SmartQuant.Providers.BrokerOrder[] orders)
		{
			this.orders = orders;
		}
		public void CopyTo(Array array, int index)
		{
			ArrayList arrayList = new ArrayList();
			foreach (BrokerOrder value in this)
			{
				arrayList.Add(value);
			}
			arrayList.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			try
			{
				SmartQuant.Providers.BrokerOrder[] array = this.orders;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerOrder brokerOrder = array[i];
					yield return new BrokerOrder(brokerOrder);
				}
			}
			finally
			{
			}
			yield break;
		}
	}
}

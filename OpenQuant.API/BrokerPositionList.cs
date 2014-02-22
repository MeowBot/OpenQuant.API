using SmartQuant.Providers;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class BrokerPositionList : ICollection, IEnumerable
	{
		private SmartQuant.Providers.BrokerPosition[] positions;
		public int Count
		{
			get
			{
				return this.positions.Length;
			}
		}
		public bool IsSynchronized
		{
			get
			{
				return this.positions.IsSynchronized;
			}
		}
		public object SyncRoot
		{
			get
			{
				return this.positions.SyncRoot;
			}
		}
		public BrokerPosition this[int index]
		{
			get
			{
				if (index >= 0 && index < this.positions.Length)
				{
					return new BrokerPosition(this.positions[index]);
				}
				return null;
			}
		}
		internal BrokerPositionList(SmartQuant.Providers.BrokerPosition[] positions)
		{
			this.positions = positions;
		}
		public void CopyTo(Array array, int index)
		{
			ArrayList arrayList = new ArrayList();
			foreach (BrokerPosition value in this)
			{
				arrayList.Add(value);
			}
			arrayList.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			try
			{
				SmartQuant.Providers.BrokerPosition[] array = this.positions;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerPosition brokerPosition = array[i];
					yield return new BrokerPosition(brokerPosition);
				}
			}
			finally
			{
			}
			yield break;
		}
	}
}

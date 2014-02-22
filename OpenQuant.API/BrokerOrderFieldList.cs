using SmartQuant.Providers;
using System;
using System.Collections;
namespace OpenQuant.API
{
	public class BrokerOrderFieldList : ICollection, IEnumerable
	{
		private SmartQuant.Providers.BrokerOrderField[] fields;
		public int Count
		{
			get
			{
				return this.fields.Length;
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
		public BrokerOrderField this[string name]
		{
			get
			{
				SmartQuant.Providers.BrokerOrderField[] array = this.fields;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerOrderField brokerOrderField = array[i];
					if (brokerOrderField.Name == name)
					{
						return new BrokerOrderField(brokerOrderField);
					}
				}
				return null;
			}
		}
		internal BrokerOrderFieldList(SmartQuant.Providers.BrokerOrderField[] fields)
		{
			this.fields = fields;
		}
		public void CopyTo(Array array, int index)
		{
			ArrayList arrayList = new ArrayList();
			foreach (BrokerOrderField value in this)
			{
				arrayList.Add(value);
			}
			arrayList.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			try
			{
				SmartQuant.Providers.BrokerOrderField[] array = this.fields;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerOrderField field = array[i];
					yield return new BrokerOrderField(field);
				}
			}
			finally
			{
			}
			yield break;
		}
	}
}

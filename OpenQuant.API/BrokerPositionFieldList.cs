using SmartQuant.Providers;
using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API
{
	public class BrokerPositionFieldList : ICollection, IEnumerable
	{
		private SmartQuant.Providers.BrokerPositionField[] fields;
		private Dictionary<string, SmartQuant.Providers.BrokerPositionField> table;
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
				return this.fields.IsSynchronized;
			}
		}
		public object SyncRoot
		{
			get
			{
				return this.fields.SyncRoot;
			}
		}
		public BrokerPositionField this[string name]
		{
			get
			{
				SmartQuant.Providers.BrokerPositionField field;
				if (this.table.TryGetValue(name, out field))
				{
					return new BrokerPositionField(field);
				}
				return null;
			}
		}
		internal BrokerPositionFieldList(SmartQuant.Providers.BrokerPositionField[] fields)
		{
			this.fields = fields;
			this.table = new Dictionary<string, SmartQuant.Providers.BrokerPositionField>();
			for (int i = 0; i < fields.Length; i++)
			{
				SmartQuant.Providers.BrokerPositionField brokerPositionField = fields[i];
				this.table.Add(brokerPositionField.Name, brokerPositionField);
			}
		}
		public void CopyTo(Array array, int index)
		{
			ArrayList arrayList = new ArrayList();
			foreach (BrokerPositionField value in this)
			{
				arrayList.Add(value);
			}
			arrayList.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			try
			{
				SmartQuant.Providers.BrokerPositionField[] array = this.fields;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerPositionField field = array[i];
					yield return new BrokerPositionField(field);
				}
			}
			finally
			{
			}
			yield break;
		}
	}
}

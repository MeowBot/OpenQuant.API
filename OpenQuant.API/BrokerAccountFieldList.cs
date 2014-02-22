using SmartQuant.Providers;
using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API
{
	public class BrokerAccountFieldList : ICollection, IEnumerable
	{
		private SmartQuant.Providers.BrokerAccountField[] fields;
		private Dictionary<string, Dictionary<string, SmartQuant.Providers.BrokerAccountField>> table;
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
		public BrokerAccountField this[string name, string currency]
		{
			get
			{
				Dictionary<string, SmartQuant.Providers.BrokerAccountField> dictionary;
				if (!this.table.TryGetValue(name, out dictionary))
				{
					return null;
				}
				SmartQuant.Providers.BrokerAccountField field;
				if (dictionary.TryGetValue(currency, out field))
				{
					return new BrokerAccountField(field);
				}
				return null;
			}
		}
		public BrokerAccountField this[string name]
		{
			get
			{
				return this[name, string.Empty];
			}
		}
		internal BrokerAccountFieldList(SmartQuant.Providers.BrokerAccountField[] fields)
		{
			this.fields = fields;
			this.table = new Dictionary<string, Dictionary<string, SmartQuant.Providers.BrokerAccountField>>();
			for (int i = 0; i < fields.Length; i++)
			{
				SmartQuant.Providers.BrokerAccountField brokerAccountField = fields[i];
				Dictionary<string, SmartQuant.Providers.BrokerAccountField> dictionary;
				if (!this.table.TryGetValue(brokerAccountField.Name, out dictionary))
				{
					dictionary = new Dictionary<string, SmartQuant.Providers.BrokerAccountField>();
					this.table.Add(brokerAccountField.Name, dictionary);
				}
				dictionary.Add(brokerAccountField.Currency, brokerAccountField);
			}
		}
		public void CopyTo(Array array, int index)
		{
			ArrayList arrayList = new ArrayList();
			foreach (BrokerAccountField value in this)
			{
				arrayList.Add(value);
			}
			arrayList.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			try
			{
				SmartQuant.Providers.BrokerAccountField[] array = this.fields;
				for (int i = 0; i < array.Length; i++)
				{
					SmartQuant.Providers.BrokerAccountField field = array[i];
					yield return new BrokerAccountField(field);
				}
			}
			finally
			{
			}
			yield break;
		}
		public BrokerAccountField[] GetAllByName(string name)
		{
			Dictionary<string, SmartQuant.Providers.BrokerAccountField> dictionary;
			if (this.table.TryGetValue(name, out dictionary))
			{
				List<BrokerAccountField> list = new List<BrokerAccountField>();
				foreach (SmartQuant.Providers.BrokerAccountField current in dictionary.Values)
				{
					list.Add(new BrokerAccountField(current));
				}
				return list.ToArray();
			}
			return new BrokerAccountField[0];
		}
		public bool Contains(string name, string currency)
		{
			Dictionary<string, SmartQuant.Providers.BrokerAccountField> dictionary;
			return this.table.TryGetValue(name, out dictionary) && dictionary.ContainsKey(currency);
		}
		public bool Contains(string name)
		{
			return this.Contains(name, string.Empty);
		}
	}
}

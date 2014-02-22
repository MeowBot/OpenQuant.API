using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API.Engine
{
	public class ParameterSet : IEnumerable
	{
		private Dictionary<string, Parameter> parameters;
		public int Count
		{
			get
			{
				return this.parameters.Count;
			}
		}
		public Parameter this[string name]
		{
			get
			{
				return this.parameters[name];
			}
		}
		public IEnumerator GetEnumerator()
		{
			return this.parameters.Values.GetEnumerator();
		}
		internal ParameterSet(List<Parameter> list)
		{
			this.parameters = new Dictionary<string, Parameter>();
			foreach (Parameter current in list)
			{
				this.parameters[current.Name] = current;
			}
		}
		public bool Contains(string name)
		{
			return this.parameters.ContainsKey(name);
		}
		public bool TryGetValue(string name, out Parameter parameter)
		{
			return this.parameters.TryGetValue(name, out parameter);
		}
	}
}

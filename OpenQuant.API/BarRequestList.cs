using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API
{
	public class BarRequestList : IEnumerable
	{
		private List<BarRequest> list = new List<BarRequest>();
		public int Count
		{
			get
			{
				return this.list.Count;
			}
		}
		public BarRequest this[int index]
		{
			get
			{
				return this.list[index];
			}
		}
		public IEnumerator GetEnumerator()
		{
			return this.list.GetEnumerator();
		}
		public bool Contains(BarRequest barRequest)
		{
			return this.Contains(barRequest.BarType, barRequest.BarSize, barRequest.IsBarFactoryRequest);
		}
		public bool Contains(BarType barType, long barSize, bool isBuiltFromTrades)
		{
			foreach (BarRequest current in this.list)
			{
				if (barSize == current.BarSize && barType == current.BarType && isBuiltFromTrades == current.IsBarFactoryRequest)
				{
					return true;
				}
			}
			return false;
		}
		public bool Contains(BarType barType, long barSize)
		{
			foreach (BarRequest current in this.list)
			{
				if (barSize == current.BarSize && barType == current.BarType)
				{
					return true;
				}
			}
			return false;
		}
		public void Add(BarRequest barRequest)
		{
			this.list.Add(barRequest);
		}
		public BarRequest Add(BarType barType, long barSize, bool isBarFacroryRequest)
		{
			BarRequest barRequest = new BarRequest(barType, barSize, isBarFacroryRequest);
			this.Add(barRequest);
			return barRequest;
		}
		public void Remove(BarRequest barRequest)
		{
			this.list.Remove(barRequest);
		}
		public void Remove(BarType barType, long barSize)
		{
			BarRequest barRequest = new BarRequest(barType, barSize, true);
			this.Remove(barRequest);
		}
	}
}

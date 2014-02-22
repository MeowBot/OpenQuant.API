using SmartQuant.FIX;
using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API
{
	public class ExecutionReportList : IEnumerable
	{
		private List<FIXMessage> messages;
		public int Count
		{
			get
			{
				return this.messages.Count;
			}
		}
		public ExecutionReport this[int index]
		{
			get
			{
				FIXMessage message = this.messages[index];
				return new ExecutionReport(message);
			}
		}
		public ExecutionReport Last
		{
			get
			{
				return this[this.Count - 1];
			}
		}
		internal ExecutionReportList(List<FIXMessage> messages)
		{
			this.messages = messages;
		}
		public IEnumerator GetEnumerator()
		{
			return new ExecutionReportListEnumerator(this.messages);
		}
	}
}

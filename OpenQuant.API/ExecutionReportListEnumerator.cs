using SmartQuant.FIX;
using System;
using System.Collections;
using System.Collections.Generic;
namespace OpenQuant.API
{
	internal class ExecutionReportListEnumerator : IEnumerator
	{
		private List<FIXMessage> messages;
		private IEnumerator enumerator;
		public object Current
		{
			get
			{
				SmartQuant.FIX.ExecutionReport message = this.enumerator.Current as SmartQuant.FIX.ExecutionReport;
				return new ExecutionReport(message);
			}
		}
		internal ExecutionReportListEnumerator(List<FIXMessage> messages)
		{
			this.messages = messages;
			this.enumerator = messages.GetEnumerator();
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

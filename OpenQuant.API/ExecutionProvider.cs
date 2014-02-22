using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	public class ExecutionProvider : Provider
	{
		internal ExecutionProvider(IExecutionProvider provider) : base(provider)
		{
			this.provider = provider;
		}
	}
}

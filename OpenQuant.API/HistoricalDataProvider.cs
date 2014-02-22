using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	public class HistoricalDataProvider : Provider
	{
		internal HistoricalDataProvider(IHistoricalDataProvider provider) : base(provider)
		{
		}
	}
}

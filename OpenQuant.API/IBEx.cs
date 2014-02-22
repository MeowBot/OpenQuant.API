using OpenQuant.API.Design;
using SmartQuant.Execution;
using SmartQuant.FIX;
using System;
using System.ComponentModel;
namespace OpenQuant.API
{
	[TypeConverter(typeof(IBExTypeConverter))]
	public class IBEx
	{
		private SingleOrder order;
		public bool Hidden
		{
			get
			{
				return this.order.Hidden;
			}
			set
			{
				this.order.Hidden = value;
			}
		}
		public double DisplaySize
		{
			get
			{
				return this.order.DisplaySize;
			}
			set
			{
				this.order.DisplaySize = value;
			}
		}
		public string FaGroup
		{
			get
			{
				return this.order.FaGroup;
			}
			set
			{
				this.order.FaGroup = value;
			}
		}
		public IBFaMethod FaMethod
		{
			get
			{
				switch (this.order.FaMethod)
				{
				case SmartQuant.FIX.FaMethod.PctChange:
					return IBFaMethod.PctChange;
				case SmartQuant.FIX.FaMethod.AvailableEquity:
					return IBFaMethod.AvailableEquity;
				case SmartQuant.FIX.FaMethod.NetLiq:
					return IBFaMethod.NetLiq;
				case SmartQuant.FIX.FaMethod.EqualQuantity:
					return IBFaMethod.EqualQuantity;
				case SmartQuant.FIX.FaMethod.Undefined:
					return IBFaMethod.Undefined;
				default:
					throw new ArgumentException(string.Format("Unknown method - {0}", this.order.FaMethod));
				}
			}
			set
			{
				switch (value)
				{
				case IBFaMethod.PctChange:
					this.order.FaMethod = SmartQuant.FIX.FaMethod.PctChange;
					return;
				case IBFaMethod.AvailableEquity:
					this.order.FaMethod = SmartQuant.FIX.FaMethod.AvailableEquity;
					return;
				case IBFaMethod.NetLiq:
					this.order.FaMethod = SmartQuant.FIX.FaMethod.NetLiq;
					return;
				case IBFaMethod.EqualQuantity:
					this.order.FaMethod = SmartQuant.FIX.FaMethod.EqualQuantity;
					return;
				case IBFaMethod.Undefined:
					return;
				default:
					throw new ArgumentException(string.Format("Unknown method - {0}", value));
				}
			}
		}
		public double FaPercentage
		{
			get
			{
				return this.order.FaPercentage;
			}
			set
			{
				this.order.FaPercentage = value;
			}
		}
		public string FaProfile
		{
			get
			{
				return this.order.FaProfile;
			}
			set
			{
				this.order.FaProfile = value;
			}
		}
		internal IBEx(SingleOrder order)
		{
			this.order = order;
		}
	}
}

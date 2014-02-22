using System;
using System.ComponentModel;
namespace OpenQuant.API.Plugins
{
	internal class SQProviderPropertyDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor parent;
		public override Type ComponentType
		{
			get
			{
				return this.parent.ComponentType;
			}
		}
		public override bool IsReadOnly
		{
			get
			{
				return this.parent.IsReadOnly;
			}
		}
		public override Type PropertyType
		{
			get
			{
				return this.parent.PropertyType;
			}
		}
		public SQProviderPropertyDescriptor(PropertyDescriptor parent) : base(parent)
		{
			this.parent = parent;
		}
		public override bool CanResetValue(object component)
		{
			SQProvider sQProvider = component as SQProvider;
			return this.parent.CanResetValue(sQProvider.UserProvider);
		}
		public override object GetValue(object component)
		{
			SQProvider sQProvider = component as SQProvider;
			return this.parent.GetValue(sQProvider.UserProvider);
		}
		public override void ResetValue(object component)
		{
			SQProvider sQProvider = component as SQProvider;
			this.parent.ResetValue(sQProvider.UserProvider);
		}
		public override void SetValue(object component, object value)
		{
			SQProvider sQProvider = component as SQProvider;
			this.parent.SetValue(sQProvider.UserProvider, value);
		}
		public override bool ShouldSerializeValue(object component)
		{
			SQProvider sQProvider = component as SQProvider;
			return this.parent.ShouldSerializeValue(sQProvider.UserProvider);
		}
	}
}

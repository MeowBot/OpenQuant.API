using System;
using System.ComponentModel;
namespace OpenQuant.API.Plugins
{
	internal class SQProviderTypeDescriptor : CustomTypeDescriptor
	{
		private SQProvider provider;
		public SQProviderTypeDescriptor(SQProvider provider)
		{
			this.provider = provider;
		}
		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			foreach (PropertyDescriptor parent in TypeDescriptor.GetProperties(this.provider.UserProvider, attributes, false))
			{
				propertyDescriptorCollection.Add(new SQProviderPropertyDescriptor(parent));
			}
			return propertyDescriptorCollection;
		}
	}
}

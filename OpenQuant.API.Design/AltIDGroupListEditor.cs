using SmartQuant.FIX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
namespace OpenQuant.API.Design
{
	internal class AltIDGroupListEditor : ArrayEditor
	{
		private Instrument instrument;
		public AltIDGroupListEditor() : base(typeof(ArrayList))
		{
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context != null && context.Instance is Instrument)
			{
				this.instrument = (Instrument)context.Instance;
			}
			return base.EditValue(context, provider, value);
		}
		protected override object CreateInstance(Type itemType)
		{
			if (itemType == typeof(AltIDGroup))
			{
				AltIDGroup[] result = null;
				AltSourceForm altSourceForm = new AltSourceForm();
				if (altSourceForm.ShowDialog() == DialogResult.OK)
				{
					AltIDGroup altIDGroup = this.instrument.AltIDGroups.Add(altSourceForm.AltSource);
					result = new AltIDGroup[]
					{
						altIDGroup
					};
				}
				return result;
			}
			return base.CreateInstance(itemType);
		}
		protected override IList GetObjectsFromInstance(object instance)
		{
			if (instance is ICollection)
			{
				return new ArrayList((ICollection)instance);
			}
			return null;
		}
		protected override object[] GetItems(object editValue)
		{
			List<object> list = new List<object>();
			foreach (FIXSecurityAltIDGroup group in this.instrument.instrument.SecurityAltIDGroup)
			{
				list.Add(new AltIDGroup(this.instrument, group));
			}
			return list.ToArray();
		}
		protected override object SetItems(object editValue, object[] value)
		{
			AltIDGroupList altIDGroupList = editValue as AltIDGroupList;
			altIDGroupList.instrument.instrument.SecurityAltIDGroup.Clear();
			for (int i = 0; i < value.Length; i++)
			{
				AltIDGroup altIDGroup = (AltIDGroup)value[i];
				altIDGroupList.instrument.instrument.SecurityAltIDGroup.Add(altIDGroup.group);
			}
			return altIDGroupList;
		}
		protected override Type CreateCollectionItemType()
		{
			return typeof(AltIDGroup);
		}
	}
}

using SmartQuant.Providers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace OpenQuant.API.Design
{
	internal class AltSourceForm : Form
	{
		private IContainer components;
		private ComboBox cbxAltSources;
		private Button btnCancel;
		private Button btnOK;
		public string AltSource
		{
			get
			{
				return this.cbxAltSources.Text.Trim();
			}
		}
		public AltSourceForm()
		{
			this.InitializeComponent();
			this.cbxAltSources.BeginUpdate();
			this.cbxAltSources.Items.Clear();
			foreach (IProvider provider in SmartQuant.Providers.ProviderManager.Providers)
			{
				this.cbxAltSources.Items.Add(provider.Name);
			}
			this.cbxAltSources.EndUpdate();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.cbxAltSources = new ComboBox();
			this.btnCancel = new Button();
			this.btnOK = new Button();
			base.SuspendLayout();
			this.cbxAltSources.FormattingEnabled = true;
			this.cbxAltSources.Location = new Point(12, 28);
			this.cbxAltSources.Name = "cbxAltSources";
			this.cbxAltSources.Size = new Size(149, 21);
			this.cbxAltSources.Sorted = true;
			this.cbxAltSources.TabIndex = 0;
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.Location = new Point(93, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(50, 22);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.Location = new Point(37, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new Size(50, 22);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new Size(175, 98);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.cbxAltSources);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AltSourceForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Select AltSource";
			base.ResumeLayout(false);
		}
	}
}

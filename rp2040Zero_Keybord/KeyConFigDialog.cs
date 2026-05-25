using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace rp2040Zero_Keybord
{
	public partial class KeyConFigDialog : Form
	{

		public KeyConFigDialog()
		{
			InitializeComponent();

			cbModeChange.CheckedChanged += (s, e) =>
			{
				bool modeChange = cbModeChange.Checked;
				SetModeChange(modeChange);
			};
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public string Caption
		{
			get { return lbCaption.Text; }
			set { lbCaption.Text = value; }
		}
		public void Clear()
		{
			cbControl.Checked = false;
			cbShift.Checked = false;
			cbAlt.Checked = false;
			keyDropDownList1.SelectedIndex = 0;
			cbMouseL.Checked = false;
			cbMouseR.Checked = false;
			cbMouseM.Checked = false;
			cbModeChange.Checked = false;
		}
		public void SetModeChange(bool modeChange)
		{
			cbModeChange.Checked = modeChange;

			gbK.Enabled = !modeChange;
			gbK.Enabled = !modeChange;
			gbMode.Enabled = !modeChange;
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public KeyConfig KeyConfig
		{
			get
			{

				if (cbModeChange.Checked == true)
				{
					return new KeyConfig(0, HidKey.MODE_CHANGE, 0);
				}
				return new KeyConfig(
					(byte)((cbControl.Checked ? 1 : 0) | (cbShift.Checked ? 2 : 0) | (cbAlt.Checked ? 4 : 0)),
					(byte)keyDropDownList1.SelectedKeyCode,
					(cbMouseL.Checked ? ClickType.MOUSE_L : ClickType.NONE) |
					(cbMouseR.Checked ? ClickType.MOUSE_R : ClickType.NONE) |
					(cbMouseM.Checked ? ClickType.MOUSE_M : ClickType.NONE)
				);
			}
			set
			{
				Clear();
				if (value.keycode == HidKey.MODE_CHANGE)
				{
					cbModeChange.Checked = true;
					return;
				}
				else
				{
					cbControl.Checked = (value.modifier & 1) != 0;
					cbShift.Checked = (value.modifier & 2) != 0;
					cbAlt.Checked = (value.modifier & 4) != 0;
					keyDropDownList1.SelectedKeyCode = value.keycode;
					cbMouseL.Checked = (value.mouse & ClickType.MOUSE_L) != 0;
					cbMouseR.Checked = (value.mouse & ClickType.MOUSE_R) != 0;
					cbMouseM.Checked = (value.mouse & ClickType.MOUSE_M) != 0;
				}
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			using (Pen pen = new Pen(Color.DarkGray))
			{
				e.Graphics.DrawRectangle(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
			}
		}
		static public bool ShowEditDialog(ref KeyConfig config,int mx,int my)
		{
			using (KeyConFigDialog dialog = new KeyConFigDialog())
			{
				dialog.StartPosition = FormStartPosition.Manual;
				dialog.Location = new Point(mx-75, my-75);

				dialog.KeyConfig = config;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					config = dialog.KeyConfig;
					return true;
				}
			}
			return false;
		}
	}
}

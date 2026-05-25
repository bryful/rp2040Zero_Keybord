using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace rp2040Zero_Keybord
{
	public class KeyConfigSW : Control
	{
		private KeyConfig m_KeyConfig = new KeyConfig();
		private CheckBox[] modifierCheckBoxes = new CheckBox[4];
		private KeyDropDownList keyDropDownList = new KeyDropDownList();
		private MouseDropDownList mouseDropDownList = new MouseDropDownList();

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyConfig KeyConfig
		{
			get
			{
				UpdateKeyConfig();
				return m_KeyConfig;
			}
			set
			{
				m_KeyConfig = value;
				for (int i = 0; i < modifierCheckBoxes.Length; i++)
				{
					modifierCheckBoxes[i].Checked = (m_KeyConfig.modifier & (1 << i)) != 0;
				}
				keyDropDownList.SelectedKeyCode = m_KeyConfig.keycode;
				mouseDropDownList.SelectedMouse = (byte)m_KeyConfig.mouse;
			}
		}

		public KeyConfigSW()
		{
			this.Size = new Size(204, 78);
			string[] modifierNames = new string[] { "Ctrl", "Shift", "Alt", "GUI" };
			int[] modifierSize = new int[] { 48, 50, 45, 45 };

			int x = 0;
			for (int i = 0; i < modifierCheckBoxes.Length; i++)
			{
				modifierCheckBoxes[i] = new CheckBox();
				modifierCheckBoxes[i].Text = modifierNames[i];
				modifierCheckBoxes[i].Size = new Size(modifierSize[i], 20);
				modifierCheckBoxes[i].Location = new Point(10 + x, 2);
				this.Controls.Add(modifierCheckBoxes[i]);
				x += modifierSize[i];
			}

			Label kl = new Label();
			kl.Text = "Key:";
			kl.Location = new Point(30, 24);
			kl.Size = new Size(45, 20);
			this.Controls.Add(kl);

			keyDropDownList.Location = new Point(80, 24);
			keyDropDownList.Size = new Size(120, 23);
			this.Controls.Add(keyDropDownList);

			Label ml = new Label();
			ml.Text = "Mouse:";
			ml.Location = new Point(30, 48);
			ml.Size = new Size(45, 20);
			this.Controls.Add(ml);

			mouseDropDownList.Location = new Point(80, 48);
			mouseDropDownList.Size = new Size(120, 23);
			this.Controls.Add(mouseDropDownList);

			this.Size = new Size(250, 75);
		}

		private void UpdateKeyConfig()
		{
			m_KeyConfig.modifier = 0;
			if (modifierCheckBoxes[0].Checked) m_KeyConfig.modifier |= 0x01; // Ctrl
			if (modifierCheckBoxes[1].Checked) m_KeyConfig.modifier |= 0x02; // Shift
			if (modifierCheckBoxes[2].Checked) m_KeyConfig.modifier |= 0x04; // Alt
			if (modifierCheckBoxes[3].Checked) m_KeyConfig.modifier |= 0x08; // GUI
			m_KeyConfig.keycode = keyDropDownList.SelectedKey.Code;
			m_KeyConfig.mouse = (ClickType)mouseDropDownList.SelectedMouse;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// 必要に応じてカスタム描画を行う

			using (Pen pen = new Pen(Color.Gray))
			{
				e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
			}
		}
	}
}
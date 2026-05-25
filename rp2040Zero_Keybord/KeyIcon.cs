using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public  class KeyIcon :Control
	{
		private KeyConfig m_keyConfig = new KeyConfig();
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyConfig KeyConfig
		{
			get { return m_keyConfig; }
			set
			{
				m_keyConfig = value;
				this.Invalidate(); // 再描画
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public Byte Modifier
		{
			get { return m_keyConfig.modifier; }
			set
			{
				m_keyConfig.modifier = value;
				this.Invalidate(); // 再描画
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public byte Mouse
		{
			get { return (byte)m_keyConfig.mouse; }
			set
			{
				m_keyConfig.mouse = (ClickType)value;
				this.Invalidate(); // 再描画
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public byte KeyCode {
			get
			{
				return m_keyConfig.keycode;
			} 
			set
			{
				m_keyConfig.keycode = value;
				this.Invalidate(); // 再描画
			}
		}
		
		public KeyIcon()
		{
			this.Size = new Size(64, 64);
			this.BackColor = SystemColors.Control;
			this.DoubleBuffered = true;
		}
		public void Clear()
		{
			m_keyConfig = new KeyConfig();
			this.Invalidate(); // 再描画
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			using (SolidBrush brush = new SolidBrush(this.BackColor))
			using (Pen  pen = new Pen(this.ForeColor))
			{
				g.FillRectangle(brush, this.ClientRectangle);
				g.DrawRectangle(pen, 0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
			}
			using (Font font = new Font("Arial", 7))
			{
				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;
				if (m_keyConfig.keycode == 0 && m_keyConfig.modifier == 0 && m_keyConfig.mouse==0)
				{
					e.Graphics.DrawString("None", font, Brushes.Black, this.ClientRectangle, format);
				}
				else
				{
					string displayText = "";
					if (m_keyConfig.modifier != 0)
					{
						string ss = "";
						if ((m_keyConfig.modifier & 0x01) != 0) ss += "Ctrl+";
						if ((m_keyConfig.modifier & 0x02) != 0) ss += "Shift+";
						if ((m_keyConfig.modifier & 0x04) != 0) ss += "Alt+";
						if ((m_keyConfig.modifier & 0x08) != 0) ss += "Gui+";
						displayText = ss;
					}
					if (m_keyConfig.keycode != 0)
					{
						KeyInfo? keyInfo = KeyDatabase.GetByCode(m_keyConfig.keycode);
						if (keyInfo != null)
						{
							displayText = displayText + keyInfo.DisplayName;
						}
					}
					if (m_keyConfig.mouse != 0)
					{
						string ss = "";
						if (((byte)m_keyConfig.mouse & 0x01) != 0) ss = "Mouse Left";
						else if (((byte)m_keyConfig.mouse & 0x02) != 0) ss = "Mouse Right";
						else if (((byte)m_keyConfig.mouse & 0x04) != 0) ss = "Mouse Middle";
						if (ss != "")
						displayText = displayText+ "\r\n" + ss;

					}
					e.Graphics.DrawString(displayText, font, Brushes.Black, this.ClientRectangle, format);
				}
			}
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			Point screenPos = this.PointToScreen(e.Location);
			if (KeyConFigDialog.ShowEditDialog(ref m_keyConfig, screenPos.X, screenPos.Y))
			{
				this.Invalidate(); // 再描画
			}
		}
	}
}

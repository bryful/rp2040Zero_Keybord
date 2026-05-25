using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public  class LayerSW :GroupBox
	{
		private KeyConfigs? _keyConfigs = null;

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public KeyConfigs? KeyConfigs
		{
			get { return _keyConfigs; }
			set
			{
				_keyConfigs = value;
				if (_keyConfigs != null)
				{
					m_layer = _keyConfigs.SelectedIndex;
					for (int i = 0; i < m_LayerCount; i++)
					{
						rb[i].Checked = (i == m_layer);
					}
				}
			}
		}

		private int m_layer = 0;
		private int m_LayerCount = 3;
		RadioButton [] rb = new RadioButton[4];
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public int LayerCount
		{
			get { return m_LayerCount; }
			set
			{
				if (value < 1) value = 1;
				if (m_layer != value)
				{
					m_LayerCount = value;
					CreateRB(m_LayerCount);
				}
			}
		}

		public void CreateRB(int v)
		{
			// 既存のRadioButtonを削除
			if (rb.Length>0)
			{
				for (int i = rb.Length-1; i >=0 ; i--)
				{
					if (rb[i] != null)
					{
						this.Controls.Remove(rb[i]);
						rb[i].Dispose();
					}
				}
			}
			// 新しいRadioButtonを作成
			rb = new RadioButton[v];
			// ここで新しいRadioButtonを作成して配置
			for (int i = 0; i < rb.Length; i++)
			{
				rb[i] = new RadioButton();
				if (i == m_layer)
				{
					rb[i].Checked = true;
				}
				rb[i].Text = $"{i}";
				rb[i].Location = new Point(60 + i * 40, 12);
				rb[i].Size = new Size(35, 20);
				rb[i].Tag = i;
				rb[i].Click += (s, e) =>
				{
					RadioButton? r = (RadioButton?)s;
					if (r != null && r.Tag != null)
					{
						if (m_layer != (int)r.Tag)
						{
							m_layer = (int)r.Tag;
							if (KeyConfigs != null)
							{
								KeyConfigs.SelectedIndex = m_layer;
							}
						}
					}
				};
				this.Controls.Add(rb[i]);
			}
		}

		public LayerSW()
		{
			this.Name = "LayerSW";
			this.Text = "LayerSW";
			this.Size = new Size(300, 40);
			this.BackColor = SystemColors.Control;
			this.ForeColor = SystemColors.ControlText;
			CreateRB(m_LayerCount);
		}
	}
}

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
					m_layer = _keyConfigs.NumMode;
					for (int i = 0; i < 4; i++)
					{
						rb[i].Checked = (i == m_layer);
					}
				}
			}
		}

		private int m_layer = 0;
		RadioButton [] rb = new RadioButton[4];

		public LayerSW()
		{
			this.Text = "Layer";
			this.Size = new Size(300, 40);

			for (int i = 0; i < 4; i++)
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
								KeyConfigs.NumMode = m_layer;
							}
						}
					}
				};

				this.Controls.Add(rb[i]);
			}
		}
	}
}

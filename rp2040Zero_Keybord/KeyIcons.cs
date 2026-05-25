using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{


	public class KeyIcons : Control
	{
		private KeyConfigSW? m_keyConfigSW = null;

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyConfigSW? KeyConfigSW
		{
			get { return m_keyConfigSW; }
			set
			{
				m_keyConfigSW = value;
				if (m_keyConfigSW != null)
				{
					if (m_iconIndex >= 0)
					{
						int row = m_iconIndex / 5;
						int col = m_iconIndex % 5;
						if (row < buttons.Count && col < buttons[row].Count)
						{
							m_keyConfigSW.KeyConfig = buttons[row][col].KeyConfig;
						}
					}
				}
			}
		}


		private int iconSize = 64;
		private int m_iconIndex = 0;
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public int IconIndex
		{
			get { return m_iconIndex; }
			set
			{
				m_iconIndex = value;
				if (m_iconIndex < 0) m_iconIndex = -1;
				SetButtonsBackColor(SystemColors.Control);
				if (m_iconIndex >= 0 && m_iconIndex < 20) // 20個のアイコンがあると仮定
				{
					int row = m_iconIndex / 5;
					int col = m_iconIndex % 5;
					if (row < buttons.Count && col < buttons[row].Count)
					{
						buttons[row][col].BackColor = Color.LightBlue;
					}
				}
			}
		}
		private List<List<KeyIcon>> buttons = new List<List<KeyIcon>>();

		private void SetButtonsBackColor(Color color)
		{
			foreach (var row in buttons)
			{
				foreach (var btn in row)
				{
					btn.BackColor = color;
				}
			}
		}

		public KeyConfig[] GetAllKeyConfigs()
		{
			List<KeyConfig> configs = new List<KeyConfig>();
			foreach (var row in buttons)
			{
				foreach (var btn in row)
				{
					configs.Add(btn.KeyConfig);
				}
			}
			return configs.ToArray();
		}
		public void SetAllKeyConfigs(KeyConfig[] configs)
		{
			int idx = 0;
			for (int row = 0; row < buttons.Count; row++)
			{
				for (int col = 0; col < buttons[row].Count; col++)
				{
					if (idx < configs.Length)
					{
						buttons[row][col].KeyConfig = configs[idx++];
					}
					else
					{
						buttons[row][col].KeyConfig = new KeyConfig(); // 残りはNoneにリセット
					}
				}
			}
			SetButtonsBackColor(SystemColors.Control);
			m_iconIndex = -1;
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public KeyConfig[] KeyConfigs
		{
			get
			{
				return GetAllKeyConfigs();
			}
			set
			{
				SetAllKeyConfigs(value);
			}
		}
		private void InitializeButtons()
		{
			int idx = 0;
			for (int row = 0; row < 4; row++)
			{
				List<KeyIcon> buttonRow = new List<KeyIcon>();
				for (int col = 0; col < 5; col++)
				{
					KeyIcon btn = new KeyIcon();
					btn.BackColor = SystemColors.Control;
					btn.Size = new Size(iconSize, iconSize);
					btn.Location = new Point(col * (iconSize + 10), row * (iconSize + 10));
					btn.Text = $"Btn {row},{col}";
					btn.Tag = idx++; // アイコンのインデックスをタグに保存
					btn.Click += (s, e) =>
					{
						SetButtonsBackColor(SystemColors.Control);
						KeyIcon? b = (KeyIcon?)s;
						if (b != null)
						{
							b.BackColor = Color.LightBlue;
							if (b.Tag != null)
							{
								m_iconIndex = (int)b.Tag;
							}
							if (m_keyConfigSW != null)
							{
								m_keyConfigSW.KeyConfig = b.KeyConfig;
							}
						}
					};
					buttonRow.Add(btn);
					this.Controls.Add(btn);
				}
				buttons.Add(buttonRow);
			}
		}
		public KeyIcons()
		{
			this.DoubleBuffered = true;
			this.Size = new Size(iconSize * 5 + 40, iconSize * 4 + 30);
			InitializeButtons();
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]

		public KeyConfig? KeyConfig
		{
			get
			{
				if (m_iconIndex >= 0 && m_iconIndex < 20) // 20個のアイコンがあると仮定
				{
					int row = m_iconIndex / 5;
					int col = m_iconIndex % 5;
					if (row < buttons.Count && col < buttons[row].Count)
					{
						return buttons[row][col].KeyConfig;
					}
				}
				return m_keyConfigSW?.KeyConfig;
			}
			set
			{
				if (value != null)
				{
					if (m_iconIndex >= 0 && m_iconIndex < 20) // 20個のアイコンがあると仮定
					{
						int row = m_iconIndex / 5;
						int col = m_iconIndex % 5;
						if (row < buttons.Count && col < buttons[row].Count)
						{
							buttons[row][col].KeyConfig = (KeyConfig)value;
						}
					}
				}
			}
		}
		public void SetKeyConfig(int index, KeyConfig config)
		{
			if (index >= 0 && index < 20) // 20個のアイコンがあると仮定
			{
				int row = index / 5;
				int col = index % 5;
				if (row < buttons.Count && col < buttons[row].Count)
				{
					buttons[row][col].KeyConfig = config;
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 19.");
			}

		}
		public void Clear()
		{
			foreach (var row in buttons)
			{
				foreach (var btn in row)
				{
					btn.KeyConfig = new KeyConfig(); // すべてのアイコンをNoneにリセット
				}
			}
			SetButtonsBackColor(SystemColors.Control);
			m_iconIndex = -1;
		}
		public void Apply()
		{
			if (m_iconIndex < 0) return;
			if (m_keyConfigSW != null)
			{
				int row = m_iconIndex / 5;
				int col = m_iconIndex % 5;
				if (row < buttons.Count && col < buttons[row].Count)
				{
					buttons[row][col].KeyConfig = m_keyConfigSW.KeyConfig;
				}
			}
		}
	}
}

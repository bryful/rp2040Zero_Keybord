using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class MouseDropDownList : System.Windows.Forms.ComboBox
	{
		private byte[] AllKeys = new byte[] { 0, 1, 2, 4 }; // None, LeftClick, RightClick, MiddleClick
		private string[] KeyNames = new string[] { "None", "LeftClick", "RightClick", "MiddleClick" };
		private bool _initialized = false;
		private byte _pendingKeyCode = 0; // ⚠️ 初期化前の値を保持

		private int GetMouseIndex(byte mouseCode)
		{
			for (int i = 0; i < AllKeys.Length; i++)
			{
				if (AllKeys[i] == mouseCode)
				{
					return i;
				}
			}
			return 0; // None
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			InitializeItems();

		}
		private void InitializeItems()
		{
			if (!_initialized)
			{
				this.Items.Clear();
				foreach (string name in KeyNames)
				{
					this.Items.Add(name);
				}
				this.SelectedIndex = 0;
				_initialized = true;
			}
		}
		public MouseDropDownList()
		{
			this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			InitializeItems();
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public Byte SelectedMouse
		{
			get
			{
				if (this.SelectedIndex >= 0 && this.SelectedIndex < AllKeys.Length)
				{
					return AllKeys[this.SelectedIndex];
				}
				return AllKeys[0];
			}
			set
			{
				if (this.Items.Count > 0)
				{
					// KeyCodeで検索
					int index = GetMouseIndex(value);
					if (index >= 0)
					{
						this.SelectedIndex = index;
					}
					else
					{
						// 見つからない場合は最初の項目を選択
						this.SelectedIndex = 0;
					}
				}
			}
		}
	}
}

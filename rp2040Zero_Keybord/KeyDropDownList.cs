using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class KeyDropDownList : System.Windows.Forms.ComboBox
	{
		private List<KeyInfo> AllKeys;
		private bool _initialized = false;
		private byte _pendingKeyCode = 0; // ⚠️ 初期化前の値を保持
		public KeyDropDownList()
		{
			AllKeys = KeyDatabase.AllKeys;
			this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			InitializeItems();
		}
		private void InitializeItems()
		{
			if (!_initialized)
			{
				this.Items.Clear();
				foreach (KeyInfo key in AllKeys)
				{
					this.Items.Add(key.DisplayName);
				}
				this.SelectedIndex = 0;
				_initialized = true;
			}
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			InitializeItems();
			// 保留中の値があれば設定
			if (_pendingKeyCode != 0)
			{
				SelectedKeyCode = _pendingKeyCode;
				_pendingKeyCode = 0;
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyInfo SelectedKey
		{
			get
			{
				if (!_initialized)
				{
					return AllKeys.FirstOrDefault(k => k.Code == _pendingKeyCode) ?? AllKeys[0];
				}

				if (this.SelectedIndex >= 0 && this.SelectedIndex < AllKeys.Count)
				{
					return AllKeys[this.SelectedIndex];
				}
				return AllKeys[0];
			}
			set
			{
				if (value == null)
				{
					if (_initialized)
						this.SelectedIndex = 0;
					else
						_pendingKeyCode = 0;
					return;
				}

				if (!_initialized)
				{
					_pendingKeyCode = value.Code;
					return;
				}

				int index = AllKeys.FindIndex(k => k.Code == value.Code);
				if (index >= 0)
				{
					this.SelectedIndex = index;
				}
				else
				{
					this.SelectedIndex = 0;
				}
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public Byte SelectedKeyCode
		{
			get
			{
				if (!_initialized)
				{
					return _pendingKeyCode;
				}
				if (this.SelectedIndex >= 0 && this.SelectedIndex < AllKeys.Count)
				{
					return AllKeys[this.SelectedIndex].Code;
				}
				return AllKeys[0].Code;
			}
			set
			{
				if (!_initialized)
				{
					_pendingKeyCode = value;
					return;
				}

				int index = AllKeys.FindIndex(k => k.Code == value);
				if (index >= 0)
				{
					this.SelectedIndex = index;
				}
				else
				{
					this.SelectedIndex = 0;
				}
			}
		}
	}
}

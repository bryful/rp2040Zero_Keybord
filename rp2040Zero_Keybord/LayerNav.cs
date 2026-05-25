using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class LayerNav : GroupBox
	{
		//private int m_layer = 0;
		private int m_LayerCount = 3;
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
					//m_layer = _keyConfigs.SelectedIndex;
					lstLayers.Items.Clear();
					lstLayers.Items.AddRange(_keyConfigs.LayerNames);
					m_LayerCount = _keyConfigs.LayerCount;
					lstLayers.SelectedIndex = _keyConfigs.SelectedIndex;
				}
			}
		}
		private Button btnAdd = new Button();
		private Button btnUp = new Button();
		private Button btnDown = new Button();
		private Button btnRemove = new Button();
		private Button btnApply = new Button();

		private TextBox txtLayerName = new TextBox();
		private NumericUpDown [] ledValues = new NumericUpDown[3];
		private ListBox lstLayers = new ListBox();

		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public string LayerName
		{
			get { return txtLayerName.Text; }
			set { txtLayerName.Text = value; }
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public byte LedRed
		{
			get { return (byte)ledValues[0].Value; }
			set { ledValues[0].Value = value; }
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public byte LedGreen
		{
			get { return (byte)ledValues[1].Value; }
			set { ledValues[1].Value = value; }
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public byte LedBlue
		{
			get { return (byte)ledValues[2].Value; }
			set { ledValues[2].Value = value; }
		}


		private void CreateUI()
		{
			btnAdd.Text = "Add";
			this.Controls.Add(btnAdd);
			btnUp.Text = "Up";
			this.Controls.Add(btnUp);
			btnDown.Text = "Down";
			this.Controls.Add(btnDown);
			btnRemove.Text = "Del";
			this.Controls.Add(btnRemove);

			btnApply.Text = "Apply";
			this.Controls.Add(btnApply);

			txtLayerName.MaxLength = 16;
			this.Controls.Add(txtLayerName);

			for (int i = 0; i < ledValues.Length; i++)
			{
				ledValues[i] = new NumericUpDown();
				ledValues[i].Minimum = 0;
				ledValues[i].Maximum = 255;
				this.Controls.Add(ledValues[i]);
			}
			this.Controls.Add(lstLayers);

			lstLayers.SelectedIndexChanged += (s, e) =>
			{
				if (lstLayers.SelectedIndex >= 0 && _keyConfigs != null)
				{
					_keyConfigs.SetSelectedIndex(lstLayers.SelectedIndex);

					txtLayerName.Text = _keyConfigs.LayerNames[lstLayers.SelectedIndex];
					LedRed = _keyConfigs.ledRed;
					LedGreen = _keyConfigs.ledGreen;
					LedBlue = _keyConfigs.ledBlue;
				}
			};
			btnUp.Click += (s, e) =>
			{
				if (lstLayers.SelectedIndex > 0)
				{
					if (_keyConfigs != null)
					{
						if (_keyConfigs.ItemUp())
						{
							this.ItemUp();
						}
					}
				}
			};
			btnDown.Click += (s, e) =>
			{
				if (lstLayers.SelectedIndex < lstLayers.Items.Count - 1)
				{
					if (_keyConfigs != null)
					{
						if (_keyConfigs.ItemDown())
						{
							this.ItemDown();
						}
					}
				}
			};
			btnRemove.Click += (s, e) =>
			{
				if (lstLayers.SelectedIndex >= 0)
				{
					if (_keyConfigs != null)
					{
						_keyConfigs.Delete();
						lstLayers.Items.Clear();
						lstLayers.Items.AddRange(_keyConfigs.LayerNames);
						lstLayers.SelectedIndex = _keyConfigs.SelectedIndex;
					}
				}
			};
			btnAdd.Click += (s, e) =>
			{
				if (_keyConfigs != null)
				{
					_keyConfigs.Insert();
					lstLayers.Items.Clear();
					lstLayers.Items.AddRange(_keyConfigs.LayerNames);
					lstLayers.SelectedIndex = _keyConfigs.SelectedIndex;
				}
			};
			btnApply.Click += (s, e) =>
			{
				if (lstLayers.SelectedIndex >= 0 && _keyConfigs != null)
				{
					_keyConfigs.LayerName = txtLayerName.Text;
					_keyConfigs.ledRed = LedRed;
					_keyConfigs.ledGreen = LedGreen;
					_keyConfigs.ledBlue = LedBlue;
					lstLayers.Items[lstLayers.SelectedIndex] = txtLayerName.Text;
				}
			};
		}
		
		public LayerNav()
		{
			this.Text = "Layers";
			this.Size = new Size(180, 340);
			CreateUI();
			ChkSize();
		}
		public void ItemUp()
		{
			if (lstLayers.SelectedIndex > 0)
			{
				string temp = lstLayers.Items[lstLayers.SelectedIndex - 1].ToString() ?? "";
				lstLayers.Items[lstLayers.SelectedIndex - 1] = lstLayers.Items[lstLayers.SelectedIndex];
				lstLayers.Items[lstLayers.SelectedIndex] = temp;
				lstLayers.SelectedIndex -= 1;
			}
		}
		public void ItemDown()
		{
			if (lstLayers.SelectedIndex < lstLayers.Items.Count - 1)
			{
				string temp = lstLayers.Items[lstLayers.SelectedIndex + 1].ToString() ?? "";
				lstLayers.Items[lstLayers.SelectedIndex + 1] = lstLayers.Items[lstLayers.SelectedIndex];
				lstLayers.Items[lstLayers.SelectedIndex] = temp;
				lstLayers.SelectedIndex += 1;
			}
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public int SelectedIndex
		{
			get 
			{ return lstLayers.SelectedIndex; }
			set {
				lstLayers.SelectedIndex = value; 
			}
		}
		private void ChkSize()
		{
			int y = 20;
			btnAdd.Location = new Point(10, y);
			btnAdd.Size = new Size(this.Width - 20, 23);
			y += 25;
			int ww = (this.Width - 20 - 10 - 10) / 3;
			btnUp.Location = new Point(10, y);
			btnUp.Size = new Size(ww, 23);
			
			btnDown.Location = new Point(10 + ww + 10, y);
			btnDown.Size = new Size(ww, 23);
			
			btnRemove.Location = new Point(10 + ww + 10 + ww + 10, y);
			btnRemove.Size = new Size(ww, 23);
			y += 25;
			
			txtLayerName.Location = new Point(10, y);
			int wwt = (this.Width - 20 - 10 - 50);
			txtLayerName.Size = new Size(wwt, 23);

			btnApply.Location = new Point(10 + wwt + 10, y);
			btnApply.Size = new Size(50, 23);
			y += 25;
			int wwl = ww;
			for (int i = 0; i < ledValues.Length; i++)
			{
				if (ledValues[i] != null)
				{
					ledValues[i].Location = new Point(10 + (wwl + 10) * i, y);
					ledValues[i].Size = new Size(wwl, 23);
				}
			}
			y += 25;
			lstLayers.Location = new Point(10, y);
			lstLayers.Size = new Size(this.Width - 20, this.Height - y - 10);
		
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			ChkSize();
			this.Invalidate();
		}
	}
}

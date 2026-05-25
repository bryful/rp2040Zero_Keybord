using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class RotaryEncoderSW :Control
	{

		private KeyIcon keyIcon_CW = new KeyIcon();
		private KeyIcon keyIcon_CCW = new KeyIcon();
		private KeyIcon keyIcon_SW = new KeyIcon();


		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyConfig[] keyConfigs
		{
			get
			{
				return new KeyConfig[] { keyIcon_CW.KeyConfig, keyIcon_CCW.KeyConfig, keyIcon_SW.KeyConfig };
			}
			set
			{
				if (value != null && value.Length >= 3)
				{
					keyIcon_CW.KeyConfig = value[0];
					keyIcon_CCW.KeyConfig = value[1];
					keyIcon_SW.KeyConfig = value[2];
				}
			}
		}
		public void Clear()
		{
			keyIcon_CW.Clear();
			keyIcon_CCW.Clear();
			keyIcon_SW.Clear();
		}
		public RotaryEncoderSW()
		{
			this.Size = new Size(64*3+20, 84);
			this.BackColor = SystemColors.Control;

			Label lbCW = new Label();
			lbCW.Text = "CW";
			lbCW.Location = new Point(0, 0);
			lbCW.Size = new Size(64, 20);
			this.Controls.Add(lbCW);
			keyIcon_CW.Location = new Point(0, 20);
			keyIcon_CW.Size = new Size(64, 64);
			this.Controls.Add(keyIcon_CW);


			Label lbCCW = new Label();
			lbCCW.Text = "CCW";
			lbCCW.Location = new Point(74, 0);
			lbCCW.Size = new Size(64, 20);
			this.Controls.Add(lbCCW);
			keyIcon_CCW.Location = new Point(74, 20);
			keyIcon_CCW.Size = new Size(64, 64);
			this.Controls.Add(keyIcon_CCW);

			Label lbSW = new Label();
			lbSW.Text = "SW";
			lbSW.Location = new Point(74+60+10, 0);
			lbSW.Size = new Size(64, 20);
			this.Controls.Add(lbSW);		
			
			keyIcon_SW.Location = new Point(74+60+10, 20);
			keyIcon_SW.Size = new Size(64, 64);
			this.Controls.Add(keyIcon_SW);
		}
	}
}

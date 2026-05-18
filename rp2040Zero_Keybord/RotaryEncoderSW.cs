using System;
using System.Collections.Generic;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class RotaryEncoderSW :Control
	{
		private KeyConfigSW keyConfigSW_CW = new KeyConfigSW();
		private KeyConfigSW keyConfigSW_CCW = new KeyConfigSW();
		private KeyConfigSW keyConfigSW_SW = new KeyConfigSW();


		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(true)]
		public KeyConfig[] keyConfigs
		{
			get
			{
				return new KeyConfig[] { keyConfigSW_CW.KeyConfig, keyConfigSW_CCW.KeyConfig, keyConfigSW_SW.KeyConfig };
			}
			set
			{
				if (value != null && value.Length >= 3)
				{
					keyConfigSW_CW.KeyConfig = value[0];
					keyConfigSW_CCW.KeyConfig = value[1];
					keyConfigSW_SW.KeyConfig = value[2];
				}
			}
		}
		public RotaryEncoderSW()
		{
			this.Size = new Size(430, 190);
			this.BackColor = SystemColors.Control;

			Label lbCW = new Label();
			lbCW.Text = "CW";
			lbCW.Location = new Point(0, 0);
			lbCW.Size = new Size(100, 20);
			this.Controls.Add(lbCW);
			keyConfigSW_CW.Location = new Point(0, 20);
			keyConfigSW_CW.Size = new Size(210, 72);
			this.Controls.Add(keyConfigSW_CW);


			Label lbCCW = new Label();
			lbCCW.Text = "CCW";
			lbCCW.Location = new Point(220, 0);
			lbCCW.Size = new Size(100, 20);
			this.Controls.Add(lbCCW);
			keyConfigSW_CCW.Location = new Point(220, 20);
			keyConfigSW_CCW.Size = new Size(210, 72);
			this.Controls.Add(keyConfigSW_CCW);

			Label lbSW = new Label();
			lbSW.Text = "SW";
			lbSW.Location = new Point(0, 94);
			lbSW.Size = new Size(100, 20);
			this.Controls.Add(lbSW);		
			
			keyConfigSW_SW.Location = new Point(0, 114);
			keyConfigSW_SW.Size = new Size(210, 72);
			this.Controls.Add(keyConfigSW_SW);
		}
	}
}

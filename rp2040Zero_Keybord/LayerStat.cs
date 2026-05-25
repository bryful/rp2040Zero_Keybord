using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace rp2040Zero_Keybord
{
	public class LayerStat :GroupBox
	{
		private TextBox tb = new TextBox();
		private NumericUpDown[] led = new NumericUpDown[3];

		public LayerStat()
		{
			int y = 16;
			Label lb = new Label();
			lb.Text = "Name";
			lb.Location = new Point(5, y+5);
			lb.Size = new Size(40, 23);
			this.Controls.Add(lb);

			tb.Location = new Point(45, y);
			tb.Size = new Size(100, 23);
			tb.MaxLength = 16;
			this.Controls.Add(tb);

			Label ledl = new Label();
			ledl.Text = "LED";
			ledl.Location = new Point(150, y + 5);
			ledl.Size = new Size(30, 23);
			this.Controls.Add(ledl);
			Label[] l = new Label[3];
			for (int i = 0; i < led.Length; i++)
			{
				l[i] = new Label();
				if (i == 0)
				{
					l[i].Text = $"R";
				}
				else if (i == 1)
				{
					l[i].Text = $"G";
				}
				else if (i == 2)
				{
					l[i].Text = $"B";
				}
				l[i].Location = new Point(180 + 66*i, y+5);
				l[i].Size = new Size(16, 23);
				this.Controls.Add(l[i]);

				led[i] = new NumericUpDown();
				this.Controls.Add(led[i]);
				led[i].Location = new Point(180 + 66*i+16, y);
				led[i].Size = new Size(50, 23);
				led[i].Minimum = 0;
				led[i].Maximum = 255;
			}
		}
		public void ChkSize()
		{
			int y = 16;
			Label lb = new Label();
			lb.Text = "Name";
			lb.Location = new Point(5, y + 5);
			lb.Size = new Size(40, 23);
			this.Controls.Add(lb);

			tb.Location = new Point(45, y);
			tb.Size = new Size(100, 23);
			tb.MaxLength = 16;
			this.Controls.Add(tb);

			Label ledl = new Label();
			ledl.Text = "LED";
			ledl.Location = new Point(150, y + 5);
			ledl.Size = new Size(30, 23);
			this.Controls.Add(ledl);
			Label[] l = new Label[3];
			for (int i = 0; i < led.Length; i++)
			{
				l[i] = new Label();
				if (i == 0)
				{
					l[i].Text = $"R";
				}
				else if (i == 1)
				{
					l[i].Text = $"G";
				}
				else if (i == 2)
				{
					l[i].Text = $"B";
				}
				l[i].Location = new Point(180 + 66 * i, y + 5);
				l[i].Size = new Size(16, 23);
				this.Controls.Add(l[i]);

				led[i] = new NumericUpDown();
				this.Controls.Add(led[i]);
				led[i].Location = new Point(180 + 66 * i + 16, y);
				led[i].Size = new Size(50, 23);
				led[i].Minimum = 0;
				led[i].Maximum = 255;
			}
			this.Invalidate();
		}
	}
}

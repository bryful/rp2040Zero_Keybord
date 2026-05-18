namespace rp2040Zero_Keybord
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			saveToolStripMenuItem = new ToolStripMenuItem();
			toClipboardToolStripMenuItem = new ToolStripMenuItem();
			quitToolStripMenuItem = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyFromindex0ToolStripMenuItem = new ToolStripMenuItem();
			copyFromindex1ToolStripMenuItem = new ToolStripMenuItem();
			copyFromindex2ToolStripMenuItem = new ToolStripMenuItem();
			copyFromindex3ToolStripMenuItem = new ToolStripMenuItem();
			layersw1 = new LayerSW();
			groupBoxKeys = new GroupBox();
			keyIcons1 = new KeyIcons();
			keyConfigsw1 = new KeyConfigSW();
			btnSet = new Button();
			btnClear = new Button();
			groupBox1 = new GroupBox();
			rotaryEncoder1 = new RotaryEncoderSW();
			groupBox2 = new GroupBox();
			rotaryEncoder2 = new RotaryEncoderSW();
			menuStrip1.SuspendLayout();
			groupBoxKeys.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(879, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, toClipboardToolStripMenuItem, quitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new Size(137, 22);
			openToolStripMenuItem.Text = "Open";
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new Size(137, 22);
			saveToolStripMenuItem.Text = "Save";
			// 
			// toClipboardToolStripMenuItem
			// 
			toClipboardToolStripMenuItem.Name = "toClipboardToolStripMenuItem";
			toClipboardToolStripMenuItem.Size = new Size(137, 22);
			toClipboardToolStripMenuItem.Text = "ToClipboard";
			toClipboardToolStripMenuItem.Click += toClipboardToolStripMenuItem_Click;
			// 
			// quitToolStripMenuItem
			// 
			quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			quitToolStripMenuItem.Size = new Size(137, 22);
			quitToolStripMenuItem.Text = "Quit";
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyFromindex0ToolStripMenuItem, copyFromindex1ToolStripMenuItem, copyFromindex2ToolStripMenuItem, copyFromindex3ToolStripMenuItem });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// copyFromindex0ToolStripMenuItem
			// 
			copyFromindex0ToolStripMenuItem.Name = "copyFromindex0ToolStripMenuItem";
			copyFromindex0ToolStripMenuItem.Size = new Size(162, 22);
			copyFromindex0ToolStripMenuItem.Text = "CopyFromindex0";
			// 
			// copyFromindex1ToolStripMenuItem
			// 
			copyFromindex1ToolStripMenuItem.Name = "copyFromindex1ToolStripMenuItem";
			copyFromindex1ToolStripMenuItem.Size = new Size(162, 22);
			copyFromindex1ToolStripMenuItem.Text = "CopyFromindex1";
			// 
			// copyFromindex2ToolStripMenuItem
			// 
			copyFromindex2ToolStripMenuItem.Name = "copyFromindex2ToolStripMenuItem";
			copyFromindex2ToolStripMenuItem.Size = new Size(162, 22);
			copyFromindex2ToolStripMenuItem.Text = "CopyFromindex2";
			// 
			// copyFromindex3ToolStripMenuItem
			// 
			copyFromindex3ToolStripMenuItem.Name = "copyFromindex3ToolStripMenuItem";
			copyFromindex3ToolStripMenuItem.Size = new Size(162, 22);
			copyFromindex3ToolStripMenuItem.Text = "CopyFromindex3";
			// 
			// layersw1
			// 
			layersw1.Location = new Point(12, 29);
			layersw1.Name = "layersw1";
			layersw1.Size = new Size(300, 40);
			layersw1.TabIndex = 3;
			layersw1.TabStop = false;
			layersw1.Text = "Layer";
			// 
			// groupBoxKeys
			// 
			groupBoxKeys.Controls.Add(keyConfigsw1);
			groupBoxKeys.Controls.Add(btnSet);
			groupBoxKeys.Controls.Add(btnClear);
			groupBoxKeys.Controls.Add(keyIcons1);
			groupBoxKeys.Location = new Point(12, 75);
			groupBoxKeys.Name = "groupBoxKeys";
			groupBoxKeys.Size = new Size(393, 433);
			groupBoxKeys.TabIndex = 1;
			groupBoxKeys.TabStop = false;
			groupBoxKeys.Text = "Keyboard";
			// 
			// keyIcons1
			// 
			keyIcons1.Location = new Point(0, 0);
			keyIcons1.Name = "keyIcons1";
			keyIcons1.Size = new Size(360, 286);
			keyIcons1.TabIndex = 0;
			// 
			// keyConfigsw1
			// 
			keyConfigsw1.Location = new Point(6, 329);
			keyConfigsw1.Name = "keyConfigsw1";
			keyConfigsw1.Size = new Size(217, 75);
			keyConfigsw1.TabIndex = 1;
			// 
			// btnSet
			// 
			btnSet.Location = new Point(229, 376);
			btnSet.Name = "btnSet";
			btnSet.Size = new Size(137, 51);
			btnSet.TabIndex = 2;
			btnSet.Text = "Set";
			btnSet.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(229, 329);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(137, 31);
			btnClear.TabIndex = 3;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(rotaryEncoder1);
			groupBox1.Location = new Point(411, 296);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(450, 215);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "RotaryEncoder1";
			// 
			// rotaryEncoder1
			// 
			rotaryEncoder1.BackColor = SystemColors.Control;
			rotaryEncoder1.Location = new Point(0, 0);
			rotaryEncoder1.Name = "rotaryEncoder1";
			rotaryEncoder1.Size = new Size(430, 190);
			rotaryEncoder1.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(rotaryEncoder2);
			groupBox2.Location = new Point(411, 75);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(450, 215);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "RotaryEncoder2";
			// 
			// rotaryEncoder2
			// 
			rotaryEncoder2.BackColor = SystemColors.Control;
			rotaryEncoder2.Location = new Point(0, 0);
			rotaryEncoder2.Name = "rotaryEncoder2";
			rotaryEncoder2.Size = new Size(430, 190);
			rotaryEncoder2.TabIndex = 0;
			// 
			// Form1
			// 
			ClientSize = new Size(879, 520);
			Controls.Add(menuStrip1);
			Controls.Add(layersw1);
			Controls.Add(groupBoxKeys);
			Controls.Add(groupBox1);
			Controls.Add(groupBox2);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			groupBoxKeys.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem quitToolStripMenuItem;
		private LayerSW layersw1;

		private GroupBox groupBoxKeys;
		private KeyIcons keyIcons1;
		private KeyConfigSW keyConfigsw1;
		private Button btnSet;
		private Button btnClear;

		private GroupBox groupBox2;
		private RotaryEncoderSW rotaryEncoder2;
		private GroupBox groupBox1;
		private RotaryEncoderSW rotaryEncoder1;
		private ToolStripMenuItem toClipboardToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem copyFromindex0ToolStripMenuItem;
		private ToolStripMenuItem copyFromindex1ToolStripMenuItem;
		private ToolStripMenuItem copyFromindex2ToolStripMenuItem;
		private ToolStripMenuItem copyFromindex3ToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
	}
}

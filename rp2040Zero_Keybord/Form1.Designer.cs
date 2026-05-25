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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openMenu = new ToolStripMenuItem();
			saveMenu = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			ToClipboardCPPMenu = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripSeparator();
			quitMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyFromindex0Menu = new ToolStripMenuItem();
			copyFromindex1Menu = new ToolStripMenuItem();
			copyFromindex2Menu = new ToolStripMenuItem();
			groupBoxKeys = new GroupBox();
			keyConfigsw1 = new KeyConfigSW();
			btnSet = new Button();
			btnClear = new Button();
			keyIcons1 = new KeyIcons();
			groupBox1 = new GroupBox();
			textBox1 = new TextBox();
			rotaryEncoder1 = new RotaryEncoderSW();
			groupBox2 = new GroupBox();
			rotaryEncoder2 = new RotaryEncoderSW();
			layerNav1 = new LayerNav();
			getDeviceMenu = new ToolStripMenuItem();
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
			menuStrip1.Size = new Size(1064, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openMenu, saveMenu, toolStripMenuItem1, ToClipboardCPPMenu, toolStripMenuItem2, getDeviceMenu, quitMenu });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openMenu
			// 
			openMenu.Name = "openMenu";
			openMenu.Size = new Size(158, 22);
			openMenu.Text = "Open";
			// 
			// saveMenu
			// 
			saveMenu.Name = "saveMenu";
			saveMenu.Size = new Size(158, 22);
			saveMenu.Text = "Save";
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(155, 6);
			// 
			// ToClipboardCPPMenu
			// 
			ToClipboardCPPMenu.Name = "ToClipboardCPPMenu";
			ToClipboardCPPMenu.Size = new Size(158, 22);
			ToClipboardCPPMenu.Text = "ToClipboardCPP";
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(155, 6);
			// 
			// quitMenu
			// 
			quitMenu.Name = "quitMenu";
			quitMenu.Size = new Size(158, 22);
			quitMenu.Text = "Quit";
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyFromindex0Menu, copyFromindex1Menu, copyFromindex2Menu });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// copyFromindex0Menu
			// 
			copyFromindex0Menu.Name = "copyFromindex0Menu";
			copyFromindex0Menu.Size = new Size(162, 22);
			copyFromindex0Menu.Text = "CopyFromindex0";
			// 
			// copyFromindex1Menu
			// 
			copyFromindex1Menu.Name = "copyFromindex1Menu";
			copyFromindex1Menu.Size = new Size(162, 22);
			copyFromindex1Menu.Text = "CopyFromindex1";
			// 
			// copyFromindex2Menu
			// 
			copyFromindex2Menu.Name = "copyFromindex2Menu";
			copyFromindex2Menu.Size = new Size(162, 22);
			copyFromindex2Menu.Text = "CopyFromindex2";
			// 
			// groupBoxKeys
			// 
			groupBoxKeys.Controls.Add(keyConfigsw1);
			groupBoxKeys.Controls.Add(btnSet);
			groupBoxKeys.Controls.Add(btnClear);
			groupBoxKeys.Controls.Add(keyIcons1);
			groupBoxKeys.Location = new Point(188, 27);
			groupBoxKeys.Name = "groupBoxKeys";
			groupBoxKeys.Size = new Size(393, 473);
			groupBoxKeys.TabIndex = 1;
			groupBoxKeys.TabStop = false;
			groupBoxKeys.Text = "Keyboard";
			// 
			// keyConfigsw1
			// 
			keyConfigsw1.Location = new Point(17, 369);
			keyConfigsw1.Name = "keyConfigsw1";
			keyConfigsw1.Size = new Size(217, 75);
			keyConfigsw1.TabIndex = 1;
			// 
			// btnSet
			// 
			btnSet.Location = new Point(240, 369);
			btnSet.Name = "btnSet";
			btnSet.Size = new Size(137, 75);
			btnSet.TabIndex = 2;
			btnSet.Text = "Set";
			btnSet.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(311, 22);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(66, 31);
			btnClear.TabIndex = 3;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// keyIcons1
			// 
			keyIcons1.Location = new Point(17, 64);
			keyIcons1.Name = "keyIcons1";
			keyIcons1.Size = new Size(360, 286);
			keyIcons1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(rotaryEncoder1);
			groupBox1.Location = new Point(587, 262);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(450, 238);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "RotaryEncoder1";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(257, 167);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(149, 23);
			textBox1.TabIndex = 1;
			// 
			// rotaryEncoder1
			// 
			rotaryEncoder1.BackColor = SystemColors.Control;
			rotaryEncoder1.Location = new Point(14, 19);
			rotaryEncoder1.Name = "rotaryEncoder1";
			rotaryEncoder1.Size = new Size(430, 190);
			rotaryEncoder1.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(rotaryEncoder2);
			groupBox2.Location = new Point(587, 27);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(462, 229);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "RotaryEncoder2";
			// 
			// rotaryEncoder2
			// 
			rotaryEncoder2.BackColor = SystemColors.Control;
			rotaryEncoder2.Location = new Point(14, 17);
			rotaryEncoder2.Name = "rotaryEncoder2";
			rotaryEncoder2.Size = new Size(430, 192);
			rotaryEncoder2.TabIndex = 0;
			rotaryEncoder2.Click += rotaryEncoder2_Click;
			// 
			// layerNav1
			// 
			layerNav1.Location = new Point(12, 27);
			layerNav1.Name = "layerNav1";
			layerNav1.Size = new Size(170, 473);
			layerNav1.TabIndex = 17;
			layerNav1.TabStop = false;
			layerNav1.Text = "Layer";
			// 
			// getDeviceMenu
			// 
			getDeviceMenu.Name = "getDeviceMenu";
			getDeviceMenu.Size = new Size(158, 22);
			getDeviceMenu.Text = "GetDevice";
			// 
			// Form1
			// 
			ClientSize = new Size(1064, 509);
			Controls.Add(layerNav1);
			Controls.Add(groupBox1);
			Controls.Add(menuStrip1);
			Controls.Add(groupBoxKeys);
			Controls.Add(groupBox2);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			groupBoxKeys.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem quitMenu;

		private GroupBox groupBoxKeys;
		private KeyIcons keyIcons1;
		private KeyConfigSW keyConfigsw1;
		private Button btnSet;
		private Button btnClear;

		private GroupBox groupBox2;
		private RotaryEncoderSW rotaryEncoder2;
		private GroupBox groupBox1;
		private RotaryEncoderSW rotaryEncoder1;
		private ToolStripMenuItem ToClipboardCPPMenu;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem copyFromindex0Menu;
		private ToolStripMenuItem copyFromindex1Menu;
		private ToolStripMenuItem copyFromindex2Menu;
		private ToolStripMenuItem openMenu;
		private ToolStripMenuItem saveMenu;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private LayerNav layerNav1;
		private TextBox textBox1;
		private ToolStripMenuItem getDeviceMenu;
	}
}

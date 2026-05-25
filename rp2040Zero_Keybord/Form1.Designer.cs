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
			getDeviceMenu = new ToolStripMenuItem();
			setDeviceMenu = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			quitMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			clearMenu = new ToolStripMenuItem();
			groupBoxKeys = new GroupBox();
			keyIcons1 = new KeyIcons();
			btnClear = new Button();
			groupBox1 = new GroupBox();
			rotaryEncoder1 = new RotaryEncoderSW();
			groupBox2 = new GroupBox();
			rotaryEncoder2 = new RotaryEncoderSW();
			layerNav1 = new LayerNav();
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
			menuStrip1.Size = new Size(861, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openMenu, saveMenu, toolStripMenuItem1, ToClipboardCPPMenu, toolStripMenuItem2, getDeviceMenu, setDeviceMenu, toolStripMenuItem3, quitMenu });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openMenu
			// 
			openMenu.Name = "openMenu";
			openMenu.ShortcutKeys = Keys.Control | Keys.O;
			openMenu.Size = new Size(158, 22);
			openMenu.Text = "Open";
			// 
			// saveMenu
			// 
			saveMenu.Name = "saveMenu";
			saveMenu.ShortcutKeys = Keys.Control | Keys.S;
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
			// getDeviceMenu
			// 
			getDeviceMenu.Name = "getDeviceMenu";
			getDeviceMenu.Size = new Size(158, 22);
			getDeviceMenu.Text = "GetDevice";
			// 
			// setDeviceMenu
			// 
			setDeviceMenu.Name = "setDeviceMenu";
			setDeviceMenu.Size = new Size(158, 22);
			setDeviceMenu.Text = "SetDevice";
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(155, 6);
			// 
			// quitMenu
			// 
			quitMenu.Name = "quitMenu";
			quitMenu.ShortcutKeys = Keys.Control | Keys.Q;
			quitMenu.Size = new Size(158, 22);
			quitMenu.Text = "Quit";
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearMenu });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// clearMenu
			// 
			clearMenu.Name = "clearMenu";
			clearMenu.ShortcutKeys = Keys.Control | Keys.Delete;
			clearMenu.Size = new Size(166, 22);
			clearMenu.Text = "Clear";
			// 
			// groupBoxKeys
			// 
			groupBoxKeys.Controls.Add(keyIcons1);
			groupBoxKeys.Location = new Point(188, 27);
			groupBoxKeys.Name = "groupBoxKeys";
			groupBoxKeys.Size = new Size(393, 320);
			groupBoxKeys.TabIndex = 1;
			groupBoxKeys.TabStop = false;
			groupBoxKeys.Text = "Keyboard";
			// 
			// keyIcons1
			// 
			keyIcons1.Location = new Point(17, 22);
			keyIcons1.Name = "keyIcons1";
			keyIcons1.Size = new Size(360, 286);
			keyIcons1.TabIndex = 0;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(601, 273);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(66, 62);
			btnClear.TabIndex = 3;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(rotaryEncoder1);
			groupBox1.Location = new Point(587, 152);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(240, 115);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "RotaryEncoder1";
			// 
			// rotaryEncoder1
			// 
			rotaryEncoder1.BackColor = SystemColors.Control;
			rotaryEncoder1.Location = new Point(14, 19);
			rotaryEncoder1.Name = "rotaryEncoder1";
			rotaryEncoder1.Size = new Size(214, 90);
			rotaryEncoder1.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(rotaryEncoder2);
			groupBox2.Location = new Point(587, 27);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(240, 119);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "RotaryEncoder2";
			// 
			// rotaryEncoder2
			// 
			rotaryEncoder2.BackColor = SystemColors.Control;
			rotaryEncoder2.Location = new Point(14, 17);
			rotaryEncoder2.Name = "rotaryEncoder2";
			rotaryEncoder2.Size = new Size(214, 89);
			rotaryEncoder2.TabIndex = 0;
			rotaryEncoder2.Click += rotaryEncoder2_Click;
			// 
			// layerNav1
			// 
			layerNav1.Location = new Point(12, 27);
			layerNav1.Name = "layerNav1";
			layerNav1.Size = new Size(170, 320);
			layerNav1.TabIndex = 17;
			layerNav1.TabStop = false;
			layerNav1.Text = "Layer";
			// 
			// Form1
			// 
			ClientSize = new Size(861, 360);
			Controls.Add(btnClear);
			Controls.Add(layerNav1);
			Controls.Add(groupBox1);
			Controls.Add(menuStrip1);
			Controls.Add(groupBoxKeys);
			Controls.Add(groupBox2);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			Text = "rp2040 Zero RotaryEncoder And Keyboard";
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
		private ToolStripMenuItem quitMenu;

		private GroupBox groupBoxKeys;
		private KeyIcons keyIcons1;
		private Button btnClear;

		private GroupBox groupBox2;
		private RotaryEncoderSW rotaryEncoder2;
		private GroupBox groupBox1;
		private RotaryEncoderSW rotaryEncoder1;
		private ToolStripMenuItem ToClipboardCPPMenu;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem openMenu;
		private ToolStripMenuItem saveMenu;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private LayerNav layerNav1;
		private ToolStripMenuItem getDeviceMenu;
		private ToolStripMenuItem setDeviceMenu;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem clearMenu;
	}
}

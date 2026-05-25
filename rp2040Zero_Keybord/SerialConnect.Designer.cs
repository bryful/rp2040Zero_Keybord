namespace rp2040Zero_Keybord
{
	partial class SerialConnect
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			comboBoxPorts = new ComboBox();
			label1 = new Label();
			btnOK = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// comboBoxPorts
			// 
			comboBoxPorts.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxPorts.FormattingEnabled = true;
			comboBoxPorts.Location = new Point(78, 36);
			comboBoxPorts.Name = "comboBoxPorts";
			comboBoxPorts.Size = new Size(121, 23);
			comboBoxPorts.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(32, 39);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.TabIndex = 1;
			label1.Text = "Port";
			// 
			// btnOK
			// 
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point(124, 65);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "Connect";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(32, 65);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// SerialConnect
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(237, 116);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(label1);
			Controls.Add(comboBoxPorts);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "SerialConnect";
			StartPosition = FormStartPosition.CenterParent;
			Text = "SerialConnect";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox comboBoxPorts;
		private Label label1;
		private Button btnOK;
		private Button btnCancel;
	}
}
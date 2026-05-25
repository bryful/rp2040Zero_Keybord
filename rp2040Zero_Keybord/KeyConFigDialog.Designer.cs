namespace rp2040Zero_Keybord
{
	partial class KeyConFigDialog
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
			lbCaption = new Label();
			cbShift = new CheckBox();
			cbControl = new CheckBox();
			cbAlt = new CheckBox();
			cbWin = new CheckBox();
			cbMouseL = new CheckBox();
			cbMouseR = new CheckBox();
			cbMouseM = new CheckBox();
			cbModeChange = new CheckBox();
			gbM = new GroupBox();
			gbK = new GroupBox();
			keyDropDownList1 = new KeyDropDownList();
			gbMouse = new GroupBox();
			gbMode = new GroupBox();
			btnOK = new Button();
			btnCancel = new Button();
			bntClear = new Button();
			gbM.SuspendLayout();
			gbK.SuspendLayout();
			gbMouse.SuspendLayout();
			gbMode.SuspendLayout();
			SuspendLayout();
			// 
			// lbCaption
			// 
			lbCaption.AutoSize = true;
			lbCaption.Location = new Point(12, 15);
			lbCaption.Name = "lbCaption";
			lbCaption.Size = new Size(38, 15);
			lbCaption.TabIndex = 0;
			lbCaption.Text = "label1";
			// 
			// cbShift
			// 
			cbShift.AutoSize = true;
			cbShift.Location = new Point(6, 22);
			cbShift.Name = "cbShift";
			cbShift.Size = new Size(50, 19);
			cbShift.TabIndex = 1;
			cbShift.Text = "Shift";
			cbShift.UseVisualStyleBackColor = true;
			// 
			// cbControl
			// 
			cbControl.AutoSize = true;
			cbControl.Location = new Point(6, 47);
			cbControl.Name = "cbControl";
			cbControl.Size = new Size(65, 19);
			cbControl.TabIndex = 2;
			cbControl.Text = "Control";
			cbControl.UseVisualStyleBackColor = true;
			// 
			// cbAlt
			// 
			cbAlt.AutoSize = true;
			cbAlt.Location = new Point(6, 72);
			cbAlt.Name = "cbAlt";
			cbAlt.Size = new Size(41, 19);
			cbAlt.TabIndex = 3;
			cbAlt.Text = "Alt";
			cbAlt.UseVisualStyleBackColor = true;
			// 
			// cbWin
			// 
			cbWin.AutoSize = true;
			cbWin.Location = new Point(6, 97);
			cbWin.Name = "cbWin";
			cbWin.Size = new Size(47, 19);
			cbWin.TabIndex = 4;
			cbWin.Text = "Win";
			cbWin.UseVisualStyleBackColor = true;
			// 
			// cbMouseL
			// 
			cbMouseL.AutoSize = true;
			cbMouseL.Location = new Point(23, 22);
			cbMouseL.Name = "cbMouseL";
			cbMouseL.Size = new Size(99, 19);
			cbMouseL.TabIndex = 6;
			cbMouseL.Text = "Mouse L Click";
			cbMouseL.UseVisualStyleBackColor = true;
			// 
			// cbMouseR
			// 
			cbMouseR.AutoSize = true;
			cbMouseR.Location = new Point(23, 47);
			cbMouseR.Name = "cbMouseR";
			cbMouseR.Size = new Size(99, 19);
			cbMouseR.TabIndex = 7;
			cbMouseR.Text = "Mouse L Click";
			cbMouseR.UseVisualStyleBackColor = true;
			// 
			// cbMouseM
			// 
			cbMouseM.AutoSize = true;
			cbMouseM.Location = new Point(23, 72);
			cbMouseM.Name = "cbMouseM";
			cbMouseM.Size = new Size(104, 19);
			cbMouseM.TabIndex = 8;
			cbMouseM.Text = "Mouse M Click";
			cbMouseM.UseVisualStyleBackColor = true;
			// 
			// cbModeChange
			// 
			cbModeChange.AutoSize = true;
			cbModeChange.Location = new Point(20, 22);
			cbModeChange.Name = "cbModeChange";
			cbModeChange.Size = new Size(97, 19);
			cbModeChange.TabIndex = 9;
			cbModeChange.Text = "ModeChange";
			cbModeChange.UseVisualStyleBackColor = true;
			// 
			// gbM
			// 
			gbM.Controls.Add(cbShift);
			gbM.Controls.Add(cbControl);
			gbM.Controls.Add(cbAlt);
			gbM.Controls.Add(cbWin);
			gbM.Location = new Point(12, 33);
			gbM.Name = "gbM";
			gbM.Size = new Size(80, 165);
			gbM.TabIndex = 10;
			gbM.TabStop = false;
			gbM.Text = "modifier";
			// 
			// gbK
			// 
			gbK.Controls.Add(keyDropDownList1);
			gbK.Location = new Point(98, 33);
			gbK.Name = "gbK";
			gbK.Size = new Size(185, 62);
			gbK.TabIndex = 11;
			gbK.TabStop = false;
			gbK.Text = "Keycode";
			// 
			// keyDropDownList1
			// 
			keyDropDownList1.DropDownStyle = ComboBoxStyle.DropDownList;
			keyDropDownList1.FormattingEnabled = true;
			keyDropDownList1.Items.AddRange(new object[] { "なし", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Enter", "Esc", "Backspace", "Tab", "Space", "- (マイナス)", "^ (ハット)", "@ (アット)", "[ (左角括弧)", "] (右角括弧)", "\\ (円記号)", "; (セミコロン)", "' (アポストロフィ)", "` (グレーブ)", ", (カンマ)", ". (ピリオド)", "/ (スラッシュ)", ": (コロン)", "_ (アンダースコア)", "| (パイプ)", "CapsLock", "NumLock", "ScrollLock", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "PrintScreen", "Pause", "Insert", "Delete", "Home", "End", "PageUp", "PageDown", "→", "←", "↓", "↑", "KP 0", "KP 1", "KP 2", "KP 3", "KP 4", "KP 5", "KP 6", "KP 7", "KP 8", "KP 9", "KP + (プラス)", "KP - (マイナス)", "KP * (アスタリスク)", "KP / (スラッシュ)", "KP . (ピリオド)", "KP , (カンマ)", "KP = (イコール)", "KP Enter", "ろ", "かな", "英数", "変換", "無変換", "ひらがな", "全角/半角", "INTL1 (ろ)", "INTL2 (¥)", "INTL3 (変換)", "INTL4 (無変換)", "INTL5 (ひらがな)", "INTL6 (全角/半角)", "INTL7 (英数)", "INTL8 (:)", "INTL9 (_)", "Left Ctrl", "Left Shift", "Left Alt", "Left Win", "Right Ctrl", "Right Shift", "Right Alt", "Right Win", "Mute", "Vol+", "Vol-", "Menu", "Power", "Execute", "Help", "Menu", "Select", "Stop", "Again", "Undo", "Cut", "Copy", "Paste", "Find", "Mode Change", "なし", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Enter", "Esc", "Backspace", "Tab", "Space", "- (マイナス)", "^ (ハット)", "@ (アット)", "[ (左角括弧)", "] (右角括弧)", "\\ (円記号)", "; (セミコロン)", "' (アポストロフィ)", "` (グレーブ)", ", (カンマ)", ". (ピリオド)", "/ (スラッシュ)", ": (コロン)", "_ (アンダースコア)", "| (パイプ)", "CapsLock", "NumLock", "ScrollLock", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "PrintScreen", "Pause", "Insert", "Delete", "Home", "End", "PageUp", "PageDown", "→", "←", "↓", "↑", "KP 0", "KP 1", "KP 2", "KP 3", "KP 4", "KP 5", "KP 6", "KP 7", "KP 8", "KP 9", "KP + (プラス)", "KP - (マイナス)", "KP * (アスタリスク)", "KP / (スラッシュ)", "KP . (ピリオド)", "KP , (カンマ)", "KP = (イコール)", "KP Enter", "ろ", "かな", "英数", "変換", "無変換", "ひらがな", "全角/半角", "INTL1 (ろ)", "INTL2 (¥)", "INTL3 (変換)", "INTL4 (無変換)", "INTL5 (ひらがな)", "INTL6 (全角/半角)", "INTL7 (英数)", "INTL8 (:)", "INTL9 (_)", "Left Ctrl", "Left Shift", "Left Alt", "Left Win", "Right Ctrl", "Right Shift", "Right Alt", "Right Win", "Mute", "Vol+", "Vol-", "Menu", "Power", "Execute", "Help", "Menu", "Select", "Stop", "Again", "Undo", "Cut", "Copy", "Paste", "Find", "Mode Change", "なし", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Enter", "Esc", "Backspace", "Tab", "Space", "- (マイナス)", "^ (ハット)", "@ (アット)", "[ (左角括弧)", "] (右角括弧)", "\\ (円記号)", "; (セミコロン)", "' (アポストロフィ)", "` (グレーブ)", ", (カンマ)", ". (ピリオド)", "/ (スラッシュ)", ": (コロン)", "_ (アンダースコア)", "| (パイプ)", "CapsLock", "NumLock", "ScrollLock", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "PrintScreen", "Pause", "Insert", "Delete", "Home", "End", "PageUp", "PageDown", "→", "←", "↓", "↑", "KP 0", "KP 1", "KP 2", "KP 3", "KP 4", "KP 5", "KP 6", "KP 7", "KP 8", "KP 9", "KP + (プラス)", "KP - (マイナス)", "KP * (アスタリスク)", "KP / (スラッシュ)", "KP . (ピリオド)", "KP , (カンマ)", "KP = (イコール)", "KP Enter", "ろ", "かな", "英数", "変換", "無変換", "ひらがな", "全角/半角", "INTL1 (ろ)", "INTL2 (¥)", "INTL3 (変換)", "INTL4 (無変換)", "INTL5 (ひらがな)", "INTL6 (全角/半角)", "INTL7 (英数)", "INTL8 (:)", "INTL9 (_)", "Left Ctrl", "Left Shift", "Left Alt", "Left Win", "Right Ctrl", "Right Shift", "Right Alt", "Right Win", "Mute", "Vol+", "Vol-", "Menu", "Power", "Execute", "Help", "Menu", "Select", "Stop", "Again", "Undo", "Cut", "Copy", "Paste", "Find", "Mode Change", "なし", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "Enter", "Esc", "Backspace", "Tab", "Space", "- (マイナス)", "^ (ハット)", "@ (アット)", "[ (左角括弧)", "] (右角括弧)", "\\ (円記号)", "; (セミコロン)", "' (アポストロフィ)", "` (グレーブ)", ", (カンマ)", ". (ピリオド)", "/ (スラッシュ)", ": (コロン)", "_ (アンダースコア)", "| (パイプ)", "CapsLock", "NumLock", "ScrollLock", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "F13", "F14", "F15", "F16", "F17", "F18", "F19", "F20", "F21", "F22", "F23", "F24", "PrintScreen", "Pause", "Insert", "Delete", "Home", "End", "PageUp", "PageDown", "→", "←", "↓", "↑", "KP 0", "KP 1", "KP 2", "KP 3", "KP 4", "KP 5", "KP 6", "KP 7", "KP 8", "KP 9", "KP + (プラス)", "KP - (マイナス)", "KP * (アスタリスク)", "KP / (スラッシュ)", "KP . (ピリオド)", "KP , (カンマ)", "KP = (イコール)", "KP Enter", "ろ", "かな", "英数", "変換", "無変換", "ひらがな", "全角/半角", "INTL1 (ろ)", "INTL2 (¥)", "INTL3 (変換)", "INTL4 (無変換)", "INTL5 (ひらがな)", "INTL6 (全角/半角)", "INTL7 (英数)", "INTL8 (:)", "INTL9 (_)", "Left Ctrl", "Left Shift", "Left Alt", "Left Win", "Right Ctrl", "Right Shift", "Right Alt", "Right Win", "Mute", "Vol+", "Vol-", "Menu", "Power", "Execute", "Help", "Menu", "Select", "Stop", "Again", "Undo", "Cut", "Copy", "Paste", "Find", "Mode Change" });
			keyDropDownList1.Location = new Point(6, 25);
			keyDropDownList1.Name = "keyDropDownList1";
			keyDropDownList1.Size = new Size(173, 23);
			keyDropDownList1.TabIndex = 0;
			// 
			// gbMouse
			// 
			gbMouse.Controls.Add(cbMouseL);
			gbMouse.Controls.Add(cbMouseR);
			gbMouse.Controls.Add(cbMouseM);
			gbMouse.Location = new Point(98, 101);
			gbMouse.Name = "gbMouse";
			gbMouse.Size = new Size(179, 100);
			gbMouse.TabIndex = 12;
			gbMouse.TabStop = false;
			gbMouse.Text = "mouse";
			// 
			// gbMode
			// 
			gbMode.Controls.Add(cbModeChange);
			gbMode.Location = new Point(289, 36);
			gbMode.Name = "gbMode";
			gbMode.Size = new Size(126, 59);
			gbMode.TabIndex = 13;
			gbMode.TabStop = false;
			gbMode.Text = "ModeChange";
			// 
			// btnOK
			// 
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point(304, 159);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(104, 39);
			btnOK.TabIndex = 14;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Location = new Point(304, 130);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(104, 23);
			btnCancel.TabIndex = 15;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// bntClear
			// 
			bntClear.Location = new Point(304, 101);
			bntClear.Name = "bntClear";
			bntClear.Size = new Size(103, 23);
			bntClear.TabIndex = 16;
			bntClear.Text = "Clear";
			bntClear.UseVisualStyleBackColor = true;
			// 
			// KeyConFigDialog
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(420, 210);
			Controls.Add(bntClear);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(gbMode);
			Controls.Add(gbMouse);
			Controls.Add(gbK);
			Controls.Add(gbM);
			Controls.Add(lbCaption);
			FormBorderStyle = FormBorderStyle.None;
			Name = "KeyConFigDialog";
			StartPosition = FormStartPosition.Manual;
			Text = "KeyConFigDialog";
			gbM.ResumeLayout(false);
			gbM.PerformLayout();
			gbK.ResumeLayout(false);
			gbMouse.ResumeLayout(false);
			gbMouse.PerformLayout();
			gbMode.ResumeLayout(false);
			gbMode.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbCaption;
		private CheckBox cbShift;
		private CheckBox cbControl;
		private CheckBox cbAlt;
		private CheckBox cbWin;
		private CheckBox cbMouseL;
		private CheckBox cbMouseR;
		private CheckBox cbMouseM;
		private CheckBox cbModeChange;
		private GroupBox gbM;
		private GroupBox gbK;
		private GroupBox gbMouse;
		private GroupBox gbMode;
		private Button btnOK;
		private Button btnCancel;
		private Button bntClear;
		private KeyDropDownList keyDropDownList1;
	}
}
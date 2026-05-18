using System;
using System.Collections.Generic;
using System.Linq;

namespace rp2040Zero_Keybord
{
	// マウスボタン定義
	public static class Mouse
	{
		public const byte Left = 1;
		public const byte Right = 2;
		public const byte Middle = 4;
		public const byte All = Left | Right | Middle;
	}

	// キーボードモディファイア
	[Flags]
	public enum KeyboardModifier : byte
	{
		None = 0,
		LeftCtrl = 1 << 0,
		LeftShift = 1 << 1,
		LeftAlt = 1 << 2,
		LeftGui = 1 << 3,
		RightCtrl = 1 << 4,
		RightShift = 1 << 5,
		RightAlt = 1 << 6,
		RightGui = 1 << 7
	}

	// HIDキーコード
	public static class HidKey
	{
		public const byte None = 0x00;
		public const byte A = 0x04;
		public const byte B = 0x05;
		public const byte C = 0x06;
		public const byte D = 0x07;
		public const byte E = 0x08;
		public const byte F = 0x09;
		public const byte G = 0x0A;
		public const byte H = 0x0B;
		public const byte I = 0x0C;
		public const byte J = 0x0D;
		public const byte K = 0x0E;
		public const byte L = 0x0F;
		public const byte M = 0x10;
		public const byte N = 0x11;
		public const byte O = 0x12;
		public const byte P = 0x13;
		public const byte Q = 0x14;
		public const byte R = 0x15;
		public const byte S = 0x16;
		public const byte T = 0x17;
		public const byte U = 0x18;
		public const byte V = 0x19;
		public const byte W = 0x1A;
		public const byte X = 0x1B;
		public const byte Y = 0x1C;
		public const byte Z = 0x1D;
		public const byte Key1 = 0x1E;
		public const byte Key2 = 0x1F;
		public const byte Key3 = 0x20;
		public const byte Key4 = 0x21;
		public const byte Key5 = 0x22;
		public const byte Key6 = 0x23;
		public const byte Key7 = 0x24;
		public const byte Key8 = 0x25;
		public const byte Key9 = 0x26;
		public const byte Key0 = 0x27;
		public const byte Enter = 0x28;
		public const byte Escape = 0x29;
		public const byte Backspace = 0x2A;
		public const byte Tab = 0x2B;
		public const byte Space = 0x2C;
		public const byte Minus = 0x2D;
		public const byte Equal = 0x2E;
		public const byte Caret = 0x2E;
		public const byte BracketLeft = 0x2F;
		public const byte At = 0x2F;
		public const byte BracketRight = 0x30;
		public const byte LeftBrace = 0x30;
		public const byte Backslash = 0x31;
		public const byte Europe1 = 0x32;
		public const byte RightBrace = 0x32;
		public const byte Semicolon = 0x33;
		public const byte Apostrophe = 0x34;
		public const byte Grave = 0x35;
		public const byte Comma = 0x36;
		public const byte Period = 0x37;
		public const byte Dot = 0x37;
		public const byte Slash = 0x38;
		public const byte CapsLock = 0x39;
		public const byte F1 = 0x3A;
		public const byte F2 = 0x3B;
		public const byte F3 = 0x3C;
		public const byte F4 = 0x3D;
		public const byte F5 = 0x3E;
		public const byte F6 = 0x3F;
		public const byte F7 = 0x40;
		public const byte F8 = 0x41;
		public const byte F9 = 0x42;
		public const byte F10 = 0x43;
		public const byte F11 = 0x44;
		public const byte F12 = 0x45;
		public const byte PrintScreen = 0x46;
		public const byte ScrollLock = 0x47;
		public const byte Pause = 0x48;
		public const byte Insert = 0x49;
		public const byte Home = 0x4A;
		public const byte PageUp = 0x4B;
		public const byte Delete = 0x4C;
		public const byte End = 0x4D;
		public const byte PageDown = 0x4E;
		public const byte ArrowRight = 0x4F;
		public const byte ArrowLeft = 0x50;
		public const byte ArrowDown = 0x51;
		public const byte ArrowUp = 0x52;
		public const byte NumLock = 0x53;
		public const byte KeypadDivide = 0x54;
		public const byte KpSlash = 0x54;
		public const byte KeypadMultiply = 0x55;
		public const byte KpAsterisk = 0x55;
		public const byte KeypadSubtract = 0x56;
		public const byte KpMinus = 0x56;
		public const byte KeypadAdd = 0x57;
		public const byte KpPlus = 0x57;
		public const byte KeypadEnter = 0x58;
		public const byte KpEnter = 0x58;
		public const byte Keypad1 = 0x59;
		public const byte Keypad2 = 0x5A;
		public const byte Keypad3 = 0x5B;
		public const byte Keypad4 = 0x5C;
		public const byte Keypad5 = 0x5D;
		public const byte Keypad6 = 0x5E;
		public const byte Keypad7 = 0x5F;
		public const byte Keypad8 = 0x60;
		public const byte Keypad9 = 0x61;
		public const byte Keypad0 = 0x62;
		public const byte KeypadDecimal = 0x63;
		public const byte KpDot = 0x63;
		public const byte Europe2 = 0x64;
		public const byte Pipe = 0x64;
		public const byte Application = 0x65;
		public const byte Power = 0x66;
		public const byte KeypadEqual = 0x67;
		public const byte KpEqual = 0x67;
		public const byte F13 = 0x68;
		public const byte F14 = 0x69;
		public const byte F15 = 0x6A;
		public const byte F16 = 0x6B;
		public const byte F17 = 0x6C;
		public const byte F18 = 0x6D;
		public const byte F19 = 0x6E;
		public const byte F20 = 0x6F;
		public const byte F21 = 0x70;
		public const byte F22 = 0x71;
		public const byte F23 = 0x72;
		public const byte F24 = 0x73;
		public const byte Execute = 0x74;
		public const byte Help = 0x75;
		public const byte Menu = 0x76;
		public const byte Select = 0x77;
		public const byte Stop = 0x78;
		public const byte Again = 0x79;
		public const byte Undo = 0x7A;
		public const byte Cut = 0x7B;
		public const byte Copy = 0x7C;
		public const byte Paste = 0x7D;
		public const byte Find = 0x7E;
		public const byte Mute = 0x7F;
		public const byte VolumeUp = 0x80;
		public const byte VolumeDown = 0x81;
		public const byte LockingCapsLock = 0x82;
		public const byte LockingNumLock = 0x83;
		public const byte LockingScrollLock = 0x84;
		public const byte KeypadComma = 0x85;
		public const byte KpComma = 0x85;
		public const byte KeypadEqualSign = 0x86;
		public const byte Kanji1 = 0x87;
		public const byte Ro = 0x87;
		public const byte Intl1 = 0x87;
		public const byte Kanji2 = 0x88;
		public const byte Kana = 0x88;
		public const byte Kanji3 = 0x89;
		public const byte Intl2 = 0x89;
		public const byte Kanji4 = 0x8A;
		public const byte Henkan = 0x8A;
		public const byte Intl3 = 0x8A;
		public const byte Kanji5 = 0x8B;
		public const byte Muhenkan = 0x8B;
		public const byte Intl4 = 0x8B;
		public const byte Kanji6 = 0x8C;
		public const byte Hiragana = 0x8C;
		public const byte Intl5 = 0x8C;
		public const byte Kanji7 = 0x8D;
		public const byte ZenkakuHankaku = 0x8D;
		public const byte Intl6 = 0x8D;
		public const byte Kanji8 = 0x8E;
		public const byte Kanji9 = 0x8F;
		public const byte Lang1 = 0x90;
		public const byte Lang2 = 0x91;
		public const byte Lang3 = 0x92;
		public const byte Colon = 0x92;
		public const byte Intl8 = 0x92;
		public const byte Lang4 = 0x93;
		public const byte Underscore = 0x93;
		public const byte Intl9 = 0x93;
		public const byte Lang5 = 0x94;
		public const byte Eisu = 0x94;
		public const byte Intl7 = 0x94;
		public const byte Lang6 = 0x95;
		public const byte Lang7 = 0x96;
		public const byte Lang8 = 0x97;
		public const byte Lang9 = 0x98;
		public const byte AlternateErase = 0x99;
		public const byte SysreqAttention = 0x9A;
		public const byte Cancel = 0x9B;
		public const byte Clear = 0x9C;
		public const byte Prior = 0x9D;
		public const byte Return = 0x9E;
		public const byte Separator = 0x9F;
		public const byte Out = 0xA0;
		public const byte Oper = 0xA1;
		public const byte ClearAgain = 0xA2;
		public const byte CrselProps = 0xA3;
		public const byte Exsel = 0xA4;
		public const byte Keypad00 = 0xB0;
		public const byte Keypad000 = 0xB1;
		public const byte ThousandsSeparator = 0xB2;
		public const byte DecimalSeparator = 0xB3;
		public const byte CurrencyUnit = 0xB4;
		public const byte CurrencySubunit = 0xB5;
		public const byte KeypadLeftParenthesis = 0xB6;
		public const byte KeypadRightParenthesis = 0xB7;
		public const byte KeypadLeftBrace = 0xB8;
		public const byte KeypadRightBrace = 0xB9;
		public const byte KeypadTab = 0xBA;
		public const byte KeypadBackspace = 0xBB;
		public const byte KeypadA = 0xBC;
		public const byte KeypadB = 0xBD;
		public const byte KeypadC = 0xBE;
		public const byte KeypadD = 0xBF;
		public const byte KeypadE = 0xC0;
		public const byte KeypadF = 0xC1;
		public const byte KeypadXor = 0xC2;
		public const byte KeypadCaret = 0xC3;
		public const byte KeypadPercent = 0xC4;
		public const byte KeypadLessThan = 0xC5;
		public const byte KeypadGreaterThan = 0xC6;
		public const byte KeypadAmpersand = 0xC7;
		public const byte KeypadDoubleAmpersand = 0xC8;
		public const byte KeypadVerticalBar = 0xC9;
		public const byte KeypadDoubleVerticalBar = 0xCA;
		public const byte KeypadColon = 0xCB;
		public const byte KeypadHash = 0xCC;
		public const byte KeypadSpace = 0xCD;
		public const byte KeypadAt = 0xCE;
		public const byte KeypadExclamation = 0xCF;
		public const byte KeypadMemoryStore = 0xD0;
		public const byte KeypadMemoryRecall = 0xD1;
		public const byte KeypadMemoryClear = 0xD2;
		public const byte KeypadMemoryAdd = 0xD3;
		public const byte KeypadMemorySubtract = 0xD4;
		public const byte KeypadMemoryMultiply = 0xD5;
		public const byte KeypadMemoryDivide = 0xD6;
		public const byte KeypadPlusMinus = 0xD7;
		public const byte KeypadClear = 0xD8;
		public const byte KeypadClearEntry = 0xD9;
		public const byte KeypadBinary = 0xDA;
		public const byte KeypadOctal = 0xDB;
		public const byte KeypadDecimal2 = 0xDC;
		public const byte KeypadHexadecimal = 0xDD;
		public const byte ControlLeft = 0xE0;
		public const byte ShiftLeft = 0xE1;
		public const byte AltLeft = 0xE2;
		public const byte GuiLeft = 0xE3;
		public const byte ControlRight = 0xE4;
		public const byte ShiftRight = 0xE5;
		public const byte AltRight = 0xE6;
		public const byte GuiRight = 0xE7;

		public const byte MODE_CHANGE = 0xFF;
	}

	// キー情報
	public class KeyInfo
	{
		public byte Code { get; set; }
		public string DisplayName { get; set; }
		public string CppConstName { get; set; }
		public string Description { get; set; }

		public KeyInfo(byte code, string displayName, string cppConstName, string description = "")
		{
			Code = code;
			DisplayName = displayName;
			CppConstName = cppConstName;
			Description = description;
		}

		public override string ToString() => DisplayName;
	}

	// キーデータベース
	public static class KeyDatabase
	{
		public static List<KeyInfo> AllKeys { get; } = new()
		{
			new(HidKey.None, "なし", "HID_KEY_NONE"),
            
            // アルファベット
            new(HidKey.A, "A", "HID_KEY_A"),
			new(HidKey.B, "B", "HID_KEY_B"),
			new(HidKey.C, "C", "HID_KEY_C"),
			new(HidKey.D, "D", "HID_KEY_D"),
			new(HidKey.E, "E", "HID_KEY_E"),
			new(HidKey.F, "F", "HID_KEY_F"),
			new(HidKey.G, "G", "HID_KEY_G"),
			new(HidKey.H, "H", "HID_KEY_H"),
			new(HidKey.I, "I", "HID_KEY_I"),
			new(HidKey.J, "J", "HID_KEY_J"),
			new(HidKey.K, "K", "HID_KEY_K"),
			new(HidKey.L, "L", "HID_KEY_L"),
			new(HidKey.M, "M", "HID_KEY_M"),
			new(HidKey.N, "N", "HID_KEY_N"),
			new(HidKey.O, "O", "HID_KEY_O"),
			new(HidKey.P, "P", "HID_KEY_P"),
			new(HidKey.Q, "Q", "HID_KEY_Q"),
			new(HidKey.R, "R", "HID_KEY_R"),
			new(HidKey.S, "S", "HID_KEY_S"),
			new(HidKey.T, "T", "HID_KEY_T"),
			new(HidKey.U, "U", "HID_KEY_U"),
			new(HidKey.V, "V", "HID_KEY_V"),
			new(HidKey.W, "W", "HID_KEY_W"),
			new(HidKey.X, "X", "HID_KEY_X"),
			new(HidKey.Y, "Y", "HID_KEY_Y"),
			new(HidKey.Z, "Z", "HID_KEY_Z"),
            
            // 数字
            new(HidKey.Key1, "1", "HID_KEY_1"),
			new(HidKey.Key2, "2", "HID_KEY_2"),
			new(HidKey.Key3, "3", "HID_KEY_3"),
			new(HidKey.Key4, "4", "HID_KEY_4"),
			new(HidKey.Key5, "5", "HID_KEY_5"),
			new(HidKey.Key6, "6", "HID_KEY_6"),
			new(HidKey.Key7, "7", "HID_KEY_7"),
			new(HidKey.Key8, "8", "HID_KEY_8"),
			new(HidKey.Key9, "9", "HID_KEY_9"),
			new(HidKey.Key0, "0", "HID_KEY_0"),
            
            // 制御キー
            new(HidKey.Enter, "Enter", "HID_KEY_ENTER"),
			new(HidKey.Escape, "Esc", "HID_KEY_ESCAPE"),
			new(HidKey.Backspace, "Backspace", "HID_KEY_BACKSPACE"),
			new(HidKey.Tab, "Tab", "HID_KEY_TAB"),
			new(HidKey.Space, "Space", "HID_KEY_SPACE"),
            
            // JIS記号キー
            new(HidKey.Minus, "- (マイナス)", "HID_KEY_MINUS", "JIS: - ="),
			new(HidKey.Caret, "^ (ハット)", "HID_KEY_CARET", "JIS: ^ ~"),
			new(HidKey.At, "@ (アット)", "HID_KEY_AT", "JIS: @ `"),
			new(HidKey.LeftBrace, "[ (左角括弧)", "HID_KEY_LEFTBRACE", "JIS: [ {"),
			new(HidKey.RightBrace, "] (右角括弧)", "HID_KEY_RIGHTBRACE", "JIS: ] }"),
			new(HidKey.Backslash, "\\ (円記号)", "HID_KEY_BACKSLASH", "US: \\"),
			new(HidKey.Semicolon, "; (セミコロン)", "HID_KEY_SEMICOLON", "JIS: ; +"),
			new(HidKey.Apostrophe, "' (アポストロフィ)", "HID_KEY_APOSTROPHE", "JIS: : *"),
			new(HidKey.Grave, "` (グレーブ)", "HID_KEY_GRAVE"),
			new(HidKey.Comma, ", (カンマ)", "HID_KEY_COMMA", "JIS: , <"),
			new(HidKey.Dot, ". (ピリオド)", "HID_KEY_DOT", "JIS: . >"),
			new(HidKey.Slash, "/ (スラッシュ)", "HID_KEY_SLASH", "JIS: / ?"),
			new(HidKey.Colon, ": (コロン)", "HID_KEY_COLON", "JIS: :"),
			new(HidKey.Underscore, "_ (アンダースコア)", "HID_KEY_UNDERSCORE", "JIS: _"),
			new(HidKey.Pipe, "| (パイプ)", "HID_KEY_PIPE", "JIS: |"),
            
            // ロックキー
            new(HidKey.CapsLock, "CapsLock", "HID_KEY_CAPS_LOCK"),
			new(HidKey.NumLock, "NumLock", "HID_KEY_NUM_LOCK"),
			new(HidKey.ScrollLock, "ScrollLock", "HID_KEY_SCROLL_LOCK"),
            
            // ファンクションキー
            new(HidKey.F1, "F1", "HID_KEY_F1"),
			new(HidKey.F2, "F2", "HID_KEY_F2"),
			new(HidKey.F3, "F3", "HID_KEY_F3"),
			new(HidKey.F4, "F4", "HID_KEY_F4"),
			new(HidKey.F5, "F5", "HID_KEY_F5"),
			new(HidKey.F6, "F6", "HID_KEY_F6"),
			new(HidKey.F7, "F7", "HID_KEY_F7"),
			new(HidKey.F8, "F8", "HID_KEY_F8"),
			new(HidKey.F9, "F9", "HID_KEY_F9"),
			new(HidKey.F10, "F10", "HID_KEY_F10"),
			new(HidKey.F11, "F11", "HID_KEY_F11"),
			new(HidKey.F12, "F12", "HID_KEY_F12"),
			new(HidKey.F13, "F13", "HID_KEY_F13"),
			new(HidKey.F14, "F14", "HID_KEY_F14"),
			new(HidKey.F15, "F15", "HID_KEY_F15"),
			new(HidKey.F16, "F16", "HID_KEY_F16"),
			new(HidKey.F17, "F17", "HID_KEY_F17"),
			new(HidKey.F18, "F18", "HID_KEY_F18"),
			new(HidKey.F19, "F19", "HID_KEY_F19"),
			new(HidKey.F20, "F20", "HID_KEY_F20"),
			new(HidKey.F21, "F21", "HID_KEY_F21"),
			new(HidKey.F22, "F22", "HID_KEY_F22"),
			new(HidKey.F23, "F23", "HID_KEY_F23"),
			new(HidKey.F24, "F24", "HID_KEY_F24"),
            
            // ナビゲーションキー
            new(HidKey.PrintScreen, "PrintScreen", "HID_KEY_PRINT_SCREEN"),
			new(HidKey.Pause, "Pause", "HID_KEY_PAUSE"),
			new(HidKey.Insert, "Insert", "HID_KEY_INSERT"),
			new(HidKey.Delete, "Delete", "HID_KEY_DELETE"),
			new(HidKey.Home, "Home", "HID_KEY_HOME"),
			new(HidKey.End, "End", "HID_KEY_END"),
			new(HidKey.PageUp, "PageUp", "HID_KEY_PAGE_UP"),
			new(HidKey.PageDown, "PageDown", "HID_KEY_PAGE_DOWN"),
			new(HidKey.ArrowRight, "→", "HID_KEY_ARROW_RIGHT"),
			new(HidKey.ArrowLeft, "←", "HID_KEY_ARROW_LEFT"),
			new(HidKey.ArrowDown, "↓", "HID_KEY_ARROW_DOWN"),
			new(HidKey.ArrowUp, "↑", "HID_KEY_ARROW_UP"),
            
            // テンキー数字
            new(HidKey.Keypad0, "KP 0", "HID_KEY_KEYPAD_0"),
			new(HidKey.Keypad1, "KP 1", "HID_KEY_KEYPAD_1"),
			new(HidKey.Keypad2, "KP 2", "HID_KEY_KEYPAD_2"),
			new(HidKey.Keypad3, "KP 3", "HID_KEY_KEYPAD_3"),
			new(HidKey.Keypad4, "KP 4", "HID_KEY_KEYPAD_4"),
			new(HidKey.Keypad5, "KP 5", "HID_KEY_KEYPAD_5"),
			new(HidKey.Keypad6, "KP 6", "HID_KEY_KEYPAD_6"),
			new(HidKey.Keypad7, "KP 7", "HID_KEY_KEYPAD_7"),
			new(HidKey.Keypad8, "KP 8", "HID_KEY_KEYPAD_8"),
			new(HidKey.Keypad9, "KP 9", "HID_KEY_KEYPAD_9"),
            
            // テンキー記号（重要）
            new(HidKey.KpPlus, "KP + (プラス)", "HID_KEY_KP_PLUS", "Keypad +"),
			new(HidKey.KpMinus, "KP - (マイナス)", "HID_KEY_KP_MINUS", "Keypad -"),
			new(HidKey.KpAsterisk, "KP * (アスタリスク)", "HID_KEY_KP_ASTERISK", "Keypad *"),
			new(HidKey.KpSlash, "KP / (スラッシュ)", "HID_KEY_KP_SLASH", "Keypad /"),
			new(HidKey.KpDot, "KP . (ピリオド)", "HID_KEY_KP_DOT", "Keypad ."),
			new(HidKey.KpComma, "KP , (カンマ)", "HID_KEY_KP_COMMA", "JIS Keypad ,"),
			new(HidKey.KpEqual, "KP = (イコール)", "HID_KEY_KP_EQUAL", "Keypad ="),
			new(HidKey.KpEnter, "KP Enter", "HID_KEY_KP_ENTER", "Keypad Enter"),
            
            // JIS日本語キー（重要）
            new(HidKey.Ro, "ろ", "HID_KEY_RO", "JIS: ろ / _"),
			new(HidKey.Kana, "かな", "HID_KEY_KANA", "JIS: かな"),
			new(HidKey.Eisu, "英数", "HID_KEY_EISU", "JIS: 英数"),
			new(HidKey.Henkan, "変換", "HID_KEY_HENKAN", "JIS: 変換"),
			new(HidKey.Muhenkan, "無変換", "HID_KEY_MUHENKAN", "JIS: 無変換"),
			new(HidKey.Hiragana, "ひらがな", "HID_KEY_HIRAGANA", "JIS: ひらがな/カタカナ"),
			new(HidKey.ZenkakuHankaku, "全角/半角", "HID_KEY_ZENKAKU_HANKAKU", "JIS: 全角/半角"),
            
            // INTLキー
            new(HidKey.Intl1, "INTL1 (ろ)", "HID_KEY_INTL1", "JIS: ろ"),
			new(HidKey.Intl2, "INTL2 (¥)", "HID_KEY_INTL2", "JIS: ¥"),
			new(HidKey.Intl3, "INTL3 (変換)", "HID_KEY_INTL3", "JIS: 変換"),
			new(HidKey.Intl4, "INTL4 (無変換)", "HID_KEY_INTL4", "JIS: 無変換"),
			new(HidKey.Intl5, "INTL5 (ひらがな)", "HID_KEY_INTL5", "JIS: ひらがな"),
			new(HidKey.Intl6, "INTL6 (全角/半角)", "HID_KEY_INTL6", "JIS: 全角/半角"),
			new(HidKey.Intl7, "INTL7 (英数)", "HID_KEY_INTL7", "JIS: 英数"),
			new(HidKey.Intl8, "INTL8 (:)", "HID_KEY_INTL8", "JIS: :"),
			new(HidKey.Intl9, "INTL9 (_)", "HID_KEY_INTL9", "JIS: _"),
            
            // モディファイア
            new(HidKey.ControlLeft, "Left Ctrl", "HID_KEY_CONTROL_LEFT"),
			new(HidKey.ShiftLeft, "Left Shift", "HID_KEY_SHIFT_LEFT"),
			new(HidKey.AltLeft, "Left Alt", "HID_KEY_ALT_LEFT"),
			new(HidKey.GuiLeft, "Left Win", "HID_KEY_GUI_LEFT"),
			new(HidKey.ControlRight, "Right Ctrl", "HID_KEY_CONTROL_RIGHT"),
			new(HidKey.ShiftRight, "Right Shift", "HID_KEY_SHIFT_RIGHT"),
			new(HidKey.AltRight, "Right Alt", "HID_KEY_ALT_RIGHT"),
			new(HidKey.GuiRight, "Right Win", "HID_KEY_GUI_RIGHT"),
            // メディアキー
            new(HidKey.Mute, "Mute", "HID_KEY_MUTE"),
			new(HidKey.VolumeUp, "Vol+", "HID_KEY_VOLUME_UP"),
			new(HidKey.VolumeDown, "Vol-", "HID_KEY_VOLUME_DOWN"),
            
            // その他
            new(HidKey.Application, "Menu", "HID_KEY_APPLICATION"),
			new(HidKey.Power, "Power", "HID_KEY_POWER"),
			new(HidKey.Execute, "Execute", "HID_KEY_EXECUTE"),
			new(HidKey.Help, "Help", "HID_KEY_HELP"),
			new(HidKey.Menu, "Menu", "HID_KEY_MENU"),
			new(HidKey.Select, "Select", "HID_KEY_SELECT"),
			new(HidKey.Stop, "Stop", "HID_KEY_STOP"),
			new(HidKey.Again, "Again", "HID_KEY_AGAIN"),
			new(HidKey.Undo, "Undo", "HID_KEY_UNDO"),
			new(HidKey.Cut, "Cut", "HID_KEY_CUT"),
			new(HidKey.Copy, "Copy", "HID_KEY_COPY"),
			new(HidKey.Paste, "Paste", "HID_KEY_PASTE"),
			new(HidKey.Find, "Find", "HID_KEY_FIND"),
			new(HidKey.MODE_CHANGE, "Mode Change", "KEY_MODE_CHANGE"),
		};

		public static KeyInfo? GetByCode(byte code) => AllKeys.FirstOrDefault(k => k.Code == code);
		public static KeyInfo? GetByDisplayName(string displayName) => AllKeys.FirstOrDefault(k => k.DisplayName == displayName);
		public static KeyInfo? GetByCppName(string cppName) => AllKeys.FirstOrDefault(k => k.CppConstName == cppName);
	}
}
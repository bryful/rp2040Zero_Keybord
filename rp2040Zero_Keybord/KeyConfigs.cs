using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO.Ports;
namespace rp2040Zero_Keybord
{

	// *********************************************************************************
	public class KeyConfigs
	{
		private string[] _layerNamesDef = new string[] {
			"Photoshop",
			"After Effects",
			"Illustrator",
			"Premiere Pro",
			"Application 5",
			"Application 6",
			"Application 7",
			"Application 8",
			"Application 9",
			"Application 10"
		};
		private byte[][] _ledColorsDef = new byte[][]
		{
			new byte[]{ 0, 0, 0},
			new byte[]{128, 0, 0},
			new byte[]{0, 128, 0},
			new byte[]{0, 0,128},
			new byte[]{0,128,128,},
			new byte[]{128,0,128,},
			new byte[]{128,128,0},
			new byte[]{128,128,128},
		};

		private LayerInfo[] layers = new LayerInfo[_LayerMaxCount];

		public byte ledRed
		{
			get
			{
				if (!IsSelected)
				{
					return 0;
				}
				return layers[m_SelectedIndex].ledR;
			}
			set
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].ledR = value;
				}
			}
		}
		public byte ledGreen
		{
			get
			{
				if (!IsSelected)
				{
					return 0;
				}
				return layers[m_SelectedIndex].ledG;
			}
			set
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].ledG = value;
				}
			}
		}
		public byte ledBlue
		{
			get
			{
				if (!IsSelected)
				{
					return 0;
				}
				return layers[m_SelectedIndex].ledB;
			}
			set
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].ledB = value;
				}
			}
		}
		public string[] LayerNames
		{
			get
			{
				List<string> names = new List<string>();

				for (int i = 0; i < _LayerCount; i++)
				{
					names.Add(NameChk(layers[i].layerName));
				}
				return names.ToArray();
			}
		}
		public string NameChk(string src)
		{
			var str = "";
			src = src.Trim();
			if (src.Length > 0)
			{
				for (int i = 0; i < src.Length; i++)
				{
					char c = src[i];
					if (c >= 'a' && c <= 'z'
						|| c >= 'A' && c <= 'Z'
						|| c >= '0' && c <= '9'
						|| c == '-' || c == '_' || c == '+' || c == '#' || c == '$' || c == '[' || c == ']' || c == ' ')
					{
						str += c;
						if (str.Length >= 16)
						{
							break;
						}
					}
				}
			}
			return str;
		}
		public string LayerName
		{
			get
			{
				if (!IsSelected)
				{
					return "";
				}
				return NameChk( layers[m_SelectedIndex].layerName);
			}
			set
			{

				if (IsSelected)
				{
					layers[m_SelectedIndex].layerName = NameChk(value);
				}
			}
		}


		private KeyIcons? _icons = null;

		public KeyIcons? Icons
		{
			get
			{
				return _icons;
			}
			set
			{
				_icons = value;
				if (_icons != null)
				{
					_icons.KeyConfigs = layers[m_SelectedIndex].Keys();
				}
			}
		}
		private RotaryEncoderSW? _rotaryEncoder1 = null;
		public RotaryEncoderSW? RotaryEncoder1
		{
			get
			{
				return _rotaryEncoder1;
			}
			set
			{
				_rotaryEncoder1 = value;
				if (_rotaryEncoder1 != null)
				{
					_rotaryEncoder1.keyConfigs = layers[m_SelectedIndex].Encoders(0);
				}
			}
		}
		private RotaryEncoderSW? _rotaryEncoder2 = null;
		public RotaryEncoderSW? RotaryEncoder2
		{
			get
			{
				return _rotaryEncoder2;
			}
			set
			{
				_rotaryEncoder2 = value;
				if (_rotaryEncoder2 != null)
				{
					_rotaryEncoder2.keyConfigs = layers[m_SelectedIndex].Encoders(1);
				}
			}
		}
		private LayerNav? _layerNav = null;
		public LayerNav? LayerNav
		{
			get { return _layerNav; }
			set
			{
				_layerNav = value;
				if (_layerNav != null)
				{
					_layerNav.KeyConfigs = this;
				}
			}
		}
		private const int _LayerMaxCount = 8;

		private int _LayerCount = 3;
		public int LayerCount
		{
			get
			{
				return _LayerCount;
			}
		}

		private int m_SelectedIndex = 0;

		private bool IsSelected
		{
			get { return SelectedIndex >= 0 && SelectedIndex < _LayerCount; }
		}


		public int SelectedIndex
		{
			get
			{
				return m_SelectedIndex;
			}
			set
			{
				SetSelectedIndex(value);
			}
		}
		public void SetSelectedIndex(int num_mode)
		{
			int newValue = num_mode;
			if (newValue < 0) newValue = 0;
			if (newValue >= _LayerCount) newValue = _LayerCount - 1;

			if (m_SelectedIndex != newValue)
			{
				if (_icons != null)
				{
					layers[m_SelectedIndex].SetKeys(_icons.KeyConfigs);
					_icons.KeyConfigs = layers[newValue].Keys();
					_icons.IconIndex = -1;
				}
				if (_rotaryEncoder1 != null)
				{
					layers[m_SelectedIndex].SetEncoders(0, _rotaryEncoder1.keyConfigs);
					_rotaryEncoder1.keyConfigs = layers[newValue].Encoders(0);
					_rotaryEncoder1.Invalidate();
				}
				if (_rotaryEncoder2 != null)
				{
					layers[m_SelectedIndex].SetEncoders(1, _rotaryEncoder2.keyConfigs);
					_rotaryEncoder2.keyConfigs = layers[newValue].Encoders(1);
					_rotaryEncoder2.Invalidate();
				}
				m_SelectedIndex = newValue;
			}
		}


		public void SetLayerInfo(int index, LayerInfo layer)
		{
			if (index >= 0 && index < _LayerCount)
			{
				layers[index].CopyFrom(layer);
			}
		}
		public LayerInfo GetLayerInfo(int index)
		{
			LayerInfo ret = new LayerInfo();
			if (index >= 0 && index < _LayerCount)
			{
				ret.CopyFrom(layers[index]);
			}
			return ret;
		}

		public KeyConfigs()
		{
			Initialize();
		}
		public void Initialize()
		{
			for (int layer = 0; layer < _LayerMaxCount; layer++)
			{
				layers[layer] = new LayerInfo();
				layers[layer].layerName = _layerNamesDef[layer % _LayerMaxCount];
				layers[layer].ledR = _ledColorsDef[layer % _ledColorsDef.Length][0];
				layers[layer].ledG = _ledColorsDef[layer % _ledColorsDef.Length][1];
				layers[layer].ledB = _ledColorsDef[layer % _ledColorsDef.Length][2];
			}
		}
		public void CopyFromIndex(int index)
		{
			if (m_SelectedIndex == index) return;

			if (index >= 0 && index < _LayerCount)
			{
				layers[m_SelectedIndex].CopyFrom(layers[index]);
				Pull();
			}


		}
		public void SwapAtIndex(int index)
		{
			if (m_SelectedIndex == index) return;

			if (index >= 0 && index < _LayerCount)
			{
				Push();
				LayerInfo temp = new LayerInfo();
				temp.CopyFrom(layers[m_SelectedIndex]);
				layers[m_SelectedIndex].CopyFrom(layers[index]);
				layers[index].CopyFrom(temp);
				m_SelectedIndex = index;
				Pull();
			}

		}
		public bool ItemUp()
		{
			bool ret = false;
			if (m_SelectedIndex > 0)
			{
				SwapAtIndex(m_SelectedIndex - 1);
				ret = true;
			}
			return ret;
		}
		public bool ItemDown()
		{
			bool ret = false;
			if (m_SelectedIndex < _LayerCount - 1)
			{
				SwapAtIndex(m_SelectedIndex + 1);
				ret = true;
			}
			return ret;
		}
		public void Push()
		{
			if (_icons != null)
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].SetKeys(_icons.KeyConfigs);
				}
			}
			if (_rotaryEncoder1 != null)
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].SetEncoders(0, _rotaryEncoder1.keyConfigs);
				}
			}
			if (_rotaryEncoder2 != null)
			{
				if (IsSelected)
				{
					layers[m_SelectedIndex].SetEncoders(1, _rotaryEncoder2.keyConfigs);
				}
			}
			if (_layerNav != null)
			{

			}
		}
		public void Pull()
		{
			if (_icons != null)
			{
				_icons.KeyConfigs = layers[m_SelectedIndex].Keys();
				_icons.Update();
			}
			if (_rotaryEncoder1 != null)
			{
				_rotaryEncoder1.keyConfigs = layers[m_SelectedIndex].Encoders(0);
				_rotaryEncoder1.Invalidate();
			}
			if (_rotaryEncoder2 != null)
			{
				_rotaryEncoder2.keyConfigs = layers[m_SelectedIndex].Encoders(1);
				_rotaryEncoder2.Invalidate();
			}
		}
		// *****************************************************************************
		// ================================================================================
		// 【新規追加】構造体 ⇔ バイト配列 相互変換用ヘルパー
		// ================================================================================
		private byte[] StructureToBytes<T>(T str) where T : struct
		{
			int size = Marshal.SizeOf(str);
			byte[] arr = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);

			Marshal.StructureToPtr(str, ptr, true);
			Marshal.Copy(ptr, arr, 0, size);
			Marshal.FreeHGlobal(ptr);

			return arr;
		}

		private T BytesToStructure<T>(byte[] arr) where T : struct
		{
			T str = new T();
			int size = Marshal.SizeOf(str);
			IntPtr ptr = Marshal.AllocHGlobal(size);

			Marshal.Copy(arr, 0, ptr, size);
			str = (T)Marshal.PtrToStructure(ptr, typeof(T));
			Marshal.FreeHGlobal(ptr);

			return str;
		}

		// ================================================================================
		// 【新規追加】バイナリファイルへの保存 (SAVE)
		// ================================================================================
		public void SaveToBinaryFile(string filePath)
		{
			try
			{
				Push(); // 画面上の最新データを layers 配列に同期

				int layerSize = Marshal.SizeOf(typeof(LayerInfo));
				int totalBinarySize = layerSize * _LayerMaxCount; // 97バイト × 8 ＝ 776バイト[cite: 6]

				// バッファを確保：[有効数 (1 byte)] + [生バイナリ全体 (776 bytes)] ＝ 計777バイト
				byte[] saveBuffer = new byte[1 + totalBinarySize];

				// 1バイト目に現在の有効数を格納
				saveBuffer[0] = (byte)_LayerCount; //[cite: 6]

				// layers 配列の内容を連続したバイナリにシリアライズ[cite: 6]
				for (int i = 0; i < _LayerMaxCount; i++) //[cite: 6]
				{
					byte[] layerBytes = StructureToBytes(layers[i]); //[cite: 6]
					Buffer.BlockCopy(layerBytes, 0, saveBuffer, 1 + (i * layerSize), layerSize);
				}

				// 一括ファイル書き込み
				File.WriteAllBytes(filePath, saveBuffer);
			}
			catch (Exception ex)
			{
				throw new IOException($"バイナリファイルの保存に失敗しました: {ex.Message}", ex);
			}
		}

		// ================================================================================
		// 【新規追加】バイナリファイルからの読み込み (LOAD)
		// ================================================================================
		public void LoadFromBinaryFile(string filePath)
		{
			try
			{
				if (!File.Exists(filePath)) return;

				byte[] readBuffer = File.ReadAllBytes(filePath);

				int layerSize = Marshal.SizeOf(typeof(LayerInfo));
				int totalBinarySize = layerSize * _LayerMaxCount; // 776バイト[cite: 6]

				// ファイルサイズが正しいか検証 (1 + 776 = 777バイト)
				if (readBuffer.Length < 1 + totalBinarySize)
				{
					throw new FormatException("ファイルサイズが不正なため、キーマップを復元できません。");
				}

				// 1バイト目から有効数を復元
				_LayerCount = readBuffer[0]; //[cite: 6]
				if (_LayerCount > _LayerMaxCount) _LayerCount = _LayerMaxCount; //[cite: 6]

				// バイナリから各 LayerInfo 構造体を復元して配列へ展開[cite: 6]
				byte[] singleLayerBuffer = new byte[layerSize];
				for (int i = 0; i < _LayerMaxCount; i++) //[cite: 6]
				{
					Buffer.BlockCopy(readBuffer, 1 + (i * layerSize), singleLayerBuffer, 0, layerSize);
					layers[i] = BytesToStructure<LayerInfo>(singleLayerBuffer); //[cite: 6]
				}

				// 選択インデックスの安全策
				if (m_SelectedIndex >= _LayerCount) //[cite: 6]
				{
					m_SelectedIndex = 0; //[cite: 6]
				}

				Pull(); // 復元したデータを画面（UI）側に反映[cite: 6]
			}
			catch (Exception ex)
			{
				//throw new IOException($"バイナリファイルの読み込みに失敗しました: {ex.Message}", ex);
			}
		}
		// ================================================================================
		// 【新規追加】USB接続されたマイコン（RP2040）へ設定を一撃送信 (SAVE)
		// ================================================================================
		public bool SendConfigToDevice(SerialPortInfo info)
		{
			if (!info.IsValid)
			{
				MessageBox.Show("有効なシリアルポートが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			try
			{
				Push(); // 画面上の最新データを layers 配列に完全同期

				int layerSize = Marshal.SizeOf(typeof(LayerInfo)); // 97
				int totalBinarySize = layerSize * _LayerMaxCount; // 97 * 8 = 776

				// 送信バッファ確保 [有効数 (1 byte)] + [生バイナリ全体 (776 bytes)] = 777 bytes
				byte[] sendBuffer = new byte[1 + totalBinarySize];
				sendBuffer[0] = (byte)_LayerCount; // 1バイト目に現在の有効数を格納

				// 全レイヤーをバイナリ化してバッファに敷き詰める
				for (int i = 0; i < _LayerMaxCount; i++)
				{
					// 配列内の未初期化（null）バグを防ぐ安全策
					if (layers[i].matrix == null) layers[i].matrix = new KeyConfig[(int)KEYMAT_SIZE.SIZE];
					if (layers[i].encoders == null) layers[i].encoders = new KeyConfig[(int)KEYMAT_SIZE.R_SIZE];

					byte[] layerBytes = StructureToBytes(layers[i]);
					Buffer.BlockCopy(layerBytes, 0, sendBuffer, 1 + (i * layerSize), layerSize);
				}

				// シリアル通信ポートを開いてコマンド処理を実行
				using (SerialPort serial = new SerialPort(info.PortName, 115200))
				{
					serial.DtrEnable = info.DtrEnable; // DTRを有効にしてマイコンのリセットを促す
					serial.RtsEnable = info.RtsEnable;
					serial.ReadTimeout = 2000;
					serial.WriteTimeout = 2000;
					serial.Open();

					// マイコンへ保存セッション開始を要求
					serial.Write("SAVE_CONFIG\n");

					// マイコンからの受け入れ完了「READY」の返事を確認
					string response = serial.ReadLine().Trim();
					if (response != "READY") return false;

					// 777バイトのバイナリストリームを流し込む
					serial.Write(sendBuffer, 0, sendBuffer.Length);

					// LittleFSへの書き込みが成功したかの結果「SUCCESS」を受け取る
					string result = serial.ReadLine().Trim();
					return result == "SUCCESS";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"マイコンへの設定転送に失敗しました:\n{ex.Message}", "通信エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		// ================================================================================
		// 【新規追加】USB接続されたマイコン（RP2040）から現在の設定を逆吸い出し (LOAD)
		// ================================================================================
		public bool ReceiveConfigFromDevice(SerialPortInfo info)
		{
			if (!info.IsValid)
			{
				MessageBox.Show("有効なシリアルポートが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			try
			{
				int layerSize = Marshal.SizeOf(typeof(LayerInfo)); // 97
				int totalBinarySize = layerSize * _LayerMaxCount; // 776

				using (SerialPort serial = new SerialPort(info.PortName, 115200))
				{
					serial.DtrEnable = info.DtrEnable; // DTRを有効にしてマイコンのリセットを促す
					serial.RtsEnable = info.RtsEnable;
					serial.ReadTimeout = 3000;
					serial.Open();

					// マイコンへロードセッション開始を要求
					serial.Write("LOAD_CONFIG\n");

					// 1. 最初の1バイト目（有効レイヤー数）を受信
					int firstByte = serial.ReadByte();
					if (firstByte == -1) return false;

					_LayerCount = (int)((byte)firstByte);
					if (_LayerCount > _LayerMaxCount) _LayerCount = _LayerMaxCount;

					// 2. 残りの連続した全レイヤーバイナリ（776バイト）を受信
					byte[] readBuffer = new byte[totalBinarySize];
					int received = 0;
					while (received < totalBinarySize)
					{
						int amt = serial.Read(readBuffer, received, totalBinarySize - received);
						if (amt <= 0) break;
						received += amt;
					}

					if (received < totalBinarySize) return false;

					// 3. 各 LayerInfo 構造体に切り分けて配列に復元展開
					byte[] singleLayerBuffer = new byte[layerSize];
					for (int i = 0; i < _LayerMaxCount; i++)
					{
						Buffer.BlockCopy(readBuffer, i * layerSize, singleLayerBuffer, 0, layerSize);
						layers[i] = BytesToStructure<LayerInfo>(singleLayerBuffer);
					}

					// インデックスがはみ出さないように安全リセット
					if (m_SelectedIndex >= _LayerCount) m_SelectedIndex = 0;

					Pull(); // ロードした内容を画面（UI）側にマッピング
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"マイコンからの設定吸い出しに失敗しました:\n{ex.Message}", "通信エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public string ToCpp()
		{
			var sb = new StringBuilder();

			// ヘッダーコメント
			sb.AppendLine("// Auto-generated key configuration");
			sb.AppendLine("// Generated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			sb.AppendLine();

			// 定数定義
			sb.AppendLine("#define NUM_MODES " + _LayerMaxCount);
			sb.AppendLine("#define ENCODER_COUNT 2");
			sb.AppendLine();

			// keyMaps配列の生成
			sb.AppendLine("KeyConfig keyMaps[NUM_MODES][4][5] = {");

			for (int layer = 0; layer < _LayerMaxCount; layer++)
			{
				sb.AppendLine("    {");

				for (int row = 0; row < 4; row++)
				{
					sb.Append("        {");
					for (int col = 0; col < 5; col++)
					{
						var config = layers[layer].KeyAt(row, col);
						sb.Append($"{{{FormatModifier(config.modifier)}, {FormatKeycode(config.keycode)}, {FormatMouse(config.mouse)}}}");

						if (col < 4)
							sb.Append(", ");
					}
					sb.Append("}");

					if (row < 3)
						sb.AppendLine(",");
					else
						sb.AppendLine("}");
				}

				if (layer < _LayerMaxCount - 1)
					sb.AppendLine(",");
			}

			sb.AppendLine("};");
			sb.AppendLine();

			// encoderMaps配列の生成
			sb.AppendLine("KeyConfig encoderMaps[NUM_MODES][ENCODER_COUNT][3] = {");

			for (int layer = 0; layer < _LayerMaxCount; layer++)
			{
				sb.AppendLine("    {");

				for (int encoder = 0; encoder < 2; encoder++)
				{
					sb.AppendLine($"        // Enc{encoder}");
					sb.Append("        {");

					RotaryEncoder encoderConfig = layers[layer].REncodetor(encoder);
					KeyConfig[] configs = new KeyConfig[3] { encoderConfig.CW, encoderConfig.CCW, encoderConfig.SW };
					for (int value = 0; value < 3; value++) // CW, CCW, SW
					{
						var config = configs[value];
						sb.Append($"{{{FormatModifier(config.modifier)}, {FormatKeycode(config.keycode)}, {FormatMouse(config.mouse)}}}");

						if (value < 2)
							sb.Append(", ");
					}
					sb.Append("}");

					if (encoder < 1)
						sb.AppendLine(",");
					else
						sb.AppendLine();
				}

				sb.Append("    }");

				if (layer < _LayerMaxCount - 1)
					sb.AppendLine(",");
				else
					sb.AppendLine();
			}

			sb.AppendLine("};");
			return sb.ToString();
		}
		/// <summary>
		/// C++形式（RP2040ファームウェア用）でキー設定を書き出します
		/// </summary>
		/// <param name="filePath">保存先ファイルパス（.hまたは.cpp）</param>
		public void SaveToCppFile(string filePath)
		{
			try
			{
				Push(); // 現在の設定を保存
				File.WriteAllText(filePath, ToCpp(), Encoding.UTF8);
			}
			catch (Exception ex)
			{
				throw new IOException($"C++ファイルの書き出しに失敗しました: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// ModifierをC++形式でフォーマット
		/// </summary>
		private string FormatModifier(byte modifier)
		{
			if (modifier == 0) return "0";

			var parts = new List<string>();
			var mod = (KeyboardModifier)modifier;

			if (mod.HasFlag(KeyboardModifier.LeftCtrl)) parts.Add("KEYBOARD_MODIFIER_LEFTCTRL");
			if (mod.HasFlag(KeyboardModifier.LeftShift)) parts.Add("KEYBOARD_MODIFIER_LEFTSHIFT");
			if (mod.HasFlag(KeyboardModifier.LeftAlt)) parts.Add("KEYBOARD_MODIFIER_LEFTALT");
			if (mod.HasFlag(KeyboardModifier.LeftGui)) parts.Add("KEYBOARD_MODIFIER_LEFTGUI");
			if (mod.HasFlag(KeyboardModifier.RightCtrl)) parts.Add("KEYBOARD_MODIFIER_RIGHTCTRL");
			if (mod.HasFlag(KeyboardModifier.RightShift)) parts.Add("KEYBOARD_MODIFIER_RIGHTSHIFT");
			if (mod.HasFlag(KeyboardModifier.RightAlt)) parts.Add("KEYBOARD_MODIFIER_RIGHTALT");
			if (mod.HasFlag(KeyboardModifier.RightGui)) parts.Add("KEYBOARD_MODIFIER_RIGHTGUI");

			return parts.Count > 0 ? string.Join(" | ", parts) : "0";
		}

		/// <summary>
		/// KeycodeをC++形式でフォーマット
		/// </summary>
		private string FormatKeycode(byte keycode)
		{
			var keyInfo = KeyDatabase.GetByCode(keycode);
			return keyInfo?.CppConstName ?? $"0x{keycode:X2}";
		}

		/// <summary>
		/// MouseをC++形式でフォーマット
		/// </summary>
		private string FormatMouse(ClickType mouse)
		{
			if (mouse == ClickType.NONE) return "NONE";

			var parts = new List<string>();

			if ((mouse & ClickType.MOUSE_L) != 0) parts.Add("MOUSE_L");
			if ((mouse & ClickType.MOUSE_R) != 0) parts.Add("MOUSE_R");
			if ((mouse & ClickType.MOUSE_M) != 0) parts.Add("MOUSE_M");

			return parts.Count > 0 ? string.Join(" | ", parts) : "NONE";
		}
		public void SaveSettings()
		{
			try
			{
				using (var dialog = new SaveFileDialog())
				{
					dialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";
					dialog.DefaultExt = "dat";

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						SaveToBinaryFile(dialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"保存に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void LoadSettings()
		{
			try
			{
				using (var dialog = new OpenFileDialog())
				{
					dialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						LoadFromBinaryFile(dialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"読み込みに失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public void Clear()
		{
			layers[m_SelectedIndex].Clear();
			Pull();
		}
		public void Delete()
		{
			for (int i = m_SelectedIndex; i < _LayerCount - 1; i++)
			{
				layers[i].CopyFrom(layers[i + 1]);
			}
			layers[_LayerCount - 1].Clear();
			Pull();
			if (m_SelectedIndex >= _LayerCount - 1)
			{
				m_SelectedIndex = _LayerCount - 2;
				if (m_SelectedIndex < 0) m_SelectedIndex = 0;
				Pull();
			}
			_LayerCount--;
		}
		public void Insert()
		{
			if (_LayerCount >= _LayerMaxCount) return;
			for (int i = _LayerCount; i > m_SelectedIndex; i--)
			{
				layers[i].CopyFrom(layers[i - 1]);
			}
			layers[m_SelectedIndex].Clear();
			Pull();
			_LayerCount++;
		}
	}
}

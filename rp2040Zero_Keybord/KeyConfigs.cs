using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace rp2040Zero_Keybord
{
	// ファイル保存用のデータ構造
	public class KeyConfigData
	{
		public byte Modifier { get; set; }
		public byte Keycode { get; set; }
		public byte Mouse { get; set; }

		public KeyConfigData() { }

		public KeyConfigData(KeyConfig config)
		{
			Modifier = config.modifier;
			Keycode = config.keycode;
			Mouse = config.mouse;
		}

		public KeyConfig ToKeyConfig()
		{
			return new KeyConfig
			{
				modifier = Modifier,
				keycode = Keycode,
				mouse = Mouse
			};
		}
	}
	public class KeyMapsData
	{
		public KeyConfigData[][][] KeyMaps { get; set; } = null!;
		public KeyConfigData[][][] EncoderMaps { get; set; } = null!;
		public int Version { get; set; } = 1;
	}
	public class KeyConfigs
	{
		private KeyConfig[][][] keyMaps = new KeyConfig[LayerCount][][]; // 4 layers, 4 rows, 5 columns
		private KeyConfig[][][] EncoderMaps = new KeyConfig[LayerCount][][]; // 4 layers, 2 count, 3 value

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
					_icons.KeyConfigs = GetKeyConfigs(m_num_mode);
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
					_rotaryEncoder1.keyConfigs = GetEncoderConfigs(m_num_mode,0);
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
					_rotaryEncoder2.keyConfigs = GetEncoderConfigs(m_num_mode, 1);
				}
			}
		}
		public const int num_mode_max = 4;
		private const int LayerCount = 4;

		private int m_num_mode = 0;


		public int NumMode
		{
			get
			{
				return m_num_mode;
			}
			set
			{
				SetNumMode(value);
			}
		}
		public void SetNumMode(int num_mode)
		{
			int newValue = num_mode;
			if (newValue < 0) newValue = 0;
			if (newValue >= num_mode_max) newValue = num_mode_max - 1;

			if (m_num_mode != newValue)
			{
				if (_icons != null)
				{
					SetKeyConfigs(m_num_mode, _icons.KeyConfigs);
					_icons.KeyConfigs = GetKeyConfigs(newValue);
					_icons.IconIndex = -1;
				}
				if (_rotaryEncoder1 != null)
				{
					SetEncoderConfigs(m_num_mode, 0, _rotaryEncoder1.keyConfigs);
					_rotaryEncoder1.keyConfigs = GetEncoderConfigs(newValue, 0);
					_rotaryEncoder1.Invalidate();
				}
				if (_rotaryEncoder2 != null)
				{
					SetEncoderConfigs(m_num_mode, 1, _rotaryEncoder2.keyConfigs);
					_rotaryEncoder2.keyConfigs = GetEncoderConfigs(newValue, 1);
					_rotaryEncoder2.Invalidate();
				}
				m_num_mode = newValue;
			}
			else
			{
				if (_icons != null)
				{
					SetKeyConfigs(m_num_mode, _icons.KeyConfigs);
				}
				if (_rotaryEncoder1 != null)
				{
					SetEncoderConfigs(m_num_mode, 0 ,_rotaryEncoder1.keyConfigs);
				}
				if (_rotaryEncoder2 != null)
				{
					SetEncoderConfigs(m_num_mode,1, _rotaryEncoder2.keyConfigs);
				}
			}

		}


		public void SetKeyConfigs(int index, KeyConfig[] config)
		{
			if (index >= 0 && index < LayerCount)
			{
				for (int row = 0; row < 4; row++)
				{
					for (int col = 0; col < 5; col++)
					{
						int configIndex = row * 5 + col;
						if (configIndex < config.Length)
						{
							// 修正: ディープコピー
							keyMaps[index][row][col].modifier = config[configIndex].modifier;
							keyMaps[index][row][col].keycode = config[configIndex].keycode;
							keyMaps[index][row][col].mouse = config[configIndex].mouse;
						}
						else
						{
							keyMaps[index][row][col] = new KeyConfig(); // デフォルトのKeyConfigを設定
						}
					}
				}
			}
		}
		public KeyConfig[] GetKeyConfigs(int index)
		{
			if (index >= 0 && index < LayerCount)
			{
				List<KeyConfig> configs = new List<KeyConfig>();
				for (int row = 0; row < 4; row++)
				{
					for (int col = 0; col < 5; col++)
					{
						// 修正: 新しいインスタンスを返す
						configs.Add(new KeyConfig
						{
							modifier = keyMaps[index][row][col].modifier,
							keycode = keyMaps[index][row][col].keycode,
							mouse = keyMaps[index][row][col].mouse
						});
					}
				}
				return configs.ToArray();
			}
			else
			{
				List<KeyConfig> configs = new List<KeyConfig>();

				for (int row = 0; row < 4; row++)
				{
					for (int col = 0; col < 5; col++)
					{
						configs.Add(new KeyConfig());
					}
				}
				return configs.ToArray();
			}
		}
		public void SetEncoderConfigs(int index,int encoderIndex, KeyConfig[] config)
		{
			if (index >= 0 && index < LayerCount)
			{
				if (encoderIndex<0) encoderIndex = 0;
				else if (encoderIndex>=2) encoderIndex = 1;

				for (int value = 0; value < 3; value++)
					// 修正: ディープコピーする
					if (value < config.Length)
					{
						EncoderMaps[index][encoderIndex][value].modifier = config[value].modifier;
						EncoderMaps[index][encoderIndex][value].keycode = config[value].keycode;
						EncoderMaps[index][encoderIndex][value].mouse = config[value].mouse;
					}

			}
		}
		public KeyConfig[] GetEncoderConfigs(int index, int encoderIndex)
		{

			if (index >= 0 && index < LayerCount)
			{
				if (encoderIndex < 0) encoderIndex = 0;
				else if (encoderIndex >= 2) encoderIndex = 1;

				List<KeyConfig> configs = new List<KeyConfig>();
				for (int value = 0; value < 3; value++)
				{
					// 修正: 新しいインスタンスを返す
					configs.Add(new KeyConfig
					{
						modifier = EncoderMaps[index][encoderIndex][value].modifier,
						keycode = EncoderMaps[index][encoderIndex][value].keycode,
						mouse = EncoderMaps[index][encoderIndex][value].mouse
					});
				}
				return configs.ToArray();
			}
			else
			{
				List<KeyConfig> configs = new List<KeyConfig>();
				for (int value = 0; value < 3; value++)
				{
					configs.Add(new KeyConfig());
				}
				return configs.ToArray();
			}
		}
		public KeyConfigs()
		{
			Initialize();
		}
		public void Initialize()
		{
			for (int layer = 0; layer < LayerCount; layer++)
			{
				keyMaps[layer] = new KeyConfig[4][];
				for (int row = 0; row < 4; row++)
				{
					keyMaps[layer][row] = new KeyConfig[5];
					for (int col = 0; col < 5; col++)
					{
						keyMaps[layer][row][col] = new KeyConfig();
					}
				}
				EncoderMaps[layer] = new KeyConfig[2][];
				for (int count = 0; count < 2; count++)
				{
					EncoderMaps[layer][count] = new KeyConfig[3];
					for (int value = 0; value < 3; value++)
					{
						EncoderMaps[layer][count][value] = new KeyConfig();
					}
				}
			}
		}
		public void CopyFromIndex(int index)
		{
			if (m_num_mode == index) return;

			if (index >= 0 && index < LayerCount)
			{
				var sourceKeyConfigs = GetKeyConfigs(index);
				SetKeyConfigs(m_num_mode, sourceKeyConfigs);
				for (int encoderIndex = 0; encoderIndex < 2; encoderIndex++)
				{
					var sourceEncoderConfigs = GetEncoderConfigs(index, encoderIndex);
					SetEncoderConfigs(m_num_mode, encoderIndex, sourceEncoderConfigs);
				}
				Pull();
			}
			
		}
		public void Push()
		{
			if (_icons != null)
			{
				SetKeyConfigs(m_num_mode, _icons.KeyConfigs);
			}
			if (_rotaryEncoder1 != null)
			{
				var configs = _rotaryEncoder1.keyConfigs;
				System.Diagnostics.Debug.WriteLine($"Push Encoder1[0]: modifier={configs[0].modifier}, keycode={configs[0].keycode}, mouse={configs[0].mouse}");
				SetEncoderConfigs(m_num_mode,0, _rotaryEncoder1.keyConfigs);
			}
			if (_rotaryEncoder2 != null)
			{
				var configs = _rotaryEncoder2.keyConfigs;
				System.Diagnostics.Debug.WriteLine($"Push Encoder2[0]: modifier={configs[0].modifier}, keycode={configs[0].keycode}, mouse={configs[0].mouse}");
				SetEncoderConfigs(m_num_mode, 1, _rotaryEncoder2.keyConfigs);
			}
		}
		public void Pull()
		{
			if (_icons != null)
			{
				_icons.KeyConfigs = GetKeyConfigs(m_num_mode);
			}
			if (_rotaryEncoder1 != null)
			{
				_rotaryEncoder1.keyConfigs = GetEncoderConfigs(m_num_mode, 0);
				_rotaryEncoder1.Invalidate();
			}
			if (_rotaryEncoder2 != null)
			{
				_rotaryEncoder2.keyConfigs = GetEncoderConfigs(m_num_mode, 1);
				_rotaryEncoder2.Invalidate();
			}
		}
		public string ToJson()
		{
			Push();
			// KeyConfig配列をシリアライズ可能な形式に変換
			var data = new KeyMapsData
			{
				Version = 1,
				KeyMaps = ConvertKeyMapsToData(keyMaps),
				EncoderMaps = ConvertKeyMapsToData(EncoderMaps)
			};

			// JSON形式で保存
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,
				Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};

			string jsonString = JsonSerializer.Serialize(data, options);
			return jsonString;
		}
		// ********************************************************************************
		/// <summary>
		/// キー設定をJSONファイルに保存します
		/// </summary>
		/// <param name="filePath">保存先ファイルパス</param>
		public void SaveToFile(string filePath)
		{
			try
			{
				
				File.WriteAllText(filePath, ToJson(), Encoding.UTF8);
			}
			catch (Exception ex)
			{
				throw new IOException($"キー設定の保存に失敗しました: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// JSONファイルからキー設定を読み込みます
		/// </summary>
		/// <param name="filePath">読み込み元ファイルパス</param>
		public void LoadFromFile(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					throw new FileNotFoundException($"ファイルが見つかりません: {filePath}");
				}

				string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
				var data = JsonSerializer.Deserialize<KeyMapsData>(jsonString);

				if (data == null)
				{
					throw new InvalidDataException("ファイルの読み込みに失敗しました");
				}

				// バージョンチェック
				if (data.Version != 1)
				{
					throw new InvalidDataException($"サポートされていないバージョンです: {data.Version}");
				}

				// データを復元
				ConvertDataToKeyMaps(data.KeyMaps, keyMaps);
				ConvertDataToKeyMaps(data.EncoderMaps, EncoderMaps);

				// UIに反映
				Pull();
			}
			catch (JsonException ex)
			{
				throw new InvalidDataException($"JSONの解析に失敗しました: {ex.Message}", ex);
			}
			catch (Exception ex)
			{
				throw new IOException($"キー設定の読み込みに失敗しました: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// バイナリ形式で保存（よりコンパクト）
		/// </summary>
		/// <param name="filePath">保存先ファイルパス</param>
		public void SaveToBinaryFile(string filePath)
		{
			try
			{
				Push();
				// デバッグ: 保存前のEncoderMaps[0][0][0]の値を確認
				System.Diagnostics.Debug.WriteLine($"保存前 EncoderMaps[0][0][0]: modifier={EncoderMaps[0][0][0].modifier}, keycode={EncoderMaps[0][0][0].keycode}, mouse={EncoderMaps[0][0][0].mouse}");
				System.Diagnostics.Debug.WriteLine($"保存前 EncoderMaps[0][1][0]: modifier={EncoderMaps[0][1][0].modifier}, keycode={EncoderMaps[0][1][0].keycode}, mouse={EncoderMaps[0][1][0].mouse}");

				using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
				{
					// ヘッダー: マジックナンバーとバージョン
					writer.Write(0x4B4D5031); // "KMP1" (Key Map v1)
					writer.Write((byte)1);     // Version

					// KeyMaps保存
					WriteKeyMapsToStream(writer, keyMaps);

					// EncoderMaps保存
					WriteKeyMapsToStream(writer, EncoderMaps);
				}
			}
			catch (Exception ex)
			{
				throw new IOException($"バイナリ保存に失敗しました: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// バイナリ形式から読み込み
		/// </summary>
		/// <param name="filePath">読み込み元ファイルパス</param>
		public bool LoadFromBinaryFile(string filePath)
		{
			bool ret = false;
			try
			{
				if (!File.Exists(filePath))
				{
					return ret;
				}

				using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
				{
					// ヘッダー検証
					int magic = reader.ReadInt32();
					if (magic != 0x4B4D5031)
					{
						throw new InvalidDataException("無効なファイル形式です");
					}

					byte version = reader.ReadByte();
					if (version != 1)
					{
						return ret;
					}

					// KeyMaps読み込み
					ReadKeyMapsFromStream(reader, keyMaps);

					// EncoderMaps読み込み
					ReadKeyMapsFromStream(reader, EncoderMaps);
				}
				// デバッグ: 読み込み後のEncoderMaps[0][0][0]の値を確認
				System.Diagnostics.Debug.WriteLine($"読込後 EncoderMaps[0][0][0]: modifier={EncoderMaps[0][0][0].modifier}, keycode={EncoderMaps[0][0][0].keycode}, mouse={EncoderMaps[0][0][0].mouse}");
				System.Diagnostics.Debug.WriteLine($"読込後 EncoderMaps[0][1][0]: modifier={EncoderMaps[0][1][0].modifier}, keycode={EncoderMaps[0][1][0].keycode}, mouse={EncoderMaps[0][1][0].mouse}");

				// UIに反映
				Pull();
				ret = true;
			}
			catch (Exception ex)
			{
				throw new IOException($"バイナリ読み込みに失敗しました: {ex.Message}", ex);
			}
			return ret;
		}

		#region Private Helper Methods

		private KeyConfigData[][][] ConvertKeyMapsToData(KeyConfig[][][] source)
		{
			var result = new KeyConfigData[source.Length][][];
			for (int i = 0; i < source.Length; i++)
			{
				result[i] = new KeyConfigData[source[i].Length][];
				for (int j = 0; j < source[i].Length; j++)
				{
					result[i][j] = new KeyConfigData[source[i][j].Length];
					for (int k = 0; k < source[i][j].Length; k++)
					{
						result[i][j][k] = new KeyConfigData(source[i][j][k]);
					}
				}
			}
			return result;
		}

		private void ConvertDataToKeyMaps(KeyConfigData[][][] source, KeyConfig[][][] target)
		{
			for (int i = 0; i < source.Length && i < target.Length; i++)
			{
				for (int j = 0; j < source[i].Length && j < target[i].Length; j++)
				{
					for (int k = 0; k < source[i][j].Length && k < target[i][j].Length; k++)
					{
						target[i][j][k] = source[i][j][k].ToKeyConfig();
					}
				}
			}
		}

		private void WriteKeyMapsToStream(BinaryWriter writer, KeyConfig[][][] maps)
		{
			writer.Write((byte)maps.Length);
			for (int i = 0; i < maps.Length; i++)
			{
				writer.Write((byte)maps[i].Length);
				for (int j = 0; j < maps[i].Length; j++)
				{
					writer.Write((byte)maps[i][j].Length);
					for (int k = 0; k < maps[i][j].Length; k++)
					{
						writer.Write(maps[i][j][k].modifier);
						writer.Write(maps[i][j][k].keycode);
						writer.Write(maps[i][j][k].mouse);
					}
				}
			}
		}

		private void ReadKeyMapsFromStream(BinaryReader reader, KeyConfig[][][] maps)
		{
			int layerCount = reader.ReadByte();
			for (int i = 0; i < layerCount && i < maps.Length; i++)
			{
				int rowCount = reader.ReadByte();
				for (int j = 0; j < rowCount && j < maps[i].Length; j++)
				{
					int colCount = reader.ReadByte();
					for (int k = 0; k < colCount && k < maps[i][j].Length; k++)
					{
						maps[i][j][k].modifier = reader.ReadByte();
						maps[i][j][k].keycode = reader.ReadByte();
						maps[i][j][k].mouse = reader.ReadByte();
					}
				}
			}
		}

		#endregion

		public string ToCpp()
		{
			var sb = new StringBuilder();

			// ヘッダーコメント
			sb.AppendLine("// Auto-generated key configuration");
			sb.AppendLine("// Generated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			sb.AppendLine();

			// 定数定義
			sb.AppendLine("#define NUM_MODES " + LayerCount);
			sb.AppendLine("#define ENCODER_COUNT 2");
			sb.AppendLine();

			// keyMaps配列の生成
			sb.AppendLine("KeyConfig keyMaps[NUM_MODES][4][5] = {");

			for (int layer = 0; layer < LayerCount; layer++)
			{
				string layerComment = layer switch
				{
					0 => "固定キー (Default)",
					1 => "PhotoShop",
					2 => "AfterEffects",
					3 => "Custom",
					_ => $"Layer {layer}"
				};

				sb.AppendLine($"    // --- {layer}. {layerComment} ---");
				sb.AppendLine("    {");

				for (int row = 0; row < 4; row++)
				{
					sb.Append("        {");
					for (int col = 0; col < 5; col++)
					{
						var config = keyMaps[layer][row][col];
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

				if (layer < LayerCount - 1)
					sb.AppendLine(",");
			}

			sb.AppendLine("};");
			sb.AppendLine();

			// encoderMaps配列の生成
			sb.AppendLine("KeyConfig encoderMaps[NUM_MODES][ENCODER_COUNT][3] = {");

			for (int layer = 0; layer < LayerCount; layer++)
			{
				string layerComment = layer switch
				{
					0 => "固定キー (Default)",
					1 => "PhotoShop",
					2 => "AfterEffects",
					3 => "Custom",
					_ => $"Layer {layer}"
				};

				sb.AppendLine($"    // --- {layer}. {layerComment} ---");
				sb.AppendLine("    {");

				for (int encoder = 0; encoder < 2; encoder++)
				{
					sb.AppendLine($"        // Enc{encoder}");
					sb.Append("        {");

					for (int value = 0; value < 3; value++) // CW, CCW, SW
					{
						var config = EncoderMaps[layer][encoder][value];
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

				if (layer < LayerCount - 1)
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
				/*
				var sb = new StringBuilder();

				// ヘッダーコメント
				sb.AppendLine("// Auto-generated key configuration");
				sb.AppendLine("// Generated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				sb.AppendLine();

				// 定数定義
				sb.AppendLine("#define NUM_MODES " + LayerCount);
				sb.AppendLine("#define ENCODER_COUNT 2");
				sb.AppendLine();

				// keyMaps配列の生成
				sb.AppendLine("KeyConfig keyMaps[NUM_MODES][4][5] = {");

				for (int layer = 0; layer < LayerCount; layer++)
				{
					string layerComment = layer switch
					{
						0 => "固定キー (Default)",
						1 => "PhotoShop",
						2 => "AfterEffects",
						3 => "Custom",
						_ => $"Layer {layer}"
					};

					sb.AppendLine($"    // --- {layer}. {layerComment} ---");
					sb.AppendLine("    {");

					for (int row = 0; row < 4; row++)
					{
						sb.Append("        {");
						for (int col = 0; col < 5; col++)
						{
							var config = keyMaps[layer][row][col];
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

					if (layer < LayerCount - 1)
						sb.AppendLine(",");
				}

				sb.AppendLine("};");
				sb.AppendLine();

				// encoderMaps配列の生成
				sb.AppendLine("KeyConfig encoderMaps[NUM_MODES][ENCODER_COUNT][3] = {");

				for (int layer = 0; layer < LayerCount; layer++)
				{
					string layerComment = layer switch
					{
						0 => "固定キー (Default)",
						1 => "PhotoShop",
						2 => "AfterEffects",
						3 => "Custom",
						_ => $"Layer {layer}"
					};

					sb.AppendLine($"    // --- {layer}. {layerComment} ---");
					sb.AppendLine("    {");

					for (int encoder = 0; encoder < 2; encoder++)
					{
						sb.AppendLine($"        // Enc{encoder}");
						sb.Append("        {");

						for (int value = 0; value < 3; value++) // CW, CCW, SW
						{
							var config = EncoderMaps[layer][encoder][value];
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

					if (layer < LayerCount - 1)
						sb.AppendLine(",");
					else
						sb.AppendLine();
				}

				sb.AppendLine("};");
				*/

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
		private string FormatMouse(byte mouse)
		{
			if (mouse == 0) return "NONE";

			var parts = new List<string>();

			if ((mouse & Mouse.Left) != 0) parts.Add("MOUSE_L");
			if ((mouse & Mouse.Right) != 0) parts.Add("MOUSE_R");
			if ((mouse & Mouse.Middle) != 0) parts.Add("MOUSE_M");
			// 必要に応じてMouse定数にBack/Forwardを追加
			if ((mouse & 0x08) != 0) parts.Add("MOUSE_BACK");
			if ((mouse & 0x10) != 0) parts.Add("MOUSE_FORWARD");

			return parts.Count > 0 ? string.Join(" | ", parts) : "NONE";
		}
		public void SaveSettings()
		{
			try
			{
				using (var dialog = new SaveFileDialog())
				{
					dialog.Filter = "JSON Files (*.json)|*.json|Binary Files (*.kmp)|*.kmp|All Files (*.*)|*.*";
					dialog.DefaultExt = "json";

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						if (dialog.FileName.EndsWith(".kmp"))
						{
							SaveToBinaryFile(dialog.FileName);
						}
						else
						{
							SaveToFile(dialog.FileName);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"保存に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// JSON形式で読み込み
		public void LoadSettings()
		{
			try
			{
				using (var dialog = new OpenFileDialog())
				{
					dialog.Filter = "JSON Files (*.json)|*.json|Binary Files (*.kmp)|*.kmp|All Files (*.*)|*.*";

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						if (dialog.FileName.EndsWith(".kmp"))
						{
							LoadFromBinaryFile(dialog.FileName);
						}
						else
						{
							LoadFromFile(dialog.FileName);
						}
						MessageBox.Show("設定を読み込みました", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			keyMaps[m_num_mode] = new KeyConfig[4][];
			for (int row = 0; row < 4; row++)
			{
				keyMaps[m_num_mode][row] = new KeyConfig[5];
				for (int col = 0; col < 5; col++)
				{
					keyMaps[m_num_mode][row][col] = new KeyConfig();
				}
			}
			EncoderMaps[m_num_mode] = new KeyConfig[2][];
			for (int count = 0; count < 2; count++)
			{
				EncoderMaps[m_num_mode][count] = new KeyConfig[3];
				for (int value = 0; value < 3; value++)
				{
					EncoderMaps[m_num_mode][count][value] = new KeyConfig();
				}
			}
			Pull();
		}
	}
}

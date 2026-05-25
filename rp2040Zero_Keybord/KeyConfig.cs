using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO.Ports;
namespace rp2040Zero_Keybord
{
	public enum ClickType : byte
	{
		NONE = 0,
		MOUSE_L = 1, // MOUSE_LEFT
		MOUSE_R = 2, // MOUSE_RIGHT
		MOUSE_M = 4  // MOUSE_MIDDLE
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct KeyConfig
	{
		public byte modifier = 0;
		public byte keycode  = 0;
		public ClickType mouse = ClickType.NONE;
		public KeyConfig(byte modifier, byte keycode, ClickType mouse)
		{
			this.modifier = modifier;
			this.keycode = keycode;
			this.mouse = mouse;
		}
		public KeyConfig()
		{
			this.modifier = 0;
			this.keycode = 0;
			this.mouse = ClickType.NONE;
		}
	}
	
	public struct RotaryEncoder
	{
		public KeyConfig CW  = new KeyConfig();
		public KeyConfig CCW  = new KeyConfig();
		public KeyConfig SW  = new KeyConfig();
		public RotaryEncoder()
		{
		}
	}
	
	public enum KEYMAT_SIZE : byte
	{
		ROW = 4,
		COLUMN = 5,
		SIZE = 20,
		R_COUNT = 2,
		R_OPTION = 3,
		R_SIZE = 6,
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	public struct LayerInfo
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string layerName = "";

		public byte ledR =0;
		public byte ledG =0;
		public byte ledB =0;

		// 4行 × 5列 ＝ 20個のキーマトリクス設定 (3バイト × 20 ＝ 60バイト)
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public KeyConfig[] matrix = new KeyConfig[20];

		// 2個 × 3状態(CW, CCW, SW) ＝ 6個のエンコーダー設定 (3バイト × 6 ＝ 18バイト)
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public KeyConfig[] encoders = new KeyConfig[6];

		// ********************************************************************************
		public void Clear()
		{
			for (int i = 0; i < (int)KEYMAT_SIZE.SIZE; i++)
			{
				this.matrix[i] = new KeyConfig();
				this.matrix[i].modifier = 0;
				this.matrix[i].keycode = 0;
				this.matrix[i].mouse = 0;

			}
			for (int i = 0; i < (int)KEYMAT_SIZE.R_SIZE; i++)
			{
				this.encoders[i] = new KeyConfig();
				this.encoders[i].modifier = 0;
				this.encoders[i].keycode = 0;
				this.encoders[i].mouse = 0;
			}
			this.ledR = 0;
			this.ledG = 0;
			this.ledB = 0;
			this.layerName = "Layer";
		}
		public KeyConfig KeyAt(int row, int column)
		{
			if (row < 0) row = 0;
			else if (row >= (int)KEYMAT_SIZE.ROW) row = (int)KEYMAT_SIZE.ROW - 1;
			if (column < 0) column = 0;
			else if (column >= (int)KEYMAT_SIZE.COLUMN) column = (int)KEYMAT_SIZE.COLUMN - 1;
			return matrix[row * (int)KEYMAT_SIZE.COLUMN + column];
		}
		public void SetKeyAt(int row, int column, KeyConfig keyConfig)
		{
			if (row < 0) row = 0;
			else if (row >= (int)KEYMAT_SIZE.ROW) row = (int)KEYMAT_SIZE.ROW - 1;
			if (column < 0) column = 0;
			else if (column >= (int)KEYMAT_SIZE.COLUMN) column = (int)KEYMAT_SIZE.COLUMN - 1;
			matrix[row * (int)KEYMAT_SIZE.COLUMN + column] = keyConfig;
		}

		public KeyConfig[] Keys()
		{
			KeyConfig[] allKeys = new KeyConfig[(int)KEYMAT_SIZE.SIZE];
			int index = 0;
			for (int i = 0; i < (int)KEYMAT_SIZE.SIZE; i++)
			{
				allKeys[index++] = matrix[i];
			}
			return allKeys;

		}
		public void SetKeys(KeyConfig[] keyConfigs)
		{
			if (keyConfigs.Length != (int)KEYMAT_SIZE.SIZE)
			{
				throw new ArgumentException($"keyConfigs must have exactly {(int)KEYMAT_SIZE.SIZE} elements.");
			}
			int index = 0;
			for (int i = 0; i < (int)KEYMAT_SIZE.SIZE; i++)
			{
					this.matrix[i].modifier = keyConfigs[index].modifier;
					this.matrix[i].keycode = keyConfigs[index].keycode;
					this.matrix[i].mouse = keyConfigs[index].mouse;
					index++;
			}
		}
		public RotaryEncoder REncodetor(int idx)
		{
			if (idx < 0) idx = 0;
			else if (idx > 1) idx = 1;
			RotaryEncoder ret = new RotaryEncoder();
			int index = (int)KEYMAT_SIZE.R_OPTION * idx;
			ret.CW = encoders[index++];
			ret.CCW = encoders[index++];
			ret.SW = encoders[index++];
			return ret;
		}
		public void SetREncoder(int idx, RotaryEncoder encoderConfig)
		{
			if (idx < 0) idx = 0;
			else if (idx > 1) idx = 1;
			int index = (int)KEYMAT_SIZE.R_OPTION * idx;
			this.encoders[index++] = encoderConfig.CW;
			this.encoders[index++] = encoderConfig.CCW;
			this.encoders[index++] = encoderConfig.SW;
		}
		public KeyConfig[] Encoders(int idx)
		{
			if (idx < 0) idx = 0;
			else if (idx > 1) idx = 1;
			KeyConfig[] ret = new KeyConfig[3];
			int index = (int)KEYMAT_SIZE.R_OPTION * idx;
			ret[0] = encoders[index++];
			ret[1] = encoders[index++];
			ret[2] = encoders[index++];

			return ret;
		}
		public void SetEncoders(int idx, KeyConfig[] encoderConfigs)
		{
			if (encoderConfigs.Length != 3)
			{
				throw new ArgumentException($"encoderConfigs must have exactly 3 elements.");
			}
			if (idx < 0) idx = 0;
			else if (idx > 1) idx = 1;
			int index = (int)KEYMAT_SIZE.R_OPTION * idx;
			for (int i = 0; i < 3; i++)
				this.encoders[index++] = encoderConfigs[i];

		}
		public LayerInfo()
		{
			Clear();
		}
		public void CopyFrom(LayerInfo source)
		{
			this.layerName = source.layerName;
			this.ledR = source.ledR;
			this.ledG = source.ledG;
			this.ledB = source.ledB;
			for (int i = 0; i < (int)KEYMAT_SIZE.SIZE; i++)
			{
				this.matrix[i].modifier = source.matrix[i].modifier;
				this.matrix[i].keycode = source.matrix[i].keycode;
				this.matrix[i].mouse = source.matrix[i].mouse;
			}
			for (int i = 0; i < (int)KEYMAT_SIZE.R_SIZE; i++)
			{
				this.encoders[i].modifier = source.encoders[i].modifier;
				this.encoders[i].keycode = source.encoders[i].keycode;
				this.encoders[i].mouse = source.encoders[i].mouse;
			}
		}
	}
}

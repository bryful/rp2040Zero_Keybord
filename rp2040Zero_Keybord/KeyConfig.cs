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
	
	public class KeyConfig
	{
		public Byte modifier =0;
		public Byte keycode =0;
		public Byte mouse =0;
	}
	public class RotaryEncoder
	{
		public KeyConfig configCW = new KeyConfig();
		public KeyConfig configCCW = new KeyConfig();
		public KeyConfig configSW = new KeyConfig();
	}
}

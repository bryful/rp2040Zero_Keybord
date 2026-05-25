using System.Runtime.InteropServices;

namespace rp2040Zero_Keybord
{
	public partial class Form1 : Form
	{
		private readonly KeyConfigs _configs = new KeyConfigs();

		public KeyConfigs Configs => _configs;
		public Form1()
		{
			InitializeComponent();
			InitializeKeyboardComponents();
			RegisterEventHandlers();
		}
		private void InitializeKeyboardComponents()
		{
			if (layerNav1 == null || keyIcons1 == null || 
				rotaryEncoder1 == null || rotaryEncoder2 == null)
			{
				throw new InvalidOperationException("Required controls are not initialized.");
			}
			_configs.LoadFromBinaryFile("keyconfigs.dat");


			layerNav1.KeyConfigs = _configs;

			_configs.Icons = keyIcons1;
			_configs.RotaryEncoder1 = rotaryEncoder1;
			_configs.RotaryEncoder2 = rotaryEncoder2;
			_configs.LayerNav = layerNav1;
		}
		private void RegisterEventHandlers()
		{
			btnClear.Click += btnClear_Click;

			quitMenu.Click += (s, e) =>
			{
				Application.Exit();
			};
			openMenu.Click += (s, e) =>
			{
				_configs.LoadSettings();
			};
			saveMenu.Click += (s, e) =>
			{
				_configs.SaveSettings();
			};
			ToClipboardCPPMenu.Click += (s, e) =>
			{
				string cpp = _configs.ToCpp();
				Clipboard.SetText(cpp);
			};
			getDeviceMenu.Click += (s, e) =>
			{
				GetlayerInfo();
			};
			clearMenu.Click += (s, e) =>
			{
				Clear();
			};
		}

		private void CopyFromindex0Menu_Click(object? sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem menuItem && menuItem.Tag is int index)
			{
				_configs.CopyFromIndex(index);
			}
		}

		private void BtnSet_Click(object? sender, EventArgs e)
		{
			keyIcons1.Apply();
			_configs.Push();
		}
		public void Clear()
		{
			keyIcons1.Clear();
			rotaryEncoder1.Clear();
			rotaryEncoder2.Clear();
			_configs.Push();
		}
		private void btnClear_Click(object? sender, EventArgs e)
		{
			Clear();
		}
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			_configs.SaveToBinaryFile("keyconfigs.dat");

		}

		private void toClipboardCPPMenuClick(object sender, EventArgs e)
		{
			string s = _configs.ToCpp();
			Clipboard.SetText(s);

		}

		private void rotaryEncoder2_Click(object sender, EventArgs e)
		{

		}
		public SerialPortInfo ConnectToDevice()
		{
			using (SerialConnect serialConnect = new SerialConnect())
			{
				return serialConnect.ShowDialogAndGetSelectedPort();
			}
		}
		public void GetlayerInfo()
		{
			SerialPortInfo info = ConnectToDevice();
			if (info.IsValid)
			{
				_configs.ReceiveConfigFromDevice(info);
			}
		}
		public void SendConfigToDevice()
		{
			SerialPortInfo info = ConnectToDevice();
			if (info.IsValid)
			{
				_configs.SendConfigToDevice(info);
			}
		}
	}
}

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
			if (layersw1 == null || keyIcons1 == null || keyConfigsw1 == null ||
				rotaryEncoder1 == null || rotaryEncoder2 == null)
			{
				throw new InvalidOperationException("Required controls are not initialized.");
			}
			_configs.LoadFromBinaryFile("keyconfigs.dat");


			layersw1.KeyConfigs = _configs;
			keyIcons1.KeyConfigSW = keyConfigsw1;
			_configs.Icons = keyIcons1;
			_configs.RotaryEncoder1 = rotaryEncoder1;
			_configs.RotaryEncoder2 = rotaryEncoder2;

			copyFromindex0ToolStripMenuItem.Tag = 0;
			copyFromindex1ToolStripMenuItem.Tag = 1;
			copyFromindex2ToolStripMenuItem.Tag = 2;
			copyFromindex3ToolStripMenuItem.Tag = 3;
		}
		private void RegisterEventHandlers()
		{
			btnSet.Click += BtnSet_Click;
			copyFromindex0ToolStripMenuItem.Click += CopyFromindex0ToolStripMenuItem_Click;
			copyFromindex1ToolStripMenuItem.Click += CopyFromindex0ToolStripMenuItem_Click;
			copyFromindex2ToolStripMenuItem.Click += CopyFromindex0ToolStripMenuItem_Click;
			copyFromindex3ToolStripMenuItem.Click += CopyFromindex0ToolStripMenuItem_Click;
		}

		private void CopyFromindex0ToolStripMenuItem_Click(object? sender, EventArgs e)
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
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			_configs.SaveToBinaryFile("keyconfigs.dat");

		}

		private void toClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string s = _configs.ToCpp();
			Clipboard.SetText(s);

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			_configs.Clear();
		}
	}
}

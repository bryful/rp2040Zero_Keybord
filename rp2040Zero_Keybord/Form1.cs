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

			copyFromindex0Menu.Tag = 0;
			copyFromindex1Menu.Tag = 1;
			copyFromindex2Menu.Tag = 2;
		}
		private void RegisterEventHandlers()
		{
			btnSet.Click += BtnSet_Click;
			btnClear.Click += btnClear_Click;
			copyFromindex0Menu.Click += CopyFromindex0Menu_Click;
			copyFromindex1Menu.Click += CopyFromindex0Menu_Click;
			copyFromindex2Menu.Click += CopyFromindex0Menu_Click;
			quitMenu.Click += (s, e) =>
			{
				Application.Exit();
			};
			openMenu.Click += (s, e) =>
			{
				_configs.LoadSettings();
			};
			saveMenu.Click += (s, e) => {
				_configs.SaveSettings();
			};
			ToClipBoardJsonMenu.Click += (s, e) =>
			{
				string json = _configs.ToJson();
				Clipboard.SetText(json);
			};
			ToClipboardCPPMenu.Click += (s, e) =>
			{
				string cpp = _configs.ToCpp();
				Clipboard.SetText(cpp);
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
		private void btnClear_Click(object? sender, EventArgs e)
		{
			keyIcons1.Clear();
			_configs.Push();
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

		
			
	}
}

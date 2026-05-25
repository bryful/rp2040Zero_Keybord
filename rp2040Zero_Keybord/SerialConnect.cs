using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace rp2040Zero_Keybord
{
	public partial class SerialConnect : Form
	{
		public SerialConnect()
		{
			InitializeComponent();

			SerialPort.GetPortNames().ToList().ForEach(port =>
			{
				comboBoxPorts.Items.Add(port);
			});
		}
		public string ShowDialogAndGetSelectedPort()
		{
			if (comboBoxPorts.Items.Count > 0)
			{
				comboBoxPorts.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("No serial ports found. Please connect your device and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "";
			}
			if (this.ShowDialog() == DialogResult.OK)
			{

				return comboBoxPorts.SelectedItem.ToString();
			}
			return "";
		}
	}
}

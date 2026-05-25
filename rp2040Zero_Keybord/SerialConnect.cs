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
	public struct SerialPortInfo
	{
		public bool IsValid => !string.IsNullOrEmpty(PortName);
		public string PortName { get; set; } = "";
		public bool DtrEnable { get; set; } = true;
		public bool RtsEnable { get; set; } = false;
		public SerialPortInfo(string portName, bool dtrEnable = true, bool rtsEnable = false)
		{
			PortName = portName;
			DtrEnable = dtrEnable;
			RtsEnable = rtsEnable;
		}
		public SerialPortInfo() { }
	}


	public partial class SerialConnect : Form
	{
		public SerialConnect()
		{
			InitializeComponent();

			SerialPort.GetPortNames().ToList().ForEach(port =>
			{
				comboBoxPorts.Items.Add(port);
			});
			cbDtrEnable.Checked = true;
			cbRtsEnable.Checked = false;
		}
		public SerialPortInfo ShowDialogAndGetSelectedPort()
		{
			if (comboBoxPorts.Items.Count > 0)
			{
				comboBoxPorts.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("No serial ports found. Please connect your device and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return new SerialPortInfo();
			}
			SerialPortInfo info = new SerialPortInfo();
			if (this.ShowDialog() == DialogResult.OK)
			{
				string? nm = (string?)comboBoxPorts.SelectedItem.ToString(); 
				if (string.IsNullOrEmpty(nm))
				{
					info.PortName = "";
				}
				else
				{
					info.PortName = (string)nm;
					info.DtrEnable = cbDtrEnable.Checked;
					info.RtsEnable = cbRtsEnable.Checked;
				}
			}
			return info;
		}
	}
}

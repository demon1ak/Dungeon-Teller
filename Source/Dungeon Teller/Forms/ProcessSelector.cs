using Dungeon_Teller.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dungeon_Teller.Forms
{
	public partial class ProcessSelector : Form
	{
		List<ListBoxObject> pList = new List<ListBoxObject> { };
        public static Dictionary<int, string> DungeonIDs = new Dictionary<int, string>();
        public static Dictionary<int, string> BattlefieldIDs = new Dictionary<int, string>();
		Properties.Settings settings = Properties.Settings.Default;
		private const int SW_RESTORE = 9;

		public ProcessSelector()
		{
			InitializeComponent();
		}

		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private void updateProcessList()
		{
			pList.Clear();
			lbx_WoWIds.DataSource = null;
			pList.Clear();
			Process[] pr = Process.GetProcessesByName("WoW");

			int pCount = 0;

			foreach (Process p in pr)
			{
				Memory.OpenProcess(p.Id);

				string playerName = Memory.Read<string>(Memory.BaseAddress + Offsets.playerName.val);
				string playerRealm = Memory.Read<string>(Memory.BaseAddress + Offsets.playerRealm.val);

				if (playerName.Length != 0 && playerRealm.Length != 0)
				{
					pCount++;
					string wow = String.Format("{0}: {2} - {3}", p.Id.ToString(), p.ProcessName, playerName, playerRealm);
					pList.Add(new ListBoxObject(p.Id, wow));
				}

			}

			if (pCount == 0)
			{
				timerBlink.Start();
				lbl_processCount.ForeColor = System.Drawing.Color.Red;
				lbl_processInfo.Text = "Are you logged in? Try to refresh!";
			}
			else
			{
				timerBlink.Stop();
				lbl_processInfo.Text = "Please select your wow process";
				lbl_processCount.Visible = true;
				lbl_processCount.ForeColor = System.Drawing.SystemColors.ControlText;
			}

			lbl_processCount.Text = pCount + " WoW instance(s) found";

			lbx_WoWIds.DataSource = pList;
			lbx_WoWIds.DisplayMember = "Text";
			lbx_WoWIds.ValueMember = "Value";
		}

		private bool attachToProcess(int pid)
		{
			Memory.OpenProcess(pid);

            string playerName = "N/A";
            string playerRealm = "N/A";

			if (playerName.Length != 0 && playerRealm.Length != 0)
			{
				return true;
			}

			return false;
		}

		private void btn_Attach_Click(object sender, EventArgs e)
		{
			if (lbx_WoWIds.SelectedItem != null)
			{
				int pid = (int)lbx_WoWIds.SelectedValue;
				bool attached = attachToProcess(pid);
				
				if (attached)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("Nothing selected!", "Dungeon Teller", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_Refresh_Click(object sender, EventArgs e)
		{
			updateProcessList();
		}

		private void timerBlink_Tick(object sender, EventArgs e)
		{
			this.lbl_processCount.Visible = !this.lbl_processCount.Visible;
		}

		private void lbx_WoWIds_DoubleClick(object sender, EventArgs e)
		{
			if (lbx_WoWIds.SelectedItem != null)
			{
				try
				{
					int pid = (int)lbx_WoWIds.SelectedValue;
					IntPtr handle = Process.GetProcessById(pid).MainWindowHandle;
					SetForegroundWindow(handle);
					ShowWindow(handle, SW_RESTORE);
				}
				catch
				{
					MessageBox.Show("The process has quit!");
					lbx_WoWIds.Items.Clear();
					Process[] pr = Process.GetProcessesByName("WoW");
					foreach (Process p in pr)
					{
						lbx_WoWIds.Items.Add(p.Id);
					}
				}
			}
		}

		private void ProcessSelector_Shown(object sender, EventArgs e)
		{
			updateProcessList();

			if (settings.AutoSelect)
			{
				Process[] pr = Process.GetProcessesByName("WoW");

				if (pr.Length == 1)
				{
					bool attached = attachToProcess(pr[0].Id);

					if (attached)
					{
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			}
		}

		public class ListBoxObject
		{
			readonly int value;
			readonly string text;

			public ListBoxObject(int value, string text)
			{
				this.value = value;
				this.text = text;
			}

			public string Text
			{
				get { return text; }
			}

			public int Value
			{
				get { return value; }
			}
		}

        private void ProcessSelector_Load(object sender, EventArgs e)
        {
            using (System.IO.StringReader stream = new System.IO.StringReader(Properties.Resources.dungeonids))
            {
                string line = stream.ReadLine();
                while ((line != null))
                {
                    string[] explstr = line.Split((char)',');
                    DungeonIDs.Add(Convert.ToInt32(explstr[0]), explstr[1]);
                    line = stream.ReadLine();
                }
            } //MUST... LEARN... CODE REUSE
            using (System.IO.StringReader stream = new System.IO.StringReader(Properties.Resources.BattlefieldIDs))
            {
                string line = stream.ReadLine();
                while ((line != null))
                {
                    string[] explstr = line.Split((char)',');
                    BattlefieldIDs.Add(Convert.ToInt32(explstr[0]), explstr[1]);
                    line = stream.ReadLine();
                }
            }
        }

	}
}
using Dungeon_Teller.Classes;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dungeon_Teller.Forms
{
	public partial class Options : Form
	{
		MainForm main;
		ProcessSelector ps;
		Properties.Settings settings = Properties.Settings.Default;

		public Options(MainForm main)
		{
			InitializeComponent();
			AddEvents(this.Controls);
			this.combo_pushProvider.SelectedIndex = 0;
			this.main = main;
		}

		public Options(ProcessSelector ps)
		{
			InitializeComponent();
			AddEvents(this.Controls);
			this.ps = ps;
		}

		void AddEvents(System.Windows.Forms.Control.ControlCollection Controls)
		{
			foreach (Control c in Controls)
			{
				if (c.HasChildren)
				{
					AddEvents(c.Controls);
				}
				else if (c is TextBox)
				{
					((TextBox)c).TextChanged += new EventHandler(SettingsChanged);
				}
				else if (c is CheckBox)
				{
					((CheckBox)c).CheckedChanged += new EventHandler(SettingsChanged);
				}
				else if (c is RadioButton)
				{
					((RadioButton)c).CheckedChanged += new EventHandler(SettingsChanged);
				}
				else if (c is NumericUpDown)
				{
					((NumericUpDown)c).ValueChanged += new EventHandler(SettingsChanged);
				}
				else if (c is ComboBox)
				{
					((ComboBox)c).SelectedValueChanged += new EventHandler(SettingsChanged);
				}
				//Expand this to include any other type of controls your form 
				//has that you need to add the event to
			}
		}

		void SettingsChanged(object obj, EventArgs e)
		{
			btn_apply.Enabled = true;
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private bool applySettings()
		{
			if (combo_pushProvider.SelectedIndex != 0 && tb_pushKey.Text == "")
			{
				MessageBox.Show("PushOver notifications are checked but no API Key is given!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else if (cb_mailNotification.Checked && tb_mailTo.Text == "")
			{
				MessageBox.Show("Mail notifications are checked but no mail address is given!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			else
			{
				settings.AntiAFK = cb_antiAfk.Checked;
				settings.AutoJoin = cb_autoJoin.Checked;

				settings.Sound = cb_sound.Checked;
				settings.DesktopNotification = cb_desktopNotification.Checked;
				settings.BalloonTips = cb_balloonTips.Checked;

				settings.TrayOnly = cb_trayOnly.Checked;
				settings.LockWindow = cb_lockWindow.Checked;
				settings.BringToFront = cb_bringToFront.Checked;

				settings.AutoSelect = cb_autoSelect.Checked;
				settings.PauseFocus = cb_pauseFocus.Checked;
				settings.Opacity = (int)num_opacity.Value;
				settings.CheckForUpdates = cb_updates.Checked;

				settings.PushProider = combo_pushProvider.SelectedIndex;
				settings.PushKey = tb_pushKey.Text;

				settings.MailNotification = cb_mailNotification.Checked;
				settings.MailAddress = tb_mailTo.Text;

                settings.UseMQTT = useMQTT.Checked;

				if (settings.LockWindow) main.lockToBottomRight();

				if (settings.TrayOnly)
				{
					main.Hide();
					this.Focus();
				}
				else
				{
					main.Show();
					this.Focus();
				}

				main.Opacity = (double)settings.Opacity / 100;
				main.Refresh();

				return true;
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (applySettings())
				this.Close();
		}

		private void btn_apply_Click(object sender, EventArgs e)
		{
			btn_apply.Enabled = false;
			applySettings();
		}

		private void lnk_push_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			switch (combo_pushProvider.SelectedIndex)
			{
				case 1:
					Process.Start("https://pushover.net/");
					break;
				case 2:
					Process.Start("https://www.notifymyandroid.com/account.jsp");
					break;
				case 3:
					Process.Start("https://www.prowlapp.com/api_settings.php");
					break;
			}
		}


		private void Options_Load(object sender, EventArgs e)
		{
			cb_antiAfk.Checked = settings.AntiAFK;
			cb_autoJoin.Checked = settings.AutoJoin;

			cb_sound.Checked = settings.Sound;
			cb_desktopNotification.Checked = settings.DesktopNotification;
			cb_balloonTips.Checked = settings.BalloonTips;

			cb_lockWindow.Checked = settings.LockWindow;
			cb_trayOnly.Checked = settings.TrayOnly;
			cb_bringToFront.Checked = settings.BringToFront;

			cb_autoSelect.Checked = settings.AutoSelect;
			cb_pauseFocus.Checked = settings.PauseFocus;
			num_opacity.Value = settings.Opacity;
			cb_updates.Checked = settings.CheckForUpdates;

			combo_pushProvider.SelectedIndex = settings.PushProider;
			tb_pushKey.Text = settings.PushKey;
			if (settings.PushProider != 0)
			{
				lbl_push.Enabled = true;
				tb_pushKey.Enabled = true;
				lnk_push.Enabled = true;
				btn_pushTest.Enabled = true;
			}

			cb_mailNotification.Checked = settings.MailNotification;
			tb_mailTo.Text = settings.MailAddress;
			if (settings.MailNotification)
			{
				lbl_mailAddress.Enabled = true;
				tb_mailTo.Enabled = true;
				btn_mailTest.Enabled = true;
			}

			btn_apply.Enabled = false;
		}

		private void btn_restore_Click(object sender, EventArgs e)
		{
			cb_antiAfk.Checked = bool.Parse((string)settings.Properties["AntiAFK"].DefaultValue);
			cb_autoJoin.Checked = bool.Parse((string)settings.Properties["AutoJoin"].DefaultValue);

			cb_sound.Checked = bool.Parse((string)settings.Properties["Sound"].DefaultValue);
			cb_desktopNotification.Checked = bool.Parse((string)settings.Properties["DesktopNotification"].DefaultValue);
			cb_balloonTips.Checked = bool.Parse((string)settings.Properties["BalloonTips"].DefaultValue);

			cb_lockWindow.Checked = bool.Parse((string)settings.Properties["LockWindow"].DefaultValue);
			cb_trayOnly.Checked = bool.Parse((string)settings.Properties["TrayOnly"].DefaultValue);
			cb_bringToFront.Checked = bool.Parse((string)settings.Properties["BringToFront"].DefaultValue);

			cb_autoSelect.Checked = bool.Parse((string)settings.Properties["AutoSelect"].DefaultValue);
			cb_pauseFocus.Checked = bool.Parse((string)settings.Properties["PauseFocus"].DefaultValue);
			num_opacity.Value = int.Parse((string)settings.Properties["Opacity"].DefaultValue);
			cb_updates.Checked = bool.Parse((string)settings.Properties["CheckForUpdates"].DefaultValue);

			combo_pushProvider.SelectedIndex = int.Parse((string)settings.Properties["PushProider"].DefaultValue);
			tb_pushKey.Text = (string)settings.Properties["PushKey"].DefaultValue;
			if (combo_pushProvider.SelectedIndex != 0)
			{
				lbl_push.Enabled = true;
				tb_pushKey.Enabled = true;
				lnk_push.Enabled = true;
				btn_pushTest.Enabled = true;
			}

			cb_mailNotification.Checked = bool.Parse((string)settings.Properties["MailNotification"].DefaultValue);
			tb_mailTo.Text = (string)settings.Properties["MailAddress"].DefaultValue;
			if (cb_mailNotification.Checked)
			{
				lbl_mailAddress.Enabled = true;
				tb_mailTo.Enabled = true;
				btn_mailTest.Enabled = true;
			}

			btn_apply.Enabled = false;
		}

		private void btn_pushTest_Click(object sender, EventArgs e)
		{
			if (tb_pushKey.Text != "")
			{
				Notification.sendPushNotification(combo_pushProvider.SelectedIndex, tb_pushKey.Text, "Test Event", "Test message");
			}
			else
			{
				MessageBox.Show("Please enter a key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_mailTest_Click(object sender, EventArgs e)
		{
			Notification.sendMail(tb_mailTo.Text, "Dungeon Teller Test", "This is just a tets.");
		}

		private void combo_pushProvider_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (combo_pushProvider.SelectedIndex != 0)
			{
				tb_pushKey.Enabled = lnk_push.Enabled = lbl_push.Enabled = btn_pushTest.Enabled = true;
			}
			else
			{
				tb_pushKey.Enabled = lnk_push.Enabled = lbl_push.Enabled = btn_pushTest.Enabled = false;
			}

			switch (combo_pushProvider.SelectedIndex)
			{
				case 1:
					lbl_push.Text = "Your PushOver user key:";
					lnk_push.Text = "Get your PushOver user key";
					break;
				case 2:
					lbl_push.Text = "Your Notify My Android API key:";
					lnk_push.Text = "Get your Notify Ny Android API key";
					break;
				case 3:
					lbl_push.Text = "Your Prowl! API key:";
					lnk_push.Text = "Get your Prowl API key";
					break;
				default:
					lbl_push.Text = "Your API or user key:";
					lnk_push.Text = "Get your API or user key";
					break;
			}

		}

		private void cb_mailNotification_CheckedChanged(object sender, EventArgs e)
		{
			lbl_mailAddress.Enabled = !lbl_mailAddress.Enabled;
			tb_mailTo.Enabled = !tb_mailTo.Enabled;
			btn_mailTest.Enabled = !btn_mailTest.Enabled;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/demon1ak/mqtt-android2.2-froyo-dungeonteller.git");
        }
	}
}

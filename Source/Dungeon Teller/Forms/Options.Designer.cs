namespace Dungeon_Teller.Forms
{
	partial class Options
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_updates = new System.Windows.Forms.CheckBox();
            this.cb_pauseFocus = new System.Windows.Forms.CheckBox();
            this.cb_autoSelect = new System.Windows.Forms.CheckBox();
            this.cb_trayOnly = new System.Windows.Forms.CheckBox();
            this.num_opacity = new System.Windows.Forms.NumericUpDown();
            this.cb_lockWindow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_bringToFront = new System.Windows.Forms.CheckBox();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.cb_balloonTips = new System.Windows.Forms.CheckBox();
            this.cb_desktopNotification = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.useMQTT = new System.Windows.Forms.CheckBox();
            this.btn_mailTest = new System.Windows.Forms.Button();
            this.tb_mailTo = new System.Windows.Forms.TextBox();
            this.lbl_mailAddress = new System.Windows.Forms.Label();
            this.cb_mailNotification = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_pushProvider = new System.Windows.Forms.ComboBox();
            this.btn_pushTest = new System.Windows.Forms.Button();
            this.lnk_push = new System.Windows.Forms.LinkLabel();
            this.tb_pushKey = new System.Windows.Forms.TextBox();
            this.lbl_push = new System.Windows.Forms.Label();
            this.btn_restore = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cb_antiAfk = new System.Windows.Forms.CheckBox();
            this.cb_autoJoin = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_opacity)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(317, 315);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.Enabled = false;
            this.btn_apply.Location = new System.Drawing.Point(479, 315);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 11;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(398, 315);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_updates);
            this.groupBox1.Controls.Add(this.cb_pauseFocus);
            this.groupBox1.Controls.Add(this.cb_autoSelect);
            this.groupBox1.Controls.Add(this.cb_trayOnly);
            this.groupBox1.Controls.Add(this.num_opacity);
            this.groupBox1.Controls.Add(this.cb_lockWindow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(340, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 196);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General options";
            // 
            // cb_updates
            // 
            this.cb_updates.AutoSize = true;
            this.cb_updates.Location = new System.Drawing.Point(15, 111);
            this.cb_updates.Name = "cb_updates";
            this.cb_updates.Size = new System.Drawing.Size(113, 17);
            this.cb_updates.TabIndex = 23;
            this.cb_updates.Text = "Check for updates";
            this.toolTip1.SetToolTip(this.cb_updates, "If checked program and offset update check at startup is enabled");
            this.cb_updates.UseVisualStyleBackColor = true;
            // 
            // cb_pauseFocus
            // 
            this.cb_pauseFocus.AutoSize = true;
            this.cb_pauseFocus.Location = new System.Drawing.Point(15, 88);
            this.cb_pauseFocus.Name = "cb_pauseFocus";
            this.cb_pauseFocus.Size = new System.Drawing.Size(151, 17);
            this.cb_pauseFocus.TabIndex = 22;
            this.cb_pauseFocus.Text = "Pause when WoW in front";
            this.toolTip1.SetToolTip(this.cb_pauseFocus, "If checked Dungeon Teller won\'t do anything while WoW is the the foreground windo" +
        "w");
            this.cb_pauseFocus.UseVisualStyleBackColor = true;
            // 
            // cb_autoSelect
            // 
            this.cb_autoSelect.AutoSize = true;
            this.cb_autoSelect.Location = new System.Drawing.Point(15, 65);
            this.cb_autoSelect.Name = "cb_autoSelect";
            this.cb_autoSelect.Size = new System.Drawing.Size(150, 17);
            this.cb_autoSelect.TabIndex = 21;
            this.cb_autoSelect.Text = "Auto select WoW process";
            this.toolTip1.SetToolTip(this.cb_autoSelect, "If checked the first WoW process found will be selected automatically at startup");
            this.cb_autoSelect.UseVisualStyleBackColor = true;
            // 
            // cb_trayOnly
            // 
            this.cb_trayOnly.AutoSize = true;
            this.cb_trayOnly.Location = new System.Drawing.Point(15, 19);
            this.cb_trayOnly.Name = "cb_trayOnly";
            this.cb_trayOnly.Size = new System.Drawing.Size(78, 17);
            this.cb_trayOnly.TabIndex = 20;
            this.cb_trayOnly.Text = "Stay in tray";
            this.toolTip1.SetToolTip(this.cb_trayOnly, "If checked the main window will stay in tray");
            this.cb_trayOnly.UseVisualStyleBackColor = true;
            // 
            // num_opacity
            // 
            this.num_opacity.Location = new System.Drawing.Point(13, 156);
            this.num_opacity.Name = "num_opacity";
            this.num_opacity.Size = new System.Drawing.Size(85, 20);
            this.num_opacity.TabIndex = 18;
            this.num_opacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cb_lockWindow
            // 
            this.cb_lockWindow.AutoSize = true;
            this.cb_lockWindow.Checked = true;
            this.cb_lockWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lockWindow.Location = new System.Drawing.Point(15, 42);
            this.cb_lockWindow.Name = "cb_lockWindow";
            this.cb_lockWindow.Size = new System.Drawing.Size(159, 17);
            this.cb_lockWindow.TabIndex = 12;
            this.cb_lockWindow.Text = "Lock window to bottom right";
            this.toolTip1.SetToolTip(this.cb_lockWindow, "If checked the main window is locked to the bottom right corner of your desktop");
            this.cb_lockWindow.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Main window opacity:";
            // 
            // cb_bringToFront
            // 
            this.cb_bringToFront.AutoSize = true;
            this.cb_bringToFront.Location = new System.Drawing.Point(15, 88);
            this.cb_bringToFront.Name = "cb_bringToFront";
            this.cb_bringToFront.Size = new System.Drawing.Size(117, 17);
            this.cb_bringToFront.TabIndex = 22;
            this.cb_bringToFront.Text = "Bring WoW to front";
            this.toolTip1.SetToolTip(this.cb_bringToFront, "If checked WoW is made in foreground when a queue is ready");
            this.cb_bringToFront.UseVisualStyleBackColor = true;
            // 
            // cb_sound
            // 
            this.cb_sound.AutoSize = true;
            this.cb_sound.Checked = true;
            this.cb_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sound.Location = new System.Drawing.Point(15, 42);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(96, 17);
            this.cb_sound.TabIndex = 19;
            this.cb_sound.Text = "Enable sounds";
            this.toolTip1.SetToolTip(this.cb_sound, "If checked a sound will be played when a queue is ready");
            this.cb_sound.UseVisualStyleBackColor = true;
            // 
            // cb_balloonTips
            // 
            this.cb_balloonTips.AutoSize = true;
            this.cb_balloonTips.Checked = true;
            this.cb_balloonTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_balloonTips.Location = new System.Drawing.Point(15, 65);
            this.cb_balloonTips.Name = "cb_balloonTips";
            this.cb_balloonTips.Size = new System.Drawing.Size(115, 17);
            this.cb_balloonTips.TabIndex = 11;
            this.cb_balloonTips.Text = "Enable balloon tips";
            this.toolTip1.SetToolTip(this.cb_balloonTips, "If checked balloont tips will inform you about different queue events");
            this.cb_balloonTips.UseVisualStyleBackColor = true;
            // 
            // cb_desktopNotification
            // 
            this.cb_desktopNotification.AutoSize = true;
            this.cb_desktopNotification.Checked = true;
            this.cb_desktopNotification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_desktopNotification.Location = new System.Drawing.Point(15, 19);
            this.cb_desktopNotification.Name = "cb_desktopNotification";
            this.cb_desktopNotification.Size = new System.Drawing.Size(165, 17);
            this.cb_desktopNotification.TabIndex = 10;
            this.cb_desktopNotification.Text = "Enbable desktop notifications";
            this.toolTip1.SetToolTip(this.cb_desktopNotification, "If checked a message box is shown when a queue is ready");
            this.cb_desktopNotification.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.useMQTT);
            this.groupBox2.Controls.Add(this.btn_mailTest);
            this.groupBox2.Controls.Add(this.tb_mailTo);
            this.groupBox2.Controls.Add(this.lbl_mailAddress);
            this.groupBox2.Controls.Add(this.cb_mailNotification);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.combo_pushProvider);
            this.groupBox2.Controls.Add(this.cb_bringToFront);
            this.groupBox2.Controls.Add(this.btn_pushTest);
            this.groupBox2.Controls.Add(this.cb_sound);
            this.groupBox2.Controls.Add(this.lnk_push);
            this.groupBox2.Controls.Add(this.cb_balloonTips);
            this.groupBox2.Controls.Add(this.tb_pushKey);
            this.groupBox2.Controls.Add(this.lbl_push);
            this.groupBox2.Controls.Add(this.cb_desktopNotification);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 297);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notification options";
            // 
            // useMQTT
            // 
            this.useMQTT.AutoSize = true;
            this.useMQTT.Location = new System.Drawing.Point(179, 186);
            this.useMQTT.Name = "useMQTT";
            this.useMQTT.Size = new System.Drawing.Size(112, 17);
            this.useMQTT.TabIndex = 29;
            this.useMQTT.Text = "enable mobile app";
            this.useMQTT.UseVisualStyleBackColor = true;
            // 
            // btn_mailTest
            // 
            this.btn_mailTest.Enabled = false;
            this.btn_mailTest.Location = new System.Drawing.Point(229, 146);
            this.btn_mailTest.Name = "btn_mailTest";
            this.btn_mailTest.Size = new System.Drawing.Size(75, 23);
            this.btn_mailTest.TabIndex = 28;
            this.btn_mailTest.Text = "Test";
            this.toolTip1.SetToolTip(this.btn_mailTest, "Send a test mail to the given address");
            this.btn_mailTest.UseVisualStyleBackColor = true;
            // 
            // tb_mailTo
            // 
            this.tb_mailTo.Enabled = false;
            this.tb_mailTo.Location = new System.Drawing.Point(29, 148);
            this.tb_mailTo.Name = "tb_mailTo";
            this.tb_mailTo.Size = new System.Drawing.Size(194, 20);
            this.tb_mailTo.TabIndex = 27;
            // 
            // lbl_mailAddress
            // 
            this.lbl_mailAddress.AutoSize = true;
            this.lbl_mailAddress.Enabled = false;
            this.lbl_mailAddress.Location = new System.Drawing.Point(29, 132);
            this.lbl_mailAddress.Name = "lbl_mailAddress";
            this.lbl_mailAddress.Size = new System.Drawing.Size(69, 13);
            this.lbl_mailAddress.TabIndex = 26;
            this.lbl_mailAddress.Text = "Mail address:";
            // 
            // cb_mailNotification
            // 
            this.cb_mailNotification.AutoSize = true;
            this.cb_mailNotification.Location = new System.Drawing.Point(15, 111);
            this.cb_mailNotification.Name = "cb_mailNotification";
            this.cb_mailNotification.Size = new System.Drawing.Size(137, 17);
            this.cb_mailNotification.TabIndex = 25;
            this.cb_mailNotification.Text = "Send E-Mail notification";
            this.toolTip1.SetToolTip(this.cb_mailNotification, "If checked a mail will be send to the given address when a queue is ready");
            this.cb_mailNotification.UseVisualStyleBackColor = true;
            this.cb_mailNotification.CheckedChanged += new System.EventHandler(this.cb_mailNotification_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Push notification provider:";
            // 
            // combo_pushProvider
            // 
            this.combo_pushProvider.AutoCompleteCustomSource.AddRange(new string[] {
            "none",
            "Pushover",
            "Notify My Android",
            "Prowl"});
            this.combo_pushProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_pushProvider.FormattingEnabled = true;
            this.combo_pushProvider.Items.AddRange(new object[] {
            "none",
            "PushOver",
            "Notify My Android",
            "Prowl"});
            this.combo_pushProvider.Location = new System.Drawing.Point(15, 202);
            this.combo_pushProvider.Name = "combo_pushProvider";
            this.combo_pushProvider.Size = new System.Drawing.Size(121, 21);
            this.combo_pushProvider.TabIndex = 23;
            this.combo_pushProvider.SelectedIndexChanged += new System.EventHandler(this.combo_pushProvider_SelectedIndexChanged);
            // 
            // btn_pushTest
            // 
            this.btn_pushTest.Enabled = false;
            this.btn_pushTest.Location = new System.Drawing.Point(229, 241);
            this.btn_pushTest.Name = "btn_pushTest";
            this.btn_pushTest.Size = new System.Drawing.Size(75, 23);
            this.btn_pushTest.TabIndex = 8;
            this.btn_pushTest.Text = "Test";
            this.toolTip1.SetToolTip(this.btn_pushTest, "Send a test push message with the given API/user key");
            this.btn_pushTest.UseVisualStyleBackColor = true;
            this.btn_pushTest.Click += new System.EventHandler(this.btn_pushTest_Click);
            // 
            // lnk_push
            // 
            this.lnk_push.AutoSize = true;
            this.lnk_push.Enabled = false;
            this.lnk_push.Location = new System.Drawing.Point(26, 267);
            this.lnk_push.Name = "lnk_push";
            this.lnk_push.Size = new System.Drawing.Size(122, 13);
            this.lnk_push.TabIndex = 5;
            this.lnk_push.TabStop = true;
            this.lnk_push.Text = "Get your API or user key";
            this.lnk_push.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_push_LinkClicked);
            // 
            // tb_pushKey
            // 
            this.tb_pushKey.Enabled = false;
            this.tb_pushKey.Location = new System.Drawing.Point(29, 244);
            this.tb_pushKey.Name = "tb_pushKey";
            this.tb_pushKey.Size = new System.Drawing.Size(194, 20);
            this.tb_pushKey.TabIndex = 2;
            // 
            // lbl_push
            // 
            this.lbl_push.AutoSize = true;
            this.lbl_push.Enabled = false;
            this.lbl_push.Location = new System.Drawing.Point(29, 229);
            this.lbl_push.Name = "lbl_push";
            this.lbl_push.Size = new System.Drawing.Size(107, 13);
            this.lbl_push.TabIndex = 1;
            this.lbl_push.Text = "Your API or user key:";
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(12, 315);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(119, 23);
            this.btn_restore.TabIndex = 19;
            this.btn_restore.Text = "Restore defaults";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // cb_antiAfk
            // 
            this.cb_antiAfk.AutoSize = true;
            this.cb_antiAfk.Location = new System.Drawing.Point(15, 23);
            this.cb_antiAfk.Name = "cb_antiAfk";
            this.cb_antiAfk.Size = new System.Drawing.Size(103, 17);
            this.cb_antiAfk.TabIndex = 10;
            this.cb_antiAfk.Text = "Enable Anti-AFK";
            this.toolTip1.SetToolTip(this.cb_antiAfk, "If checked Anti-AFK protection while in queue is enabled");
            this.cb_antiAfk.UseVisualStyleBackColor = true;
            // 
            // cb_autoJoin
            // 
            this.cb_autoJoin.AutoSize = true;
            this.cb_autoJoin.Location = new System.Drawing.Point(15, 46);
            this.cb_autoJoin.Name = "cb_autoJoin";
            this.cb_autoJoin.Size = new System.Drawing.Size(106, 17);
            this.cb_autoJoin.TabIndex = 11;
            this.cb_autoJoin.Text = "Enable Auto-Join";
            this.toolTip1.SetToolTip(this.cb_autoJoin, "If checked auto joining when a queue is ready is enabled");
            this.cb_autoJoin.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_antiAfk);
            this.groupBox3.Controls.Add(this.cb_autoJoin);
            this.groupBox3.Location = new System.Drawing.Point(342, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 95);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keyboard emulation options";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(208, 206);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 13);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "download";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Options
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(566, 347);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dungeon Teller - Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_opacity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_apply;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tb_pushKey;
		private System.Windows.Forms.Label lbl_push;
		private System.Windows.Forms.CheckBox cb_lockWindow;
		private System.Windows.Forms.CheckBox cb_balloonTips;
		private System.Windows.Forms.CheckBox cb_desktopNotification;
		private System.Windows.Forms.Button btn_pushTest;
		private System.Windows.Forms.LinkLabel lnk_push;
		private System.Windows.Forms.CheckBox cb_sound;
		private System.Windows.Forms.NumericUpDown num_opacity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_restore;
		private System.Windows.Forms.CheckBox cb_trayOnly;
		private System.Windows.Forms.CheckBox cb_autoSelect;
		private System.Windows.Forms.CheckBox cb_bringToFront;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox cb_antiAfk;
		private System.Windows.Forms.CheckBox cb_autoJoin;
		private System.Windows.Forms.CheckBox cb_pauseFocus;
		private System.Windows.Forms.CheckBox cb_updates;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox combo_pushProvider;
		private System.Windows.Forms.Button btn_mailTest;
		private System.Windows.Forms.TextBox tb_mailTo;
		private System.Windows.Forms.Label lbl_mailAddress;
		private System.Windows.Forms.CheckBox cb_mailNotification;
        private System.Windows.Forms.CheckBox useMQTT;
        private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
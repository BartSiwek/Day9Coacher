namespace Day9Coacher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playlistObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.filePathColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.slotDurationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playlistGroupBox = new System.Windows.Forms.GroupBox();
            this.removeSongButton = new System.Windows.Forms.Button();
            this.addSongButton = new System.Windows.Forms.Button();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeAmmountLabel = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicOnGamereplaysorgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.day9sStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.day9sBliptvArchivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.day9sYoutubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistObjectListView)).BeginInit();
            this.playlistGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.savePlaylistToolStripMenuItem,
            this.loadPlaylistToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newPlaylistToolStripMenuItem.Text = "&New Playlist";
            this.newPlaylistToolStripMenuItem.Click += new System.EventHandler(this.newPlaylistToolStripMenuItem_Click);
            // 
            // savePlaylistToolStripMenuItem
            // 
            this.savePlaylistToolStripMenuItem.Name = "savePlaylistToolStripMenuItem";
            this.savePlaylistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.savePlaylistToolStripMenuItem.Text = "&Save Playlist";
            this.savePlaylistToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistToolStripMenuItem_Click);
            // 
            // loadPlaylistToolStripMenuItem
            // 
            this.loadPlaylistToolStripMenuItem.Name = "loadPlaylistToolStripMenuItem";
            this.loadPlaylistToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadPlaylistToolStripMenuItem.Text = "&Load Playlist";
            this.loadPlaylistToolStripMenuItem.Click += new System.EventHandler(this.loadPlaylistToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playButton.Location = new System.Drawing.Point(12, 383);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(122, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play (Shift+Ctrl+Alt+A)";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.Location = new System.Drawing.Point(140, 383);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(124, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop (Shift+Ctrl+Alt+S)";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playlistObjectListView
            // 
            this.playlistObjectListView.AllColumns.Add(this.filePathColumn);
            this.playlistObjectListView.AllColumns.Add(this.slotDurationColumn);
            this.playlistObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistObjectListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.playlistObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filePathColumn,
            this.slotDurationColumn});
            this.playlistObjectListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playlistObjectListView.Location = new System.Drawing.Point(6, 19);
            this.playlistObjectListView.Name = "playlistObjectListView";
            this.playlistObjectListView.ShowGroups = false;
            this.playlistObjectListView.Size = new System.Drawing.Size(545, 296);
            this.playlistObjectListView.TabIndex = 4;
            this.playlistObjectListView.UseCompatibleStateImageBehavior = false;
            this.playlistObjectListView.View = System.Windows.Forms.View.Details;
            this.playlistObjectListView.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.playlistObjectListView_CellEditFinishing);
            this.playlistObjectListView.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.playlistObjectListView_CellEditValidating);
            this.playlistObjectListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playlistObjectListView_KeyDown);
            // 
            // filePathColumn
            // 
            this.filePathColumn.AspectName = "FilePath";
            this.filePathColumn.FillsFreeSpace = true;
            this.filePathColumn.IsEditable = false;
            this.filePathColumn.Text = "File path";
            // 
            // slotDurationColumn
            // 
            this.slotDurationColumn.AspectName = "SlotDurationInSeconds";
            this.slotDurationColumn.MaximumWidth = 100;
            this.slotDurationColumn.MinimumWidth = 100;
            this.slotDurationColumn.Text = "Slot duration (sec)";
            this.slotDurationColumn.Width = 100;
            // 
            // playlistGroupBox
            // 
            this.playlistGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistGroupBox.Controls.Add(this.removeSongButton);
            this.playlistGroupBox.Controls.Add(this.addSongButton);
            this.playlistGroupBox.Controls.Add(this.playlistObjectListView);
            this.playlistGroupBox.Location = new System.Drawing.Point(15, 27);
            this.playlistGroupBox.Name = "playlistGroupBox";
            this.playlistGroupBox.Size = new System.Drawing.Size(557, 350);
            this.playlistGroupBox.TabIndex = 6;
            this.playlistGroupBox.TabStop = false;
            this.playlistGroupBox.Text = "Playlist";
            // 
            // removeSongButton
            // 
            this.removeSongButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSongButton.Location = new System.Drawing.Point(35, 321);
            this.removeSongButton.Name = "removeSongButton";
            this.removeSongButton.Size = new System.Drawing.Size(23, 23);
            this.removeSongButton.TabIndex = 6;
            this.removeSongButton.Text = "-";
            this.removeSongButton.UseVisualStyleBackColor = true;
            this.removeSongButton.Click += new System.EventHandler(this.removeSongButton_Click);
            // 
            // addSongButton
            // 
            this.addSongButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSongButton.Location = new System.Drawing.Point(6, 321);
            this.addSongButton.Name = "addSongButton";
            this.addSongButton.Size = new System.Drawing.Size(23, 23);
            this.addSongButton.TabIndex = 5;
            this.addSongButton.Text = "+";
            this.addSongButton.UseVisualStyleBackColor = true;
            this.addSongButton.Click += new System.EventHandler(this.addSongButton_Click);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeTrackBar.AutoSize = false;
            this.volumeTrackBar.Location = new System.Drawing.Point(321, 383);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(218, 23);
            this.volumeTrackBar.TabIndex = 7;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 50;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(270, 388);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(45, 13);
            this.volumeLabel.TabIndex = 8;
            this.volumeLabel.Text = "Volume:";
            // 
            // volumeAmmountLabel
            // 
            this.volumeAmmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeAmmountLabel.AutoSize = true;
            this.volumeAmmountLabel.Location = new System.Drawing.Point(545, 388);
            this.volumeAmmountLabel.Name = "volumeAmmountLabel";
            this.volumeAmmountLabel.Size = new System.Drawing.Size(27, 13);
            this.volumeAmmountLabel.TabIndex = 9;
            this.volumeAmmountLabel.Text = "50%";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topicOnGamereplaysorgToolStripMenuItem,
            this.toolStripMenuItem2,
            this.day9sStreamToolStripMenuItem,
            this.day9sBliptvArchivesToolStripMenuItem,
            this.day9sYoutubeChannelToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // topicOnGamereplaysorgToolStripMenuItem
            // 
            this.topicOnGamereplaysorgToolStripMenuItem.Name = "topicOnGamereplaysorgToolStripMenuItem";
            this.topicOnGamereplaysorgToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.topicOnGamereplaysorgToolStripMenuItem.Text = "Topic on &Gamereplays.org";
            this.topicOnGamereplaysorgToolStripMenuItem.Click += new System.EventHandler(this.topicOnGamereplaysorgToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 6);
            // 
            // day9sStreamToolStripMenuItem
            // 
            this.day9sStreamToolStripMenuItem.Name = "day9sStreamToolStripMenuItem";
            this.day9sStreamToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.day9sStreamToolStripMenuItem.Text = "day[9]\'s &Stream";
            this.day9sStreamToolStripMenuItem.Click += new System.EventHandler(this.day9sStreamToolStripMenuItem_Click);
            // 
            // day9sBliptvArchivesToolStripMenuItem
            // 
            this.day9sBliptvArchivesToolStripMenuItem.Name = "day9sBliptvArchivesToolStripMenuItem";
            this.day9sBliptvArchivesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.day9sBliptvArchivesToolStripMenuItem.Text = "day[9]\'s &Blip.tv Archives";
            this.day9sBliptvArchivesToolStripMenuItem.Click += new System.EventHandler(this.day9sBliptvArchivesToolStripMenuItem_Click);
            // 
            // day9sYoutubeChannelToolStripMenuItem
            // 
            this.day9sYoutubeChannelToolStripMenuItem.Name = "day9sYoutubeChannelToolStripMenuItem";
            this.day9sYoutubeChannelToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.day9sYoutubeChannelToolStripMenuItem.Text = "day[9]\'s &Youtube Channel";
            this.day9sYoutubeChannelToolStripMenuItem.Click += new System.EventHandler(this.day9sYoutubeChannelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 414);
            this.Controls.Add(this.volumeAmmountLabel);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeTrackBar);
            this.Controls.Add(this.playlistGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "day[9]\'s Mental Checklist Coacher v1.0 (by Sify)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistObjectListView)).EndInit();
            this.playlistGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView playlistObjectListView;
        private BrightIdeasSoftware.OLVColumn filePathColumn;
        private BrightIdeasSoftware.OLVColumn slotDurationColumn;
        private System.Windows.Forms.GroupBox playlistGroupBox;
        private System.Windows.Forms.Button removeSongButton;
        private System.Windows.Forms.Button addSongButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadPlaylistToolStripMenuItem;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.Label volumeAmmountLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicOnGamereplaysorgToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem day9sStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem day9sBliptvArchivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem day9sYoutubeChannelToolStripMenuItem;
    }
}


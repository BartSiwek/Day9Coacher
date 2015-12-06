using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Media;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Xml.Serialization;
using System.Security;
using Day9CoacherPlayer;
using System.Diagnostics;

namespace Day9Coacher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Setup hook handler
            m_hook = new KeyboardHook();
            m_hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(m_hook_KeyPressed);

            //Setup playlist view
            SimpleDragSource dragSource = new SimpleDragSource();
            MyRearrangingDropSink dropSink = new MyRearrangingDropSink(false);
            dropSink.AfterDropped += playlistObjectListView_AfterDropped;

            playlistObjectListView.DragSource = dragSource;
            playlistObjectListView.DropSink = dropSink;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Try to register hooks
                m_hook.RegisterHotKey(MODIFIER_KEYS, Keys.A);
                m_hook.RegisterHotKey(MODIFIER_KEYS, Keys.S);
                m_hook.RegisterHotKey(MODIFIER_KEYS, Keys.D);

                //Get last sound volume
                float lastSoundVolume = Properties.Settings.Default.SoundVolume;

                //Update volume UI
                int trackBarValue = (int)(lastSoundVolume * volumeTrackBar.Maximum);
                volumeAmmountLabel.Text = string.Format("{0}%", trackBarValue);
                volumeTrackBar.Value = trackBarValue;

                //Send volume to player
                Player.Instance.SetVolume(lastSoundVolume);

                //Get last playlist
                Playlist lastPlaylist = Properties.Settings.Default.Playlist;
                if (lastPlaylist == null)
                {
                    lastPlaylist = new Playlist();
                }

                //Update playlist UI
                SetCurrentPlaylist(lastPlaylist);

                //Send playlist to player
                Player.Instance.SetPlaylist(lastPlaylist);
            }
            catch (InvalidOperationException)
            {
                //Show error
                MessageBox.Show("Could not register a hotkey. The program will now exit.", "Error", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error, 
                                MessageBoxDefaultButton.Button1);

                //Do exit
                Application.Exit();
            }
        }

        private void m_hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //Handle global hooks
            if (e.Key == Keys.A && e.Modifier == MODIFIER_KEYS)
            {
                playButton_Click(sender, EventArgs.Empty);
            }
            else if (e.Key == Keys.S && e.Modifier == MODIFIER_KEYS)
            {
                stopButton_Click(sender, EventArgs.Empty);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            //Stop playback
            Player.Close();
            
            //Save settings
            Properties.Settings.Default.Save();

            //Actually exit the app
            Application.Exit();
        }

        private void topicOnGamereplaysorgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.grOrgTopicUrl);
        }

        private void day9sStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.day9StreamUrl);
        }

        private void day9sBliptvArchivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.day9BlipUrl);
        }

        private void day9sYoutubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.day9YoutubeUrl);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop playback
            Player.Close();

            //Save settings
            Properties.Settings.Default.Save();

            //Actually exit the app
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //User pressed play
            Player.Instance.StartPlayback();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //User pressed stop
            Player.Instance.StopPlayback();
        }

        private void addSongButton_Click(object sender, EventArgs e)
        {
            //Create a song slection dialog
            OpenFileDialog addSongDialog = new OpenFileDialog();
            addSongDialog.Filter = "WAV files (*.wav)|*.wav|" +
                                   "MP3 files (*.mp3)|*.mp3";
            addSongDialog.InitialDirectory = addSongLastFolder;
            addSongDialog.Title = "Add file";
            addSongDialog.Multiselect = false;
            addSongDialog.CheckFileExists = true;
            addSongDialog.CheckPathExists = true;

            //Show the dialog
            if (addSongDialog.ShowDialog() == DialogResult.OK)
            {
                //Update last folder used
                addSongLastFolder = Path.GetDirectoryName(addSongDialog.FileName);

                //Create a new playlist entry
                PlaylistEntry entry = new PlaylistEntry(addSongDialog.FileName);

                //Add filename to playlist
                playlistObjectListView.AddObject(entry);

                //Update the player
                SendPlaylistToPlayer(GetCurrentPlaylist());
            }
        }

        private void playlistObjectListView_AfterDropped(object sender, EventArgs e)
        {
            //Get the playlist (before dropping occurs)
            Playlist newPlaylist = GetCurrentPlaylist();

            //Update the player
            SendPlaylistToPlayer(newPlaylist);
        }

        private void playlistObjectListView_CellEditValidating(object sender, CellEditEventArgs e)
        {
            //Check if the change pertains the right column
            if (e.Column == slotDurationColumn)
            {
                if (e.NewValue is double)
                {
                    double newSlotDuration = (double)e.NewValue;
                    if (newSlotDuration <= 0.0f)
                    {
                        //Less than zero - revert to old value
                        e.Cancel = true;
                    }
                }
                else
                {
                    //Not int - revert to old value
                    e.Cancel = true;
                }
            }
        }

        private void playlistObjectListView_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column == slotDurationColumn && !e.Cancel)
            {
                //Update the player
                Playlist newPlaylist = GetCurrentPlaylist();
                newPlaylist[e.ListViewItem.Index].SlotDurationInSeconds = (double)e.NewValue;
                SendPlaylistToPlayer(newPlaylist);
            }
        }

        private void removeSongButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedSong();
        }

        private void playlistObjectListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedSong();
            }
        }

        private void RemoveSelectedSong()
        {
            //Get selected song
            object selectedObject = playlistObjectListView.GetSelectedObject();

            if (selectedObject != null)
            {
                //Remove the song
                playlistObjectListView.RemoveObject(selectedObject);

                //Update player
                SendPlaylistToPlayer(GetCurrentPlaylist());
            }        
        }


        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear the playlist
            playlistObjectListView.ClearObjects();

            //Update the player
            SendPlaylistToPlayer(GetCurrentPlaylist());
        }

        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a playlist save dialog
            SaveFileDialog savePlaylistDialog = new SaveFileDialog();
            savePlaylistDialog.Filter = "XML files (*.xml)|*.xml";
            savePlaylistDialog.InitialDirectory = playlistLastFolder;
            savePlaylistDialog.Title = "Save playlist";
            savePlaylistDialog.CheckFileExists = false;
            savePlaylistDialog.CheckPathExists = false;

            //Show the dialog
            if (savePlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                //Update last folder used
                playlistLastFolder = Path.GetDirectoryName(savePlaylistDialog.FileName);

                //Cancel cell edit
                playlistObjectListView.CancelCellEdit();

                //Save playlist
                SavePlaylistToFile(savePlaylistDialog.FileName, GetCurrentPlaylist());
            }
        }

        private void loadPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a playlist save dialog
            OpenFileDialog loadPlaylistDialog = new OpenFileDialog();
            loadPlaylistDialog.Filter = "XML files (*.xml)|*.xml";
            loadPlaylistDialog.InitialDirectory = playlistLastFolder;
            loadPlaylistDialog.Title = "Load playlist";
            loadPlaylistDialog.Multiselect = false;
            loadPlaylistDialog.CheckFileExists = true;
            loadPlaylistDialog.CheckPathExists = true;

            //Show the dialog
            if (loadPlaylistDialog.ShowDialog() == DialogResult.OK)
            {
                //Update last folder used
                playlistLastFolder = Path.GetDirectoryName(loadPlaylistDialog.FileName);

                //Load playlist from file
                Playlist playlist = LoadPlaylistFromFile(loadPlaylistDialog.FileName);

                //Clear the current playlist
                playlistObjectListView.ClearObjects();

                //Load the new playlist
                SetCurrentPlaylist(playlist);

                //Update the player
                SendPlaylistToPlayer(playlist);
            }
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            //User changed the volume
            volumeAmmountLabel.Text = string.Format("{0}%", volumeTrackBar.Value);
            float newVolume = (float)volumeTrackBar.Value / (float)volumeTrackBar.Maximum;
            SendVolumeToPlayer(newVolume);
        }

        private void SavePlaylistToFile(string filename, Playlist playlist)
        {
            try
            {
                TextWriter writer = new StreamWriter(filename, false, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(Playlist));
                serializer.Serialize(writer, GetCurrentPlaylist());
                writer.Close();
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SecurityException se)
            {
                MessageBox.Show(se.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Playlist LoadPlaylistFromFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(Playlist));
                Playlist playlist = (Playlist)serializer.Deserialize(fs);
                fs.Close();
                return playlist;
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException nse)
            {
                MessageBox.Show(nse.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SecurityException se)
            {
                MessageBox.Show(se.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(uae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If loading fails return empty list
            return new Playlist();
        }

        private void SendPlaylistToPlayer(Playlist playlist)
        {
            Properties.Settings.Default.Playlist = playlist;
            Player.Instance.SetPlaylist(playlist);
        }

        private void SendVolumeToPlayer(float volume)
        {
            Properties.Settings.Default.SoundVolume = volume;
            Player.Instance.SetVolume(volume);
        }

        private Playlist GetCurrentPlaylist()
        {
            Playlist playlist = new Playlist();
            for (int modelObjectIndex = 0; modelObjectIndex < playlistObjectListView.GetItemCount(); ++modelObjectIndex)
            {
                playlist.AddSong((PlaylistEntry)playlistObjectListView.GetModelObject(modelObjectIndex));
            }
            return playlist;
        }

        private void SetCurrentPlaylist(Playlist playlist)
        {
            playlistObjectListView.SetObjects(playlist.Entries);
        }

        static string addSongLastFolder = Environment.CurrentDirectory;
        static string playlistLastFolder = Environment.CurrentDirectory;

        private KeyboardHook m_hook;
        private const Day9Coacher.ModifierKeys MODIFIER_KEYS = Day9Coacher.ModifierKeys.Control |
                                                               Day9Coacher.ModifierKeys.Shift |
                                                               Day9Coacher.ModifierKeys.Alt;
    }
}

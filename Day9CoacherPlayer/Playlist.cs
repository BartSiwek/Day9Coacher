using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Day9CoacherPlayer
{
    [Serializable]
    [XmlRoot(ElementName="Playlist", IsNullable=false)]
    public sealed class Playlist
    {
        public Playlist()
        {
            m_playlist = new List<PlaylistEntry>();
        }

        public void AddSong(string filename)
        {
            PlaylistEntry newEntry = new PlaylistEntry(filename);
            m_playlist.Add(newEntry);
        }

        public void AddSong(string filename, double slotDuration)
        {
            PlaylistEntry newEntry = new PlaylistEntry(filename, slotDuration);
            m_playlist.Add(newEntry);
        }

        public void AddSong(PlaylistEntry entry)
        {
            m_playlist.Add(entry);
        }

        public void AddSong(PlaylistEntry entry, int index)
        {
            m_playlist.Insert(index, entry);
        }

        public PlaylistEntry this[int index]
        {
            get 
            {
                return m_playlist[index];
            }
            set 
            {
                m_playlist[index] = value;
            }
        }

        public void RemoveSong(int index)
        {
            m_playlist.RemoveAt(index);
        }

        [XmlElement("Entries")]
        public List<PlaylistEntry> Entries
        {
            get
            {
                return m_playlist;
            }
        }

        public int Count
        {
            get
            {
                return m_playlist.Count;
            }
        }

        private List<PlaylistEntry> m_playlist;
    }
}

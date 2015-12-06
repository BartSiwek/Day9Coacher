using System;
using System.Media;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Day9CoacherPlayer
{
    [Serializable]
    public sealed class PlaylistEntry
    {
        public PlaylistEntry() : this("", DEFAULT_SLOT_DURATION)
        { }

        public PlaylistEntry(string filePath) : this(filePath, DEFAULT_SLOT_DURATION)
        { }

        public PlaylistEntry(string filePath, double slotDuration)
        {
            FilePath = filePath;
            SlotDurationInSeconds = slotDuration;
        }

        [XmlAttribute("Path")]
        public string FilePath
        {
            get;
            set;
        }

        [XmlAttribute("SlotDuration")]
        public double SlotDurationInSeconds
        {
            get;
            set;
        }

        private const int DEFAULT_SLOT_DURATION = 5;
    }
}

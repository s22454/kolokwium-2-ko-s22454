using System.Collections.Generic;

namespace kolokwium_2_ko_s22454.Models.DTOs
{
    public class MusicianGet
    {
        public int IdMusican { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public class Track
        {
            public int IdTrack { get; set; }
            public string TrackName { get; set; }
            public float Duraturation { get; set; }
            public int? IdMusicAlbum { get; set; }
        }
    }
}
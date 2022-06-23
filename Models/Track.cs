using System.Collections.Generic;

namespace kolokwium_2_ko_s22454.Models
{
    public class Track
    {
        public Track()
        {
            MusicanTracks = new HashSet<Musican_Track>();
        }
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duraturation { get; set; }
        public int? IdMusicAlbum { get; set; }
        public virtual IEnumerable<Musican_Track> MusicanTracks { get; set; }
    }
}
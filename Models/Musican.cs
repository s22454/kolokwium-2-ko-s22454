using System.Collections.Generic;

namespace kolokwium_2_ko_s22454.Models
{
    public class Musican
    {

        public Musican()
        {
            MusicanTracks = new HashSet<Musican_Track>();
        }
        public int IdMusican { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public virtual ICollection<Musican_Track> MusicanTracks { get; set; }
    }
}
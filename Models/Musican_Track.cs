namespace kolokwium_2_ko_s22454.Models
{
    public class Musican_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Musican Musican { get; set; }
        public virtual Track Track { get; set; }
    }
}
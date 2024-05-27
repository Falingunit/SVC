using System.Text.Json;

namespace SVC.Models
{
    public class GalleryAlbum
    {
        public string name { get; set; }

        public string description { get; set; }

        public GalleryImage[] images { get; set; }

        public override string ToString() => JsonSerializer.Serialize<GalleryAlbum>(this);
    }
}

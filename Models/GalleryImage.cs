using System.Text.Json;

namespace SVC.Models
{
    public class GalleryImage
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public string _path;
        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
				_path = value;
            }
        }

        public override string ToString() => JsonSerializer.Serialize<GalleryImage>(this);

    }
}
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SVC.Models;
using System.Text.Json;

namespace SVC.Services
{
    public class JsonFileGalleryImageService
    {

        public string Prefix {  get; set; }

        public GalleryAlbum[] Albums { get; set; }

		private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "gallery", "gallerydata.json");

		public JsonFileGalleryImageService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            Prefix = "images/";

			using var jsonFileReader = File.OpenText(JsonFileName);
			Albums = JsonSerializer.Deserialize<GalleryAlbum[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		    if (Albums == null)
            {
                throw new Exception("Unable to get album data!");
            }
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        public IEnumerable<GalleryImage> GetImages(string albumName)
        {
            foreach (GalleryAlbum album in this.Albums)
            {
                if (album.name == albumName)
                {
                    foreach (GalleryImage image in album.images)
                    {
                        image.Path = Prefix + image.Path;
                    }
                    return album.images;
                }
            }

            throw new ArgumentException("Given album doesnt exist. {" + albumName + "}");
        }
    }
}
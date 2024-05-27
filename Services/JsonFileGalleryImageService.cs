using Microsoft.AspNetCore.Mvc.ModelBinding;
using SVC.Models;
using System.Text.Json;

namespace SVC.Services
{
    public class JsonFileGalleryImageService
    {

        public string Prefix {  get; set; }

        public JsonFileGalleryImageService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            Prefix = "images/";
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "gallery", "gallerydata.json");

        public IEnumerable<GalleryImage> GetImages(string albumName)
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            var albums = JsonSerializer.Deserialize<GalleryAlbum[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            foreach (GalleryAlbum album in albums)
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

            throw new ArgumentException("Given album doesnt exist");
        }
    }
}
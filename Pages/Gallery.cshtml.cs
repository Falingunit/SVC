using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SVC.Models;
using SVC.Services;

namespace SVC.Pages
{
    public class GalleryModel : PageModel
    {
        public JsonFileGalleryImageService GalleryService;

        public GalleryModel(JsonFileGalleryImageService galleryService)
        {
            this.GalleryService = galleryService;
            
        }
    }
}

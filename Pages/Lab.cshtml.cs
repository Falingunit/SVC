using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SVC.Models;
using SVC.Services;

namespace SVC.Pages
{
    public class LabModel : PageModel
    {
        public JsonFileGalleryImageService GalleryService;

        public LabModel(JsonFileGalleryImageService galleryService)
        {
            this.GalleryService = galleryService;
        }
    }
}

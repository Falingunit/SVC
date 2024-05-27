using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SVC.Services;

namespace SVC.Pages.Departments
{
    public class DepartmentsModel : PageModel
    {
        public JsonFileGalleryImageService GalleryService;

        public DepartmentsModel(JsonFileGalleryImageService galleryService)
        {
            this.GalleryService = galleryService;
            this.GalleryService.Prefix = "../images/";
        }
    }
}

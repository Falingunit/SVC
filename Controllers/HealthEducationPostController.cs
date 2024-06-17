using Microsoft.AspNetCore.Mvc;


namespace SVC.Controllers
{
    public class HealthEducationPostController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public HealthEducationPostController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
    }


}

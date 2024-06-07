using Microsoft.AspNetCore.Mvc;


namespace SVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public BlogController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
    }


}

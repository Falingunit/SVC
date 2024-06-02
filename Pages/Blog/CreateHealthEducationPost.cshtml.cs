using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SVC.Pages.Blog
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SVC.DatabaseContexts;
    using SVC.Models;
    using System.Threading.Tasks;

    public class CreateHealthEducationPostModel : PageModel
    {
        private readonly BlogContext _context;

        public CreateHealthEducationPostModel(BlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BlogPost.DateCreated = DateTime.Now;
            _context.BlogPosts.Add(BlogPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./HealthEducationIndex");
        }
    }

}

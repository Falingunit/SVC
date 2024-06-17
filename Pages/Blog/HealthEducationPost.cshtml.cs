using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SVC.Pages.Blog
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using SVC.DatabaseContexts;
    using SVC.Models;
    using System.Threading.Tasks;

    public class HealthEducationPostModel : PageModel
    {
        private readonly SVCDatabaseContext _context;

        public HealthEducationPostModel(SVCDatabaseContext context)
        {
            _context = context;
        }

        public HealthEducationPost BlogPost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPost = await _context.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);

            if (BlogPost == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}

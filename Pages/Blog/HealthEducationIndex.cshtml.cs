using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SVC.Pages.Blog
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using SVC.DatabaseContexts;
    using SVC.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HealthEducationIndexModel : PageModel
    {
        private readonly SVCDatabaseContext _context;

        public HealthEducationIndexModel(SVCDatabaseContext context)
        {
            _context = context;
        }

        public IList<HealthEducationPost> BlogPosts { get; set; }

        public async Task OnGetAsync()
        {
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }

}

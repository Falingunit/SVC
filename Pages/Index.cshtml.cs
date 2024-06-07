using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SVC.DatabaseContexts;
using SVC.Models;

namespace SVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private BlogContext _context;

        public IndexModel(ILogger<IndexModel> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<BlogPost> BlogPosts { get; private set; }

        public async Task OnGetAsync()
        {
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }
}

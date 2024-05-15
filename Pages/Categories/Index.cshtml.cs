using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budget.Data;
using Budget.Models;

namespace Budget.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Budget.Data.BudgetContext _context;

        public IndexModel(Budget.Data.BudgetContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}

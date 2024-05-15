using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budget.Data;
using Budget.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Budget.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Budget.Data.BudgetContext _context;

        public CreateModel(Budget.Data.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Categories.Add(Category);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                if (innerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    // Unique constraint violation
                    ModelState.AddModelError(string.Empty, "Category name must be unique.");
                    return Page();
                }
                else
                {
                    // Other database exception, rethrow
                    throw;
                }
            }
        }
    }
}

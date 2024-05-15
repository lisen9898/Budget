using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budget.Data;
using Budget.Models;

namespace Budget.Pages.Transactions
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
        ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage);
                }

                return Page();
            }

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

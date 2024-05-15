using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budget.Data;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class DetailsModel : PageModel
    {
        private readonly Budget.Data.BudgetContext _context;

        public DetailsModel(Budget.Data.BudgetContext context)
        {
            _context = context;
        }

        public Transaction Transaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            Transaction = transaction;
            return Page();
        }
    }
}

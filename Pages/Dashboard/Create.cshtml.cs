using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TTG.Data;
using TTG.Models;

namespace TTG.Pages.Dashboard
{
    public class CreateModel : PageModel
    {
        private readonly TTG.Data.ApplicationDbContext _context;

        public CreateModel(TTG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrainTrip TrainTrip { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainTrip.Add(TrainTrip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

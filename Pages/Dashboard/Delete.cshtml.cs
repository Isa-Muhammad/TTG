using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TTG.Data;
using TTG.Models;

namespace TTG.Pages.Dashboard
{
    public class DeleteModel : PageModel
    {
        private readonly TTG.Data.ApplicationDbContext _context;

        public DeleteModel(TTG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainTrip TrainTrip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainTrip = await _context.TrainTrip.FirstOrDefaultAsync(m => m.Id == id);

            if (TrainTrip == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainTrip = await _context.TrainTrip.FindAsync(id);

            if (TrainTrip != null)
            {
                _context.TrainTrip.Remove(TrainTrip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

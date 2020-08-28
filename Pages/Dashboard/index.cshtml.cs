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
    public class IndexModel : PageModel
    {
        private readonly TTG.Data.ApplicationDbContext _context;

        public IndexModel(TTG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TrainTrip> TrainTrips { get; set; }

        public async Task OnGetAsync()
        {
            TrainTrips = await _context.TrainTrip.ToListAsync();
        }
    }
}

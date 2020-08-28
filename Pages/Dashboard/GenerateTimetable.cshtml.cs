using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TTG.Models;

namespace TTG.Pages.Dashboard
{
    public class GenerateTimetableModel : PageModel
    {
        private readonly TTG.Data.ApplicationDbContext _context;

        public GenerateTimetableModel(TTG.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DataTable Timetable { get; set; }

        public async Task OnGetAsync()
        {
            Timetable = new DataTable();

            var trainTrips = await _context.TrainTrip.ToListAsync();

            Timetable.Columns.Add("Descriptions");
            Timetable.Columns.Add("Train Code");

            foreach (var tt in trainTrips)
            {
                string columnName = "Departure " + tt.DepartureStation;

                if (!Timetable.Columns.Contains(columnName))
                    Timetable.Columns.Add(columnName);

                columnName = "Arrival " + tt.ArrivalStation;

                if (!Timetable.Columns.Contains(columnName))
                    Timetable.Columns.Add(columnName);
            }

            int count = 0;
            string trainCode = "";

            DataRow row = null;

            foreach (var tt in trainTrips)
            {
                if (trainCode != tt.TrainCode)
                {
                    count++;

                    row = Timetable.NewRow();

                    row["Descriptions"] = "Trip " + count;
                    row["Train Code"] = tt.TrainCode;

                    Timetable.Rows.Add(row);

                    trainCode = tt.TrainCode;
                }

                string columnName = "Departure " + tt.DepartureStation;
                row[columnName] = tt.DepartureTime;

                columnName = "Arrival " + tt.ArrivalStation;
                row[columnName] = tt.ArrivalTime;
            }

            Debug.WriteLine(Timetable);
        }
    }
}

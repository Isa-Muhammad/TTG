using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TTG.Models
{
    public class TrainTrip
    {
        public int Id { get; set; }

        [Display(Name = "Train Code")]
        [Required]
        public string TrainCode { get; set; }

        [Display(Name = "Departure Station")]
        [Required]
        public string DepartureStation { get; set; }

        [Display(Name = "Arrival Station")]
        [Required]
        public string ArrivalStation { get; set; }

        [Display(Name = "Departure Time")]
        [Required]
        public string DepartureTime { get; set; }

        [Display(Name = "Arrival Time")]
        [Required]
        public string ArrivalTime { get; set; }
    }
}

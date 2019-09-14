using System;
using System.Collections.Generic;

namespace TASK2.Models
{
    public partial class Flight
    {
        public int Id { get; set; }
        public int? AirlineId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArivalTime { get; set; }
    }
}

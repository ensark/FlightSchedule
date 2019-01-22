using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.DataAccessLayer.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        [Required]
        public DateTimeOffset DepartureTime { get; set; }

        [Required]
        public DateTimeOffset ArrivalTime { get; set; }

        [Required]
        public int AirlineId { get; set; }
    }
}

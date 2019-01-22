using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSchedule.DataAccessLayer.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        [Required]
        public int OriginCityId { get; set; }

        [Required]
        public int DestinationCityId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DepartureDate { get; set; }

        public ICollection<Flight> Flights { get; } = new Collection<Flight>();
    }
}

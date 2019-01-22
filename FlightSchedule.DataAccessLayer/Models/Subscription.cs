using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.DataAccessLayer.Models
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public int OriginCityId { get; set; }

        [Required]
        public int DestinationCityId { get; set; }
    }
}

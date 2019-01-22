using System;

namespace FlightSchedule.Contracts
{
    public class FlightSearchQuery
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AgencyId { get; set; }
    }
}

using System;

namespace FlightSchedule.Contracts
{
    public class QueryResult
    {
        public int FlightId { get; set; }
        public int OriginCityId { get; set; }
        public int DestinationCityId { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int AirlineId { get; set; }
        public int AgencyId { get; set; }
    }
}

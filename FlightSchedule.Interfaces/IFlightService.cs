using System.Collections.Generic;
using FlightSchedule.Contracts;

namespace FlightSchedule.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<QueryResult> Search(FlightSearchQuery searchParameters);
    }
}

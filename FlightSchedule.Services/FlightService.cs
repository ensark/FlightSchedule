using System.Collections.Generic;
using FlightSchedule.Contracts;
using FlightSchedule.Interfaces;

namespace FlightSchedule.Services
{
    public class FlightService: IFlightService
    {
        private readonly IRepository<QueryResult, FlightSearchQuery> _flightRepository;

        public FlightService(IRepository<QueryResult, FlightSearchQuery> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<QueryResult> Search(FlightSearchQuery searchParameters)
        {
            return _flightRepository.Search(searchParameters);
        }
    }
}

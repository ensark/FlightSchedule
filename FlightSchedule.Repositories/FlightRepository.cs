using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Contracts;
using FlightSchedule.Interfaces;
using FlightSchedule.DataAccessLayer.Context;

namespace FlightSchedule.Repositories
{
    public class FlightRepository : IRepository<QueryResult, FlightSearchQuery>
    {
        private readonly IMapper _mapper;

        public FlightRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<QueryResult> Search(FlightSearchQuery searchQuery)
        {
            using (var context = new FlightScheduleDbContext())
            {
                var query = from routes in context.Routes
                            join flights in context.Flights
                            on routes.RouteId equals flights.RouteId
                            join subscriptions in context.Subscriptions
                            on routes.OriginCityId equals subscriptions.OriginCityId
                            where routes.DepartureDate >= searchQuery.StartDate.Date && routes.DepartureDate < searchQuery.EndDate.Date
                            && subscriptions.AgencyId == searchQuery.AgencyId
                            select new QueryResult
                            {
                                FlightId = flights.FlightId,
                                OriginCityId = routes.OriginCityId,
                                DestinationCityId = routes.DestinationCityId,
                                DepartureTime = flights.DepartureTime,
                                ArrivalTime = flights.ArrivalTime,
                                AirlineId = flights.AirlineId,
                                AgencyId = subscriptions.AgencyId
                            };
                var result = query.ToList();

                var mappedFlights = _mapper.Map<IEnumerable<QueryResult>>(result);
                return mappedFlights;
            }
        }
    }
}

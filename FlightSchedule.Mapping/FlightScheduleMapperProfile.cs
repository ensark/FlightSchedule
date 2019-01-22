using AutoMapper;
using contracts = FlightSchedule.Contracts;
using domain = FlightSchedule.DataAccessLayer.Models;

namespace FlightSchedule.Mapping
{
    public class FlightScheduleMapperProfile: Profile
    {
        public FlightScheduleMapperProfile()
        {
            CreateMap<contracts.QueryResult, domain.QueryResult>()
               .ReverseMap();
        }
    }
}

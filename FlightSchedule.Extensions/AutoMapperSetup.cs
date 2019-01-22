using AutoMapper;

namespace FlightSchedule.Extensions
{
    public class AutoMapperSetup
    {
        public static readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfiles("FlightSchedule.Mapping");
            cfg.CreateMissingTypeMaps = false;
        });
    }
}

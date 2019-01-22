using System;
using System.IO;
using FlightSchedule.Contracts;
using FlightSchedule.Interfaces;

namespace FlightSchedule.ConsoleUI
{
    public class Application
    {
        private readonly IFlightService _flightService;
        private readonly IRepository<QueryResult, FlightSearchQuery> _flightRepository;

        public Application(IFlightService flightService, IRepository<QueryResult, FlightSearchQuery> flightRepository)
        {
            _flightService = flightService;
            _flightRepository = flightRepository;
        }

        public void PrintResult(FlightSearchQuery searchQuery)
        {
            var flights = _flightService.Search(searchQuery);

            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream("../../../CSVResults/Results_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", FileMode.OpenOrCreate, FileAccess.Write);
            writer = new StreamWriter(ostrm);

            Console.SetOut(writer);
            Console.WriteLine("   FlightId  " + "|" + " OriginCityId  " + "|" + " DestinationCityId " + "|" + "        DepartureTime        " + " |" + "       ArrivalTime         " + "|" + "   AirlineId");

            foreach (var flight in flights)
            {
                Console.WriteLine("   " + flight.FlightId + "   |      " + flight.OriginCityId + "     |        " + flight.DestinationCityId + "        |   " + flight.DepartureTime + "  | " + flight.ArrivalTime + " |       " + flight.AirlineId);
            }
            Console.SetOut(oldOut);

            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}

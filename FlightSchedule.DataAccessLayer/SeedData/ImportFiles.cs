using FlightSchedule.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightSchedule.DataAccessLayer.Context
{
    public class ImportFiles
    {
        public static IEnumerable<Route> GetRoutes()
        {
            var sourceFile = ("../../../../FlightSchedule.DataAccessLayer/SeedData/CSV/routes.csv");

            var routes = from line in File.ReadAllLines(sourceFile).Skip(1)
                         let columns = line.Split(',')
                         select new Route
                         {
                             RouteId = Convert.ToInt32(columns[0]),
                             OriginCityId = Convert.ToInt32(columns[1]),
                             DestinationCityId = Convert.ToInt32(columns[2])
                         };
            return routes;
        }

        public static IEnumerable<Flight> GetFlights()
        {
            var sourceFile = ("../../../../FlightSchedule.DataAccessLayer/SeedData/CSV/flights.csv");
           
            var flights = from line in File.ReadAllLines(sourceFile).Skip(1)
                          let columns = line.Split(',')
                          select new Flight
                          {
                              FlightId = Convert.ToInt32(columns[0]),
                              RouteId = Convert.ToInt32(columns[1]),
                              DepartureTime = Convert.ToDateTime(columns[2]),
                              ArrivalTime = Convert.ToDateTime(columns[3]),
                              AirlineId = Convert.ToInt32(columns[4])
                          };
            return flights;
        }

        public static IEnumerable<Subscription> GetSubscriptions()
        {
            var sourceFile = ("../../../../FlightSchedule.DataAccessLayer/SeedData/CSV/subscriptions.csv");
       
            var subscriptions = from line in File.ReadAllLines(sourceFile).Skip(1)
                                let columns = line.Split(',')
                                select new Subscription
                                {
                                    Id = Guid.NewGuid(),
                                    AgencyId = Convert.ToInt32(columns[0]),
                                    OriginCityId = Convert.ToInt32(columns[1]),
                                    DestinationCityId = Convert.ToInt32(columns[2])
                                };
            return subscriptions;
        }
    }
}

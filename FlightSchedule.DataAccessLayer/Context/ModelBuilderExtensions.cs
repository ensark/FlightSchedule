using System;
using Microsoft.EntityFrameworkCore;
using FlightSchedule.DataAccessLayer.Models;

namespace FlightSchedule.DataAccessLayer.Context
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRoutes(this ModelBuilder modelBuilder)
        {
            //foreach (var route in ImportFiles.GetRoutes())
            //{
            //    modelBuilder.Entity<Route>().HasData(
            //        new Route
            //        {
            //            RouteId = route.RouteId,
            //            OriginCityId = route.OriginCityId,
            //            DestinationCityId = route.DestinationCityId,
            //        });
            //}
        }

        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            //foreach (var flight in ImportFiles.GetFlights())
            //{
            //    modelBuilder.Entity<Flight>().HasData(
            //        new Flight
            //        {
            //            FlightId = flight.FlightId,
            //            RouteId = flight.RouteId,
            //            DepartureTime = flight.DepartureTime,
            //            ArrivalTime = flight.ArrivalTime,
            //            AirlineId = flight.AirlineId
            //        });
            //}
        }

        public static void SeedSubscriptions(this ModelBuilder modelBuilder)
        {
            //foreach (var subscription in ImportFiles.GetSubscriptions())
            //{
            //    modelBuilder.Entity<Subscription>().HasData(
            //        new Subscription
            //        {
            //            Id = subscription.Id,
            //            AgencyId = subscription.AgencyId,
            //            OriginCityId = subscription.OriginCityId,
            //            DestinationCityId = subscription.DestinationCityId,
            //        });
            //}
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Autofac;
using System;

using FlightSchedule.ConsoleUI;
using FlightSchedule.Services;
using FlightSchedule.Interfaces;
using FlightSchedule.Contracts;
using FlightSchedule.Repositories;
using FlightSchedule.Mapping;
using FlightSchedule.DataAccessLayer.Context;

namespace FlightSchedule.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Flight Schedule";

            DateTime startDate;
            DateTime endDate;
            int agencyId;

            Console.WriteLine("Please enter parameters in correct format like this: 2018-01-01 2018-01-15 1 ");

            if (args.Length > 0)
            {
                string userInput = Console.ReadLine();
                string[] values = userInput.Split(' ');

                startDate = DateTime.Parse(values[0]).Date;
                endDate = DateTime.Parse(values[1]).Date;
                agencyId = int.Parse(values[2]);

                var flightSearchQuery = new FlightSearchQuery();
                flightSearchQuery.StartDate = startDate;
                flightSearchQuery.EndDate = endDate;
                flightSearchQuery.AgencyId = agencyId;

                Console.WriteLine("Please wait until the results are saved...");
                BuildContainer().Resolve<Application>().PrintResult(flightSearchQuery);
            }
            else
            {
                Console.WriteLine("No arguments were passed.");
            }

            using (var context = new FlightScheduleDbContext())
            {
                context.Database.Migrate();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();


        // Builder for IOC container and Mapper for Console Application
        static private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();

            builder.Register(
                c => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new FlightScheduleMapperProfile());
                }))
                .AsSelf()
                .SingleInstance();

            builder.Register(
                c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FlightRepository>().As<IRepository<QueryResult, FlightSearchQuery>>().InstancePerDependency();
            builder.RegisterType<FlightService>().As<IFlightService>().InstancePerDependency();
            return builder.Build();
        }
    }
}

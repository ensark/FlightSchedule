using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSchedule.Interfaces;
using FlightSchedule.Repositories;
using FlightSchedule.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using FlightSchedule.Contracts;

namespace FlightSchedule.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            AddIocMapping(services);

            services.AddMvc();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My First Swagger" });
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger");
            });

            app.UseMvc();
        }

        public void AddIocMapping(IServiceCollection services)
        {
            services.AddScoped<IRepository<QueryResult, FlightSearchQuery>, FlightRepository>();
            services.AddScoped<IFlightService, FlightService>();
        }
    }
}

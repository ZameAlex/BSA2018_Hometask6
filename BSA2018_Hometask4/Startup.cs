using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BSA2018_Hometask4.BLL.Services;
using BSA2018_Hometask4.BLL.Interfaces;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.BLL.Validators;
using BSA2018_Hometask4.BLL;
using DAL.UnitOfWork;
using BSA2018_Hometask4.BLL.Mapping;

namespace BSA2018_Hometask4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IDepartureService, DepartureService>();
            services.AddScoped<IStewadressService, StewadressService>();
            services.AddScoped<IPilotService, PilotService>();
            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<ICrewService, CrewService>();
            services.AddScoped<ITypeService, TypeService>();

            services.AddTransient<AbstractValidator<FlightDto>, FlightValidator>();
            services.AddTransient<AbstractValidator<DepartureDto>, DepartureValidator>();
            services.AddTransient<AbstractValidator<TicketDto>, TicketValidator>();
            services.AddTransient<AbstractValidator<StewadressDto>, StewadressValidator>();
            services.AddTransient<AbstractValidator<PilotDto>, PilotValidator>();
            services.AddTransient<AbstractValidator<CrewDto>, CrewValidator>();
            services.AddTransient<AbstractValidator<PlaneDto>, PlaneValidator>();
            services.AddTransient<AbstractValidator<TypeDto>, TypeValidator>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IMapper, Mapping>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

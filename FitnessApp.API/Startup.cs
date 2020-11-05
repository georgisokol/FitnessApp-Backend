using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.API.Contexts;
using FitnessApp.API.Services;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.API
{
    public class Startup
    {
        private readonly object _configuration;

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)    
        {
            services.AddMvc();

            var connectionString = @"Server=(localdb)\mssqllocaldb; DataBase = MacrosDB; Trusted_Connection = True; "; 
            services.AddDbContext<MacrosContext>(o =>
            o.UseSqlServer(connectionString)
            ); ;

            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            services.AddHangfireServer(); 

            services.AddScoped<IMacrosRepository, MacrosRepository>();
            services.AddTransient<IRecurringJobsService, RecurringJobsService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseMvc();

            // Adding Hangfire
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            // [*************BackgroundJobs****************]
            RecurringJob.AddOrUpdate<IRecurringJobsService>("ClearTheDailyIntakeMacrosAndMoveItToHistory", x => x.StartRecurringBackroundJobs(), "0 5 * * *"); //Clear Daily Macros Table And Move it To History at 5
           
        }
    }
}

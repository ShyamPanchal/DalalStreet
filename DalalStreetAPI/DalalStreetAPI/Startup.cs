using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Cron;
using DalalStreetAPI.Models;
using DalalStreetAPI.Services;
using FluentScheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace DalalStreetAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<DS_Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DS_db")));

            services.AddScoped<IDS_CompanyService, DS_CompanyService>();
            services.AddScoped<IDS_CompanyCategoryService, DS_CompanyCategoryService>();
            services.AddScoped<IDS_NewCompanyNamesService, DS_NewCompanyNamesService>();
            services.AddScoped<IDS_EventTypesService, DS_EventTypesService>();
            services.AddScoped<IDS_NewsEventService, DS_NewsEventService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IDS_PlayerService, DS_PlayerService>();

            services.AddMvc(options =>
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
            }).AddXmlSerializerFormatters();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Info
                {
                    Title = "Dalal Street API",
                    Version = "v1",
                    Description = "Service for Dalal Street using Async "
                });
            });

            #region Cron

            ServiceProvider provider = services.BuildServiceProvider();

            Registry updateFunction = new Registry();
            updateFunction.Schedule(() => new UpdateCron(provider)).ToRunNow().AndEvery(10).Seconds();

            JobManager.UseUtcTime();
            JobManager.Initialize(updateFunction);

            Console.WriteLine("Update function registered.");

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Console.WriteLine("In Development Mode");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                Console.WriteLine("Not In Development Mode");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dalal Street Services");
                options.RoutePrefix = string.Empty;
                });
        }
    }
}

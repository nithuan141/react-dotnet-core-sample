using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Timelogger.Api.BL;
using Timelogger.Api.DataAccess;
using Timelogger.Entities;

namespace Timelogger.Api
{
    public class Startup
	{
		private readonly IHostingEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}

			services.AddMvc(options =>
            {
                // Adding the custom exception filter
                options.Filters.Add(new TimerExceptionFilter());
            });
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
            }
            
			app.UseMvc();

			// Seed "database" with example data
			var context = app.ApplicationServices.GetService<ApiContext>();
			AddExampleData(context);
            AddExampleTimeData(context);
		}

        /// <summary>
        /// Configure the dependcies of the API
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDependencies(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            services.AddTransient<IProjectBC, ProjectBC>();
            services.AddTransient<IProjectDAC, ProjectDAC>();
            services.AddSingleton<IInvoiceFactory, InvoiceFactory>();
            services.AddTransient<IWorkDAC, WorkDAC>();
            services.AddTransient<IWorkBC, WorkBC>();
        }

        private static void AddExampleData(ApiContext context)
        {
            var testProject1 = new Project
            {
                Id = 1,
                Name = "Test Project"
            };

            var testProject2 = new Project
            {
                Id = 2,
                Name = "Project 1"
            };

            var testProject3 = new Project
            {
                Id = 3,
                Name = "Project 2"
            };

            context.Projects.Add(testProject1);
            context.Projects.Add(testProject2);
            context.Projects.Add(testProject3);

            context.SaveChanges();
        }

        private static void AddExampleTimeData(ApiContext context)
        {
            var testData1 = new Work
            {
                Id = 1,
                HoursSpend = 5,
                ProjectId = 1,
                UserId = 1
            };

            var testData2 = new Work
            {
                Id = 2,
                HoursSpend = 6,
                ProjectId = 2,
                UserId = 1
            };

            context.Work.Add(testData2);
            context.Work.Add(testData1);

            context.SaveChanges();
        }
    }
}

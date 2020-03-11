using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TournamentsRecord.DAL.DataAccess;
using TournamentsRecord.DAL.Exception;
using TournamentsRecord.Utilities.ExceptionHandling.Extensions;

namespace TournamentsRecord.API
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
            services.AddControllers();
            //services.AddDbContext<TournamentsRecordContext>(options => {
            //    options.UseSqlServer("TournamentsRecordDB");
            //});

            services
                .AddDbContextPool<TournamentsRecordContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TournamentsRecordDB")));

            //ashi : in future move this to extension method for DAL
            //services.AddScoped(typeof(IRepository<AuditTrail>), typeof(AuditTrailRepository));
            services.AddTransient(typeof(IRepositoryExceptionHandler), typeof(RepositoryExceptionHandler));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApiExceptionHandler();

            loggerFactory.AddFile("Logs/myapp-{Date}.txt");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

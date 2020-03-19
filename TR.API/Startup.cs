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
using TR.DAL.DataAccess;
using TR.DAL.Exception;
using TR.Infrastructure.Implementations.Providers;
using TR.Infrastructure.Implementations.Updaters;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Providers;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Utilities.ExceptionHandling.Extensions;

namespace TR.API
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
            //services.AddDbContext<TRContext>(options => {
            //    options.UseSqlServer("TRDB");
            //});

            services
                .AddDbContextPool<TRContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TRDB")));

            //services.AddAutoMapper();
            //services.AddScoped(typeof(IViewModelFactory<,>), typeof(ViewModelFactory<,>));

            //ashi : in future move this to extension method for DAL
            //services.AddScoped(typeof(IRepository<AuditTrail>), typeof(AuditTrailRepository));
            services.AddTransient(typeof(IRepositoryExceptionHandler), typeof(RepositoryExceptionHandler));

            services.AddTransient<ISportTypeViewModelProvider, SportTypeViewModelProvider>();
            services.AddTransient<IRoleTypeViewModelProvider, RoleTypeViewModelProvider>();
            services.AddTransient<IUserTypeViewModelProvider, UserTypeViewModelProvider>();
            services.AddTransient<ITournamentTypeViewModelProvider, TournamentTypeViewModelProvider>();
            services.AddTransient<ITournamentUserViewModelProvider, TournamentUserViewModelProvider>();
            services.AddTransient<ITournamentViewModelProvider, TournamentViewModelProvider>();
            services.AddTransient<IUserViewModelProvider, UserViewModelProvider>();
            services.AddTransient<ITeamViewModelProvider, TeamViewModelProvider>();
            services.AddTransient<IPlayerViewModelProvider, PlayerViewModelProvider>();
            services.AddTransient<IStaffViewModelProvider, StaffViewModelProvider>();
            services.AddTransient<ILogoViewModelProvider, LogoViewModelProvider>();


            
            services.AddTransient<ITournamentUserViewModelUpdater, TournamentUserViewModelUpdater>();
            services.AddTransient<ITournamentViewModelUpdater, TournamentViewModelUpdater>();
            services.AddTransient<IUserViewModelUpdater, UserViewModelUpdater>();
            services.AddTransient<ITeamViewModelUpdater, TeamViewModelUpdater>();
            services.AddTransient<IPlayerViewModelUpdater, PlayerViewModelUpdater>();
            services.AddTransient<IStaffViewModelUpdater, StaffViewModelUpdater>();
            services.AddTransient<ILogoViewModelUpdater, LogoViewModelUpdater>();


            services.AddTransient<ISportTypeViewModelProvider, SportTypeViewModelProvider>();
            services.AddTransient<IRoleTypeViewModelProvider, RoleTypeViewModelProvider>();
            services.AddTransient<IUserTypeViewModelProvider, UserTypeViewModelProvider>();
            services.AddTransient<ITournamentTypeViewModelProvider, TournamentTypeViewModelProvider>();
            services.AddTransient<ITournamentUserViewModelProvider, TournamentUserViewModelProvider>();
            services.AddTransient<ITournamentViewModelProvider, TournamentViewModelProvider>();
            services.AddTransient<IUserViewModelProvider, UserViewModelProvider>();
            services.AddTransient<ITeamViewModelProvider, TeamViewModelProvider>();
            services.AddTransient<IPlayerViewModelProvider, PlayerViewModelProvider>();
            services.AddTransient<IStaffViewModelProvider, StaffViewModelProvider>();
            services.AddTransient<ILogoViewModelProvider, LogoViewModelProvider>();

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

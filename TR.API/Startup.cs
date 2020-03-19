
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TR.DAL.DataAccess;
using TR.DAL.Exception;
using TR.DAL.Factory;
using TR.DAL.Models;
using TR.DAL.Repositories;
using TR.Infrastructure.Implementations.Providers;
using TR.Infrastructure.Implementations.Updaters;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Providers;
using TR.Infrastructure.Interfaces.Repositories;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Infrastructure.ViewModel;
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

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IViewModelFactory<,>), typeof(ViewModelFactory<,>));
            //services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            //services.AddScoped(typeof(IReadOnlyRespository<>), typeof(ReadOnlyRepositoryBase<>));

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



            //services.AddScoped<IContextFactory, ContextFactory>();
            services.AddTransient(typeof(IRepositoryExceptionHandler), typeof(RepositoryExceptionHandler));

            services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));
            services.AddScoped(typeof(IRepository<UserType>), typeof(UserTypeRepository));
            services.AddScoped(typeof(IRepository<Team>), typeof(TeamRepository));
            services.AddScoped(typeof(IRepository<Player>), typeof(PlayerRepository));
            services.AddScoped(typeof(IRepository<Staff>), typeof(StaffRepository));
            services.AddScoped(typeof(IRepository<Tournament>), typeof(TournamentRepository));
            services.AddScoped(typeof(IRepository<TournamentType>), typeof(TournamentTypeRepository));
            services.AddScoped(typeof(IRepository<TournamentUser>), typeof(TournamentUserRepository));
            services.AddScoped(typeof(IRepository<SportType>), typeof(SportTypeRepository));
            services.AddScoped(typeof(IRepository<Logo>), typeof(LogoRepository));
            services.AddScoped(typeof(IRepository<RoleType>), typeof(RoleTypeRepository));



            services.AddScoped(typeof(IReadOnlyRespository<LogoViewModel>), typeof(LogoReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<UserViewModel>), typeof(UserReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<TournamentViewModel>), typeof(TournamentReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<TournamentUserViewModel>), typeof(TournamentUserReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<TeamViewModel>), typeof(TeamReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<StaffViewModel>), typeof(StaffReadOnlyRespository));
            services.AddScoped(typeof(IReadOnlyRespository<PlayerViewModel>), typeof(PlayerReadOnlyRespository));


            //services.AddTransient<ISportTypeViewModelProvider, SportTypeViewModelProvider>();
            //services.AddTransient<IRoleTypeViewModelProvider, RoleTypeViewModelProvider>();
            //services.AddTransient<IUserTypeViewModelProvider, UserTypeViewModelProvider>();
            //services.AddTransient<ITournamentTypeViewModelProvider, TournamentTypeViewModelProvider>();
            //services.AddTransient<ITournamentUserViewModelProvider, TournamentUserViewModelProvider>();
            //services.AddTransient<ITournamentViewModelProvider, TournamentViewModelProvider>();
            //services.AddTransient<IUserViewModelProvider, UserViewModelProvider>();
            //services.AddTransient<ITeamViewModelProvider, TeamViewModelProvider>();
            //services.AddTransient<IPlayerViewModelProvider, PlayerViewModelProvider>();
            //services.AddTransient<IStaffViewModelProvider, StaffViewModelProvider>();
            //services.AddTransient<ILogoViewModelProvider, LogoViewModelProvider>();

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

using TR.DAL.Interfaces.Repositories;
using TR.DAL.Models;
using TR.Infrastructure.Interfaces.Factories;
using TR.Infrastructure.Interfaces.Repositories;
using TR.Infrastructure.Interfaces.Updaters;
using TR.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TR.Infrastructure.Implementations.Updaters
{
    public class LogoViewModelUpdater : ILogoViewModelUpdater
    {
        private readonly IViewModelFactory<Logo, LogoViewModel> _LogoViewModelFactory;
        private readonly IRepository<Logo> _LogoRepository;
        private readonly IReadOnlyRespository<LogoViewModel> _LogoUpdateRepository;

        public LogoViewModelUpdater(
            IViewModelFactory<Logo, LogoViewModel> LogoViewModelFactory,            
            IRepository<Logo> LogoRepository,
            IReadOnlyRespository<LogoViewModel> LogoUpdateRepository
            )
        {
            _LogoViewModelFactory = LogoViewModelFactory;            
            _LogoRepository = LogoRepository;
            _LogoUpdateRepository = LogoUpdateRepository;
        }

        public async Task<LogoViewModel> AddOrUpdateAsync(LogoViewModel Logo)
        {
            var dbLogo = await _LogoRepository.AddOrUpdateAsync(_LogoViewModelFactory.For(Logo));

            Logo.LogoId = dbLogo.LogoId;

            return Logo;
        }

        public async Task<LogoViewModel> DeleteAsync(LogoViewModel Logo)
        {
            var dbLogo = await _LogoRepository.DeleteAsync(_LogoViewModelFactory.For(Logo));

            Logo.LogoId = dbLogo.LogoId;

            return Logo;
        }

        //public async Task<LogoViewModel> MoveLogoToNewSchoolAsync(LogoViewModel Logo, int newSchoolId)
        //{
        //    var parameters = new List<SqlParameter>
        //    {
        //        new SqlParameter("@LogoId", Logo.LogoId),
        //        new SqlParameter("@OldSchoolId", Logo.SchoolId),
        //        new SqlParameter("@NewSchoolId", newSchoolId)

        //    };

        //    await _LogoUpdateRepository.ExecuteNonQueryAsync("[dbo].[uspMoveLogoToNewSchool]", parameters);

        //    Logo.SchoolId = newSchoolId;

        //    return Logo;
        //}

        //public async Task AddRangeAsync(ICollection<LogoViewModel> LogosViewModels)
        //{
        //    var Logos = new List<Logo>();

        //    foreach (var LogoViewModel in LogosViewModels)
        //    {
        //        var Logo = _LogoViewModelFactory.For(LogoViewModel);

        //        Logos.Add(Logo);
        //    }

        //    await _LogoRepository.AddRangeAsync(Logos);
        //}


    }
}

using AutoMapper;
using TR.Infrastructure.Interfaces.Factories;

namespace TR.DAL.Factory
{
    public class ViewModelFactory<TViewModel, TDomain> : IViewModelFactory<TViewModel, TDomain>
    {
        private readonly IMapper _mapper;

        public ViewModelFactory(IMapper mapper)
        {
           _mapper = mapper;
        }

      
        public TViewModel For(TDomain value)
        {
            return _mapper.Map<TViewModel>(value);
        }

        public TDomain Build(TViewModel value)
        {
            return _mapper.Map<TDomain>(value);
        }
    }
}

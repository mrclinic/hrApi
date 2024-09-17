using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class CityService : ServiceAsync<City, CityDto>, ICityService
    {
        private readonly IGenericRepository<City> cityRepository;
        private readonly IMapper _mapper;
        public CityService(IGenericRepository<City> repository, IMapper mapper) : base(repository, mapper)
        {
            cityRepository = repository;
            _mapper = mapper;
        }
    }
}
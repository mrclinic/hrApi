using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class BloodGroupService : ServiceAsync<BloodGroup, BloodGroupDto>, IBloodGroupService
    {
        private readonly IGenericRepository<BloodGroup> bloodgroupRepository;
        private readonly IMapper _mapper;
        public BloodGroupService(IGenericRepository<BloodGroup> repository, IMapper mapper) : base(repository, mapper)
        {
            bloodgroupRepository = repository;
            _mapper = mapper;
        }
    }
}
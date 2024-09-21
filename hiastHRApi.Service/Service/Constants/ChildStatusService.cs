using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class ChildStatusService : ServiceAsync<ChildStatus, ChildStatusDto>, IChildStatusService
    {
        private readonly IGenericRepository<ChildStatus> childstatusRepository;
        private readonly IMapper _mapper;
        public ChildStatusService(IGenericRepository<ChildStatus> repository, IMapper mapper) : base(repository, mapper)
        {
            childstatusRepository = repository;
            _mapper = mapper;
        }
    }
}
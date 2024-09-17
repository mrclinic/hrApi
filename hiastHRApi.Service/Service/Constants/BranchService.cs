using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class BranchService : ServiceAsync<Branch, BranchDto>, IBranchService
    {
        private readonly IGenericRepository<Branch> branchRepository;
        private readonly IMapper _mapper;
        public BranchService(IGenericRepository<Branch> repository, IMapper mapper) : base(repository, mapper)
        {
            branchRepository = repository;
            _mapper = mapper;
        }
    }
}
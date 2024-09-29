using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;

namespace hiastHRApi.Service.Service.Constants
{
    public class DocTypeService : ServiceAsync<DocType, DocTypeDto>, IDocTypeService
    {
        private readonly IGenericRepository<DocType> docTypeRepository;
        private readonly IMapper _mapper;
        public DocTypeService(IGenericRepository<DocType> repository, IMapper mapper) : base(repository, mapper)
        {
            docTypeRepository = repository;
            _mapper = mapper;
        }
    }
}
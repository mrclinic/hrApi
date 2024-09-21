using AutoMapper; 
using hiastHRApi.Domain.Entities.Constants; 
using hiastHRApi.Repository.Interfaces; 
using hiastHRApi.Service.DTO.Constants; 
using hiastHRApi.Service.IService.Constants; 

namespace hiastHRApi.Service.Service.Constants
 {
    public class PromotionPercentageService : ServiceAsync<PromotionPercentage,PromotionPercentageDto>, IPromotionPercentageService
    {
        private readonly IGenericRepository<PromotionPercentage>promotionpercentageRepository;
private readonly IMapper _mapper;
public PromotionPercentageService (IGenericRepository<PromotionPercentage> repository, IMapper mapper) : base(repository, mapper){
            promotionpercentageRepository = repository;
            _mapper = mapper;
        }
    }
}
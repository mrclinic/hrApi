using AutoMapper;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Services.Common.Mapping;

namespace hiastHRApi.Service.DTO.Constants
{
    public class JobChangeReasonDto : ConstantDto, IMapFrom
    {
        public Guid ModificationContractTypeId { get; set; }

        public ModificationContractTypeDto ModificationContractType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobChangeReason, JobChangeReasonDto>()
                                             .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                                             .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
                                             .ForMember(dest => dest.ModificationContractTypeId, src => src.MapFrom(src => src.ModificationContractTypeId))
                                             .ForMember(dest => dest.ModificationContractType, src => src.MapFrom(src => src.ModificationContractType)).ReverseMap();
        }
    }
}
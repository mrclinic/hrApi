using AutoMapper;

using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;

namespace hiastHRApi.Service.Service.Identity
{
    public class UserProfileService : ServiceAsync<UserProfile, UserProfileDto>, IUserProfileService
    {
        private readonly IGenericRepository<UserProfile> userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IGenericRepository<UserProfile> repository, IMapper mapper) : base(repository, mapper)
        {
            userProfileRepository = repository;
            _mapper = mapper;
        }
    }
}

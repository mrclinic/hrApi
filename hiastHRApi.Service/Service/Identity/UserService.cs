using AutoMapper;

using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Identity;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.Common.Constants;
using hiastHRApi.Services.Common.Token;
using hiastHRApi.Services.DTO.Identity;


namespace hiastHRApi.Service.Service.Identity
{
    public class UserService : ServiceAsync<User, UserDto>, IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Branch> _branchRepository;
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IGenericRepository<RolePermissions> _rolePermissionsRepository;
        private readonly IMapper _mapper;
        //private readonly JwtSettings _jwtSettings;

        public UserService(IGenericRepository<User> repository, IGenericRepository<Role> roleRepository, IGenericRepository<Branch> branchRepository,
            IGenericRepository<UserProfile> userProfileRepository,
            IGenericRepository<RolePermissions> rolePermissionsRepository,
            IMapper mapper
            //, JwtSettings jwtSettings
            ) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
            //_jwtSettings = jwtSettings;
            _roleRepository = roleRepository;
            _branchRepository = branchRepository;
            _userProfileRepository = userProfileRepository;
            _rolePermissionsRepository = rolePermissionsRepository;
        }

        public async Task<bool> Activate(string userName, string activateCode)
        {
            var entity = await _userRepository.FindSingle(x => x.Username.Equals(userName) && !x.IsDeleted && !x.IsActive);
            if (entity == null)
                return false;
            
            return false;
        }

        public async Task<bool> ChangePassword(Guid userID, string currentPassword, string newPassword)
        {
            var entity = await _userRepository.FindSingle(x => x.Id.Equals(userID) && !x.IsDeleted);
            if (entity == null)
                return false;
            if (BCrypt.Net.BCrypt.Verify(currentPassword, entity.Password))
            {
                entity.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _userRepository.Update(entity);
                return true;
            }
            return false;
        }

        public async Task<UserDto> getUserInfo(Guid userID)
        {
            User entity = await _userRepository.FindSingle(x => x.Id.Equals(userID));
            if (entity == null)
                return null;
            
            Role role = await _roleRepository.FindSingle(x => x.Id == entity.RoleId);
            entity.Role = role;
            bool userProfileComplete = false;
            UserProfile userProfile = await _userProfileRepository.FindSingle(x => x.UserId == entity.Id);
            if (!userProfile.Address.Equals("EMPTY") && !userProfile.BirthPlace.Equals("EMPTY") && !userProfile.PersonalCardNumber.Equals("EMPTY") && !userProfile.FatherName.Equals("EMPTY")
                && !userProfile.MotherName.Equals("EMPTY") && !userProfile.Gender.Equals("EMPTY") && !userProfile.BirthDate.ToString().Equals("1900-01-01 00:00:00"))
            {
                userProfileComplete = true;
            }

            UserDto userDto = _mapper.Map<UserDto>(entity);
            userDto.IsComplete = false;


            #region permissions
            userDto.Permissions = new List<string>();
            var rolePermissions = _rolePermissionsRepository.Find(p => p.RoleId == entity.RoleId, "Permission,Role");
            foreach (var perm in rolePermissions)
            {
                userDto.Permissions.Add(_mapper.Map<PermissionDto>(perm.Permission).Name);
            }
            #endregion

            return userDto;
        }

        public async Task<UserDto> LogIn(string userName, string passWord)
        {
            User entity = await _userRepository.FindSingle(x => x.Username.Equals(userName));
            if (entity != null && BCrypt.Net.BCrypt.Verify(passWord, entity.Password))
            {
                UserToken userToken = new UserToken();
                //string _userToken = UserToken.GenTokenkey(_jwtSettings);
                entity.Token = String.Empty;
                _userRepository.Update(entity);
                
                Role role = await _roleRepository.FindSingle(x => x.Id == entity.RoleId);
                entity.Role = role;
                UserDto userDto = _mapper.Map<UserDto>(entity);
                if (role.StatusCode.Equals(0) && !role.Name.Equals("Admin"))
                {
                    bool userProfileComplete = false;
                    UserProfile userProfile = await _userProfileRepository.FindSingle(x => x.UserId == entity.Id);
                    if (!userProfile.Address.Equals("EMPTY") && !userProfile.BirthPlace.Equals("EMPTY") && !userProfile.PersonalCardNumber.Equals("EMPTY") && !userProfile.FatherName.Equals("EMPTY")
                        && !userProfile.MotherName.Equals("EMPTY") && !userProfile.Gender.Equals("EMPTY") && !userProfile.BirthDate.ToString().Equals("1900-01-01 00:00:00"))
                    {
                        userProfileComplete = true;
                    }

                    userDto.IsComplete = false;

                }

                #region permissions
                userDto.Permissions = new List<string>();
                var rolePermissions = _rolePermissionsRepository.Find(p => p.RoleId == entity.RoleId, "Permission,Role");
                foreach (var perm in rolePermissions)
                {
                    userDto.Permissions.Add(_mapper.Map<PermissionDto>(perm.Permission).Name);
                }
                #endregion

                return userDto;
            }
            return null;
        }

        public async Task<UserDto> SignUp(UserDto user, string code)
        {
            var userEntity = _mapper.Map<User>(user);
            // hash password
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(user.PassWord);
            userEntity.Role = await _roleRepository.FindSingle(x => x.Name.Equals(Constant.User));
            await _userRepository.Add(userEntity);
            UserProfileDto newProfile = new UserProfileDto
            {
                Address = "EMPTY",
                BirthPlace = "EMPTY",
                CardNumber = "EMPTY",
                FatherName = "EMPTY",
                Gender = "EMPTY",
                MotherName = "EMPTY"
            };
            var profileEntity = _mapper.Map<UserProfile>(newProfile);
            profileEntity.UserId = userEntity.Id;
            await _userProfileRepository.Add(profileEntity);
            return _mapper.Map<UserDto>(userEntity);
        }
    }
}

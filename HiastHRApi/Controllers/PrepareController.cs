using hiastHRApi.Authorization;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Services.DTO.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace HiastHRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrepareController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _provider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PrepareController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ICountryService _countryService;
        private readonly IBranchService _branchService;
        private readonly IUniversityService _universityService;
        private readonly IPermissionService _permissionService;
        private readonly IDepartmentService _departmentService;
        private readonly IRolePermissionsService _rolePermissionsService;
        public PrepareController(IActionDescriptorCollectionProvider provider, IUnitOfWork unitOfWork, ILogger<PrepareController> logger, IUserService userService, IRoleService roleService,
            ICountryService countryService, IBranchService branchService, IUniversityService universityService, IPermissionService permissionService,
            IDepartmentService departmentService, IRolePermissionsService rolePermissionsService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userService = userService;
            _roleService = roleService;
            _countryService = countryService;
            _branchService = branchService;
            _universityService = universityService;
            _provider = provider;
            _permissionService = permissionService;
            _departmentService = departmentService;
            _rolePermissionsService = rolePermissionsService;

        }
        [HttpGet(nameof(install))]
        [AllowAnonymous]
        public async Task<IActionResult> install()
        {
            #region install permissions

            var permissions = new List<PermissionDto>();
            var routes = _provider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Area = x.RouteValues["Area"],
                Name = x.FilterDescriptors.Where(a => a.Filter is DisplayActionName),
                Name1 = x.FilterDescriptors.Where(a => a.Filter is DisplayActionName).Any()
            }).Where(a => a.Name1 == true).ToList();
            int order = 1;
            foreach (var route in routes)
            {
                DisplayActionName displayActionName = (DisplayActionName)route.Name.FirstOrDefault().Filter;
                string permstrDisplayName = (displayActionName != null ? displayActionName.DisplayName : "");
                string permstr = route.Area + "_" + route.Controller + "_" + route.Action;
                //find perms
                var perms = await _permissionService.FindPermissionByName(permstr);
                if (perms == null)
                {
                    permissions.Add(new PermissionDto
                    {
                        DisplayName = permstrDisplayName,
                        Order = order,
                        Name = permstr
                    });
                }
                order++;
            }
            await _permissionService.AddRange(permissions);
            #endregion
            await _unitOfWork.CompleteAsync();
            return new JsonResult("Success") { StatusCode = 200, Value = true };
        }
        [HttpGet(nameof(prepareData))]
        [AllowAnonymous]
        public async Task<IActionResult> prepareData()
        {
            var roles = new List<RoleDto>();
            roles.Add(new RoleDto { Name = "Admin", DisplayName = "مدير", StatusCode = 0 });
            roles.Add(new RoleDto { Name = "User", DisplayName = "مستخدم", StatusCode = 0 });
            roles.Add(new RoleDto { Name = "Immanence", DisplayName = "ذاتية", StatusCode = 1 });
            roles.Add(new RoleDto { Name = "HeadBranch", DisplayName = "رئيس فرع", StatusCode = 3 });
            roles.Add(new RoleDto { Name = "HeadCommittee", DisplayName = "رئيس لجنة", StatusCode = 2 });
            await _roleService.AddRange(roles);

            var countries = new List<CountryDto>();
            countries.Add(new CountryDto { Name = "سوريا" });
            countries.Add(new CountryDto { Name = "لبنان" });
            countries.Add(new CountryDto { Name = "روسيا" });
            countries.Add(new CountryDto { Name = "مصر" });
            countries.Add(new CountryDto { Name = "فرنسا" });
            countries.Add(new CountryDto { Name = "إيران" });
            countries.Add(new CountryDto { Name = "بريطانيا" });
            await _countryService.AddRange(countries);
            await _unitOfWork.CompleteAsync();

            var country = await _countryService.Find(p => p.Name.Equals("سوريا"));
            var countryId = country.FirstOrDefault().Id;

            var adminRoel = await _roleService.Find(p => p.Name.Equals("Admin"));
            var adminRoleId = adminRoel.FirstOrDefault().Id;
            var userRoel = await _roleService.Find(p => p.Name.Equals("User"));
            var userRoleId = userRoel.FirstOrDefault().Id;
            var immanenceRole = await _roleService.Find(p => p.Name.Equals("Immanence"));
            var immanenceRoleId = immanenceRole.FirstOrDefault().Id;
            var headBranchRole = await _roleService.Find(p => p.Name.Equals("HeadBranch"));
            var headBranchRoleId = headBranchRole.FirstOrDefault().Id;
            var headCommitteeRole = await _roleService.Find(p => p.Name.Equals("HeadCommittee"));
            var headCommitteeRoleId = headCommitteeRole.FirstOrDefault().Id;

            #region role permissions
            var perms = _permissionService.GetAll();
            var roleAdminPerms = new List<RolePermissionsDto>();

            //assign all permissions to Role Admin
            foreach (var perm in perms)
            {
                roleAdminPerms.Add(new RolePermissionsDto { PermissionId = perm.Id, RoleId = adminRoleId });
            }

            //assign permissions to Role User
            var roleUserPerms = assignUserPerms(perms, userRoleId);

            //assign permissions to Immanence User
            var roleImmanencePerms = assignImmanencePerms(perms, immanenceRoleId);

            //assign permissions to Role HeadBranch
            var roleHeadBranchPerms = assignHeadBranchPerms(perms, headBranchRoleId);

            //assign permissions to Role HeadCommittee
            var roleHeadCommitteePerms = assignHeadCommitteePerms(perms, headCommitteeRoleId);

            await _rolePermissionsService.AddRange(roleAdminPerms);
            await _rolePermissionsService.AddRange(roleUserPerms);
            await _rolePermissionsService.AddRange(roleImmanencePerms);
            await _rolePermissionsService.AddRange(roleHeadBranchPerms);
            await _rolePermissionsService.AddRange(roleHeadCommitteePerms);
            #endregion

            //create some accounts
            var users = createUsers( immanenceRoleId, headBranchRoleId, headCommitteeRoleId, adminRoleId, userRoleId);
            await _userService.AddRange(users);

            var depts = new List<DepartmentDto>();
            depts.Add(new DepartmentDto { Name = "الهندسة المدنية" });
            depts.Add(new DepartmentDto { Name = "الهندسة المعمارية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الميكانيكية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الكهربائية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الكيميائية" });
            depts.Add(new DepartmentDto { Name = "هندسة الجيولوجيا والمناجم والتعدين" });
            depts.Add(new DepartmentDto { Name = "هندسة البترول والغاز" });
            depts.Add(new DepartmentDto { Name = "الهندسة النووية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الفيزيائية" });
            depts.Add(new DepartmentDto { Name = "هندسة الصناعات النسيجية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الصناعية والصناعات" });
            depts.Add(new DepartmentDto { Name = "هندسة الصناعات الغذائية" });
            depts.Add(new DepartmentDto { Name = "قسم الهندسة الاقتصادية" });
            depts.Add(new DepartmentDto { Name = "الهندسة الطبية" });
            depts.Add(new DepartmentDto { Name = "الهندسة المعلوماتية" });
            await _departmentService.AddRange(depts);
            await _unitOfWork.CompleteAsync();

            return new JsonResult("Success") { StatusCode = 200, Value = true };
        }

        private List<RolePermissionsDto> assignHeadCommitteePerms(IEnumerable<PermissionDto> perms, Guid headCommitteeRoleId)
        {
            var roleHeadCommitteePerms = new List<RolePermissionsDto>();
            roleHeadCommitteePerms.Add(new RolePermissionsDto
            { RoleId = headCommitteeRoleId, PermissionId = perms.FirstOrDefault(p => p.Name.Equals("UserManagment_UserProfile_GetAllUserProfilesInfo")).Id });
            
            return roleHeadCommitteePerms;
        }

        private List<RolePermissionsDto> assignHeadBranchPerms(IEnumerable<PermissionDto> perms, Guid headBranchRoleId)
        {
            var roleHeadBranchPerms = new List<RolePermissionsDto>();
            roleHeadBranchPerms.Add(new RolePermissionsDto
            { RoleId = headBranchRoleId, PermissionId = perms.FirstOrDefault(p => p.Name.Equals("UserManagment_UserProfile_GetAllUserProfilesInfo")).Id });
           
            return roleHeadBranchPerms;
        }

        private List<RolePermissionsDto> assignImmanencePerms(IEnumerable<PermissionDto> perms, Guid immanenceRoleId)
        {
            var roleImmanencePerms = new List<RolePermissionsDto>();
            roleImmanencePerms.Add(new RolePermissionsDto
            { RoleId = immanenceRoleId, PermissionId = perms.FirstOrDefault(p => p.Name.Equals("UserManagment_UserProfile_GetAllUserProfilesInfo")).Id });
            
            return roleImmanencePerms;
        }

        private List<UserDto> createUsers( Guid immanenceRoleId, Guid headBranchRoleId, Guid headCommitteeRoleId, Guid adminRoleId, Guid userRoleId)
        {
            var users = new List<UserDto>();
            users.Add(new UserDto
            {
                EmailAddress = "immanence@engApi.com",
                FName = "immanence",
                IsActive = true,
                IsComplete = true,
                LName = "immanence",
                NatNum = "00000050000",
                PassWord = BCrypt.Net.BCrypt.HashPassword("immanence"),
                Phone = "0000006000",
                UserName = "immanence",
                RoleID = immanenceRoleId,
                UserToken="tttt"
            });
            users.Add(new UserDto
            {
                EmailAddress = "headBranch@engApi.com",
                FName = "headBranch",
                IsActive = true,
                IsComplete = true,
                LName = "headBranch",
                NatNum = "00030000000",
                PassWord = BCrypt.Net.BCrypt.HashPassword("headBranch"),
                Phone = "0000300000",
                UserName = "headBranch",
                RoleID = headBranchRoleId,
                UserToken = "tttt"
            });
            users.Add(new UserDto
            {
                EmailAddress = "headCommittee@engApi.com",
                FName = "headCommittee",
                IsActive = true,
                IsComplete = true,
                LName = "headCommittee",
                NatNum = "00004440000",
                PassWord = BCrypt.Net.BCrypt.HashPassword("headCommittee"),
                Phone = "0000033000",
                UserName = "headCommittee",
                RoleID = headCommitteeRoleId,
                UserToken = "tttt"
            });
            users.Add(new UserDto
            {
                EmailAddress = "admin@engApi.com",
                FName = "admin",
                IsActive = true,
                IsComplete = true,
                LName = "admin",
                NatNum = "00000000000",
                PassWord = BCrypt.Net.BCrypt.HashPassword("admin"),
                Phone = "0000000000",
                UserName = "admin",
                RoleID = adminRoleId,
                UserToken = "tttt"
            });
            users.Add(new UserDto
            {
                EmailAddress = "test@engApi.com",
                FName = "test",
                IsActive = true,
                IsComplete = true,
                LName = "test",
                NatNum = "11111111111",
                PassWord = BCrypt.Net.BCrypt.HashPassword("test"),
                Phone = "1111111111",
                UserName = "test",
                RoleID = userRoleId,
                UserToken = "tttt"
            });
            return users;
        }

        private List<RolePermissionsDto> assignUserPerms(IEnumerable<PermissionDto> perms, System.Guid userRoleId)
        {
            var roleUserPerms = new List<RolePermissionsDto>();
            
            roleUserPerms.Add(new RolePermissionsDto
            {
                RoleId = userRoleId,
                PermissionId = perms.FirstOrDefault(p => p.Name.Equals("UserManagment_UserProfile_GetMyUserProfiles")).Id
            });
            roleUserPerms.Add(new RolePermissionsDto
            {
                RoleId = userRoleId,
                PermissionId = perms.FirstOrDefault(p => p.Name.Equals("UserManagment_UserProfile_UpdateUserProfile")).Id
            });
            return roleUserPerms;
        }
    }
}

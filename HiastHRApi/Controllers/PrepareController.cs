using hiastHRApi.Authorization;
using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Service.DTO.Constants;
using hiastHRApi.Service.IService.Constants;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Service.Service.Constants;
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
        private readonly IBloodGroupService _bloodGroupService;
        private readonly IChildStatusService _childStatusService;
        private readonly ICityService _cityService;
        private readonly IDegreesAuthorityService _degreesAuthorityService;
        private readonly IDeputationObjectiveService _deputationObjectiveService;
        private readonly IDeputationStatusService _deputationStatusService;
        private readonly IDeputationTypeService _deputationTypeService;
        private readonly IDisabilityTypeService _disabilityTypeService;
        private readonly IEmploymentStatusTypeService _employmentStatusTypeService;
        private readonly IEvaluationGradeService _evaluationGradeService;
        private readonly IEvaluationQuarterService _evaluationQuarterService;
        private readonly IExperienceTypeService _experienceTypeService;
        private readonly IFinancialImpactService _financialImpactService;
        private readonly IFinancialIndicatorTypeService _financialIndicatorTypeService;
        private readonly IForcedVacationTypeService _forcedVacationTypeService;
        private readonly IGenderService _genderService;
        private readonly IHealthyStatusService _healthyStatusService;
        private readonly IInsuranceSystemService _insuranceSystemService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IJobChangeReasonService _jobChangeReasonService;
        private readonly IJobTitleService _jobTitleService;
        private readonly ILanguageService _languageService;
        private readonly ILanguageLevelService _languageLevelService;
        private readonly ILawService _lawService;
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IMilitaryRankService _militaryRankService;
        private readonly IMilitarySpecializationService _militarySpecializationService;
        private readonly IModificationContractTypeService _modificationContractTypeService;
        private readonly INationalityService _nationalityService;
        private readonly IOccurrencePartnerTypeService _occurrencePartnerTypeService;
        private readonly IPromotionPercentageService _promotionPercentageService;
        private readonly IPunishmentTypeService _punishmentTypeService;
        private readonly IQualificationService _qualificationService;
        private readonly IRelinquishmentReasonService _relinquishmentReasonService;
        private readonly IRewardTypeService _rewardTypeService;
        private readonly ISpecializationService _specializationService;
        private readonly IStartingTypeService _startingTypeService;
        private readonly ISubDepartmentService _subDepartmentService;
        private readonly ITerminationReasonService _terminationReasonService;
        private readonly IVacationTypeService _vacationTypeService;
        public PrepareController(IActionDescriptorCollectionProvider provider, IUnitOfWork unitOfWork, ILogger<PrepareController> logger, IUserService userService, IRoleService roleService,
            ICountryService countryService, IBranchService branchService, IUniversityService universityService, IPermissionService permissionService,
            IDepartmentService departmentService, IRolePermissionsService rolePermissionsService
            , IBloodGroupService bloodGroupService,
                IChildStatusService childStatusService,
                ICityService cityService,
                IDegreesAuthorityService degreesAuthorityService,
                IDeputationObjectiveService deputationObjectiveService,
                IDeputationStatusService deputationStatusService,
                IDeputationTypeService deputationTypeService,
                IDisabilityTypeService disabilityTypeService,
                IEmploymentStatusTypeService employmentStatusTypeService,
                IEvaluationGradeService evaluationGradeService,
                IEvaluationQuarterService evaluationQuarterService,
                IExperienceTypeService experienceTypeService,
                IFinancialImpactService financialImpactService,
                IFinancialIndicatorTypeService financialIndicatorTypeService,
                IForcedVacationTypeService forcedVacationTypeService,
                IGenderService genderService,
                IHealthyStatusService healthyStatusService,
                IInsuranceSystemService insuranceSystemService,
                IJobCategoryService jobCategoryService,
                IJobChangeReasonService jobChangeReasonService,
                IJobTitleService jobTitleService,
                ILanguageService languageService,
                ILanguageLevelService languageLevelService,
                ILawService lawService,
                IMaritalStatusService maritalStatusService,
                IMilitaryRankService militaryRankService,
                IMilitarySpecializationService militarySpecializationService,
                IModificationContractTypeService modificationContractTypeService,
                INationalityService nationalityService,
                IOccurrencePartnerTypeService occurrencePartnerTypeService,
                IPromotionPercentageService promotionPercentageService,
                IPunishmentTypeService punishmentTypeService,
                IQualificationService qualificationService,
                IRelinquishmentReasonService relinquishmentReasonService,
                IRewardTypeService rewardTypeService,
                ISpecializationService specializationService,
                IStartingTypeService startingTypeService,
                ISubDepartmentService subDepartmentService,
                ITerminationReasonService terminationReasonService,
                IVacationTypeService vacationTypeService)
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
            _bloodGroupService = bloodGroupService;
            _childStatusService = childStatusService;
            _cityService = cityService;
            _degreesAuthorityService = degreesAuthorityService;
            _deputationObjectiveService = deputationObjectiveService;
            _deputationStatusService = deputationStatusService;
            _deputationTypeService = deputationTypeService;
            _disabilityTypeService = disabilityTypeService;
            _employmentStatusTypeService = employmentStatusTypeService;
            _evaluationGradeService = evaluationGradeService;
            _evaluationQuarterService = evaluationQuarterService;
            _experienceTypeService = experienceTypeService;
            _financialImpactService = financialImpactService;
            _financialIndicatorTypeService = financialIndicatorTypeService;
            _forcedVacationTypeService = forcedVacationTypeService;
            _genderService = genderService;
            _healthyStatusService = healthyStatusService;
            _insuranceSystemService = insuranceSystemService;
            _jobCategoryService = jobCategoryService;
            _jobChangeReasonService = jobChangeReasonService;
            _jobTitleService = jobTitleService;
            _languageService = languageService;
            _languageLevelService = languageLevelService;
            _lawService = lawService;
            _maritalStatusService = maritalStatusService;
            _militaryRankService = militaryRankService;
            _militarySpecializationService = militarySpecializationService;
            _modificationContractTypeService = modificationContractTypeService;
            _nationalityService = nationalityService;
            _occurrencePartnerTypeService = occurrencePartnerTypeService;
            _promotionPercentageService = promotionPercentageService;
            _punishmentTypeService = punishmentTypeService;
            _qualificationService = qualificationService;
            _relinquishmentReasonService = relinquishmentReasonService;
            _rewardTypeService = rewardTypeService;
            _specializationService = specializationService;
            _startingTypeService = startingTypeService;
            _subDepartmentService = subDepartmentService;
            _terminationReasonService = terminationReasonService;
            _vacationTypeService = vacationTypeService;

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

            List<BloodGroupDto> bloodGroups = new List<BloodGroupDto>
                                           {
                                               new BloodGroupDto { Name = "A+", },
                                               new BloodGroupDto { Name = "A-", },
                                               new BloodGroupDto { Name = "B+", },
                                               new BloodGroupDto { Name = "B-", },
                                               new BloodGroupDto { Name = "O+", },
                                               new BloodGroupDto { Name = "O-", },
                                               new BloodGroupDto { Name = "AB+", },
                                               new BloodGroupDto { Name = "AB-", },
                                           };
            await _bloodGroupService.AddRange(bloodGroups);

            List<ChildStatusDto> childStatuses = new List<ChildStatusDto>
                                              {
                                                  new ChildStatusDto { Name = "رضيع", },
                                                  new ChildStatusDto { Name = "طفل صغير", },
                                                  new ChildStatusDto { Name = "'طالب مدرسة ابتدائية", },
                                                  new ChildStatusDto { Name = "'طالب مدرسة إعدادية", },
                                                  new ChildStatusDto { Name = "'طالب مدرسة ثانوية", },
                                                  new ChildStatusDto { Name = "طالب جامعي", },
                                                  new ChildStatusDto { Name = "متخرج من الجامعة", },
                                                  new ChildStatusDto { Name = "معاق", },
                                              };
            await _childStatusService.AddRange(childStatuses);
            List<CountryDto> countries = new List<CountryDto>
                                              {
                                                  new CountryDto { Name = "سوريا", },
                                                  new CountryDto { Name = "لبنان", },
                                                  new CountryDto { Name = "مصر", },
                                                  new CountryDto { Name = "فلسطين", },
                                                  new CountryDto { Name = "العراق", },
                                                  new CountryDto { Name = "روسيا", },
                                                  new CountryDto { Name = "إيران", },
                                                  new CountryDto { Name = "كندا", },
                                              };
            await _countryService.AddRange(countries);

            List<DegreesAuthorityDto> degreesAuthorities = new List<DegreesAuthorityDto>
                                                        {
                                                            new DegreesAuthorityDto { Name = "المعهد العالي للعلوم التطبيقية والتكنلوجيا", },
                                                            new DegreesAuthorityDto { Name = "جامعة حلب", },
                                                            new DegreesAuthorityDto { Name = "جامعة دمشق", },
                                                            new DegreesAuthorityDto { Name = "الجامعة الافتراضية السورية", },
                                                        };
            await _degreesAuthorityService.AddRange(degreesAuthorities);

            List<DeputationStatusDto> deputationStatuses = new List<DeputationStatusDto>
                                                        {
                                                            new DeputationStatusDto { Name = "تمديد", },
                                                            new DeputationStatusDto { Name = "مجمد", },
                                                            new DeputationStatusDto { Name = "مقبول", },
                                                            new DeputationStatusDto { Name = "مرفوض", },
                                                            new DeputationStatusDto { Name = "مؤجل", },
                                                            new DeputationStatusDto { Name = "ملغي", },
                                                            new DeputationStatusDto { Name = "منجز", },
                                                        };
            await _deputationStatusService.AddRange(deputationStatuses);
            List<DeputationTypeDto> deputationTypes = new List<DeputationTypeDto>
                                                   {
                                                       new DeputationTypeDto { Name = "مهمة", },
                                                       new DeputationTypeDto { Name = "بعثة", },
                                                   };
            await _deputationTypeService.AddRange(deputationTypes);
            List<DisabilityTypeDto> disabilityTypes = new List<DisabilityTypeDto>
                                                   {
                                                       new DisabilityTypeDto { Name = "الشلل الدماغي", },
                                                       new DisabilityTypeDto { Name = "ضعف السمع", },
                                                       new DisabilityTypeDto { Name = "ضعف البصر", },
                                                       new DisabilityTypeDto { Name = "ضعف الكلام", },
                                                       new DisabilityTypeDto { Name = "صعوبات التعلم", },
                                                       new DisabilityTypeDto { Name = "صعوبات في الحركة", },
                                                   };
            await _disabilityTypeService.AddRange(disabilityTypes);

            List<EmploymentStatusTypeDto> employmentStatusTypes = new List<EmploymentStatusTypeDto>
                                                               {
                                                                   new EmploymentStatusTypeDto { Name = "مباشر", },
                                                                   new EmploymentStatusTypeDto { Name = "تارك", },
                                                                   new EmploymentStatusTypeDto { Name = "طالب", },
                                                               };
            await _employmentStatusTypeService.AddRange(employmentStatusTypes);
            List<EvaluationGradeDto> evaluationGrades = new List<EvaluationGradeDto>
                                                     {
                                                         new EvaluationGradeDto { Name = "ممتاز", },
                                                         new EvaluationGradeDto { Name = "جيد جداً", },
                                                         new EvaluationGradeDto { Name = "جيد", },
                                                         new EvaluationGradeDto { Name = "وسط", },
                                                         new EvaluationGradeDto { Name = "ضعيف", },
                                                     };
            await _evaluationGradeService.AddRange(evaluationGrades);
            List<EvaluationQuarterDto> evaluationQuarters = new List<EvaluationQuarterDto>
                                                         {
                                                             new EvaluationQuarterDto { Name = "أول", },
                                                             new EvaluationQuarterDto { Name = "ثاني", },
                                                             new EvaluationQuarterDto { Name = "ثالث", },
                                                             new EvaluationQuarterDto { Name = "رابع", },
                                                         };
            await _evaluationQuarterService.AddRange(evaluationQuarters);
            List<ExperienceTypeDto> experienceTypes = new List<ExperienceTypeDto>
                                                   {
                                                       new ExperienceTypeDto { Name = "تنضيد الكتروني", },
                                                       new ExperienceTypeDto { Name = "خبرة عملية", },
                                                       new ExperienceTypeDto { Name = "تدريب", },
                                                       new ExperienceTypeDto { Name = "مشروع تخرج", },
                                                       new ExperienceTypeDto { Name = "مشروع بحث", },
                                                   };
            await _experienceTypeService.AddRange(experienceTypes);
            List<FinancialImpactDto> financialImpacts = new List<FinancialImpactDto>
                                                     {
                                                         new FinancialImpactDto { Name = "لا يوجد", },
                                                         new FinancialImpactDto { Name = "بلا أجر", },
                                                         new FinancialImpactDto { Name = "بأجر", },
                                                     };
            await _financialImpactService.AddRange(financialImpacts);
            List<FinancialIndicatorTypeDto> financialIndicatorTypes = new List<FinancialIndicatorTypeDto>
                                                                   {
                                                                       new FinancialIndicatorTypeDto { Name = "نسبة", },
                                                                       new FinancialIndicatorTypeDto { Name = "مبلغ", },
                                                                   };
            await _financialIndicatorTypeService.AddRange(financialIndicatorTypes);
            List<ForcedVacationTypeDto> forcedVacationTypes = new List<ForcedVacationTypeDto>
                                                           {
                                                               new ForcedVacationTypeDto { Name = "وفاة", },
                                                               new ForcedVacationTypeDto { Name = "زواج", },
                                                               new ForcedVacationTypeDto { Name = "صحي", },
                                                               new ForcedVacationTypeDto { Name = "ساعات رضاعة", },
                                                           };
            await _forcedVacationTypeService.AddRange(forcedVacationTypes);
            List<GenderDto> genders = new List<GenderDto>
                                   {
                                       new GenderDto { Name = "ذكر", },
                                       new GenderDto { Name = "أنثى", },
                                   };
            await _genderService.AddRange(genders);
            List<HealthyStatusDto> healthyStatuses = new List<HealthyStatusDto>
                                                  {
                                                      new HealthyStatusDto { Name = "سليم", },
                                                      new HealthyStatusDto { Name = "مريض", },
                                                  };
            await _healthyStatusService.AddRange(healthyStatuses);
            List<InsuranceSystemDto> insuranceSystems = new List<InsuranceSystemDto>
                                                     {
                                                         new InsuranceSystemDto { Name = "التأمينات الاجتماعية", },
                                                         new InsuranceSystemDto { Name = "التأمين الصحي", },
                                                     };
            await _insuranceSystemService.AddRange(insuranceSystems);
            List<JobCategoryDto> jobCategories = new List<JobCategoryDto>
                                              {
                                                  new JobCategoryDto { Name = "أولى", },
                                                  new JobCategoryDto { Name = "ثانية", },
                                              };
            await _jobCategoryService.AddRange(jobCategories);
            List<ModificationContractTypeDto> contractTypesToAdd = new List<ModificationContractTypeDto>
                                                            {
                                                                new ModificationContractTypeDto { Name = "مرسوم", },
                                                                new ModificationContractTypeDto { Name = "قرار", },
                                                            };
            await _modificationContractTypeService.AddRange(contractTypesToAdd);
            List<JobTitleDto> jobTitles = new List<JobTitleDto>
                                       {
                                           new JobTitleDto { Name = "مدير عام", },
                                           new JobTitleDto { Name = "مدير إدارة", },
                                           new JobTitleDto { Name = "مدير قسم", },
                                           new JobTitleDto { Name = "مدرس", },
                                           new JobTitleDto { Name = "فني", },
                                           new JobTitleDto { Name = "مهندس", },
                                           new JobTitleDto { Name = "سائق", },
                                       };
            await _jobTitleService.AddRange(jobTitles);
            List<LanguageDto> languages = new List<LanguageDto>
                                       {
                                           new LanguageDto { Name = "العربية", },
                                           new LanguageDto { Name = "الإنجليزية", },
                                           new LanguageDto { Name = "الفرنسية", },
                                       };
            await _languageService.AddRange(languages);
            List<LanguageLevelDto> languageLevels = new List<LanguageLevelDto>
                                                 {
                                                     new LanguageLevelDto { Name = "جيد", },
                                                     new LanguageLevelDto { Name = "ممتاز", },
                                                 };
            await _languageLevelService.AddRange(languageLevels);
            List<LawDto> laws = new List<LawDto>
                             {
                                 new LawDto { Name = "العاملين", },
                             };
            await _lawService.AddRange(laws);
            List<MaritalStatusDto> maritalStatuses = new List<MaritalStatusDto>
                                                  {
                                                      new MaritalStatusDto { Name = "أعزب", },
                                                      new MaritalStatusDto { Name = "متزوج", },
                                                      new MaritalStatusDto { Name = "مطلق", },
                                                      new MaritalStatusDto { Name = "أرمل", },
                                                  };
            await _maritalStatusService.AddRange(maritalStatuses);
            List<MilitaryRankDto> militaryRanks = new List<MilitaryRankDto>
                                               {
                                                   new MilitaryRankDto { Name = "ملازم", },
                                                   new MilitaryRankDto { Name = "ملازم أول", },
                                                   new MilitaryRankDto { Name = "نقيب", },
                                                   new MilitaryRankDto { Name = "رائد", },
                                                   new MilitaryRankDto { Name = "مقدم", },
                                                   new MilitaryRankDto { Name = "عقيد", },
                                                   new MilitaryRankDto { Name = "عميد", },
                                                   new MilitaryRankDto { Name = "لواء", },
                                                   new MilitaryRankDto { Name = "عماد", },
                                                   new MilitaryRankDto { Name = "فريق", },
                                               };
            await _militaryRankService.AddRange(militaryRanks);
            List<MilitarySpecializationDto> militarySpecializations = new List<MilitarySpecializationDto>
                                                                   {
                                                                       new MilitarySpecializationDto { Name = "استطلاع", },
                                                                       new MilitarySpecializationDto { Name = "إاداري", },
                                                                       new MilitarySpecializationDto { Name = "المدفعية", },
                                                                       new MilitarySpecializationDto { Name = "الطيران", },
                                                                       new MilitarySpecializationDto { Name = "الدفاع الجوي", },
                                                                   };
            await _militarySpecializationService.AddRange(militarySpecializations);
            List<DeputationObjectiveDto> deputationObjectives = new List<DeputationObjectiveDto>
                                                             {
                                                                 new DeputationObjectiveDto { Name = "دكتواره", },
                                                                 new DeputationObjectiveDto { Name = "ماجستير", },
                                                                 new DeputationObjectiveDto { Name = "التدريب على الأعمال والمهارات المختلفة", },
                                                                 new DeputationObjectiveDto { Name = "مسابقات دولية", },
                                                             };
            await _deputationObjectiveService.AddRange(deputationObjectives);
            List<NationalityDto> nationalities = new List<NationalityDto>
                                              {
                                                  new NationalityDto { Name = "سوري", },
                                                  new NationalityDto { Name = "مصري", },
                                                  new NationalityDto { Name = "لبناني", },
                                              };
            await _nationalityService.AddRange(nationalities);
            List<OccurrencePartnerTypeDto> occurrencePartnerTypes = new List<OccurrencePartnerTypeDto>
                                                                 {
                                                                     new OccurrencePartnerTypeDto { Name = "زواج", },
                                                                     new OccurrencePartnerTypeDto { Name = "طلاق", },
                                                                 };
            await _occurrencePartnerTypeService.AddRange(occurrencePartnerTypes);
            List<RelinquishmentReasonDto> relinquishmentReasons = new List<RelinquishmentReasonDto>
                                                               {
                                                                   new RelinquishmentReasonDto { Name = "استقالة", },
                                                                   new RelinquishmentReasonDto { Name = "تقاعد", },
                                                                   new RelinquishmentReasonDto { Name = "بحكم المستقيل", },
                                                               };
            await _relinquishmentReasonService.AddRange(relinquishmentReasons);
            List<RewardTypeDto> rewardTypes = new List<RewardTypeDto>
                                           {
                                               new RewardTypeDto { Name = "تنبيه", },
                                               new RewardTypeDto { Name = "شكر", },
                                           };
            await _rewardTypeService.AddRange(rewardTypes);
            List<QualificationDto> qualificationsToAdd = new List<QualificationDto>
                                                  {
                                                      new QualificationDto { Name = "ثانوية", },
                                                      new QualificationDto { Name = "بكالوريوس", },
                                                      new QualificationDto { Name = "ماجستير", },
                                                      new QualificationDto { Name = "دكتوراه", },
                                                  };
            await _qualificationService.AddRange(qualificationsToAdd);
            List<StartingTypeDto> startingTypes = new List<StartingTypeDto>
                                               {
                                                   new StartingTypeDto { Name = "ملاك", },
                                                   new StartingTypeDto { Name = "خارج", },
                                               };
            await _startingTypeService.AddRange(startingTypes);
            List<TerminationReasonDto> terminationReasons = new List<TerminationReasonDto>
                                                         {
                                                             new TerminationReasonDto { Name = "استفالة", },
                                                             new TerminationReasonDto { Name = "وفاة", },
                                                             new TerminationReasonDto { Name = "كف يد", },
                                                         };
            await _terminationReasonService.AddRange(terminationReasons);
            List<UniversityDto> universities = new List<UniversityDto>
                                            {
                                                new UniversityDto { Name = "المعهد العالي للعلوم التطبيقية والتكنلوجيا", },
                                                new UniversityDto { Name = "جامعة حلب", },
                                                new UniversityDto { Name = "جامعة دمشق", },
                                                new UniversityDto { Name = "الجامعة الافتراضية السورية", },
                                            };
            await _universityService.AddRange(universities);
            List<VacationTypeDto> vacationTypes = new List<VacationTypeDto>
                                               {
                                                   new VacationTypeDto { Name = "إدارية", },
                                                   new VacationTypeDto { Name = "صحية", },
                                               };
            await _vacationTypeService.AddRange(vacationTypes);
            var roles = new List<RoleDto>();
            roles.Add(new RoleDto { Name = "Admin", DisplayName = "مدير" });
            roles.Add(new RoleDto { Name = "User", DisplayName = "مستخدم" });
            roles.Add(new RoleDto { Name = "Immanence", DisplayName = "ذاتية" });
            roles.Add(new RoleDto { Name = "HeadBranch", DisplayName = "رئيس فرع" });
            roles.Add(new RoleDto { Name = "HeadCommittee", DisplayName = "رئيس لجنة" });
            await _roleService.AddRange(roles);

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
            var users = createUsers(immanenceRoleId, headBranchRoleId, headCommitteeRoleId, adminRoleId, userRoleId);
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

        private List<UserDto> createUsers(Guid immanenceRoleId, Guid headBranchRoleId, Guid headCommitteeRoleId, Guid adminRoleId, Guid userRoleId)
        {
            var users = new List<UserDto>();
            users.Add(new UserDto
            {
                EmailAddress = "immanence@engApi.com",
                FName = "immanence",
                IsActive = true,
                LName = "immanence",
                NatNum = "00000050000",
                PassWord = BCrypt.Net.BCrypt.HashPassword("immanence"),
                Phone = "0000006000",
                UserName = "immanence",
                RoleID = immanenceRoleId,
                UserToken = "tttt"
            });
            users.Add(new UserDto
            {
                EmailAddress = "headBranch@engApi.com",
                FName = "headBranch",
                IsActive = true,
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

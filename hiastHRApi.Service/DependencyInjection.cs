using AutoMapper.Extensions.ExpressionMapping;
using hiastHRApi.Service.IService.Constants;
using hiastHRApi.Service.IService.Employee;
using hiastHRApi.Service.IService.Identity;
using hiastHRApi.Service.Service.Constants;
using hiastHRApi.Service.Service.Employee;
using hiastHRApi.Service.Service.Identity;
using hiastHRApi.Services.IService;
using hiastHRApi.Services.Service;
using hiastHRApi.Shared.Common.Activation;
using hiastHRApi.Shared.Common.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using System.Text;

namespace hiastHRApi.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            #region user management
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRolePermissionsService, RolePermissionsService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            #endregion

            #region helper
            services.AddTransient<IHelperService, HelperService>();
            #endregion

            #region constans
            services.AddTransient<IOrgDepartmentService, OrgDepartmentService>();
            services.AddTransient<IBloodGroupService, BloodGroupService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IChildStatusService, ChildStatusService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDegreesAuthorityService, DegreesAuthorityService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDeputationObjectiveService, DeputationObjectiveService>();
            services.AddTransient<IDeputationStatusService, DeputationStatusService>();
            services.AddTransient<IDeputationTypeService, DeputationTypeService>();
            services.AddTransient<IDisabilityTypeService, DisabilityTypeService>();
            services.AddTransient<IEmploymentStatusTypeService, EmploymentStatusTypeService>();
            services.AddTransient<IEvaluationGradeService, EvaluationGradeService>();
            services.AddTransient<IEvaluationQuarterService, EvaluationQuarterService>();
            services.AddTransient<IExperienceTypeService, ExperienceTypeService>();
            services.AddTransient<IFinancialImpactService, FinancialImpactService>();
            services.AddTransient<IFinancialIndicatorTypeService, FinancialIndicatorTypeService>();
            services.AddTransient<IForcedVacationTypeService, ForcedVacationTypeService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IHealthyStatusService, HealthyStatusService>();
            services.AddTransient<IInsuranceSystemService, InsuranceSystemService>();
            services.AddTransient<IJobCategoryService, JobCategoryService>();
            services.AddTransient<IJobChangeReasonService, JobChangeReasonService>();
            services.AddTransient<IJobTitleService, JobTitleService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ILanguageLevelService, LanguageLevelService>();
            services.AddTransient<ILawService, LawService>();
            services.AddTransient<IMaritalStatusService, MaritalStatusService>();
            services.AddTransient<IMilitaryRankService, MilitaryRankService>();
            services.AddTransient<IMilitarySpecializationService, MilitarySpecializationService>();
            services.AddTransient<IModificationContractTypeService, ModificationContractTypeService>();
            services.AddTransient<INationalityService, NationalityService>();
            services.AddTransient<IOccurrencePartnerTypeService, OccurrencePartnerTypeService>();
            services.AddTransient<IPromotionPercentageService, PromotionPercentageService>();
            services.AddTransient<IPunishmentTypeService, PunishmentTypeService>();
            services.AddTransient<IQualificationService, QualificationService>();
            services.AddTransient<IRelinquishmentReasonService, RelinquishmentReasonService>();
            services.AddTransient<IRewardTypeService, RewardTypeService>();
            services.AddTransient<ISpecializationService, SpecializationService>();
            services.AddTransient<IStartingTypeService, StartingTypeService>();
            services.AddTransient<ISubDepartmentService, SubDepartmentService>();
            services.AddTransient<ITerminationReasonService, TerminationReasonService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<IVacationTypeService, VacationTypeService>();

            #endregion

            #region employee
            services.AddTransient<IEmpAppointmentStatusService, EmpAppointmentStatusService>();
            services.AddTransient<IEmpAssignmentService, EmpAssignmentService>();
            services.AddTransient<IEmpChildService, EmpChildService>();
            services.AddTransient<IEmpDeputationService, EmpDeputationService>();
            services.AddTransient<IEmpEmploymentChangeService, EmpEmploymentChangeService>();
            services.AddTransient<IEmpEmploymentStatusService, EmpEmploymentStatusService>();
            services.AddTransient<IEmpExperienceService, EmpExperienceService>();
            services.AddTransient<IEmpLanguageService, EmpLanguageService>();
            services.AddTransient<IEmpMilitaryServiceCohortService, EmpMilitaryServiceCohortService>();
            services.AddTransient<IEmpMilitaryServiceService, EmpMilitaryServiceService>();
            services.AddTransient<IEmpMilitaryServiceSuspensionService, EmpMilitaryServiceSuspensionService>();
            services.AddTransient<IEmpPartnerService, EmpPartnerService>();
            services.AddTransient<IEmpPerformanceEvaluationService, EmpPerformanceEvaluationService>();
            services.AddTransient<IEmpPromotionService, EmpPromotionService>();
            services.AddTransient<IEmpPunishmentService, EmpPunishmentService>();
            services.AddTransient<IEmpQualificationService, EmpQualificationService>();
            services.AddTransient<IEmpRelinquishmentService, EmpRelinquishmentService>();
            services.AddTransient<IEmpRewardService, EmpRewardService>();
            services.AddTransient<IEmpTrainingCourseService, EmpTrainingCourseService>();
            services.AddTransient<IEmpVacationService, EmpVacationService>();
            services.AddTransient<IEmpWorkInjuryService, EmpWorkInjuryService>();
            services.AddTransient<IEmpWorkPlaceService, EmpWorkPlaceService>();
            services.AddTransient<IPersonService, PersonService>();
            #endregion

            services.AddAutoMapper(cfg =>
            {
                cfg.AddExpressionMapping(); cfg.AllowNullCollections = true;
            }
            , typeof(MappingProfile).Assembly);

            //activation Configration
            var activationSetting = configuration.GetSection(nameof(ActivationSetting));
            services.Configure<ActivationSetting>(a =>
            {
                a.ProductName = activationSetting[nameof(ActivationSetting.ProductName)];
                a.ClientIdentificationId = activationSetting[nameof(ActivationSetting.ClientIdentificationId)];
                a.VersionNumber = activationSetting[nameof(ActivationSetting.VersionNumber)]; ;
            });
            #region auto generation code
            autoGenerationCodeBlockes();
            #endregion

            return services;
        }

        public static void autoGenerationCodeBlockes()
        {
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes()
                          .Where(t => String.Equals(t.Namespace, "hiastHRApi.Service.DTO.Employee", StringComparison.Ordinal))
                          .ToArray();

            for (int i = 0; i < typelist.Length; i++)
            {
                var model = typelist[i];

                #region ui model generation
                //generateUIModels(model);
                #endregion

                #region generate ui actions
                //generateActions(model);
                #endregion

                #region generate controllers
                //generateControllers(model);
                #endregion

                #region generate Component
                generateComponentV2(model);
                #endregion

                #region ui service generation
                //generateUIServices(model);
                #endregion

                #region generate back-end services
                //generateBackEndServices(model);
                #endregion
            }
        }


        public static void generateComponentV2(Type? model)
        {
            string componentsPAth = @"c:\temp\component";
            StringBuilder srtComponentCss = new StringBuilder(".th {\r\n  text-align: center !important;\r\n" +
                "  position: sticky !important;\r\n  top: 0 !important;\r\n}\r\n\r\n.td {\r\n" +
                "  text-align: center !important;\r\n}\r\n\r\n:host ::ng-deep .p-float-label>label {\r\n" +
                "  right: 0.75rem !important;\r\n}\r\n\r\n:host ::ng-deep .p-divider.p-divider-horizontal:before {\r\n" +
                "  border-top: 0px #dee2e6 !important;\r\n}\r\n\r\n:host ::ng-deep .p-toolbar {\r\n" +
                "  background: unset !important;\r\n  border: 0px solid #dee2e6 !important;\r\n" +
                "  padding: 1rem 1.25rem;\r\n  border-radius: 4px;\r\n}\r\n\r\n:host ::ng-deep .mb-4 {\r\n" +
                "  margin-bottom: 0.5rem !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-header {\r\n" +
                "  border-bottom: 0px solid #e9ecef !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-footer {\r\n" +
                "  border-top: 0px solid #e9ecef !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-content {\r\n" +
                "  padding: 1.5rem !important;\r\n}\r\n");

            StringBuilder srtComponentTypeScript = new StringBuilder("import { Component, OnInit } from '@angular/core';\r\n" +
                "import { MessageService } from 'primeng/api';\r\n" +
                "import { APP_CONSTANTS } from 'src/app/app.contants';\r\n" +
                "import { " + model.Name.Replace("Dto", "") + " } from 'src/app/demo/models/employee/" + model.Name.Replace("Dto", "").ToLower() + ".model';\r\n" +
                "import { " + model.Name.Replace("Dto", "") + "Service } from 'src/app/demo/service/employee/" + model.Name.Replace("Dto", "").ToLower() + ".service';\r\n" +
                "import { IFormStructure } from 'src/app/demo/shared/dynamic-form/from-structure-model';\r\n\r\n" +
                "@Component({\r\n" +
                "  selector: 'app-" + model.Name.Replace("Dto", "").ToLower() + "',\r\n" +
                "  templateUrl: './" + model.Name.Replace("Dto", "").ToLower() + ".component.html',\r\n" +
                "  styleUrls: ['./" + model.Name.Replace("Dto", "").ToLower() + ".component.css']\r\n" +
                "})\r\n" +
                "export class " + model.Name.Replace("Dto", "") + "Component implements OnInit {\r\n" +
                "  cols: any[] = [];\r\n" +
                "  " + model.Name.Replace("Dto", "").ToLower() + "s: " + model.Name.Replace("Dto", "") + "[] = [];\r\n" +
                "  formStructure: IFormStructure[] = [];\r\n\r\n" +
                "  constructor(private messageService: MessageService,\r\n" +
                "    private readonly " + model.Name.Replace("Dto", "").ToLower() + "Service: " + model.Name.Replace("Dto", "") + "Service) { }\r\n\r\n" +
                "  ngOnInit(): void {\r\n" +
                "    this." + model.Name.Replace("Dto", "").ToLower() + "Service.GetAll" + model.Name.Replace("Dto", "") + "s('').subscribe(\r\n" +
                "      (res) => {\r\n" +
                "        this." + model.Name.Replace("Dto", "").ToLower() + "s = res;\r\n" +
                "        this.initColumns();\r\n" +
                "        this.initFormStructure();\r\n" +
                "      }\r\n" +
                "    );\r\n" +
                "  }\r\n\r\n" +
                "  initFormStructure() {\r\n" +
                "    this.formStructure = [\r\n");
            PropertyInfo[] propInfos = model.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in propInfos)
            {
                srtComponentTypeScript.Append(getFromStructureItemByType(prop.PropertyType.ToString(),
                    System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(prop.Name)));
            }

            srtComponentTypeScript.Append("    ];\r\n" +
            "  }\r\n\r\n" +
            "  initColumns() {\r\n" +
            "    this.cols = [\r\n");
            foreach (var prop in propInfos)
            {
                srtComponentTypeScript.Append(getTableColumnByType(prop.PropertyType.ToString(),
                    System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(prop.Name)));
            }
            srtComponentTypeScript.Append("    ]\r\n" +
            "  }\r\n\r\n" +
            "  submitEventHandler(eventData) {\r\n" +
            "    if (eventData.id) {\r\n" +
            "      this." + model.Name.Replace("Dto", "").ToLower() + "Service.Update" + model.Name.Replace("Dto", "") + "(eventData).subscribe(\r\n" +
            "        () => {\r\n" +
            "          this.messageService.add({ severity: 'success', summary: APP_CONSTANTS.SUCCESS, detail: APP_CONSTANTS.EDIT_SUCCESS, life: 3000 });\r\n" +
            "          this.reload();\r\n" +
            "        }\r\n" +
            "      )\r\n" +
            "    }\r\n" +
            "    else {\r\n" +
            "      delete eventData.id;\r\n" +
            "      this." + model.Name.Replace("Dto", "").ToLower() + "Service.Add" + model.Name.Replace("Dto", "") + "(eventData).subscribe(\r\n" +
            "        () => {\r\n" +
            "          this.messageService.add({ severity: 'success', summary: APP_CONSTANTS.SUCCESS, detail: APP_CONSTANTS.ADD_SUCCESS, life: 3000 });\r\n" +
            "          this.reload();\r\n" +
            "        }\r\n" +
            "      )\r\n" +
            "    }\r\n" +
            "  }\r\n\r\n" +
            "  deleteEventHandler(eventData) {\r\n" +
            "    this." + model.Name.Replace("Dto", "").ToLower() + "Service.Delete" + model.Name.Replace("Dto", "") + "(eventData as string).subscribe(\r\n" +
            "      (data) => {\r\n" +
            "        this.messageService.add({ severity: 'success', summary: APP_CONSTANTS.SUCCESS, detail: APP_CONSTANTS.DELETE_SUCCESS, life: 3000 });\r\n" +
            "        this.reload();\r\n" +
            "      }\r\n" +
            "    );\r\n" +
            "  }\r\n\r\n" +
            "  reload() {\r\n" +
            "    this." + model.Name.Replace("Dto", "").ToLower() + "Service.GetAll" + model.Name.Replace("Dto", "") + "s('').subscribe(\r\n" +
            "      (res) => {\r\n" +
            "        this." + model.Name.Replace("Dto", "").ToLower() + "s = res;\r\n" +
            "      }\r\n" +
            "    )\r\n" +
            "  }\r\n" +
            "}\r\n");
            StringBuilder srtComponentHTML = new StringBuilder("<app-custom-table [cols]=\"cols\" [tableData]='" + model.Name.Replace("Dto", "").ToLower() + "s' [tableTitle]=\"'kkk'\"\r\n" +
                "    (submitEventHandler)=\"submitEventHandler($event)\" (deleteEventHandler)=\"deleteEventHandler($event)\"\r\n" +
                "    [formStructure]=\"formStructure\" [canAdd]=\"canAdd\" [canEdit]=\"canEdit\" [canSingleDelete]=\"canSingleDelete\">\r\n</app-custom-table>");

            DirectoryInfo componentPath = Directory.CreateDirectory(componentsPAth + @"\" + model.Name.ToLower() + @"\");

            //save to ts files
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(componentPath.FullName + model.Name.Replace("Dto", "").ToLower() + ".component.ts"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentTypeScript.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                using (FileStream fs = File.Create(componentPath.FullName + model.Name.Replace("Dto", "").ToLower() + ".component.html"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentHTML.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                using (FileStream fs = File.Create(componentPath.FullName + model.Name.Replace("Dto", "").ToLower() + ".component.css"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentCss.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void generateBackEndServices(Type? model)
        {
            string interfacesPath = @"c:\temp\IService\Constants\";
            string implementationPath = @"c:\temp\Service\Constants\";
            string pathDepen = @"c:\temp\";
            StringBuilder depen = new StringBuilder();
            //generate dependency injection
            depen.Append(" services.AddTransient<I" + model.Name.Replace("Dto", "") + "Service, " + model.Name.Replace("Dto", "") + "Service>();\r\n");

            //generate service interfaces
            StringBuilder interfaceContent = new StringBuilder();
            interfaceContent.Append("using hiastHRApi.Domain.Entities.Constants;\r\nusing hiastHRApi.Service.DTO.Constants;\r\nusing hiastHRApi.Services.IService;" +
                "namespace hiastHRApi.Service.IService.Constants\r\n{\r\n    public interface I" + model.Name.Replace("Dto", "") + "Service : IServiceAsync<" +
                model.Name.Replace("Dto", "") + "," + model.Name + ">\r\n    {\r\n    }\r\n}\r\n");


            //generate service implementation
            StringBuilder implementationContent = new StringBuilder();
            implementationContent.Append("using AutoMapper; \r\nusing hiastHRApi.Domain.Entities.Constants; \r\nusing hiastHRApi.Repository.Interfaces; " +
                "\r\nusing hiastHRApi.Service.DTO.Constants; \r\nusing hiastHRApi.Service.IService.Constants; " +
                "\r\n\r\nnamespace hiastHRApi.Service.Service.Constants\r\n {\r\n    public class " + model.Name.Replace("Dto", "") +
                "Service : ServiceAsync<" + model.Name.Replace("Dto", "") + "," + model.Name + ">, I" +
               model.Name.Replace("Dto", "") + "Service\r\n    {\r\n        private readonly IGenericRepository<" + model.Name.Replace("Dto", "")
               + ">" + model.Name.Replace("Dto", "").ToLower() + "Repository;" + "\r\n" +
               "private readonly IMapper _mapper;" +
               "\r\n"
               + "public " + model.Name.Replace("Dto", "") +
                "Service " + "(IGenericRepository<" + model.Name.Replace("Dto", "") + "> repository, IMapper mapper) : base(repository, mapper)"
                + "{\r\n            " + model.Name.Replace("Dto", "").ToLower() + "Repository = repository;\r\n            _mapper = mapper;\r\n        }\r\n    }\r\n}"
               );

            //save to cs files
            try
            {
                //    Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(interfacesPath + "I" + model.Name.Replace("Dto", "") + "Service.cs"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(interfaceContent.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(implementationPath + model.Name.Replace("Dto", "") + "Service.cs"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(implementationContent.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                //Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(pathDepen + "pathDepen.cs"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(depen.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void generateControllers(Type? model)
        {
            string controllerPAth = @"c:\temp\Controller\";
            StringBuilder controllerContent = new StringBuilder();
            controllerContent.Append("using hiastHRApi.Authorization;\r\n" +
            "using hiastHRApi.Domain.Interfaces;\r\n" +
            "using hiastHRApi.Service.DTO.Employee;\r\n" +
            "using hiastHRApi.Service.IService.Employee;\r\n" +
            "using Microsoft.AspNetCore.Mvc;\r\n" +
            "using Sieve.Models;\r\n\r\n\r\n" +
            "namespace hiastHRApi.Areas.HR.Controllers\r\n" +
            "{\r\n    [Area(\"HR\")]\r\n    [Route(\"[area]/[controller]\")]\r\n    [ApiController]\r\n    " +
            "public class " + model.Name.Replace("Dto", "") + "Controller : ControllerBase\r\n    {\r\n        " +
            "private readonly IUnitOfWork _unitOfWork;\r\n        " +
            "private readonly ILogger<" + model.Name.Replace("Dto", "") + "Controller> _logger;\r\n        " +
            "private readonly I" + model.Name.Replace("Dto", "") + "Service _" + model.Name.Replace("Dto", "").ToLower() + "Service;\r\n        " +
            "public " + model.Name.Replace("Dto", "") + "Controller(IUnitOfWork unitOfWork, ILogger<" + model.Name.Replace("Dto", "") +
            "Controller> logger, I" + model.Name.Replace("Dto", "") + "Service " + model.Name.Replace("Dto", "").ToLower() + "Service)\r\n" +
            "        {\r\n            _unitOfWork = unitOfWork;\r\n            _logger = logger;\r\n" +
            "            _" + model.Name.Replace("Dto", "").ToLower() + "Service = " + model.Name.Replace("Dto", "").ToLower() + "Service;\r\n        }\r\n        " +
            "// GET: api/<" + model.Name.Replace("Dto", "") + "s>\r\n        [HttpGet(nameof(Get" + model.Name.Replace("Dto", "") + "s))]\r\n" +
            "        [DisplayActionName(DisplayName =\"استعلام فروع النقابة\")]\r\n " +
            "       public IActionResult Get" + model.Name.Replace("Dto", "") + "s([FromQuery]SieveModel sieveModel) => Ok(_" + model.Name.Replace("Dto", "").ToLower() + "Service.GetAll(sieveModel));\r\n\r\n" +
            "        [HttpPost(nameof(Create" + model.Name.Replace("Dto", "") + "))]\r\n        [DisplayActionName(DisplayName = \"إنشاء فرع جديد\")]\r\n" +
            "        public async Task<IActionResult> Create" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "") + "Dto " + model.Name.Replace("Dto", "").ToLower() + ")\r\n        {\r\n            " +
            "if (ModelState.IsValid)\r\n            {\r\n                await _" + model.Name.Replace("Dto", "").ToLower() + "Service.Add(" + model.Name.Replace("Dto", "").ToLower() + ");\r\n " +
            "               await _unitOfWork.CompleteAsync();\r\n                return new JsonResult(\"Success\") " +
            "{ StatusCode = 200 ,Value=" + model.Name.Replace("Dto", "").ToLower() + " };\r\n            }\r\n            return new JsonResult(\"Somethign Went wrong\") " +
            "{ StatusCode = 500 };\r\n        }\r\n\r\n        [HttpPut(nameof(Update" + model.Name.Replace("Dto", "") + "))]\r\n       " +
            " [DisplayActionName(DisplayName = \"تعديل فرع\")]\r\n        public async Task<IActionResult> " +
            "Update" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "") + "Dto " + model.Name.Replace("Dto", "").ToLower() + ")\r\n        {\r\n            if (ModelState.IsValid)\r\n" +
            "            {\r\n                await _" + model.Name.Replace("Dto", "").ToLower() + "Service.Update(" + model.Name.Replace("Dto", "").ToLower() + ");\r\n               " +
            " await _unitOfWork.CompleteAsync();\r\n                return new JsonResult(\"Success\") " +
            "{ StatusCode = 200, Value = " + model.Name.Replace("Dto", "").ToLower() + " };\r\n            }\r\n           " +
            " return new JsonResult(\"Somethign Went wrong\") { StatusCode = 500 };\r\n        }\r\n\r\n " +
            "       [HttpDelete(nameof(Delete" + model.Name.Replace("Dto", "") + "))]\r\n        [DisplayActionName(DisplayName = \"حذف فرع\")]\r\n " +
            "       public async Task<IActionResult> Delete" + model.Name.Replace("Dto", "") + "(Guid id)\r\n        {\r\n            if (ModelState.IsValid)\r\n" +
            "            {\r\n                _" + model.Name.Replace("Dto", "").ToLower() + "Service.Delete(id);\r\n                await _unitOfWork.CompleteAsync();\r\n " +
            "               return new JsonResult(\"Success\") { StatusCode = 200, Value = true };\r\n            }\r\n         " +
            "   return new JsonResult(\"Somethign Went wrong\") { StatusCode = 500 };\r\n        }\r\n    }\r\n}\r\n");



            //Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(controllerPAth + model.Name.Replace("Dto", "") + "Controller.cs"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(controllerContent.ToString());
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        public static void generateUIServices(Type? model)
        {
            string pathServices = @"c:\temp\services\";
            StringBuilder serviceUIStr = new StringBuilder("import { HttpClient } from '@angular/common/http';\r\n" +
    "import { Injectable } from '@angular/core';\r\n" +
    "import { Observable } from 'rxjs';\r\n" +
    "import { " + model.Name.Replace("Dto", "") + " } from 'src/app/models/hr/" + model.Name.Replace("Dto", "") + "';" +
    "\r\nimport { environment } from 'src/environments/environment';\r\n");
            serviceUIStr.Append("@Injectable({\r\n  providedIn: 'root'\r\n})\r\n" +
                "export class " + model.Name.Replace("Dto", "") + "Service {\r\n\r\n  " +
                "constructor(private http: HttpClient) { }\r\n\r\n  " +
                "Add" + model.Name.Replace("Dto", "") + "(payLoad: " + model.Name.Replace("Dto", "") + "): Observable<" + model.Name.Replace("Dto", "") + "> {\r\n    " +
                "return this.http.post<" + model.Name.Replace("Dto", "") + ">(`${environment.backendUrl + environment.hrUrl}" + model.Name.Replace("Dto", "") + "/Create" + model.Name.Replace("Dto", "") + "`, payLoad);" +
                "\r\n  }\r\n\r\n  " +
                "Update" + model.Name.Replace("Dto", "") + "(payLoad: " + model.Name.Replace("Dto", "") + "): Observable<" + model.Name.Replace("Dto", "") + "> {\r\n" +
                "    return this.http.put<" + model.Name.Replace("Dto", "") + ">(`${environment.backendUrl + environment.hrUrl}" + model.Name.Replace("Dto", "") + "/Update" + model.Name.Replace("Dto", "") + "`, payLoad);" +
                "\r\n  }\r\n\r\n  " +
                "Delete" + model.Name.Replace("Dto", "") + "(Id: string) {\r\n    " +
                "return this.http.delete(`${environment.backendUrl + environment.hrUrl}" + model.Name.Replace("Dto", "") + "/Delete" + model.Name.Replace("Dto", "") + "?id=${Id}`);\r\n  " +
                "}\r\n  " +
                "GetAll" + model.Name.Replace("Dto", "") + "s(payLoad: string): Observable<" + model.Name.Replace("Dto", "") + "[]> {\r\n" +
                "    return this.http.get<" + model.Name.Replace("Dto", "") + "[]>(`${environment.backendUrl + environment.hrUrl}" + model.Name.Replace("Dto", "") + "/Get" + model.Name.Replace("Dto", "") + "s?${payLoad}`);\r\n " +
                " }\r\n\r\n  Get" + model.Name.Replace("Dto", "") + "sInfo(payLoad: string): Observable<" + model.Name.Replace("Dto", "") + "[]> {\r\n   " +
                " return this.http.get<" + model.Name.Replace("Dto", "") + "[]>(`${environment.backendUrl + environment.hrUrl}" + model.Name.Replace("Dto", "") + "/Get" + model.Name.Replace("Dto", "") + "sInfo?${payLoad}`);" +
                "\r\n  }\r\n}"
                );

            //save to ts files
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(pathServices + model.Name.Replace("Dto", "").ToLower() + ".service.ts"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(serviceUIStr.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void generateComponent(Type? model)
        {
            string componentPAth = @"c:\temp\component\";
            StringBuilder depen = new StringBuilder();
            StringBuilder srtComponentTypeScript = new StringBuilder();
            StringBuilder srtComponentHtml = new StringBuilder("<p-toast dir=\"rtl\"></p-toast>\r\n" +
                "<div class=\"progress-spinner\" *ngIf=\"isLoading$ | async;\">\r\n" +
                "  <p-progressSpinner [style]=\"{width: '50px', height: '50px'}\" styleClass=\"custom-spinner\" strokeWidth=\"8\"\r\n" +
                "    fill=\"var(--surface-ground)\" animationDuration=\".5s\"></p-progressSpinner>\r\n" +
                "</div>\r\n<div class=\"card\" dir=\"rtl\">\r\n" +
                "  <p-toolbar styleClass=\"mb-4\">\r\n" +
                "    <ng-template pTemplate=\"left\">\r\n" +
                "    </ng-template>\r\n" +
                "    <ng-template pTemplate=\"right\">\r\n" +
                "      <button pButton pRipple label=\"{{'addTitle' | translate }}\" icon=\"pi pi-plus\" class=\"p-button-success mr-2\"\r\n" +
                "        (click)=\"openNew()\"></button>\r\n" +
                "    </ng-template>\r\n" +
                "  </p-toolbar>\r\n" +
                "  <p-table responsiveLayout=\"stack\" [value]=\"\"" + model.Name.Replace("Dto", "").ToLower() + "\" selectionMode=\"single\" " +
                "[(selection)]=\"" + model.Name.Replace("Dto", "").ToLower() + "\"\r\n" +
                "    [rowHover]=\"true\" [autoLayout]=\"true\" [paginator]=\"true\" [rows]=\"5\" dataKey=\"Id\" [columns]=\"cols\">\r\n" +
                "    <ng-template pTemplate=\"caption\">\r\n" +
                "      <div class=\"table-header\">\r\n" +
                "        {{'" + model.Name.Replace("Dto", "").ToLower() + "s' | translate }}\r\n" +
                "      </div>\r\n" +
                "    </ng-template>\r\n" +
                "    <ng-template pTemplate=\"header\" let-columns>\r\n" +
                "      <tr>\r\n" +
                "        <th *ngFor=\"let col of cols\" class=\"th\">\r\n" +
                "          {{col.header}}\r\n" +
                "        </th>\r\n" +
                "        <th class=\"th\"> {{'controlTilte' | translate }}</th>\r\n" +
                "      </tr>\r\n" +
                "    </ng-template>\r\n" +
                "    <ng-template pTemplate=\"body\" let-" + model.Name.Replace("Dto", "").ToLower() + " let-columns=\"columns\">\r\n" +
                "      <tr>\r\n" +
                "        <td *ngFor=\"let col of cols\" class=\"td\" [ngSwitch]=\"col.type\">\r\n" +
                "          <ng-container *ngSwitchCase=\"'Date'\">\r\n " +
                "           {{" + model.Name.Replace("Dto", "").ToLower() + "[col.field] |date :'yyyy-MM-dd'}}\r\n " +
                "         </ng-container>\r\n" +
                "          <ng-container *ngSwitchCase=\"'boolean'\">\r\n" +
                "            {{" + model.Name.Replace("Dto", "").ToLower() + "[col.field] ? 'نعم' : 'لا' }}\r\n" +
                "         </ng-container>\r\n" +
                "          <ng-container *ngSwitchDefault >\r\n" +
                "            {{" + model.Name.Replace("Dto", "").ToLower() + "[col.field]}}\r\n" +
                "          </ng-container>\r\n" +
                "        </td>\r\n " +
                "       <td class=\"td\">\r\n  " +
                "        <button pButton pRipple icon=\"pi pi-pencil\" class=\"p-button-rounded p-button-success p-mr-2\"\r\n" +
                "            (click)=\"edit" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "").ToLower() + ")\" title=\"{{'editTitle' | translate }}\"></button>\r\n" +
                "          <button pButton pRipple icon=\"pi pi-trash\" title=\"{{'deleteTitle' | translate }}\"\r\n " +
                "           class=\"p-button-rounded p-button-warning\" (click)=\"deleteSelected" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "").ToLower() + ")\"></button>\r\n" +
                "        </td>\r\n " +
                "     </tr>\r\n" +
                "    </ng-template>\r\n " +
                " </p-table>\r\n" +
                "</div>\r\n" +
                "<p-dialog [(visible)]=\"" + model.Name.Replace("Dto", "").ToLower() + "Dialog\" [style]=\"{width: '750px'}\" header=\"{{'" + model.Name.Replace("Dto", "") + "DialogHeader' | translate }}\"\r\n" +
                "  [modal]=\"true\" styleClass=\"p-fluid\" dir=\"rtl\">\r\n" +
                "  <ng-template pTemplate=\"content\">\r\n" +
                "    <form [formGroup]=\"" + model.Name.Replace("Dto", "").ToLower() + "Form\" (ngSubmit)=\"save" + model.Name.Replace("Dto", "") + "()\">\r\n" +
                "      <div class=\"row\">\r\n" +
                "        <div class=\"p-field col-sm\">\r\n" +
                "          <span class=\"p-float-label\">\r\n" +
                "            <p-calendar formControlName=\"Time\" id=\"Time\" name=\"Time\" [(ngModel)]=\"" + model.Name.Replace("Dto", "").ToLower() + ".Time\" [timeOnly]=\"true\"\r\n" +
                "              appendTo=\"body\" hourFormat=\"24\" inputId=\"timeonly\" autofocus></p-calendar>\r\n" +
                "            <small class=\"p-invalid\" [style]=\"{color: 'red'}\"\r\n" +
                "              *ngIf=\"submitted && f['Time'].invalid && f['Time'].errors && f['Time'].errors['required']\">{{'TimeError'\r\n" +
                "              |\r\n              translate }}</small>\r\n" +
                "            <label for=\"Time\" dir=\"rtl\">{{'Time' | translate }}</label>\r\n" +
                "          </span>\r\n        </div>\r\n        <div class=\"p-field col-sm\">\r\n " +
                "         <span class=\"p-float-label\">\r\n" +
                "            <input pInputText formControlName=\"Place\" id=\"Place\" name=\"Place\" [(ngModel)]=\"" + model.Name.Replace("Dto", "").ToLower() + ".Place\" />\r\n" +
                "            <small class=\"p-invalid\" [style]=\"{color: 'red'}\"\r\n" +
                "              *ngIf=\"submitted && f['Place'].invalid && f['Place'].errors && f['Place'].errors['required']\">{{'PlaceError'\r\n" +
                "              |\r\n              translate }}</small>\r\n" +
                "            <small class=\"p-invalid\" [style]=\"{color: 'red'}\" *ngIf=\"f['Place'].errors?.['maxlength']\">{{'PlaceLength'\r\n" +
                "              |\r\n              translate }}</small>\r\n" +
                "            <label for=\"Place\" dir=\"rtl\">{{'Place' | translate }}</label>\r\n" +
                "          </span>\r\n        </div>\r\n      </div>\r\n" +
                "      <p-divider></p-divider>\r\n      <div class=\"row\">\r\n" +
                "        <div class=\"p-field col-sm\">\r\n          <span class=\"p-float-label\">\r\n" +
                "            <p-calendar formControlName=\"Date\" id=\"Date\" name=\"Date\" [(ngModel)]=\"" + model.Name.Replace("Dto", "").ToLower() + ".Date\"\r\n " +
                "             dateFormat=\"yy-mm-dd\" appendTo=\"body\" [required]=true [showIcon]=\"true\" dataType=\"string\"></p-calendar>\r\n" +
                "            <small class=\"p-invalid\" [style]=\"{color: 'red'}\"\r\n" +
                "              *ngIf=\"submitted && f['Date'].invalid && f['Date'].errors && f['Date'].errors['required']\">{{'DateError'\r\n" +
                "              |\r\n              translate }}</small>\r\n" +
                "            <label for=\"Date\">{{'Date' | translate }}</label>\r\n" +
                "          </span>\r\n        </div>\r\n        <div class=\"p-field col-sm\">\r\n" +
                "          <span class=\"p-float-label\">\r\n" +
                "            <input formControlName=\"Note\" id=\"Note\" name=\"Note\" pInputText [(ngModel)]=\"" + model.Name.Replace("Dto", "").ToLower() + ".Note\" />\r\n" +
                "            <small class=\"p-invalid\" [style]=\"{color: 'red'}\" *ngIf=\"f['Note'].errors?.['Note']\">{{'NoteLength'\r\n" +
                "              |\r\n              translate }}</small>\r\n            <label for=\"Note\">{{'Note' | translate }}</label>\r\n" +
                "          </span>\r\n        </div>\r\n      </div>\r\n    </form>\r\n" +
                "  </ng-template>\r\n\r\n  <ng-template pTemplate=\"footer\">\r\n    <div class=\"row\">\r\n" +
                "      <div class=\"p-button-rounded col-sm\"></div>\r\n" +
                "      <button pButton pRipple label=\"{{'saveTitle' | translate }}\" icon=\"pi pi-check\" class=\"p-button-rounded col-sm\"\r\n" +
                "        (click)=\"save" + model.Name.Replace("Dto", "") + "()\"></button>\r\n" +
                "      <button pButton pRipple type=\"button\" label=\"{{'cancelTitle' | translate }}\" icon=\"pi pi-times\"\r\n" +
                "        class=\"p-button-rounded p-button-warning col-sm\" (click)=\"hideDialog()\"></button>\r\n" +
                "      <div class=\"p-button-rounded col-sm\"></div>\r\n    </div>\r\n  </ng-template>\r\n</p-dialog>\r\n\r\n" +
                "<p-confirmDialog [style]=\"{width: '450px'}\"></p-confirmDialog>\r\n");

            StringBuilder srtComponentCss = new StringBuilder(".th {\r\n  text-align: center !important;\r\n  position: sticky !important;\r\n  top: 0 !important;\r\n}\r\n\r\n.td {\r\n  text-align: center !important;\r\n}\r\n\r\n:host ::ng-deep .p-float-label>label {\r\n  right: 0.75rem !important;\r\n}\r\n\r\n:host ::ng-deep .p-divider.p-divider-horizontal:before {\r\n  border-top: 0px #dee2e6 !important;\r\n}\r\n\r\n:host ::ng-deep .p-toolbar {\r\n  background: unset !important;\r\n  border: 0px solid #dee2e6 !important;\r\n  padding: 1rem 1.25rem;\r\n  border-radius: 4px;\r\n}\r\n\r\n:host ::ng-deep .mb-4 {\r\n  margin-bottom: 0.5rem !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-header {\r\n  border-bottom: 0px solid #e9ecef !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-footer {\r\n  border-top: 0px solid #e9ecef !important;\r\n}\r\n\r\n:host ::ng-deep .p-dialog .p-dialog-content {\r\n  padding: 1.5rem !important;\r\n}\r\n");

            srtComponentTypeScript.Append("import { Component, OnInit } from '@angular/core';\r\n" +
                "import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';" +
                "\r\nimport { TranslateService } from '@ngx-translate/core';\r\n" +
                "import { Store } from '@ngxs/store';\r\n" +
                "import { ConfirmationService, MessageService } from 'primeng/api';\r\n" +
                "import { Observable } from 'rxjs';\r\n" +
                "import { " + model.Name.Replace("Dto", "") + " } from 'src/app/models/hr/" + model.Name.Replace("Dto", "").ToLower() + ".model';\r\n" +
                "import { University } from 'src/app/models/hr/University';\r\n" +
                "import { " + model.Name.Replace("Dto", "") + "Actions } from 'src/app/stateManagement/hr/actions/" + model.Name.Replace("Dto", "") + ".action';\r\n" +
                "import { UniversityActions } from 'src/app/stateManagement/hr/actions/university.action';\r\n\r\n" +
                "@Component({\r\n" +
                "  selector: 'app-" + model.Name.Replace("Dto", "").ToLower() + "',\r\n" +
                "  templateUrl: './" + model.Name.Replace("Dto", "").ToLower() + ".component.html',\r\n" +
                "  styleUrls: ['./" + model.Name.Replace("Dto", "").ToLower() + ".component.css']\r\n" +
                "})\r\n" +
                "export class " + model.Name.Replace("Dto", "") + "Component implements OnInit {\r\n" +
                "  isLoading$!: Observable<boolean>;\r\n" +
                "  " + model.Name.Replace("Dto", "").ToLower() + "s : " + model.Name.Replace("Dto", "") + "[] = [];\r\n" +
                "  cols: any[];\r\n" +
                "  " + model.Name.Replace("Dto", "").ToLower() + "Dialog: boolean;\r\n" +
                "  " + model.Name.Replace("Dto", "") + "!: " + model.Name.Replace("Dto", "") + ";\r\n" +
                "  submitted: boolean;\r\n" +
                "  Time: string = '';\r\n" +
                "  Place: string = '';\r\n" +
                "  DateLabel: string = '';\r\n" +
                "  Note: string = '';\r\n" +
                "  IsCancelled: string = '';\r\n" +
                "  IsDone: string = '';\r\n" +
                "  CancelReason: string = '';\r\n" +
                "  ConfirmTitle: string = '';\r\n" +
                "  ConfirmMsg: string = '';\r\n" +
                "  Success: string = '';\r\n" +
                "  deleteSuccess: string = '';\r\n" +
                "  Yes: string = '';\r\n" +
                "  No: string = '';\r\n" +
                "  editSuccess: string = '';\r\n" +
                "  addSuccess: string = '';\r\n" +
                "  RequestIdCol: string = '';\r\n" +
                "  RequestId: string = '';\r\n" +
                "  universities: University[] = [];\r\n" +
                "  " + model.Name.Replace("Dto", "").ToLower() + "Form: FormGroup;\r\n" +
                "  constructor(private fb: FormBuilder, private store: Store, private messageService: MessageService,\r\n" +
                "    private confirmationService: ConfirmationService, private translate: TranslateService) {\r\n" +
                "    this." + model.Name.Replace("Dto", "").ToLower() + "Form = fb.group({\r\n");
            PropertyInfo[] propInfos = model.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in propInfos)
            {
                srtComponentTypeScript.Append(prop.Name.ToLower() + ":new FormControl('', [Validators.required]),\r\n ");
            }
            srtComponentTypeScript.Append("    });\r\n" +
                "    this.cols = [];\r\n" +
                "    this." + model.Name.Replace("Dto", "").ToLower() + "Dialog = false;\r\n" +
                "    this.submitted = false;\r\n" +
                "  }\r\n\r\n" +
                "  ngOnInit(): void {\r\n" +
                "    this.isLoading$ = this.store.select<boolean>(\r\n" +
                "      (state) => state.users.isLoading\r\n" +
                "    );\r\n" +
                "    this.store.dispatch(new " + model.Name.Replace("Dto", "") + "Actions.Get" + model.Name.Replace("Dto", "") + "sInfo('')).subscribe(\r\n" +
                "      () => {\r\n" +
                "        this." + model.Name.Replace("Dto", "").ToLower() + "s = this.store.selectSnapshot<" + model.Name.Replace("Dto", "") + "[]>((state) => state.users." + model.Name.Replace("Dto", "").ToLower() + "s);\r\n" +
                "      }\r\n " +
                "   );\r\n " +
                "   this.translate.get('AppTitle').subscribe(\r\n " +
                "     () => {\r\n " +
                "       this.Time = this.translate.instant('Time');;\r\n" +
                "        this.Place = this.translate.instant('Place');\r\n" +
                "        this.DateLabel = this.translate.instant('Date');;\r\n" +
                "        this.Note = this.translate.instant('Note');\r\n" +
                "        this.IsCancelled = this.translate.instant('IsCancelled');\r\n" +
                "        this.IsDone = this.translate.instant('IsDone');\r\n " +
                "       this.CancelReason = this.translate.instant('CancelReason');\r\n" +
                "        this.ConfirmTitle = this.translate.instant('ConfirmTitle');\r\n " +
                "       this.ConfirmMsg = this.translate.instant('ConfirmMsg');\r\n " +
                "       this.Success = this.translate.instant('Success');\r\n " +
                "       this.deleteSuccess = this.translate.instant('deleteSuccess');\r\n " +
                "       this.Yes = this.translate.instant('Yes');\r\n " +
                "       this.No = this.translate.instant('No');\r\n  " +
                "      this.editSuccess = this.translate.instant('editSuccess');\r\n" +
                "        this.addSuccess = this.translate.instant('addSuccess');\r\n" +
                "        this.RequestIdCol = this.translate.instant('RequestId');\r\n" +
                "        this.initColumns();\r\n " +
                "     }\r\n" +
                "    )\r\n " +
                " }\r\n" +
                "  initColumns() {\r\n " +
                "   this.cols = [\r\n ");
            //PropertyInfo[] propInfos = model.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in propInfos)
            {
                srtComponentTypeScript.Append("{ field: '" + prop.Name.ToLower() + "',header: this." + prop.Name.ToLower() + ",type:'" + getType(prop.PropertyType.ToString()) + "' },\r\n ");
            }
            srtComponentTypeScript.Append("\r\n]\r\n");
            srtComponentTypeScript.Append("  }\r\n" +
            "  openNew() {\r\n" +
            "    this." + model.Name.Replace("Dto", "") + " = {};\r\n" +
            "    this.submitted = false;\r\n " +
            "   this." + model.Name.Replace("Dto", "").ToLower() + "Dialog = true;\r\n" +
            "  }\r\n" +
            "  edit" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "") + ": " + model.Name.Replace("Dto", "") + ") {\r\n" +
            "    this." + model.Name.Replace("Dto", "") + " = { ..." + model.Name.Replace("Dto", "") + " };\r\n " +
            "   this." + model.Name.Replace("Dto", "").ToLower() + "Dialog = true;\r\n" +
            "  }\r\n" +
            "  deleteSelected" + model.Name.Replace("Dto", "") + "(" + model.Name.Replace("Dto", "") + ": " + model.Name.Replace("Dto", "") + ") {\r\n" +
            "    this." + model.Name.Replace("Dto", "") + " = " + model.Name.Replace("Dto", "") + ";\r\n " +
            "   this.delete" + model.Name.Replace("Dto", "") + "();\r\n" +
            "  }\r\n " +
            " delete" + model.Name.Replace("Dto", "") + "() {\r\n " +
            "   this.confirmationService.confirm({\r\n " +
            "     message: this.ConfirmMsg + this." + model.Name.Replace("Dto", "") + ".Place + '?',\r\n " +
            "     header: this.ConfirmTitle,\r\n " +
            "     icon: 'pi pi-exclamation-triangle',\r\n" +
            "      accept: () => {\r\n" +
            "        this.store.dispatch(new " + model.Name.Replace("Dto", "") + "Actions.Delete" + model.Name.Replace("Dto", "") + "(this." + model.Name.Replace("Dto", "") + ".Id as string)).subscribe(\r\n" +
            "          data => {\r\n " +
            "           this.messageService.add({ severity: 'success', summary: this.Success, detail: this.deleteSuccess, life: 3000 });\r\n" +
            "            this.reload();\r\n" +
            "          }\r\n" +
            "        );\r\n " +
            "     },\r\n " +
            "     acceptLabel: this.Yes,\r\n" +
            "      rejectLabel: this.No,\r\n " +
            "   });\r\n" +
            "  }\r\n\r\n" +
            "  hideDialog() {\r\n" +
            "    this." + model.Name.Replace("Dto", "").ToLower() + "Dialog = false;\r\n" +
            "    this.submitted = false;\r\n" +
            "  }\r\n\r\n" +
            "  save" + model.Name.Replace("Dto", "") + "() {\r\n" +
            "    this.submitted = true;\r\n " +
            "   if (this." + model.Name.Replace("Dto", "").ToLower() + "Form.valid) {\r\n" +
            "      if (this." + model.Name.Replace("Dto", "") + ".Id) {\r\n " +
            "       delete this." + model.Name.Replace("Dto", "") + ".Request;\r\n" +
            "        this.store.dispatch(new " + model.Name.Replace("Dto", "") + "Actions.Update" + model.Name.Replace("Dto", "") + "(this." + model.Name.Replace("Dto", "") + ")).subscribe(\r\n" +
            "          () => {\r\n  " +
            "          this.messageService.add({ severity: 'success', summary: this.Success, detail: this.editSuccess, life: 3000 });\r\n " +
            "           this.reload();\r\n  " +
            "        }\r\n " +
            "       )\r\n " +
            "     }\r\n " +
            "     else {\r\n" +
            "        delete this." + model.Name.Replace("Dto", "") + ".Id;\r\n" +
            "        this.store.dispatch(new " + model.Name.Replace("Dto", "") + "Actions.Add" + model.Name.Replace("Dto", "") + "(this." + model.Name.Replace("Dto", "") + ")).subscribe(\r\n " +
            "         () => {\r\n  " +
            "          this.messageService.add({ severity: 'success', summary: this.Success, detail: this.addSuccess, life: 3000 });\r\n " +
            "           this.reload();\r\n " +
            "         }\r\n" +
            "        )\r\n" +
            "      }\r\n  " +
            "    this." + model.Name.Replace("Dto", "").ToLower() + "Dialog = false;\r\n" +
            "      this." + model.Name.Replace("Dto", "") + " = {};\r\n" +
            "    }\r\n" +
            "  }\r\n\r\n " +
            " reload() {\r\n" +
            "    this.store.dispatch(new " + model.Name.Replace("Dto", "") + "Actions.Get" + model.Name.Replace("Dto", "") + "sInfo('')).subscribe(\r\n " +
            "     () => {\r\n  " +
            "      this." + model.Name.Replace("Dto", "").ToLower() + "s = this.store.selectSnapshot<" + model.Name.Replace("Dto", "") + "[]>((state) => state.users." + model.Name.Replace("Dto", "").ToLower() + "s);\r\n" +
            "      }\r\n " +
            "   )\r\n " +
            " }\r\n\r\n" +
            "  searchUniversity(event: any) {\r\n " +
            "   let filter = \"Filters=Name@=\" + event.query;\r\n " +
            "   this.store.dispatch(new UniversityActions.GetAllUniversitys(filter)).subscribe(\r\n" +
            "      () => {\r\n " +
            "       this.universities = this.store.selectSnapshot<University[]>((state) => state.users.universities);\r\n" +
            "      }\r\n" +
            "    );\r\n" +
            "  }\r\n" +
            "  onSelectUniversity(event: any) {\r\n " +
            "   this.RequestId = event.Id;\r\n " +
            "   this." + model.Name.Replace("Dto", "") + ".RequestId = this.RequestId;\r\n " +
            " }\r\n\r\n " +
            " get f() {\r\n" +
            "    return this." + model.Name.Replace("Dto", "").ToLower() + "Form.controls;\r\n" +
            "  }\r\n" +
            "}" +
            "\r\n");

            //save to ts files
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(componentPAth + model.Name.Replace("Dto", "").ToLower() + ".component.ts"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentTypeScript.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                using (FileStream fs = File.Create(componentPAth + model.Name.Replace("Dto", "").ToLower() + ".component.css"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentCss.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                using (FileStream fs = File.Create(componentPAth + model.Name.Replace("Dto", "").ToLower() + ".component.html"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(srtComponentHtml.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void generateActions(Type? model)
        {
            string actionPath = @"c:\temp\actions\";
            StringBuilder actionStr = new StringBuilder("import { " + model.Name.Replace("Dto", "") + " } from \"src/app/models/hr/" + model.Name.Replace("Dto", "").ToLower() + ".model" + "\";\r\n\r\n" +
                "export namespace " + model.Name.Replace("Dto", "") + "Actions {\r\n\r\n    " +
                "export class Add" + model.Name.Replace("Dto", "") + " {\r\n" +
                "        static readonly type = '[" + model.Name.Replace("Dto", "") + "] Add New " + model.Name.Replace("Dto", "") + "';\r\n" +
                "        constructor(public payLoad: " + model.Name.Replace("Dto", "") + ") { };\r\n" +
                "    }\r\n" +
                "    export class Update" + model.Name.Replace("Dto", "") + " {\r\n" +
                "        static readonly type = '[" + model.Name.Replace("Dto", "") + "] Update the " + model.Name.Replace("Dto", "") + "';\r\n" +
                "        constructor(public payLoad: " + model.Name.Replace("Dto", "") + ") { }\r\n" +
                "    }\r\n\r\n" +
                "    export class GetAll" + model.Name.Replace("Dto", "") + "s {\r\n" +
                "        static readonly type = '[" + model.Name.Replace("Dto", "") + "] Get All " + model.Name.Replace("Dto", "") + "s';\r\n" +
                "        constructor(public payLoad: string) { };\r\n" +
                "    }\r\n    " +
                "export class Delete" + model.Name.Replace("Dto", "") + " {\r\n" +
                "        static readonly type = '[" + model.Name.Replace("Dto", "") + "] Delete the " + model.Name.Replace("Dto", "") + "';\r\n" +
                "        constructor(public Id: string) { };\r\n" +
                "    }\r\n\r\n" +
                "    export class Get" + model.Name.Replace("Dto", "") + "sInfo {\r\n" +
                "        static readonly type = '[" + model.Name.Replace("Dto", "") + "] Get All " + model.Name.Replace("Dto", "") + "s Info';\r\n " +
                "       constructor(public payLoad: string) { };\r\n" +
                "    }\r\n}" +
                "");

            //save to ts files
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(actionPath + model.Name.Replace("Dto", "").ToLower() + ".action.ts"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(actionStr.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void generateUIModels(Type? model)
        {
            string pathModels = @"c:\temp\models\";
            StringBuilder modelStr = new StringBuilder("export interface " + model.Name.Replace("Dto", "") + " {\r\n");
            PropertyInfo[] propInfos = model.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in propInfos)
            {
                modelStr.Append(prop.Name.ToLower()).Append("?:" + getType(prop.PropertyType.ToString()) + ";\r\n ");
            }
            modelStr.Append("}\r\n ");
            //save to ts files
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(pathModels + model.Name.Replace("Dto", "").ToLower() + ".model.ts"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(modelStr.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string getType(string srcType)
        {
            switch (srcType)
            {
                case "System.DateTime": return "Date";
                case "System.Int32":
                case "System.Decimal":
                case "number": return "number";
                case "System.Guid": return "string";
                case "System.String": return "string";
                case "System.Boolean": return "boolean";
                default: return srcType;
            }
        }

        public static string getFromStructureItemByType(string srcType, string propName)
        {
            if (srcType.EndsWith("[System.DateTime]"))
                srcType = "System.DateTime";
            if (srcType.Contains("Dto") || propName.Equals("ID", StringComparison.OrdinalIgnoreCase)) return "";
            switch (srcType)
            {
                case "System.DateTime":
                    return "{\r\n        " +
                        "type: 'Date',\r\n" +
                        "        label: APP_CONSTANTS." + propName.ToUpper() + ",\r\n" +
                        "        name: '" + propName + "',\r\n" +
                        "        value: '',\r\n" +
                        "        validations: [\r\n" +
                        "          {\r\n" +
                        "            name: 'required',\r\n" +
                        "            validator: 'required',\r\n" +
                        "            message: APP_CONSTANTS.FIELD_REQUIRED,\r\n" +
                        "          },\r\n" +
                        "        ],\r\n" +
                        "      },\r\n";
                case "System.Int32":
                case "System.Decimal":
                case "number":
                    return "{\r\n        " +
                        "type: 'number',\r\n" +
                        "        label: APP_CONSTANTS." + propName.ToUpper() + ",\r\n" +
                        "        name: '" + propName + "',\r\n" +
                        "        value: '',\r\n" +
                        "        validations: [\r\n" +
                        "          {\r\n" +
                        "            name: 'required',\r\n" +
                        "            validator: 'required',\r\n" +
                        "            message: APP_CONSTANTS.FIELD_REQUIRED,\r\n" +
                        "          },\r\n" +
                        "        ],\r\n" +
                        "      },\r\n";
                case "System.Guid":
                    return "{\r\n" +
                        "        type: 'select',\r\n" +
                        "        label: APP_CONSTANTS." + propName.Replace("Id", "").ToUpper() + "_NAME,\r\n" +
                        "        name: '" + propName + "',\r\n" +
                        "        value: '',\r\n" +
                        "        options: [...this." + propName.Replace("Id", "") + "s],\r\n" +
                        "        placeHolder: APP_CONSTANTS." + propName.Replace("Id", "").ToUpper() + "_PLACE_HOLDER,\r\n" +
                        "        validations: [\r\n" +
                        "          {\r\n" +
                        "            name: 'required',\r\n" +
                        "            validator: 'required',\r\n" +
                        "            message: APP_CONSTANTS.FIELD_REQUIRED,\r\n" +
                        "          },\r\n" +
                        "        ],\r\n" +
                        "      },\r\n";
                case "System.String":
                    return "{\r\n        " +
                        "type: 'text',\r\n" +
                        "        label: APP_CONSTANTS." + propName.ToUpper() + ",\r\n" +
                        "        name: '" + propName + "',\r\n" +
                        "        value: '',\r\n" +
                        "        validations: [\r\n" +
                        "          {\r\n" +
                        "            name: 'required',\r\n" +
                        "            validator: 'required',\r\n" +
                        "            message: APP_CONSTANTS.FIELD_REQUIRED,\r\n" +
                        "          },\r\n" +
                        "        ],\r\n" +
                        "      },\r\n";
                case "System.Boolean":
                    return "{\r\n        " +
                        "type: 'radio',\r\n" +
                        "        label: APP_CONSTANTS." + propName.ToUpper() + ",\r\n" +
                        "        name: '" + propName + "',\r\n" +
                        "        value: '',\r\n" +
                        "        validations: [\r\n" +
                        "          {\r\n" +
                        "            name: 'required',\r\n" +
                        "            validator: 'required',\r\n" +
                        "            message: APP_CONSTANTS.FIELD_REQUIRED,\r\n" +
                        "          },\r\n" +
                        "        ],\r\n" +
                        "      },\r\n";
                default: return srcType;
            }
        }

        public static string getTableColumnByType(string srcType, string propName)
        {
            if (propName.Equals("ID", StringComparison.OrdinalIgnoreCase)) return "";
            if (srcType.Contains("Dto")) return "{ dataKey: '" + propName + "Name', header: APP_CONSTANTS." + propName.ToUpper() + "NAME},\r\n";
            return "{ dataKey: '" + propName + "', header: APP_CONSTANTS." + propName.ToUpper() + "},\r\n";
        }
    }
}

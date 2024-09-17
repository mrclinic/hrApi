using hiastHRApi.Domain.Entities.Constants;
using hiastHRApi.Domain.Entities.Employee;
using hiastHRApi.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace hiastHRApi.Repository;

public partial class HrmappContext : DbContext
{
    public HrmappContext()
    {
    }

    public HrmappContext(DbContextOptions<HrmappContext> options)
        : base(options)
    {
    }
    #region user managment
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermissions> RolePermissions { get; set; }
    #endregion

    #region constants
    public DbSet<BloodGroup> BloodGroups { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<ChildStatus> ChildStatuses { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<DegreesAuthority> DegreesAuthorities { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<DeputationObjective> DeputationObjectives { get; set; }

    public DbSet<DeputationStatus> DeputationStatuses { get; set; }

    public DbSet<DeputationType> DeputationTypes { get; set; }

    public DbSet<DisabilityType> DisabilityTypes { get; set; }

    public DbSet<EmploymentStatusType> EmploymentStatusTypes { get; set; }

    public DbSet<EvaluationGrade> EvaluationGrades { get; set; }

    public DbSet<EvaluationQuarter> EvaluationQuarters { get; set; }

    public DbSet<ExperienceType> ExperienceTypes { get; set; }

    public DbSet<FinancialImpact> FinancialImpacts { get; set; }

    public DbSet<FinancialIndicatorType> FinancialIndicatorTypes { get; set; }

    public DbSet<ForcedVacationType> ForcedVacationTypes { get; set; }

    public DbSet<Gender> Genders { get; set; }

    public DbSet<HealthyStatus> HealthyStatuses { get; set; }

    public DbSet<InsuranceSystem> InsuranceSystems { get; set; }

    public DbSet<JobCategory> JobCategories { get; set; }

    public DbSet<JobChangeReason> JobChangeReasons { get; set; }

    public DbSet<JobTitle> JobTitles { get; set; }

    public DbSet<Language> Languages { get; set; }

    public DbSet<LanguageLevel> LanguageLevels { get; set; }

    public DbSet<Law> Laws { get; set; }

    public DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public DbSet<MilitaryRank> MilitaryRanks { get; set; }

    public DbSet<MilitarySpecialization> MilitarySpecializations { get; set; }

    public DbSet<ModificationContractType> ModificationContractTypes { get; set; }

    public DbSet<Nationality> Nationalities { get; set; }

    public DbSet<OccurrencePartnerType> OccurrencePartnerTypes { get; set; }

    public DbSet<PromotionPercentage> PromotionPercentages { get; set; }

    public DbSet<PunishmentType> PunishmentTypes { get; set; }

    public DbSet<Qualification> Qualifications { get; set; }

    public DbSet<RelinquishmentReason> RelinquishmentReasons { get; set; }

    public DbSet<RewardType> RewardTypes { get; set; }

    public DbSet<Specialization> Specializations { get; set; }

    public DbSet<StartingType> StartingTypes { get; set; }

    public DbSet<SubDepartment> SubDepartments { get; set; }

    public DbSet<TerminationReason> TerminationReasons { get; set; }

    public DbSet<University> Universities { get; set; }

    public DbSet<VacationType> VacationTypes { get; set; }

    #endregion


    #region employee
    public DbSet<EmpAppointmentStatus> EmpAppointmentStatuses { get; set; }


    public DbSet<EmpAssignment> EmpAssignments { get; set; }

    public DbSet<EmpChild> EmpChildren { get; set; }

    public DbSet<EmpDeputation> EmpDeputations { get; set; }

    public DbSet<EmpEmploymentChange> EmpEmploymentChanges { get; set; }

    public DbSet<EmpEmploymentStatus> EmpEmploymentStatuses { get; set; }

    public DbSet<EmpExperience> EmpExperiences { get; set; }

    public DbSet<EmpLanguage> EmpLanguages { get; set; }

    public DbSet<EmpMilitaryService> EmpMilitaryServices { get; set; }

    public DbSet<EmpMilitaryServiceCohort> EmpMilitaryServiceCohorts { get; set; }

    public DbSet<EmpMilitaryServiceSuspension> EmpMilitaryServiceSuspensions { get; set; }

    public DbSet<EmpPartner> EmpPartners { get; set; }

    public DbSet<EmpPerformanceEvaluation> EmpPerformanceEvaluations { get; set; }

    public DbSet<EmpPersonalInfo> EmpPersonalInfos { get; set; }

    public DbSet<EmpPromotion> EmpPromotions { get; set; }

    public DbSet<EmpPunishment> EmpPunishments { get; set; }

    public DbSet<EmpQualification> EmpQualifications { get; set; }

    public DbSet<EmpRelinquishment> EmpRelinquishments { get; set; }

    public DbSet<EmpReward> EmpRewards { get; set; }

    public DbSet<EmpTrainingCourse> EmpTrainingCourses { get; set; }

    public DbSet<EmpVacation> EmpVacations { get; set; }

    public DbSet<EmpWorkInjury> EmpWorkInjuries { get; set; }

    public DbSet<EmpWorkPlace> EmpWorkPlaces { get; set; }

    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=DESKTOP-A9EBI4L;Database=HRMApp;user id=sa;Password=123;TrustServerCertificate=true;Connection Timeout=3600");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region users managment
        #region User
        modelBuilder.Entity<User>()
            .HasIndex(p => new { p.Username }).IsUnique();
        modelBuilder.Entity<User>().Property(p => p.IsDeleted).HasDefaultValue(false);
        modelBuilder.Entity<User>().Property(p => p.IsActive).HasDefaultValue(false);
        modelBuilder.Entity<User>().HasIndex(p => new { p.NationalNumber, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<User>().HasIndex(p => new { p.Email, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<User>().HasIndex(p => new { p.Mobile, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<User>().Property(p => p.IsActive).HasDefaultValue(false);
        #endregion
        #region Role
        modelBuilder.Entity<Role>()
            .HasIndex(p => new { p.Name, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<Role>().Property(p => p.IsDeleted).HasDefaultValue(false);
        modelBuilder.Entity<Role>().Property(p => p.StatusCode).HasDefaultValue(0);
        #endregion
        #region Permission
        modelBuilder.Entity<Permission>().HasIndex(p => new { p.NAME, p.IsDeleted });
        modelBuilder.Entity<Permission>().Property(p => p.IsDeleted).HasDefaultValue(false);
        #endregion
        #region RolePermissions
        modelBuilder.Entity<RolePermissions>().HasIndex(p => new { p.RoleId, p.PermissionId, p.IsDeleted });
        modelBuilder.Entity<RolePermissions>().Property(p => p.IsDeleted).HasDefaultValue(false);
        #endregion
        #region Profile
        modelBuilder.Entity<UserProfile>().HasIndex(p => new { p.UserId, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<UserProfile>().Property(p => p.IsDeleted).HasDefaultValue(false);
        modelBuilder.Entity<UserProfile>().Property(p => p.IsComplete).HasDefaultValue(false);
        modelBuilder.Entity<UserProfile>().Property(p => p.BirthDate).HasDefaultValueSql("'1900-01-01'");
        modelBuilder.Entity<UserProfile>()
                .Property(e => e.BirthDate)
                .HasColumnType("date");
        #endregion
        #endregion


        modelBuilder.Entity<BloodGroup>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });
        modelBuilder.Entity<BloodGroup>()
            .HasIndex(p => new { p.Name }).IsUnique();
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Branches_DepartmentId");

            entity.HasIndex(e => e.SubDepartmentId, "IX_Branches_SubDepartmentId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.Department).WithMany(p => p.Branches)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubDepartment).WithMany(p => p.Branches)
                .HasForeignKey(d => d.SubDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<Branch>()
            .HasIndex(p => new { p.Name }).IsUnique();

        modelBuilder.Entity<ChildStatus>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasIndex(e => e.CountryId, "IX_Cities_CountryId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<Country>()
            .HasIndex(p => new { p.Name, p.IsDeleted }).IsUnique();
        modelBuilder.Entity<Country>().Property(p => p.IsDeleted).HasDefaultValue(false);

        modelBuilder.Entity<DegreesAuthority>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Department>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<DeputationObjective>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<DeputationStatus>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<DeputationType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<DisabilityType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<EmploymentStatusType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<EvaluationGrade>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<EvaluationQuarter>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<ExperienceType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<FinancialImpact>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<FinancialIndicatorType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<ForcedVacationType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Gender>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<HealthyStatus>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<InsuranceSystem>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<JobChangeReason>(entity =>
        {
            entity.HasIndex(e => e.ModificationContractTypeId, "IX_JobChangeReasons_ModificationContractTypeId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.ModificationContractType).WithMany(p => p.JobChangeReasons)
                .HasForeignKey(d => d.ModificationContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Language>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<LanguageLevel>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Law>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<MilitaryRank>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<MilitarySpecialization>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<ModificationContractType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Nationality>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<OccurrencePartnerType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<PromotionPercentage>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<PunishmentType>(entity =>
        {
            entity.HasIndex(e => e.FinancialImpactId, "IX_PunishmentTypes_FinancialImpactId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.FinancialImpact).WithMany(p => p.PunishmentTypes)
                .HasForeignKey(d => d.FinancialImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<RelinquishmentReason>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<RewardType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasIndex(e => e.QualificationId, "IX_Specializations_QualificationId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.Qualification).WithMany(p => p.Specializations)
                .HasForeignKey(d => d.QualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StartingType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<SubDepartment>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_SubDepartments_DepartmentId");


            entity.Property(e => e.Name).HasMaxLength(1023);

            entity.HasOne(d => d.Department).WithMany(p => p.SubDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TerminationReason>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<University>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<VacationType>(entity =>
        {

            entity.Property(e => e.Name).HasMaxLength(1023);
        });

        modelBuilder.Entity<EmpAppointmentStatus>(entity =>
        {
            entity.HasIndex(e => e.AppointmentContractTypeId, "IX_EmpAppointmentStatuses_AppointmentContractTypeId");

            entity.HasIndex(e => e.DisabilityTypeId, "IX_EmpAppointmentStatuses_DisabilityTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpAppointmentStatuses_EmployeeId");

            entity.HasIndex(e => e.HealthyStatusId, "IX_EmpAppointmentStatuses_HealthyStatusId");

            entity.HasIndex(e => e.InsuranceSystemId, "IX_EmpAppointmentStatuses_InsuranceSystemId");

            entity.HasIndex(e => e.JobCategoryId, "IX_EmpAppointmentStatuses_JobCategoryId");

            entity.HasIndex(e => e.LawId, "IX_EmpAppointmentStatuses_LawId");

            entity.HasIndex(e => e.ModificationContractTypeId, "IX_EmpAppointmentStatuses_ModificationContractTypeId");

            entity.HasIndex(e => e.StartingTypeId, "IX_EmpAppointmentStatuses_StartingTypeId");


            entity.Property(e => e.AppointmenContractNumber).HasMaxLength(255);
            entity.Property(e => e.AppointmentContractVisaNumber).HasMaxLength(255);
            entity.Property(e => e.InsuranceNumber).HasMaxLength(10);
            entity.Property(e => e.ModifiedAppointmentContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.AppointmentContractType).WithMany(p => p.EmpAppointmentStatusAppointmentContractTypes)
                .HasForeignKey(d => d.AppointmentContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DisabilityType).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.DisabilityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HealthyStatus).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.HealthyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InsuranceSystem).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.InsuranceSystemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.JobCategory).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.JobCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Law).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.LawId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModificationContractType).WithMany(p => p.EmpAppointmentStatusModificationContractTypes)
                .HasForeignKey(d => d.ModificationContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StartingType).WithMany(p => p.EmpAppointmentStatuses)
                .HasForeignKey(d => d.StartingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpAssignment>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpAssignments_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpAssignments_EmployeeId");


            entity.Property(e => e.AssignedWork).HasMaxLength(255);
            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpAssignments)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpAssignments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpChild>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpChildren_EmployeeId");

            entity.HasIndex(e => e.GenderId, "IX_EmpChildren_GenderId");

            entity.HasIndex(e => e.StatusId, "IX_EmpChildren_StatusId");


            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.OccurrenceContractNumber).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpChildren)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Gender).WithMany(p => p.EmpChildren)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.EmpChildren)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpDeputation>(entity =>
        {
            entity.HasIndex(e => e.CityId, "IX_EmpDeputations_CityId");

            entity.HasIndex(e => e.CountryId, "IX_EmpDeputations_CountryId");

            entity.HasIndex(e => e.DeputationObjectiveId, "IX_EmpDeputations_DeputationObjectiveId");

            entity.HasIndex(e => e.DeputationStatusId, "IX_EmpDeputations_DeputationStatusId");

            entity.HasIndex(e => e.DeputationTypeId, "IX_EmpDeputations_DeputationTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpDeputations_EmployeeId");

            entity.HasIndex(e => e.UniversityId, "IX_EmpDeputations_UniversityId");


            entity.Property(e => e.AssignedEntity).HasMaxLength(255);
            entity.Property(e => e.DeputationDecisionNumber).HasMaxLength(255);
            entity.Property(e => e.DeputationReason).HasMaxLength(255);
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.ExecutiveContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.RequiredSpecialization).HasMaxLength(255);

            entity.HasOne(d => d.City).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Country).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DeputationObjective).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.DeputationObjectiveId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DeputationStatus).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.DeputationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DeputationType).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.DeputationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.University).WithMany(p => p.EmpDeputations)
                .HasForeignKey(d => d.UniversityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpEmploymentChange>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpEmploymentChanges_EmployeeId");

            entity.HasIndex(e => e.JobChangeReasonId, "IX_EmpEmploymentChanges_JobChangeReasonId");

            entity.HasIndex(e => e.JobTitleId, "IX_EmpEmploymentChanges_JobTitleId");

            entity.HasIndex(e => e.ModificationContractTypeId, "IX_EmpEmploymentChanges_ModificationContractTypeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.VisaNumber).HasMaxLength(255);
            entity.Property(e => e.Workplace).HasMaxLength(500);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpEmploymentChanges)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.JobChangeReason).WithMany(p => p.EmpEmploymentChanges)
                .HasForeignKey(d => d.JobChangeReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.JobTitle).WithMany(p => p.EmpEmploymentChanges)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModificationContractType).WithMany(p => p.EmpEmploymentChanges)
                .HasForeignKey(d => d.ModificationContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpEmploymentStatus>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpEmploymentStatuses_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpEmploymentStatuses_EmployeeId");

            entity.HasIndex(e => e.StartingTypeId, "IX_EmpEmploymentStatuses_StartingTypeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpEmploymentStatuses)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpEmploymentStatuses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StartingType).WithMany(p => p.EmpEmploymentStatuses)
                .HasForeignKey(d => d.StartingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpExperience>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpExperiences_EmployeeId");

            entity.HasIndex(e => e.ExperienceTypeId, "IX_EmpExperiences_ExperienceTypeId");


            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpExperiences)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ExperienceType).WithMany(p => p.EmpExperiences)
                .HasForeignKey(d => d.ExperienceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpLanguage>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpLanguages_EmployeeId");

            entity.HasIndex(e => e.LanguageId, "IX_EmpLanguages_LanguageId");

            entity.HasIndex(e => e.LanguageLevelId, "IX_EmpLanguages_LanguageLevelId");


            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpLanguages)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Language).WithMany(p => p.EmpLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.LanguageLevel).WithMany(p => p.EmpLanguages)
                .HasForeignKey(d => d.LanguageLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpMilitaryService>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpMilitaryServices_EmployeeId");

            entity.HasIndex(e => e.MilitaryRankId, "IX_EmpMilitaryServices_MilitaryRankId");

            entity.HasIndex(e => e.MilitarySpecializationId, "IX_EmpMilitaryServices_MilitarySpecializationId");


            entity.Property(e => e.CohortNumber).HasMaxLength(50);
            entity.Property(e => e.MilitaryNumber).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.RecruitmentBranch).HasMaxLength(50);
            entity.Property(e => e.RecruitmentNumber).HasMaxLength(50);
            entity.Property(e => e.ReserveNumber).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpMilitaryServices)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MilitaryRank).WithMany(p => p.EmpMilitaryServices)
                .HasForeignKey(d => d.MilitaryRankId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MilitarySpecialization).WithMany(p => p.EmpMilitaryServices)
                .HasForeignKey(d => d.MilitarySpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpMilitaryServiceCohort>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpMilitaryServiceCohorts_EmployeeId");


            entity.Property(e => e.EndContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.StartContractNumber).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpMilitaryServiceCohorts)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpMilitaryServiceSuspension>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpMilitaryServiceSuspensions_EmployeeId");


            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.ReturnContractNumber).HasMaxLength(255);
            entity.Property(e => e.SuspensionContractNumber).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpMilitaryServiceSuspensions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpPartner>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpPartners_EmployeeId");

            entity.HasIndex(e => e.GenderId, "IX_EmpPartners_GenderId");

            entity.HasIndex(e => e.NationalityId, "IX_EmpPartners_NationalityId");

            entity.HasIndex(e => e.OccurrenceTypeId, "IX_EmpPartners_OccurrenceTypeId");

            entity.HasIndex(e => e.PartnerWorkId, "IX_EmpPartners_PartnerWorkId");


            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.OccurrenceContractNumber).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpPartners)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Gender).WithMany(p => p.EmpPartners)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Nationality).WithMany(p => p.EmpPartners)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OccurrenceType).WithMany(p => p.EmpPartners)
                .HasForeignKey(d => d.OccurrenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PartnerWork).WithMany(p => p.EmpPartners)
                .HasForeignKey(d => d.PartnerWorkId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpPerformanceEvaluation>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpPerformanceEvaluations_EmployeeId");

            entity.HasIndex(e => e.EvaluationGradeId, "IX_EmpPerformanceEvaluations_EvaluationGradeId");

            entity.HasIndex(e => e.EvaluationQuarterId, "IX_EmpPerformanceEvaluations_EvaluationQuarterId");


            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.ReportNumber).HasMaxLength(255);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpPerformanceEvaluations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EvaluationGrade).WithMany(p => p.EmpPerformanceEvaluations)
                .HasForeignKey(d => d.EvaluationGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EvaluationQuarter).WithMany(p => p.EmpPerformanceEvaluations)
                .HasForeignKey(d => d.EvaluationQuarterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpPersonalInfo>(entity =>
        {
            entity.HasIndex(e => e.BloodGroupId, "IX_EmpPersonalInfos_BloodGroupId");

            entity.HasIndex(e => e.CityId, "IX_EmpPersonalInfos_CityId");

            entity.HasIndex(e => e.EmploymentStatusTypeId, "IX_EmpPersonalInfos_EmploymentStatusTypeId");

            entity.HasIndex(e => e.GenderId, "IX_EmpPersonalInfos_GenderId");

            entity.HasIndex(e => e.IdentityUserId, "IX_EmpPersonalInfos_IdentityUserId").IsUnique();

            entity.HasIndex(e => e.MaritalStatusId, "IX_EmpPersonalInfos_MaritalStatusId");

            entity.HasIndex(e => e.NationalityId, "IX_EmpPersonalInfos_NationalityId");


            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BirthPlace).HasMaxLength(500);
            entity.Property(e => e.CivilRegistry).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FamilyBookNumber).HasMaxLength(50);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(10)
                .HasColumnName("IDNumber");
            entity.Property(e => e.ImagePath).HasMaxLength(1023);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.NationalNumber).HasMaxLength(10);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RegistrationPlaceAndNumber).HasMaxLength(500);

            entity.HasOne(d => d.BloodGroup).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.BloodGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.City).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EmploymentStatusType).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.EmploymentStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Gender).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Nationality).WithMany(p => p.EmpPersonalInfos)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpPromotion>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpPromotions_EmployeeId");

            entity.HasIndex(e => e.EvaluationGradeId, "IX_EmpPromotions_EvaluationGradeId");

            entity.HasIndex(e => e.PromotionPercentageId, "IX_EmpPromotions_PromotionPercentageId");


            entity.Property(e => e.BonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NewSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpPromotions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EvaluationGrade).WithMany(p => p.EmpPromotions)
                .HasForeignKey(d => d.EvaluationGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PromotionPercentage).WithMany(p => p.EmpPromotions)
                .HasForeignKey(d => d.PromotionPercentageId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpPunishment>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpPunishments_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpPunishments_EmployeeId");

            entity.HasIndex(e => e.IssuingDepartmentId, "IX_EmpPunishments_IssuingDepartmentId");

            entity.HasIndex(e => e.OrderDepartmentId, "IX_EmpPunishments_OrderDepartmentId");

            entity.HasIndex(e => e.PunishmentTypeId, "IX_EmpPunishments_PunishmentTypeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.OrderContractNumber).HasMaxLength(255);
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpPunishments)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpPunishments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IssuingDepartment).WithMany(p => p.EmpPunishmentIssuingDepartments)
                .HasForeignKey(d => d.IssuingDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OrderDepartment).WithMany(p => p.EmpPunishmentOrderDepartments)
                .HasForeignKey(d => d.OrderDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PunishmentType).WithMany(p => p.EmpPunishments)
                .HasForeignKey(d => d.PunishmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpQualification>(entity =>
        {
            entity.HasIndex(e => e.CountryId, "IX_EmpQualifications_CountryId");

            entity.HasIndex(e => e.DegreesAuthorityId, "IX_EmpQualifications_DegreesAuthorityId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpQualifications_EmployeeId");

            entity.HasIndex(e => e.QualificationId, "IX_EmpQualifications_QualificationId");

            entity.HasIndex(e => e.SpecializationId, "IX_EmpQualifications_SpecializationId");


            entity.Property(e => e.EquivalenceContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.SubSpecialization).HasMaxLength(255);

            entity.HasOne(d => d.Country).WithMany(p => p.EmpQualifications)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DegreesAuthority).WithMany(p => p.EmpQualifications)
                .HasForeignKey(d => d.DegreesAuthorityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpQualifications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Qualification).WithMany(p => p.EmpQualifications)
                .HasForeignKey(d => d.QualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Specialization).WithMany(p => p.EmpQualifications)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpRelinquishment>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpRelinquishments_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpRelinquishments_EmployeeId");

            entity.HasIndex(e => e.RelinquishmentReasonId, "IX_EmpRelinquishments_RelinquishmentReasonId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpRelinquishments)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpRelinquishments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RelinquishmentReason).WithMany(p => p.EmpRelinquishments)
                .HasForeignKey(d => d.RelinquishmentReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpReward>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpRewards_ContractTypeId");

            entity.HasIndex(e => e.DepartmentId, "IX_EmpRewards_DepartmentId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpRewards_EmployeeId");

            entity.HasIndex(e => e.FinancialIndicatorTypeId, "IX_EmpRewards_FinancialIndicatorTypeId");

            entity.HasIndex(e => e.RewardTypeId, "IX_EmpRewards_RewardTypeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);
            entity.Property(e => e.OrderNumber).HasMaxLength(255);
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpRewards)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Department).WithMany(p => p.EmpRewards)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpRewards)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FinancialIndicatorType).WithMany(p => p.EmpRewards)
                .HasForeignKey(d => d.FinancialIndicatorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RewardType).WithMany(p => p.EmpRewards)
                .HasForeignKey(d => d.RewardTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpTrainingCourse>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpTrainingCourses_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpTrainingCourses_EmployeeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.CourseName).HasMaxLength(255);
            entity.Property(e => e.CourseSource).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpTrainingCourses)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpTrainingCourses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpVacation>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpVacations_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpVacations_EmployeeId");

            entity.HasIndex(e => e.FinancialImpactId, "IX_EmpVacations_FinancialImpactId");

            entity.HasIndex(e => e.ForcedVacationTypeId, "IX_EmpVacations_ForcedVacationTypeId");

            entity.HasIndex(e => e.ModificationContractTypeId, "IX_EmpVacations_ModificationContractTypeId");

            entity.HasIndex(e => e.VacationTypeId, "IX_EmpVacations_VacationTypeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.ModificationContractNumber).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpVacationContractTypes)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpVacations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FinancialImpact).WithMany(p => p.EmpVacations)
                .HasForeignKey(d => d.FinancialImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ForcedVacationType).WithMany(p => p.EmpVacations)
                .HasForeignKey(d => d.ForcedVacationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ModificationContractType).WithMany(p => p.EmpVacationModificationContractTypes)
                .HasForeignKey(d => d.ModificationContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VacationType).WithMany(p => p.EmpVacations)
                .HasForeignKey(d => d.VacationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpWorkInjury>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_EmpWorkInjuries_EmployeeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(255);
            entity.Property(e => e.DisabilityRatio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InjuryType).HasMaxLength(255);
            entity.Property(e => e.LumpSumAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MonthlyAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpWorkInjuries)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmpWorkPlace>(entity =>
        {
            entity.HasIndex(e => e.ContractTypeId, "IX_EmpWorkPlaces_ContractTypeId");

            entity.HasIndex(e => e.EmployeeId, "IX_EmpWorkPlaces_EmployeeId");


            entity.Property(e => e.ContractNumber).HasMaxLength(10);
            entity.Property(e => e.Note).HasMaxLength(1023);

            entity.HasOne(d => d.ContractType).WithMany(p => p.EmpWorkPlaces)
                .HasForeignKey(d => d.ContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmpWorkPlaces)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

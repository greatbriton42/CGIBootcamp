using ABC.Venture.Domain;
using System.Data.Entity;

namespace ABC.Venture.Data
{
    public partial class VentureDatabase : DbContext
    {
        public VentureDatabase()
            : base("name=VentureDatabase")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
        public virtual DbSet<ConsensusRatingCategory> ConsensusRatingCategories { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FinancialInformation> FinancialInformations { get; set; }
        public virtual DbSet<Impact> Impacts { get; set; }
        public virtual DbSet<Indicator> Indicators { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueStatu> IssueStatus { get; set; }
        public virtual DbSet<IssueType> IssueTypes { get; set; }
        public virtual DbSet<LessonLearned> LessonLearneds { get; set; }
        public virtual DbSet<LessonLearnedType> LessonLearnedTypes { get; set; }
        public virtual DbSet<LOB> LOBs { get; set; }
        public virtual DbSet<Probability> Probabilities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectConsensusRating> ProjectConsensusRatings { get; set; }
        public virtual DbSet<ProjectGoal> ProjectGoals { get; set; }
        public virtual DbSet<ProjectHealth> ProjectHealths { get; set; }
        public virtual DbSet<ProjectLevel> ProjectLevels { get; set; }
        public virtual DbSet<ProjectMilestone> ProjectMilestones { get; set; }
        public virtual DbSet<ProjectProjectHealth> ProjectProjectHealths { get; set; }
        public virtual DbSet<ProjectRating> ProjectRatings { get; set; }
        public virtual DbSet<ProjectRatingHistory> ProjectRatingHistories { get; set; }
        public virtual DbSet<ProjectRatingText> ProjectRatingTexts { get; set; }
        public virtual DbSet<ProjectStandardMilestone> ProjectStandardMilestones { get; set; }
        public virtual DbSet<ProjectStatu> ProjectStatus { get; set; }
        public virtual DbSet<ProjectTeam> ProjectTeams { get; set; }
        public virtual DbSet<ProjectTeamRole> ProjectTeamRoles { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Risk> Risks { get; set; }
        public virtual DbSet<RiskStatu> RiskStatus { get; set; }
        public virtual DbSet<StandardMilestone> StandardMilestones { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TeamRole> TeamRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Roles)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Applications>()
                .HasMany(e => e.aspnet_Users)
                .WithRequired(e => e.aspnet_Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aspnet_Roles>()
                .HasMany(e => e.aspnet_Users)
                .WithMany(e => e.aspnet_Roles)
                .Map(m => m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<ConsensusRatingCategory>()
                .Property(e => e.ConsensusRatingCategory1)
                .IsUnicode(false);

            modelBuilder.Entity<ConsensusRatingCategory>()
                .HasMany(e => e.ProjectConsensusRatings)
                .WithRequired(e => e.ConsensusRatingCategory)
                .HasForeignKey(e => e.RatingCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Department1)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Issues)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.BaselineCapital)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.ApprovedCapital)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.CapitalSpent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.PendingCapital)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.BaselineExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.ApprovedExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.ExpenseSpent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.PendingExpense)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.BaselineCap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.ApprovedCap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.CapSpent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.CumulativeNetIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.CumalativeNEIImpact)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FinancialInformation>()
                .Property(e => e.CostCenter)
                .IsUnicode(false);

            modelBuilder.Entity<Impact>()
                .Property(e => e.Impact1)
                .IsUnicode(false);

            modelBuilder.Entity<Impact>()
                .HasMany(e => e.Risks)
                .WithRequired(e => e.Impact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Indicator>()
                .Property(e => e.ProjectIndicator)
                .IsUnicode(false);

            modelBuilder.Entity<Issue>()
                .Property(e => e.Issue1)
                .IsUnicode(false);

            modelBuilder.Entity<Issue>()
                .Property(e => e.NextAction)
                .IsUnicode(false);

            modelBuilder.Entity<Issue>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<IssueStatu>()
                .Property(e => e.IssueStatus)
                .IsUnicode(false);

            modelBuilder.Entity<IssueStatu>()
                .HasMany(e => e.Issues)
                .WithRequired(e => e.IssueStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IssueType>()
                .Property(e => e.IssueType1)
                .IsUnicode(false);

            modelBuilder.Entity<IssueType>()
                .HasMany(e => e.Issues)
                .WithRequired(e => e.IssueType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LessonLearned>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<LessonLearned>()
                .Property(e => e.Recommendation)
                .IsUnicode(false);

            modelBuilder.Entity<LessonLearnedType>()
                .Property(e => e.LessonLearnedType1)
                .IsUnicode(false);

            modelBuilder.Entity<LOB>()
                .Property(e => e.LOB1)
                .IsUnicode(false);

            modelBuilder.Entity<Probability>()
                .Property(e => e.Probability1)
                .IsUnicode(false);

            modelBuilder.Entity<Probability>()
                .HasMany(e => e.Risks)
                .WithRequired(e => e.Probability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.BusinessIssue)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Solution)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Benefits)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectDirectory)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProjectNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.PriorityCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.FinancialInformations)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectConsensusRatings)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectProjectHealths)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectGoal>()
                .Property(e => e.ProjectGoal1)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectHealth>()
                .Property(e => e.ProjectHealth1)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectHealth>()
                .HasMany(e => e.ProjectProjectHealths)
                .WithRequired(e => e.ProjectHealth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectLevel>()
                .Property(e => e.ProjectLevel1)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMilestone>()
                .Property(e => e.PercentComplete)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProjectMilestone>()
                .Property(e => e.Milestone)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectRating>()
                .Property(e => e.ProjectRating1)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectRatingText>()
                .Property(e => e.ProjectRatingCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProjectRatingText>()
                .Property(e => e.ProjectRatingText1)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStandardMilestone>()
                .Property(e => e.PercentComplete)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProjectStatu>()
                .Property(e => e.ExecutiveSummary)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatu>()
                .Property(e => e.Accomplishments)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatu>()
                .Property(e => e.PlannedActivities)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatu>()
                .Property(e => e.PercentEffort)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProjectTeam>()
                .HasMany(e => e.Issues)
                .WithRequired(e => e.ProjectTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectTeam>()
                .HasMany(e => e.Risks)
                .WithRequired(e => e.ProjectTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resource>()
                .Property(e => e.Resource1)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Resource)
                .HasForeignKey(e => e.DepartmentHeadID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resource>()
                .HasMany(e => e.ProjectTeams)
                .WithRequired(e => e.Resource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Risk>()
                .Property(e => e.Risk1)
                .IsUnicode(false);

            modelBuilder.Entity<Risk>()
                .Property(e => e.MitigationApproach)
                .IsUnicode(false);

            modelBuilder.Entity<Risk>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<RiskStatu>()
                .Property(e => e.RiskStatus)
                .IsUnicode(false);

            modelBuilder.Entity<RiskStatu>()
                .HasMany(e => e.Risks)
                .WithRequired(e => e.RiskStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StandardMilestone>()
                .Property(e => e.StandardMilestone1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Indicators)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.ProjectStatusID);

            modelBuilder.Entity<TeamRole>()
                .Property(e => e.TeamRole1)
                .IsUnicode(false);
        }
    }
}

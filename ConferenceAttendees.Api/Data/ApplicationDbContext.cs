using Microsoft.EntityFrameworkCore;

namespace ConferenceAttendees.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<ReferralSource> ReferralSources { get; set; }

    }
}

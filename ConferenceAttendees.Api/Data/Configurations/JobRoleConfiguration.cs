using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceAttendees.Api.Data.Configurations;

public class JobRoleConfiguration : IEntityTypeConfiguration<JobRole>
{
    public void Configure(EntityTypeBuilder<JobRole> builder)
    {
        builder.HasData(
                            new JobRole
                            {
                                Id = Guid.Parse("e42f1629-367f-42b6-b75c-36a391f7816e"),
                                Name = "Manager",
                            },
                            new JobRole
                            {
                                Id = Guid.Parse("825e19cc-89e1-4f7e-86a7-776efe3a403e"),
                                Name = "Supervisor",
                            },
                            new JobRole
                            {
                                Id = Guid.Parse("0713d4d5-5560-4d36-b1ec-5bca0f52268a"),
                                Name = "Sales",
                            },
                            new JobRole
                            {
                                Id = Guid.Parse("14c05cd3-7064-46b4-9d61-d003942d4c05"),
                                Name = "Operations",
                            }
                        );
    }
}

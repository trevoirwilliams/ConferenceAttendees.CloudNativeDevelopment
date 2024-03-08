using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceAttendees.Api.Data.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasData(
                            new Gender
                            {
                                Id = Guid.Parse("c2a3bf8d-4340-4adc-85a3-a0be30d572f2"),
                                Name = "Male",
                            },
                            new Gender
                            {
                                Id = Guid.Parse("b66910d4-f789-473d-b997-16efabdcb5d3"),
                                Name = "Female",
                            }
                        );
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
    public class DegreeConfig : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.Property(x => x.DegreeName).IsRequired().HasMaxLength(30);
        }
    }
}

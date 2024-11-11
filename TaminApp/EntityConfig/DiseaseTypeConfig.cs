using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
    public class DiseaseTypeConfig : IEntityTypeConfiguration<DiseaseType>
    {
        public void Configure(EntityTypeBuilder<DiseaseType> builder)
        {
            builder.Property(x => x.DiseaseName).IsRequired().HasMaxLength(30);
        }
    }
}

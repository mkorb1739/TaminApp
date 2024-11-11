using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
    public class PeopleDiseaseConfig : IEntityTypeConfiguration<PeopleDiseaseType>
    {
        public void Configure(EntityTypeBuilder<PeopleDiseaseType> builder)
        {
            builder.HasKey(x => new { x.PeopleId, x.DiseaseTypeId });
           builder.HasOne(x=> x.People).WithMany(x=> x.peopleDiseaseTypes).HasForeignKey(x=> x.PeopleId ).OnDelete(DeleteBehavior.Cascade);
       builder.Property(x=> x.DiseaseDate).IsRequired ();
        
        }
    }
}

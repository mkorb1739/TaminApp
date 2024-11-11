using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
    public class BaseClassConfig : IEntityTypeConfiguration<BaseClass>
    {
         public void Configure(EntityTypeBuilder<BaseClass> builder)
        {
            builder.HasKey(x=> x.ID);
            builder.Property(x => x.ID).IsRequired().ValueGeneratedOnAdd();
        }
    }
}

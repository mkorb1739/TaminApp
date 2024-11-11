using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
    public class BankConfig : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(x => x.BankName).IsRequired().HasMaxLength(50);
        }
    }
}

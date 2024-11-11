using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaminApp.Entity;

namespace TaminApp.EntityConfig
{
       public class PeopleConfig : IEntityTypeConfiguration<people>
    {
        public void Configure(EntityTypeBuilder<people> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(x=> x.LastName).IsRequired().HasMaxLength(20);
            builder.Property(x=> x.FatherName).IsRequired().HasMaxLength(15);
            builder.Property(x=> x.mobile).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x=> x.PostalCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.gender).IsRequired();
            builder.Property(x => x.BirchDate).IsRequired();
            builder.Property(x => x.BirthcertificateNumber ).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Birthcertificateseries ).IsRequired().HasMaxLength(10);
           
            builder.Property(x => x.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.MembershipNumber ).IsRequired();
            builder.Property(x => x.MembershipDate ).IsRequired();
            builder.Property(x => x.pensionNumber ).IsRequired();

            builder.Property(x => x.DegreeID ).IsRequired();
            builder.Property(x => x.TaminCode).IsRequired();
            builder.Property(x => x.Sacrifice ).IsRequired();
            builder.Property(x => x.BankID ).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
builder.HasOne(x=> x.Bank).WithMany(x=> x.People).HasForeignKey(x=> x.BankID).OnDelete(DeleteBehavior.Restrict );//درصورت متصل بودن حق حذف نداریم
builder.HasOne(x=> x.Degree).WithMany(x=> x.People).HasForeignKey(x=> x.DegreeID).OnDelete(DeleteBehavior.Restrict);



        }
    }
}

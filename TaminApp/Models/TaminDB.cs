using Microsoft.EntityFrameworkCore;
using TaminApp.Entity;
using TaminApp.EntityConfig;

namespace TaminApp.Models
{
    public class TaminDB : DbContext
    {
        public TaminDB(DbContextOptions<TaminDB> options) : base(options)
        {
            //Test
        }
        public DbSet<people> peoples { get; set; }
        public DbSet<Bank> banks { get; set; }
        public DbSet<Degree> degrees { get; set; }
        public DbSet<DiseaseType> diseaseTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BankConfig());
            modelBuilder.ApplyConfiguration(new DegreeConfig());
            modelBuilder.ApplyConfiguration(new DiseaseTypeConfig());
            modelBuilder.ApplyConfiguration(new PeopleConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}

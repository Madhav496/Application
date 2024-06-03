using MadhavApplication.Data.DataConfigure;
using Microsoft.EntityFrameworkCore;

namespace MadhavApplication.Data
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext>options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StudentConfigure());
            modelBuilder.ApplyConfiguration(new StudentProfileConfigure());
        }

    }
}

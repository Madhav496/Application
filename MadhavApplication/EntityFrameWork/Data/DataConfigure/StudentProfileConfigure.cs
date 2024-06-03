using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadhavApplication.Data.DataConfigure
{
    public class StudentProfileConfigure : IEntityTypeConfiguration<StudentProfile>
    {
        public void Configure(EntityTypeBuilder<StudentProfile> builder)
        {
            builder.ToTable("StudentsProfile");
            builder.HasKey(student => student.Id);
            builder.Property(student => student.StudentName).IsRequired();
        }


    }
}

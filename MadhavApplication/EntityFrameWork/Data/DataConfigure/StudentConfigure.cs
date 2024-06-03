using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadhavApplication.Data.DataConfigure
{
    public class StudentConfigure : IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student>builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StudentAge).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(100);
            



        }
    }
}

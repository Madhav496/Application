using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadhavApplication.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentAge { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime AddmissionDate {  get; set; }
    }
}

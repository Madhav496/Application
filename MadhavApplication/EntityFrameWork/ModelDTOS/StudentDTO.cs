using System.ComponentModel.DataAnnotations;

namespace MadhavApplication.ModelDTOS
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StudentAge { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public DateTime AddmissionDate { get; set; }
    }
}

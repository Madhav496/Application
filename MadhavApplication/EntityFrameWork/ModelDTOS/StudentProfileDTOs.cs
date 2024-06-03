using System.ComponentModel.DataAnnotations;

namespace MadhavApplication.ModelDTOS
{
    public class StudentProfileDTOs
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public long StudentPhone { get; set; }
    }
}

using MadhavApplication.Data;

using MadhavApplication.ModelDTOS;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MadhavApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly StudentDBContext _dbContext;
        public StudentProfileController(StudentDBContext dbContext)
        {

            _dbContext = dbContext;
        }



        [HttpGet]
        [Route("All")]
        public IEnumerable<StudentProfileDTOs> GetStudentProfiles()
        {
            //return _dbContext.StudentProfiles;
            var studentProfiles = _dbContext.StudentProfiles
            .Select(student => new StudentProfileDTOs
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                // Map other properties as needed
            })
            .ToList();

            return studentProfiles;
        }

        [HttpPost]
        [Route("CreatingNewProfile")]
        public ActionResult<IEnumerable<StudentProfileDTOs>> CreateNewProfile(StudentProfileDTOs model)
        {
            //int newId = _dbContext.StudentProfiles.LastOrDefault().Id + 1;
            StudentProfile newStudent = new StudentProfile
            {
                
                StudentId = model.StudentId,
                StudentName = model.StudentName,
                StudentEmail=model.StudentEmail,
                StudentPhone=model.StudentPhone,
            };
            _dbContext.StudentProfiles.Add(newStudent);
            _dbContext.SaveChanges();
            model.Id = newStudent.Id;
            return Ok(model);

        }

        [HttpGet]
        [Route("GetByStudentId")]
        public StudentProfileDTOs GetStudentProfile(int id)
        {
            //return _dbContext.StudentProfiles.Where(n=>n.Id == id).FirstOrDefault();
            var student = _dbContext.StudentProfiles.Where(n => n.Id == id).FirstOrDefault();
            var StudentProfileDTOs = new StudentProfileDTOs
            {
                Id = student.Id,
                StudentId= student.StudentId,
                StudentName = student.StudentName,
                StudentEmail= student.StudentEmail,
                StudentPhone= student.StudentPhone,

            };
            _dbContext.SaveChanges();
            return StudentProfileDTOs;

        }

    }
}

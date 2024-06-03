
using MadhavApplication.Data;
using MadhavApplication.ModelDTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography.X509Certificates;

namespace MadhavApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {


        private readonly StudentDBContext _dbContext;
        public StudentsController(StudentDBContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        [HttpGet("All")]

        public ActionResult<IEnumerable<StudentDTO>> GetStudentName()

        {
            
            var students= _dbContext.Students.Select(s=> new StudentDTO(){
                Id = s.Id,
                Name = s.Name,
                StudentAge=s.StudentAge,
                Description=s.Description,
                DateOfBirth=s.DateOfBirth,
                AddmissionDate=s.AddmissionDate,
               
            });
            _dbContext.SaveChanges();
            return Ok(students);
        }


        [HttpGet("{id:int}",Name ="GetStudentById")]
        public  ActionResult<StudentDTO> GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var student=_dbContext.Students.Where(n => n.Id == id).FirstOrDefault();
            var StudentDTO = new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                StudentAge=student.StudentAge,
                Description = student.Description,
               DateOfBirth=student.DateOfBirth,
                AddmissionDate = student.AddmissionDate,

            };
            _dbContext.SaveChanges();
            return Ok(StudentDTO);
        }


        [HttpGet("{name:alpha}")]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            var student=_dbContext.Students.Where(n => n.Name == name).FirstOrDefault();
            var StudentDTO = new StudentDTO
            {
                Id=student.Id, 
                Name = student.Name,
                StudentAge=student.StudentAge,
                Description = student.Description,
                DateOfBirth=student.DateOfBirth,
                AddmissionDate=student.AddmissionDate,

            };
            return Ok(StudentDTO);
        }


        [HttpDelete("{id}")]
        public bool DeleteStudentById(int id)
        {
            var deletedstudent= _dbContext.Students.Where(n=>n.Id==id).FirstOrDefault();
            _dbContext.Students.Remove(deletedstudent);
            _dbContext.SaveChanges();
            return true;
        }


        [HttpPost("Create")]
        public ActionResult<IEnumerable<StudentDTO>> CreateNewStudent(StudentDTO model)
        {
            
           //int newId = StudentRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student
            {
                Name = model.Name,
                StudentAge=model.StudentAge,
                DateOfBirth=model.DateOfBirth,
                Description=model.Description,
                AddmissionDate=model.AddmissionDate,
                
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            model.Id = student.Id;
            return Ok(model);
        }


        //[HttpPost("CreatingDetails by Conditions")]
        //[ProducesResponseType(StatusCodes.Status201Created)]

        //public ActionResult<IEnumerable<Student>> CreatingDefaultDetails(Student model1)
        //{
        //    if (model1.AddmissionDate < DateTime.Now)
        //    {
        //        ModelState.AddModelError("AddmissionError", "must be greater than todays date");
        //        return BadRequest(ModelState);
        //    }
        //    Student student = new Student
        //    {
        //        Id = model1.Id,
        //        Name = model1.Name,
        //        StudentAge = model1.StudentAge,
        //        DOB=model1.DOB,
        //        Description = model1.Description,
        //        AddmissionDate = model1.AddmissionDate,

        //    };
        //    _dbContext.Students.Add(student);
         
        //    model1.Id = student.Id;
        //    return CreatedAtRoute("GetStudentById", new { id = model1.Id }, model1);
        //}

        [HttpPut]
        [Route("Update")]
        public ActionResult<IEnumerable<StudentDTO>>UpdatingDetails(StudentDTO model)
        {
            var existingStudent= _dbContext.Students.Where(n=>n.Id == model.Id).FirstOrDefault();
            existingStudent.Name = model.Name;
            existingStudent.Description = model.Description;
            existingStudent.DateOfBirth = model.DateOfBirth;
            existingStudent.AddmissionDate = model.AddmissionDate;
            existingStudent.StudentAge = model.StudentAge;

            _dbContext.SaveChanges();

            return NoContent();
        } 



    }
}

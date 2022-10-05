using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBootcampNet.DAL_Data_Access_Layer_;
using ProjectBootcampNet.DTO;
using ProjectBootcampNet.Models;
using System.Security.Cryptography.X509Certificates;

namespace ProjectBootcampNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly InterfaceStudent _student;
        public StudentsController(InterfaceStudent student)
        {
            _student = student;

        }
        [HttpGet]
            public IEnumerable<StudentModel>Get  ()

        {
            var results = _student.GetAllStudent();
            return results;
           
        }
        [HttpGet("{id}")]
        public StudentModel GetID(int id)
        {
            return _student.GetById(id);
        }
        [HttpGet("ByName")]
        public IEnumerable<StudentModel> GetByName(string Lastname)
        {
            return _student.GetByName(Lastname);
        }
        [HttpPost]
        public IActionResult Post(StudentAddDTO studentDto)
        {
            try
            {
                var student = new StudentModel
                {
                    LastName = studentDto.LastName
                   
                };
                var student1 = new StudentModel
                {
                    FirstMidName = studentDto.FirstMidName

                };

                var newStudent1 = _student.Insert(student1);
                var newStudent = _student.Insert(student);
                return CreatedAtAction("Get", new { id = newStudent.ID }, newStudent);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpPut]
        public IActionResult Put(StudentModel student)
        {
            try
            {
                var editStudent = _student.Update(student);
                return Ok(editStudent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _student.Delete(id);
                return Ok($"Delete Id {id} berhasil");
            }
            catch (Exception ex)
            {

                return BadRequest($"Pesan{ex.Message}");
            }
        }

    }
}

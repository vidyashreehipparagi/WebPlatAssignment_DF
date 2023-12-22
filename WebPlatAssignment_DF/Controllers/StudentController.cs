using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using WebPlatAssignment_DF.Model;
using WebPlatAssignment_DF.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebPlatAssignment_DF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
                this.service= service;
        }
        // GET: api/<StudentController>
        [HttpGet]
        [Route("GetStudents")]
        public async Task<ActionResult> Get()
        {
           var model=await service.GetStudents();
            return new ObjectResult(model);
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult> AddStudent(Student student)
        {
            try
            {
               int result=await service.AddStudent(student);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
               
            }
           
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent(Student student)
        {
            try
            {
                int result = await service.UpdateStudent(student);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent,ex.Message);

            }

        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<ActionResult> deleteStudent(int id)
        {
            try
            {
                int result = await service.DeleteStudent(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent,ex.Message);

            }

        }
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            try
            {
                return new ObjectResult(service.GetStudentById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);

            }

        }
    }
}

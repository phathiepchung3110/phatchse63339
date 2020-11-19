using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOS.Student;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly SWDContext _context;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService,SWDContext context, IMapper mapper)
        {
            _context = context;
            _service = studentService;
            _mapper = mapper;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult InsertJob(StudentRequest Request)
        {
            var student = _mapper.Map<Student>(Request);
            if (student == null)
            {
                return NoContent();
            }

            _service.InsertApply(student);
            _service.Commit();

            return CreatedAtAction("InsertJob", new { id = student.Code, message = "Created Success" }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

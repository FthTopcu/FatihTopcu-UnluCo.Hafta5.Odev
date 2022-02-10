using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.CreateStudent;
using UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.DeleteStudent;
using UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.UpdateStudent;
using UnluCo.Hafta2.Odev.Application.StudentOperations.Queries.GetStudentDetail;
using UnluCo.Hafta2.Odev.Application.StydentOperations.Queries.GetStudents;
using UnluCo.Hafta2.Odev.DBOperations;
using static UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.CreateStudent.CreateStudentCommand;
using static UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.UpdateStudent.UpdateStudentCommand;

namespace UnluCo.Hafta2.Odev.Controllers
{
    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentsQuery query = new GetStudentsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            StudentDetailViewModel result;

            GetStudentDetailQuery query = new GetStudentDetailQuery(_mapper,_context);
            query.StudentId = id;
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }


        //Post
        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentModel newStudent)
        {
            CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);
            command.Model = newStudent;
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            validator.ValidateAndThrow(command);//valide et hatayı fırlat
            command.Handle();

            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentModel updatedStudent)
        {
            UpdateStudentCommand command = new UpdateStudentCommand(_context);
            command.StudentId = id;
            command.Model = updatedStudent;

            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = id;
            DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        } 

    }
}

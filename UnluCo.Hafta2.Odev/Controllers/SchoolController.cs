using Microsoft.AspNetCore.Mvc;
using UnluCo.Hafta2.Odev.DBOperations;
using AutoMapper;
using FluentValidation;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.CreateSchool;
using UnluCo.Hafta2.Odev.Entities;
using static UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.CreateSchool.CreateSchoolCommand;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.DeleteSchool;
using static UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.UpdateSchool.UpdateSchoolCommand;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.UpdateSchool;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchools;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchoolDetail;
using Microsoft.AspNetCore.Authorization;
using UnluCo.Hafta2.Odev.Filters;

namespace UnluCo.Hafta2.Odev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;
        public SchoolController(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSchools()
        {

            GetSchoolsQuery query = new GetSchoolsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("desc")]
        public IActionResult GetSchoolsDesc()
        {

            GetSchoolsQuery query = new GetSchoolsQuery(_context, _mapper);
            var result = query.Handle();
            result.Reverse();
            return Ok(result);

        }


        [HttpGet("id")]
        public IActionResult GetSchoolById(int id)
        {
            SchoolDetailViewModel result;

            GetSchoolDetailQuery query = new GetSchoolDetailQuery(_mapper,_context);
            query.SchoolId = id;
            GetSchoolDetailQueryValidator validator = new GetSchoolDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddSchool([FromBody]CreateSchoolModel newSchool)
        {
            CreateSchoolCommand command = new CreateSchoolCommand(_context, _mapper);
            command.Model = newSchool;
            CreateSchoolCommandValidator validator = new CreateSchoolCommandValidator();
            validator.ValidateAndThrow(command);//valide et hatayı fırlat
            command.Handle();

            return Ok();

        }
        //SchoolControllerda tek bir string güncellenmesi yapılacağı için patch kullandık, put'a gerek yok 
        //[HttpPut("{id}")]
        //public IActionResult UpdateSchool(int id, [FromBody] UpdateSchoolModel updatedSchool)
        //{
        //    UpdateSchoolCommand command = new UpdateSchoolCommand(_context);
        //    command.SchoolId = id;
        //    command.Model = updatedSchool;

        //    UpdateSchoolCommandValidator validator = new UpdateSchoolCommandValidator();
        //    validator.ValidateAndThrow(command);
        //    command.Handle();

        //    return Ok();
        //}
        [HttpPatch("id")]
        public IActionResult UpdateSchoolPatch(int id, [FromBody] UpdateSchoolModel updatedSchool)
        {
            UpdateSchoolCommand command = new UpdateSchoolCommand(_context);
            command.SchoolId = id;
            command.Model = updatedSchool;

            UpdateSchoolCommandValidator validator = new UpdateSchoolCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteSchool(int id)
        {
            DeleteSchoolCommand command = new DeleteSchoolCommand(_context);
            command.SchoolId = id;
            DeleteSchoolCommandValidator validator = new DeleteSchoolCommandValidator();
            validator.ValidateAndThrow(command);//valide et hatayı fırlat
            command.Handle();

            return Ok();
        }


    }
}

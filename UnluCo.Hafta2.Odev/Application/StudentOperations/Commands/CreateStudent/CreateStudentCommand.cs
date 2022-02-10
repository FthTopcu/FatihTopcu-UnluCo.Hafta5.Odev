using AutoMapper;
using System;
using System.Linq;
using UnluCo.Hafta2.Odev.DBOperations;
using UnluCo.Hafta2.Odev.Entities;
using UnluCo.Hafta2.Odev.StringExtensions;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        public CreateStudentModel Model { get; set; }
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateStudentCommand(ISchoolDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var student = _dbContext.Students.SingleOrDefault(x => x.Email == Model.Email);
            if (student is not null)
                throw new InvalidOperationException("Öğrenci Mevcut");
            if (!Model.Email.isValidEmail())
                throw new InvalidOperationException("Hatalı Mail Girişi");
            student = _mapper.Map<Student>(Model);

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

        }
        public class CreateStudentModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public int SchoolId { get; set; }
        }
    }
}

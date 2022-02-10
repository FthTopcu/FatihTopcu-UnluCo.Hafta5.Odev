using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public int StudentId;
        public GetStudentDetailQuery(IMapper mapper, ISchoolDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public StudentDetailViewModel Handle()
        {
            var Student = _dbContext.Students.Where(school => school.Id == StudentId).SingleOrDefault();
            if (Student is null)
                throw new InvalidOperationException("Öğrenci Mevcut Değil");
            StudentDetailViewModel vm = _mapper.Map<StudentDetailViewModel>(Student);
            return vm;
        }
    }
    public class StudentDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
    }
}

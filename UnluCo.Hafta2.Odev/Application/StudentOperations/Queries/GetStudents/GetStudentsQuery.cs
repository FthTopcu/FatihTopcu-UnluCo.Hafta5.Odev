using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnluCo.Hafta2.Odev.DBOperations;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.Application.StydentOperations.Queries.GetStudents
{
    public class GetStudentsQuery
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetStudentsQuery(ISchoolDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<StudentsViewModel> Handle()
        {
            var studentList = _dbContext.Students.Include(x => x.School).OrderBy(x => x.Name).ToList<Student>();
            List<StudentsViewModel> vm = _mapper.Map<List<StudentsViewModel>>(studentList);
            return vm;
        }
    }
    public class StudentsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
    }
}

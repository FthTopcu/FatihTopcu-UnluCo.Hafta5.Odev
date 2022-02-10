using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommand
    {
        public UpdateStudentModel Model { get; set; }
        private readonly ISchoolDbContext _dbContext;
        public int StudentId { get; set; }
        public UpdateStudentCommand(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var student = _dbContext.Students.SingleOrDefault(x => x.Id == StudentId);
            if (student is null)
                throw new InvalidOperationException("Öğrenci Mevcut Değil");
            student.Name = Model.Name != default ? Model.Name : student.Name;
            student.Surname = Model.Surname != default ? Model.Surname : student.Surname;
            student.SchoolId = Model.SchoolId != default ? Model.SchoolId : student.SchoolId;
            _dbContext.SaveChanges();

        }
        public class UpdateStudentModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int SchoolId { get; set; }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommand
    {
        private readonly ISchoolDbContext _dbContext;
        public int StudentId { get; set; }

        public DeleteStudentCommand(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var student = _dbContext.Students.SingleOrDefault(x => x.Id == StudentId);
            if(student is null)
                throw new InvalidOperationException("Öğrenci Mevcut Değil");
           
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.DeleteSchool
{
    public class DeleteSchoolCommand
    {
        private readonly ISchoolDbContext _dbContext;
        public int SchoolId { get; set; }

        public DeleteSchoolCommand(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var school = _dbContext.Schools.SingleOrDefault(x => x.Id == SchoolId);
            if(school is null)
                throw new InvalidOperationException("Okul Mevcut Değil");
            var isActiveStudent = _dbContext.Students.SingleOrDefault(x => x.SchoolId == SchoolId);
            if (isActiveStudent is not null)
                throw new InvalidOperationException("Okulda Öğrenci Mevcut");
            _dbContext.Schools.Remove(school);
            _dbContext.SaveChanges();
        }

    }
}

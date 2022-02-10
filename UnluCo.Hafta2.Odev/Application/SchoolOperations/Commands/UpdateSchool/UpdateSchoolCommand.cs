using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.UpdateSchool
{
    public class UpdateSchoolCommand
    {
        public UpdateSchoolModel Model { get; set; }
        private readonly ISchoolDbContext _dbContext;
        public int SchoolId { get; set; }
        public UpdateSchoolCommand(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var school = _dbContext.Schools.SingleOrDefault(x => x.Id == SchoolId);
            if (school is null)
                throw new InvalidOperationException("Okul Mevcut Değil");
            school.Name = Model.Name != default ? Model.Name : school.Name;
            _dbContext.SaveChanges();

        }
        public class UpdateSchoolModel
        {
            public string Name { get; set; }
           
        }
    }
}

using AutoMapper;
using System;
using System.Linq;
using UnluCo.Hafta2.Odev.DBOperations;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.CreateSchool
{
    public class CreateSchoolCommand
    {
        public CreateSchoolModel Model { get; set; }
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateSchoolCommand(ISchoolDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var school = _dbContext.Schools.SingleOrDefault(x => x.Name == Model.Name);
            if (school is not null)
                throw new InvalidOperationException("Okul Zaten Mevcut");
            school = _mapper.Map<School>(Model);

            _dbContext.Schools.Add(school);
            _dbContext.SaveChanges();

        }
        public class CreateSchoolModel
        {
            public string Name { get; set; }
        }
    }
}

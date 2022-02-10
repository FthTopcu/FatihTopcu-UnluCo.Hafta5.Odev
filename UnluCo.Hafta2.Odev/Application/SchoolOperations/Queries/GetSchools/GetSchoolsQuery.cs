using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UnluCo.Hafta2.Odev.DBOperations;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchools
{
    public class GetSchoolsQuery
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSchoolsQuery(ISchoolDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<SchoolsViewModel> Handle()
        {
            var schoolList = _dbContext.Schools.OrderBy(x => x.Name).ToList<School>();
            List<SchoolsViewModel> vm = _mapper.Map<List<SchoolsViewModel>>(schoolList);
            return vm;
        }
    }
    public class SchoolsViewModel
    {
        public string Name { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchoolDetail
{
    public class GetSchoolDetailQuery
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly IMapper _mapper;
        public int SchoolId;
        public GetSchoolDetailQuery(IMapper mapper, ISchoolDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public SchoolDetailViewModel Handle()
        {
            var School = _dbContext.Schools.Where(school => school.Id == SchoolId).SingleOrDefault();
            if (School is null)
                throw new InvalidOperationException("Okul Mevcut Değil");
            SchoolDetailViewModel vm = _mapper.Map<SchoolDetailViewModel>(School);
            return vm;
        }
    }
    public class SchoolDetailViewModel
    {
        public string Name { get; set; }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchoolDetail;
using UnluCo.Hafta2.Odev.Application.SchoolOperations.Queries.GetSchools;
using UnluCo.Hafta2.Odev.Application.StudentOperations.Queries.GetStudentDetail;
using UnluCo.Hafta2.Odev.Application.StydentOperations.Queries.GetStudents;
using UnluCo.Hafta2.Odev.Entities;
using static UnluCo.Hafta2.Odev.Application.SchoolOperations.Commands.CreateSchool.CreateSchoolCommand;
using static UnluCo.Hafta2.Odev.Application.StudentOperations.Commands.CreateStudent.CreateStudentCommand;

namespace UnluCo.Hafta2.Odev.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, StudentsViewModel>().ForMember(destination => destination.School, opt => opt.MapFrom(src => src.School.Name));
            CreateMap<Student, StudentDetailViewModel>().ForMember(destination => destination.School, opt => opt.MapFrom(src => src.School.Name));

            CreateMap<CreateSchoolModel, School>();
            CreateMap<School, SchoolsViewModel>();
            CreateMap<School, SchoolDetailViewModel>();
        }
    }
}

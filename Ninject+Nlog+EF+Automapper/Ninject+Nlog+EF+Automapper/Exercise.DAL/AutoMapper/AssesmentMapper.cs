using AutoMapper;
using Exercise.DAL.DomainDTO;
using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL.AutoMapper
{
    public class AssesmentMapper : Profile
    {
        public AssesmentMapper()
        {
            CreateMap<Assesment, AssessmentDAO>();
            CreateMap<AssessmentDAO, Assesment>(); 
        }
    }
}

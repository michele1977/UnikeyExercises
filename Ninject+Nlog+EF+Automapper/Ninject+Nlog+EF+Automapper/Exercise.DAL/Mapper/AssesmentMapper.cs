using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.DAL.DAO;
using Exercise.Domain;

namespace Exercise.DAL.Mapper
{
    public class AssesmentMapper : Profile
    {
        public AssesmentMapper()
        {
            CreateMap<AssesmentDao, Assesment>();
            CreateMap<Assesment, AssesmentDao>();
        }
    }
}

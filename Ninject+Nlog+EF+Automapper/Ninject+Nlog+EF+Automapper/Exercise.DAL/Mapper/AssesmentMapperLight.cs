using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.DAO;
using Exercise.Domain;

namespace Exercise.DAL.Mapper
{
    public class AssesmentMapperLight : Profile
    {
        public AssesmentMapperLight()
        {
            CreateMap<AssesmentDao, Assesment>().ForMember(a => a.Questions, ad => ad.Ignore());
            CreateMap<Assesment, AssesmentDao>().ForMember(ad => ad.Questions, a => a.Ignore());
        }
    }
}

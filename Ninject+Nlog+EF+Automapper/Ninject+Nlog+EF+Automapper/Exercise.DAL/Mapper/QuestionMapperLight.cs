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
    public class QuestionMapperLight : Profile
    {
        public QuestionMapperLight()
        {
            CreateMap<QuestionDao, Question>().ForMember(q => q.Answers, qd => qd.Ignore());
            CreateMap<Question, QuestionDao>().ForMember(qd => qd.Answers, q => q.Ignore());
        }
    }
}

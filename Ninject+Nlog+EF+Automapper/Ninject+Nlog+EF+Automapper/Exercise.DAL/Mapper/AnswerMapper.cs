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
    public class AnswerMapper : Profile
    {
        public AnswerMapper()
        {
            CreateMap<AnswerDao, Answer>();
            CreateMap<Answer, AnswerDao>();
        }
    }
}

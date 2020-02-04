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
    public class QuestionMapper : Profile
    {
        public QuestionMapper()
        {
            CreateMap<Question, QuestionDAO>();
            CreateMap<QuestionDAO, Question>();
        }
    }
}

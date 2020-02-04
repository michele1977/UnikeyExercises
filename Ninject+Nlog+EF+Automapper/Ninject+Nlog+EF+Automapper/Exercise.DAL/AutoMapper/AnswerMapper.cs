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
    public class AnswerMapper : Profile
    {
        public AnswerMapper()
        {
            CreateMap<Answer, AnswerDAO>();
            CreateMap<AnswerDAO, Answer>();
        }
    }
}

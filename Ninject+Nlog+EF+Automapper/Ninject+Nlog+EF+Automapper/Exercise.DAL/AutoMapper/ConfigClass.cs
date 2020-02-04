using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL.AutoMapper
{
    public class ConfigClass
    {
        public MapperConfiguration Config { get; set; }
        public ConfigClass()
        {
            Config = new MapperConfiguration(
                cfg => 
                {
                    cfg.AddProfile(new AssesmentMapper());
                    cfg.AddProfile(new QuestionMapper());
                    cfg.AddProfile(new AnswerMapper());
                });
        }
    }
}

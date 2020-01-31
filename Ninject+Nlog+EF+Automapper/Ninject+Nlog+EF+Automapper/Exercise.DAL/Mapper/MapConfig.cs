using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Exercise.DAL.Mapper
{
    public class MapConfig
    {
        public IMapper Mapper { get; set; }

        public MapConfig()
        {
            Mapper = new AutoMapper.Mapper(Configure());
        }

        public MapConfig(IMapper mapper)
        {
            Mapper = mapper;
        }

        private static MapperConfiguration Configure()
        {
            var mapperConfig = new MapperConfiguration(cfg => 
                cfg.AddProfiles(new List<Profile>
                {
                    new AssesmentMapper(),
                    new QuestionMapper(),
                    new AnswerMapper()
                }));

            return mapperConfig;
        }

        private static MapperConfiguration ConfigureLight()
        {
            var mapperConfig = new MapperConfiguration(cfg => 
                cfg.AddProfiles(new List<Profile>
                {
                    new AssesmentMapperLight(),
                    new QuestionMapperLight()
                }));

            return mapperConfig;
        }
    }
}

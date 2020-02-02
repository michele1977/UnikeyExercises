using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.Enums;

namespace Exercise.DAL.Mapper
{
    public class MapConfig
    {
        public IMapper Mapper { get; set; }

        public MapConfig(ConfigTypeEnum configType)
        {
            switch (configType)
            {
                case ConfigTypeEnum.Heavy: 
                    Mapper = new AutoMapper.Mapper(Configure());
                    break;
                case ConfigTypeEnum.Light: 
                    Mapper = new AutoMapper.Mapper(ConfigureLight());
                    break;
                default:
                    Mapper = new AutoMapper.Mapper(ConfigureLight());
                    break;
            }
            
        }

        public MapConfig(IMapper mapper)
        {
            Mapper = mapper;
        }

        #region Configurations
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
        #endregion
    }
}

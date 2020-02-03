using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.DAO;
using Exercise.DAL.Enums;
using Exercise.Domain;

namespace Exercise.DAL.Mapper
{
    public class MapConfig
    {
        public IMapper Mapper { get; set; }
        

        public MapConfig(IMapper mapper)
        {
            Mapper = mapper;
        }

        public MapConfig()
        {
        }

        public static MapperConfiguration GetConfiguration(ConfigTypeEnum configType)
        {
            switch (configType)
            {
                case ConfigTypeEnum.Heavy:
                    return Configure();
                case ConfigTypeEnum.Light:
                    return ConfigureLight();
                default:
                    return ConfigureLight();
            }
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

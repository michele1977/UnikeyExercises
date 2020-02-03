using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.Enums;
using Ninject.Modules;

namespace Exercise.DAL.Mapper
{
    public class MapperBindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<MapperConfiguration>().ToConstant(MapConfig.GetConfiguration(ConfigTypeEnum.Heavy)).InSingletonScope();
            Kernel.Bind<IMapper>().ToMethod(ctx => new AutoMapper.Mapper(MapConfig.GetConfiguration(ConfigTypeEnum.Heavy), type => Kernel.GetType()));

        }
    }
}

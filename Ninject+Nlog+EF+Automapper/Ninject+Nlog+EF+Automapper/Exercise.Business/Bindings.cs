using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL;
using Exercise.DAL.Enums;
using Exercise.DAL.Mapper;
using Ninject.Modules;

namespace Exercise.Business
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMyService>().To<MyService>();
            Kernel.Bind<IMyRepository>().To<MyRepository>();
            //Kernel.Bind<IMapper>().ToMethod(ctx => new Mapper());
        }
    }
}

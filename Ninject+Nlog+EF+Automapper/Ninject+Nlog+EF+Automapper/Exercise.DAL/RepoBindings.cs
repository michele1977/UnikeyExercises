using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.Enums;
using Exercise.DAL.Mapper;
using Ninject.Modules;

namespace Exercise.DAL
{
    public class RepoBindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMyRepository>().To<MyRepository>();
        }
    }
}

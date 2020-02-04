﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMyRepository>().To<Repository>();
        }
    }
}

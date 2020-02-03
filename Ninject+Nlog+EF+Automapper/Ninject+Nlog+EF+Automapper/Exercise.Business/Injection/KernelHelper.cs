using System.Collections.Generic;
using Exercise.DAL;
using Exercise.DAL.Mapper;
using Ninject;
using Ninject.Modules;

namespace Exercise.Business.Injection
{
    public static class KernelHelper
    {
        public static IKernel Initialize(IKernel kernel)
        {
            kernel.Load(new List<INinjectModule>
            {
                new ServiceBindings(),
                new RepoBindings(),
                new MapperBindings()
            });
            return kernel;
        }
        public static void Initialize(IKernel Kernel, KernelTypeEnum kernelType)
        {
            switch (kernelType)
            {
                case KernelTypeEnum.Repo:
                    Kernel.Load(new List<INinjectModule>
                    {
                        new RepoBindings(),
                        new MapperBindings()
                    });
                    break;
                case KernelTypeEnum.Service:
                    Kernel.Load(new List<INinjectModule>
                    {
                        new ServiceBindings(),
                        new RepoBindings(),
                        new MapperBindings()
                    });
                    break;
                case KernelTypeEnum.All:
                    Kernel.Load(new List<INinjectModule>
                    {
                        new ServiceBindings(),
                        new RepoBindings(),
                        new MapperBindings()
                    });
                    break;
                default:
                    Kernel.Load(new List<INinjectModule>
                    {
                        new MapperBindings()
                    });
                    break;
            }
        }


    }
}

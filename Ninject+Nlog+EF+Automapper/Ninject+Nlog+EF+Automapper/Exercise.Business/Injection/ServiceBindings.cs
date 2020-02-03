using Ninject;
using Ninject.Modules;

namespace Exercise.Business.Injection
{
    public class ServiceBindings : NinjectModule
    {
        public override void Load()
        {
            
            Kernel.Bind<IMyService>().To<MyService>();
        }
    }
}

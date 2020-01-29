using Ninject_Exercise.DAL;
using Ninject_Exercise.Domain;

namespace Ninject_Exercise.Business
{
    public class MyService
    {
      
        MyRepository Repo = new MyRepository();
        public void Create(DomainObject objectToInsert)
        {

            Repo.Create(objectToInsert);
        }
        public DomainObject Read(int id)
        {
            return Repo.Read(id);
        }
        public void Update(DomainObject objectToUpdate)
        {
            Repo.Update(objectToUpdate);
        }
        public void Delete(int id)
        {
            Repo.Delete(id);
        }
    }
}

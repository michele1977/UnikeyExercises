using Exercise.DAL;
using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Business
{
    public class MyService
    {
        private readonly IMyRepository Repository;
        public MyService(IMyRepository repo)
        {
            Repository = repo;
        }

        public void Create(Assesment assestment)
        {
            Repository.Create(assestment);
        }
        public Assesment Read(int id)
        {
            return Repository.Read(id);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public List<Assesment> GetTestList(string text)
        {
            return Repository.GetTestList(text);
        }
    }
}

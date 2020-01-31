using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.DAL;
using Exercise.DAL.DAO;
using Exercise.DAL.Mapper;

namespace Exercise.Business
{
    public class MyService : IMyService
    {
        public IMyRepository Repo { get; set; }

        public MyService(){}

        public MyService(IMyRepository repo)
        {
            Repo = repo;
        }

        public void Create(Assesment assesment)
        {
            Repo.Create(assesment);
        }

        public Assesment Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Assesment assesment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Assesment> GetTestList(string text)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class MyService
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
    }
}

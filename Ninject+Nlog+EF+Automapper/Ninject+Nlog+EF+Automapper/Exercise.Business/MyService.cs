using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL;
using Exercise.DAL.DAO;
using Exercise.DAL.Enums;
using Exercise.DAL.Mapper;
using Ninject;

namespace Exercise.Business
{
    public class MyService : IMyService
    {
        public IMyRepository Repo { get; set; }
        public IKernel Kernel { get; set; }
        public IMapper Mapper { get; set; }

        public MyService(){}
        public MyService(IMyRepository repo, IKernel kernel, IMapper mapper)
        {
            Repo = repo;
            Kernel = kernel;
            Mapper = mapper;
        }

        public void Create(Assesment assesment)
        {
            Repo.Create(assesment);
        }

        public Assesment Read(int id)
        {
            var assesmentDao = Repo.Read(id);
            var assesment = Mapper.Map<Assesment>(assesmentDao);
            return assesment;
        }

        public void Update(Assesment assesment)
        {
            Repo.Update(assesment);
        }

        public void Delete(int id)
        {
            Repo.Delete(id);
        }

        public List<Assesment> GetTestList(string text)
        {
            throw new NotImplementedException();
        }
    }
}

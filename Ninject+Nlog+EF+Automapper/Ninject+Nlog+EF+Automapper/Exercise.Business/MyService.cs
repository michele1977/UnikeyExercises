using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Business.Injection;
using Exercise.Common;
using Exercise.Common.Exceptions;
using Exercise.DAL;
using Exercise.DAL.DAO;
using Exercise.DAL.Enums;
using Exercise.DAL.Mapper;
using Ninject;
using Ninject.Modules;

namespace Exercise.Business
{
    public class MyService : IMyService
    {
        public IKernel Kernel { get; set; }
        public IMapper Mapper { get; set; }
        public IMyRepository Repo { get; set; }

        public MyService(IKernel kernel, IMapper mapper, IMyRepository repo)
        {
            Kernel = kernel;
            Repo = repo;
            Mapper = mapper;
        }
        
        public void Create(Assesment assesment)
        {
            try
            {
                Repo.Create(assesment);
                throw new CustomException("Test NLog");
            }
            catch (CustomException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (SqlException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (AutoMapperConfigurationException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (AutoMapperMappingException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (InvalidOperationException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            catch (Exception e)
            {
                MyLogger.Logger.Fatal(e, e.Message);
                throw;
            }
            
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

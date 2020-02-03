using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.DAL.DAO;
using Exercise.Domain;
using Dapper;
using Exercise.DAL.Mapper;
using System.Configuration;
using Exercise.DAL.Enums;
using Exercise.DAL.Helpers;
using Ninject;
using Ninject.Modules;

namespace Exercise.DAL
{
    public class MyRepository : IMyRepository
    {
        public IKernel Kernel { get; set; }
        public IMapper Mapper { get; set; }
        public MyRepository(IKernel kernel, IMapper mapper)
        {
            Kernel = kernel;
            Mapper = mapper;
        }
        public void Create(Assesment assesment)
        {
            var assesmentDao = Mapper.Map<AssesmentDao>(assesment);
            AssesmentHelper.Create(assesmentDao);
        }

        public AssesmentDao Read(int id)
        {
            var assesmentDao = AssesmentHelper.Read(id);
            return assesmentDao;
        }

        public void Update(Assesment assesment)
        {
            var assesmentDaoUpdated = Mapper.Map<AssesmentDao>(assesment);
            AssesmentHelper.Update(assesmentDaoUpdated);
        }

        public void Delete(int id)
        {
            AssesmentHelper.Delete(id);
        }

        // TODO non ho capito a cosa serve il metodo GetTestList
        public List<AssesmentDao> GetTestList(string text)
        {
            var assesmentList = new List<AssesmentDao>();

            //using (var connection =
            //    new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            //{
            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT * FROM [dbo].[Assesment]";
            //        var data = command.ExecuteReader();

            //        while (data.Read())
            //        {
            //            assesmentList.Add(CreateAssesmentDao(data));
            //        }
            //    }
            //}

            return assesmentList;
        }

    }
}

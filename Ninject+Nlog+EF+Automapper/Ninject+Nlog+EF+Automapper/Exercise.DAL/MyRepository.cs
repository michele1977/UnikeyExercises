using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Exercise.Domain;

namespace Exercise.DAL
{
    public class MyRepository : IMyRepository
    {
        private const string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ExerciseDB;Data Source=DESKTOP-UBDU9NK\SQLEXPRESS";

        public void Create(Assesment assestment)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InsertAssesment";
                    command.BeginExecuteNonQuery();
                };

                connection.Close();
            }
        }

        public Assesment Read(int id)
        {
            var assesment = new Assesment();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM [dbo].[Assesment] WHERE Id = {id}";
                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        assesment.Id = (int)data["Id"];
                        assesment.Title = (string) data["Title"];
                        assesment.CreationDate = (DateTime) data["CreationDate"];
                    }
                }

                connection.Close();
            }
            
            return assesment;
        }

        public void Update(Assesment assestment)
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

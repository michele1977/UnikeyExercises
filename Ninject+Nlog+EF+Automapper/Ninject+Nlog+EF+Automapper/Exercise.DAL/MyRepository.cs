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

namespace Exercise.DAL
{
    public class MyRepository : IMyRepository
    {
        public void Create(Assesment assesment)
        {
            var mapConfig = new MapConfig();
            var assesmentDao = mapConfig.Mapper.Map<AssesmentDao>(assesment);

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_InsertAssesment";

                    AddAssesmentParameters(command, assesmentDao);
                    var id = command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    var assesmentId = Convert.ToInt32(id.Value);

                    foreach (var q in assesmentDao.Questions)
                    {
                        command.CommandText = "sp_InsertQuestion";

                        AddQuestionParameters(command, q, assesmentId);

                        var qId = command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        });

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        command.CommandText = "sp_InsertAnswer";
                        var questionId = Convert.ToInt32(qId.Value);

                        foreach (var a in q.Answers)
                        {
                            AddAnswerParameters(command, a, questionId);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
        }

        #region AddParameters
        private static void AddAnswerParameters(SqlCommand command, AnswerDao answerDao, int questionId)
        {
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@APosition", answerDao.Position));
            command.Parameters.Add(new SqlParameter("@IsCorrect", answerDao.IsCorrect));
            command.Parameters.Add(new SqlParameter("@QuestionId", questionId));
            command.Parameters.Add(new SqlParameter("@AText", answerDao.AnswerText));
        }

        private static void AddQuestionParameters(SqlCommand command, QuestionDao questionDao, int assesmentId)
        {
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter(("@QuestionText"), questionDao.QuestionText));
            command.Parameters.Add(new SqlParameter("@Position", questionDao.Position));
            command.Parameters.Add(new SqlParameter("@AssesmentId", assesmentId));
        }

        private static void AddAssesmentParameters(SqlCommand command, AssesmentDao assesmentDao)
        {
            command.Parameters.Add(new SqlParameter("@Title", assesmentDao.Title));
            command.Parameters.Add(new SqlParameter("@CreationDate", assesmentDao.CreationDate));
        }
        #endregion

        public AssesmentDao Read(int id)
        {
            var assesmentDao = new AssesmentDao();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM [dbo].[Assesment] WHERE Id = {id}";
                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        assesmentDao.Id = (int)data["Id"];
                        assesmentDao.Title = (string) data["Title"];
                        assesmentDao.CreationDate = (DateTime) data["CreationDate"];
                        assesmentDao.Questions = new List<QuestionDao>();
                    }

                    command.CommandText = $"SELECT * FROM [dbo].[Question] WHERE AssesmentId = {assesmentDao.Id}";
                    var questionData = command.ExecuteReader();
                    while (questionData.Read())
                    {
                        assesmentDao.Questions.Add(
                            new QuestionDao
                            {
                                Id = (int)questionData["Id"],
                                QuestionText = (string)questionData["QuestionText"],
                                Position = (int)questionData["Position"],
                                Answers = new List<AnswerDao>()
                            });
                    }
                    
                    command.CommandText = $"SELECT * FROM [dbo].[Answer] WHERE QuestionId = {assesmentDao.Id}";
                    var answerData = command.ExecuteReader();
                    while (questionData.Read())
                    {
                        assesmentDao.Questions.Add(
                            new QuestionDao
                            {
                                Id = (int)questionData["Id"],
                                QuestionText = (string)questionData["QuestionText"],
                                Position = (int)questionData["Position"],
                                Answers = new List<AnswerDao>()
                            }
                        );
                    }


                }

                connection.Close();
            }
            
            return assesmentDao;
        }

        public void Update(Assesment assesment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AssesmentDao> GetTestList(string text)
        {
            throw new NotImplementedException();
        }
    }
}

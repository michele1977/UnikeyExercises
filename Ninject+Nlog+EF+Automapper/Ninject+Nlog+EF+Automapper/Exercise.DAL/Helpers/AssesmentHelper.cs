using Exercise.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.DAL.Enums;

namespace Exercise.DAL.Helpers
{
    public static class AssesmentHelper
    {
        public static void Create(AssesmentDao assesmentDao)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var assesmentId = InsertAssesment(assesmentDao, command, connection);
                    InsertQuestion(assesmentDao, command, assesmentId, connection);
                }
            }
        }
        #region Insert
        private static void InsertQuestion(AssesmentDao assesmentDao, SqlCommand command, IDataParameter assesmentId,
            IDbConnection connection)
        {
            foreach (var q in assesmentDao.Questions)
            {
                command.CommandText = "sp_InsertQuestion";
                AddQuestionParameters(command, q, Convert.ToInt32(assesmentId.Value));
                var questionId = command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                });
                ExecuteNonQuery(connection, command);

                InsertAnswer(command, connection, q, questionId);
            }
        }

        private static void InsertAnswer(SqlCommand command, IDbConnection connection, QuestionDao q, SqlParameter questionId)
        {
            command.CommandText = "sp_InsertAnswer";
            foreach (var a in q.Answers)
            {
                AddAnswerParameters(command, a, (int) questionId.Value);
                ExecuteNonQuery(connection, command);
            }
        }

        private static SqlParameter InsertAssesment(AssesmentDao assesmentDao, SqlCommand command, IDbConnection connection)
        {
            command.CommandText = "sp_InsertAssesment";

            AddAssesmentParameters(command, assesmentDao);
            var id = command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            });
            ExecuteNonQuery(connection, command);
            return id;
        }
        #endregion
        #region AddParameters
        private static void AddAnswerParameters(SqlCommand command, AnswerDao answerDao, int questionId)
        {
            command.Parameters.Clear();
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@APosition", answerDao.Position),
                new SqlParameter("@IsCorrect", answerDao.IsCorrect),
                new SqlParameter("@QuestionId", questionId),
                new SqlParameter("@AText", answerDao.AnswerText)
            });
        }

        private static void AddQuestionParameters(SqlCommand command, QuestionDao questionDao, int assesmentId)
        {
            command.Parameters.Clear();
            command.Parameters.AddRange(new[]
            {
                new SqlParameter(("@QuestionText"), questionDao.QuestionText),
                new SqlParameter("@Position", questionDao.Position),
                new SqlParameter("@AssesmentId", assesmentId)
            });
        }

        private static void AddAssesmentParameters(SqlCommand command, AssesmentDao assesmentDao)
        {
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@Title", assesmentDao.Title),
                new SqlParameter("@CreationDate", assesmentDao.CreationDate)
            });
        }
        #endregion
        

        public static AssesmentDao Read(int id)
        {
            var assesmentDao = new AssesmentDao();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM [dbo].[Assesment] WHERE Id = {id}";
                    assesmentDao = ReadAssesment(command, assesmentDao, connection);
                }
            }

            return assesmentDao;
        }
        #region Read
        private static AssesmentDao ReadAssesment(SqlCommand command, AssesmentDao assesmentDao, SqlConnection connection)
        {
            connection.Open();
            var data = command.ExecuteReader();

            if (!data.Read()) 
                return assesmentDao;

            assesmentDao = CreateAssesmentDao(data, connection);
            command.CommandText = $"SELECT * FROM [dbo].[Question] WHERE AssesmentId = {assesmentDao.Id}";
            ReadQuestion(command, assesmentDao, connection);

            return assesmentDao;
        }

        private static void ReadQuestion(SqlCommand command, AssesmentDao assesmentDao, SqlConnection connection)
        {
            connection.Open();
            var questionData = command.ExecuteReader();
            while (questionData.Read())
            {
                var question = CreateQuestionDao(questionData);
                assesmentDao.Questions.Add(question);
                ReadAnswer(assesmentDao, connection, question);
            }
        }

        private static void ReadAnswer(AssesmentDao assesmentDao, SqlConnection connection, QuestionDao question)
        {
            var command2 = connection.CreateCommand();
            command2.CommandText = $"SELECT * FROM [dbo].[Answer] WHERE QuestionId = {question.Id}";
            var answerData = command2.ExecuteReader();

            while (answerData.Read())
            {
                foreach (var q in assesmentDao.Questions)
                {
                    q.Answers.Add(CreateAnswerDao(answerData));
                }
            }
        }
        #endregion
        #region CreateDao
        private static AnswerDao CreateAnswerDao(IDataRecord answerData)
        {
            var answerDao = new AnswerDao
            {
                Id = (int) answerData["Id"],
                AnswerText = (string) answerData["AnswerText"],
                Position = (int) answerData["Position"],
                IsCorrect = (AnswerDaoType) ((byte) answerData["IsCorrect"])
            };
            return answerDao;
        }

        private static QuestionDao CreateQuestionDao(IDataRecord questionData)
        {
            var question = new QuestionDao
            {
                Id = (int) questionData["Id"],
                QuestionText = (string) questionData["QuestionText"],
                Position = (int) questionData["Position"],
                Answers = new List<AnswerDao>()
            };
            return question;
        }

        private static AssesmentDao CreateAssesmentDao(IDataRecord data, IDbConnection connection)
        {
            var assesmentDao = new AssesmentDao
            {
                Id = (int) data["Id"],
                Title = (string) data["Title"],
                CreationDate = (DateTime) data["CreationDate"],
                Questions = new List<QuestionDao>()
            };
            connection.Close();
            return assesmentDao;
        }
        #endregion

        private static void ExecuteNonQuery(IDbConnection connection, IDbCommand command)
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Update(AssesmentDao assesmentDaoUpdated)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    UpdateAssesment(assesmentDaoUpdated, command);
                    ExecuteNonQuery(connection, command);

                    UpdateQuestion(assesmentDaoUpdated, command);
                    ExecuteNonQuery(connection, command);

                    UpdateAnswer(assesmentDaoUpdated, command);
                    ExecuteNonQuery(connection, command);
                }
            }
        }
        #region Update
        private static void UpdateAnswer(AssesmentDao assesmentDaoUpdated, SqlCommand command)
        {
            command.CommandText = "sp_UpdateAnswer";
            foreach (var answerDao in assesmentDaoUpdated.Questions.SelectMany(q => q.Answers))
            {
                command.Parameters.Clear();
                command.Parameters.AddRange(new[]
                {
                    new SqlParameter("@Id", answerDao.Id),
                    new SqlParameter("@AnswerText", answerDao.AnswerText),
                    new SqlParameter("@Position", answerDao.Position),
                    new SqlParameter("@IsCorrect", answerDao.IsCorrect)
                });
            }
        }

        private static void UpdateQuestion(AssesmentDao assesmentDaoUpdated, SqlCommand command)
        {
            command.CommandText = "sp_UpdateQuestion";
            foreach (var questionDao in assesmentDaoUpdated.Questions)
            {
                command.Parameters.Clear();
                command.Parameters.AddRange(new[]
                {
                    new SqlParameter("@Id", questionDao.Id),
                    new SqlParameter("@QuestionText", questionDao.QuestionText),
                    new SqlParameter("@Position", questionDao.Position)
                });
            }
        }

        private static void UpdateAssesment(AssesmentDao assesmentDaoUpdated, SqlCommand command)
        {
            command.CommandText = "sp_UpdateAssesment";
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@Id", assesmentDaoUpdated.Id),
                new SqlParameter("@Title", assesmentDaoUpdated.Title),
                new SqlParameter("@CreationDate", assesmentDaoUpdated.CreationDate)
            });
        }
        #endregion

        public static void Delete(int id)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["ExerciseDB"].ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DeleteAssesment";
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    ExecuteNonQuery(connection, command);
                }
            }
        }
    }
}

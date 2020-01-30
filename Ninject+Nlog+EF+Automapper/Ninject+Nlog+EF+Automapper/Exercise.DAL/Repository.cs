using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL
{
    public class Repository : IMyRepository
    {
        private readonly string ConnectionString = "Data Source=DESKTOP-82C0LNT\\SQLEXPRESS;Initial Catalog=Assesment_Excercise;Integrated Security=true";
        public void Create(Assesment assestment)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                 using(SqlCommand command = new SqlCommand("InsertAssessment", connection))
                 {
                    int assesmentId;
                    int questionId;
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(new[] {
                        new SqlParameter("@AssessmentTitle", assestment.Title),
                        new SqlParameter("@AssessmentCreationDate", assestment.CreationDate)
                    });

                    SqlParameter returnedAssessmentId = command.Parameters.Add("@AssesmentId", SqlDbType.Int);
                    returnedAssessmentId.Direction = ParameterDirection.Output;

                    command.ExecuteReader();

                    assesmentId = (int)command.Parameters["@AssesmentId"].Value;

                    command.CommandText = "InsertQuestion";
                    foreach(var question in assestment.Questions)
                    {
                        command.Parameters.AddRange(new[] {
                            new SqlParameter("@QuestionText", question.QuestionText),
                            new SqlParameter("@Psition", question.Position),
                            new SqlParameter("@AssesmentId", assesmentId)
                        });
                        SqlParameter returnedQuestionId = command.Parameters.Add("@QuestionId", SqlDbType.Int);
                        returnedQuestionId.Direction = ParameterDirection.Output;

                        command.ExecuteReader();

                        questionId = (int)command.Parameters["@QuestionId"].Value;

                        command.CommandText = "InsertAnswer";
                        foreach (var answer in question.Answers)
                        {
                            command.Parameters.AddRange(new[] {
                                new SqlParameter("@AnswerText", answer.AnswerText),
                                new SqlParameter("@Psition", answer.Position),
                                new SqlParameter("@IsCorrect", answer.IsCorrect),
                                new SqlParameter("@QuestionId", questionId)
                            });

                            command.ExecuteReader();
                        }
                    }
                 }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteAssessment", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteReader();
                }
            }
        }

        public List<Assesment> GetTestList(string text)
        {
            List<Assesment> assesments = new List<Assesment>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetTestsList", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Text", text);

                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        assesments.Add(new Assesment() 
                        {
                            Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title")),
                            CreationDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("CreationDate"))
                        });
                    }

                    return assesments;
                }
            }
        }

        public Assesment Read(int id)
        {
            Assesment assesment = new Assesment();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ReadAssessment", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        assesment.Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title"));
                        assesment.CreationDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("CreationDate"));
                    }

                    return assesment;
                }
            }
        }

        public void Update(Assesment assestment)
        {
            throw new NotImplementedException();
        }
    }
}

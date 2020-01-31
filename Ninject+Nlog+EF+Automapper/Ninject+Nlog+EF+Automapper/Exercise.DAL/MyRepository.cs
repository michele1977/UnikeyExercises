using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Domain;
using Exercise.Dto;

namespace Exercise.DAL
{
    public class MyRepository
    {
        static string Esercizio =
            "Data Source=(local);Initial Catalog=Exercises;"
            + "Integrated Security=true";
        private static void AddAssestParameters(SqlCommand sqlcommand, Assestment assestment)
        {
            sqlcommand.Parameters.AddWithValue("@Title", assestment.Title);
            sqlcommand.Parameters.AddWithValue("CreationDate", assestment.CreationDate);
            var id = new SqlParameter("@Id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            sqlcommand.Parameters.AddWithValue("@Id", id);
        }
        private void AddAnswerParameters(SqlCommand sqlcommand, Answer answer)
        {
            sqlcommand.Parameters.AddWithValue("@AnswerText", answer.AnswerText);
            sqlcommand.Parameters.AddWithValue("@Position", answer.Position);
            var questionid = new SqlParameter("@QuestionId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            sqlcommand.Parameters.AddWithValue("@QuestionId", questionid);
        }
        private void AddQuestionParameters(SqlCommand sqlcommand, Question question)
        {
            sqlcommand.Parameters.AddWithValue("@QuestionText", question.QuestionText);
            sqlcommand.Parameters.AddWithValue("@Position", question.Position);
            var assestid = new SqlParameter("@AssestId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            sqlcommand.Parameters.AddWithValue("@AssestId", assestid);
        }

        public void Create(Assestment newAssestment)
            {
                string createAssesment = "AddAssestment";
                string createQuestions = "AddQuestion";
                string createAnswer = "AddAnswer";

                var assestment = newAssestment;

                using (SqlConnection con =
                new SqlConnection(Esercizio))
                {
                    using (SqlCommand sqlcommand = new SqlCommand(createAssesment, con))
                    {
                        con.Open();

                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.Parameters.Add(new SqlParameter("@Title", assestment.Title));
                        sqlcommand.Parameters.Add(new SqlParameter("@CreationDate", assestment.CreationDate));
                        var ID = sqlcommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        });
                        sqlcommand.ExecuteNonQuery();
                        assestment.Id = Convert.ToInt32(ID); 

                        foreach (var q in assestment.Questions)
                        {
                            sqlcommand.CommandText = createQuestions;
                            sqlcommand.Parameters.Clear();
                            sqlcommand.Parameters.Add(new SqlParameter("@Position", q.Position));
                            sqlcommand.Parameters.Add(new SqlParameter("@AssestId", ID));
                            sqlcommand.Parameters.Add(new SqlParameter("@QuestionText", q.QuestionText));
                            var QID = sqlcommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            });
                            sqlcommand.ExecuteNonQuery();
                            sqlcommand.CommandText = createAnswer;
                            var questionID = Convert.ToInt32(QID.Value);

                            foreach (var a in q.Answers)
                            {
                                sqlcommand.Parameters.Clear();
                                sqlcommand.Parameters.Add(new SqlParameter("@Position", a.Position));
                                sqlcommand.Parameters.Add(new SqlParameter("@IsCorrect", a.IsCorrect));
                                sqlcommand.Parameters.Add(new SqlParameter("@QuestionId", questionID));
                                sqlcommand.Parameters.Add(new SqlParameter("@AnswerText", a.AnswerText));
                                sqlcommand.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }

        //public List<AssestmentDto> ReadAll()
        //{
        //    List<AssestmentDto> assestments = new List<AssestmentDto>();
        //    using (SqlConnection connection = new SqlConnection(Esercizio))
        //    {
        //        SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Assestment", connection);
        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = sqlcommand.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                assestments.Add(new AssestmentDto((reader["Title"].ToString(),
        //                    (DateTime) reader["CreationDate"],
        //                    reader["Answers"]new quest
        //                    {

        //                    })));
        //            }
        //            reader.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return assestments;
        //}

        //public Assestment Read(int id)
        //{

        //}
        //public void Delete()
        //{
            
        //}
    }
}

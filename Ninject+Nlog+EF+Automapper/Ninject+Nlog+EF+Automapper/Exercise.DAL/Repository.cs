using AutoMapper;
using Exercise.DAL.AutoMapper;
using Exercise.DAL.DomainDTO;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Ninject;
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
        readonly IMapper Mapper;
        public Repository(IMapper mapper)
        {
            Mapper = mapper;
        }
        private readonly string ConnectionString = "Data Source=DESKTOP-82C0LNT\\SQLEXPRESS;Initial Catalog=Assesment_Excercise;Integrated Security=true;MultipleActiveResultSets=true";
        public void Create(Assesment assestment)
        {            
            var assessmentDAO = Mapper.Map<Assesment, AssessmentDAO>(assestment);
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int assesmentId = InsertAssessment(connection, assessmentDAO);

                foreach(var questionDAO in assessmentDAO.Questions)
                {
                    InsertQuestion(connection, questionDAO, assesmentId);
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
            List<Assesment> assessments = new List<Assesment>();
            List<AssessmentDAO> assesmentsDAO = new List<AssessmentDAO>();
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
                        assesmentsDAO.Add(new AssessmentDAO() 
                        {
                            Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title")),
                            CreationDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("CreationDate"))
                        });
                    }

                    foreach(var assessmentDAO in assesmentsDAO)
                    {
                        assessments.Add(Mapper.Map<AssessmentDAO, Assesment>(assessmentDAO));
                    }

                    return assessments;
                }
            }
        }

        public Assesment Read(int id)
        {
            AssessmentDAO assessmentDAO = new AssessmentDAO();
            Assesment assessment = new Assesment();
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
                        assessmentDAO.Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title"));
                        assessmentDAO.CreationDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("CreationDate"));
                        assessmentDAO.Questions = ReadQuestions(connection, id);
                    }

                    assessment = Mapper.Map<AssessmentDAO, Assesment>(assessmentDAO);

                    return assessment;
                }
            }
        }

        private List<QuestionDAO> ReadQuestions(SqlConnection connection, int assessmentId)
        {
            List<QuestionDAO> questions = new List<QuestionDAO>();
            using(SqlCommand command = new SqlCommand("ReadQuestions", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AssessmentId", assessmentId);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    questions.Add(new QuestionDAO()
                    {
                        QuestionText = reader.GetFieldValue<string>(reader.GetOrdinal("QuestionText")),
                        Position = reader.GetFieldValue<int>(reader.GetOrdinal("Position")),
                        Answers = ReadAnswers(connection, reader.GetFieldValue<int>(reader.GetOrdinal("Id")))
                    });
                }

                return questions;
            }
        }

        private List<AnswerDAO> ReadAnswers(SqlConnection connection, int questionId)
        {
            List<AnswerDAO> answers = new List<AnswerDAO>();
            using (SqlCommand command = new SqlCommand("ReadAnswers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@QuestionId", questionId);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    answers.Add(new AnswerDAO()
                    {
                        AnswerText = reader.GetFieldValue<string>(reader.GetOrdinal("AnswerText")),
                        Position = reader.GetFieldValue<int>(reader.GetOrdinal("Position")),
                        IsCorrect = (AnswerType)reader.GetFieldValue<byte>(reader.GetOrdinal("IsCorrect"))
                    });
                }

                return answers;
            }
        }

        public void Update(Assesment assestment)
        {
            throw new NotImplementedException();
        }

        private int InsertAssessment(SqlConnection connection, AssessmentDAO assessmentDAO)
        {
            using (SqlCommand command = new SqlCommand("InsertAssessment", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(new[] {
                        new SqlParameter("@AssessmentTitle", assessmentDAO.Title),
                        new SqlParameter("@AssessmentCreationDate", assessmentDAO.CreationDate)
                    });

                SqlParameter returnedAssessmentId = command.Parameters.Add("@AssesmentId", SqlDbType.Int);
                returnedAssessmentId.Direction = ParameterDirection.Output;

                command.ExecuteReader();

                return (int)command.Parameters["@AssesmentId"].Value;
            }
        }

        private void InsertQuestion(SqlConnection connection, QuestionDAO questionDAO, int assessmentId)
        {
            int questionId;
            using (SqlCommand command = new SqlCommand("InsertQuestion", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(new[] {
                        new SqlParameter("@QuestionText", questionDAO.QuestionText),
                        new SqlParameter("@Position", questionDAO.Position),
                        new SqlParameter("@AssessmentId", assessmentId)
                    });
                SqlParameter returnedQuestionId = command.Parameters.Add("@QuestionId", SqlDbType.Int);
                returnedQuestionId.Direction = ParameterDirection.Output;

                command.ExecuteReader();

                questionId = (int)command.Parameters["@QuestionId"].Value;

                foreach (var answerDAO in questionDAO.Answers)
                {
                    InsertAnswer(answerDAO, connection, questionId);
                }
            }
        }

        private void InsertAnswer(AnswerDAO answerDAO, SqlConnection connection, int questionId)
        {
            using (SqlCommand command = new SqlCommand("InsertAnswer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(new[] {
                            new SqlParameter("@AnswerText", answerDAO.AnswerText),
                            new SqlParameter("@Position", answerDAO.Position),
                            new SqlParameter("@IsCorrect", answerDAO.IsCorrect),
                            new SqlParameter("@QuestionId", questionId)
                });

                command.ExecuteReader();
            }
        }
    }
}

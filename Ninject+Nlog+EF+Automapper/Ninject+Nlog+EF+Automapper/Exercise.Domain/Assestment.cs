using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class Assestment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Question> Questions;

        public Assestment(int Id, string Title, DateTime creationDate)
        {
            this.Id = Id;
            this.Title = Title;
            this.CreationDate = creationDate;
            this.Questions = new List<Question>()
            {
                new Question(3, "domanda 3", 1, 1)
                {
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 1,
                            AnswerText = "Risposta 1",
                            Position = 1,
                            QuestionId = 1,
                            //IsCorrect = Enums.AnswerType.Correct
                        },
                        new Answer()
                        {
                            Id = 2,
                            AnswerText = "Risposta 2",
                            Position = 2,
                            QuestionId = 1,
                            //IsCorrect = Enums.AnswerType.NotCorrect
                        },
                        new Answer()
                        {
                            Id = 3,
                            AnswerText = "Risposta 3",
                            Position = 3,
                            QuestionId = 1,
                            //IsCorrect = Enums.AnswerType.NotCorrect
                        },
                        new Answer()
                        {
                            Id = 4,
                            AnswerText = "Risposta 4",
                            Position = 4,
                            QuestionId = 1,
                            //IsCorrect = Enums.AnswerType.NotCorrect
                        }

                    }
                },
                new Question(4, "domanda 4", 2, 1)
                {
                Id = 4,
                QuestionText = "Domanda 4",
                Position = 2,
                AssestId = 1,
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Id = 1,
                        AnswerText = "Risposta 1",
                        Position = 1,
                        QuestionId = 1,
                        //IsCorrect = Enums.AnswerType.Correct
                    },
                    new Answer()
                    {
                        Id = 2,
                        AnswerText = "Risposta 2",
                        Position = 2,
                        QuestionId = 1,
                        //IsCorrect = Enums.AnswerType.NotCorrect
                    },
                    new Answer()
                    {
                        Id = 3,
                        AnswerText = "Risposta 3",
                        Position = 3,
                        QuestionId = 1,
                        //IsCorrect = Enums.AnswerType.NotCorrect
                    },
                    new Answer()
                    {
                        Id = 4,
                        AnswerText = "Risposta 4",
                        Position = 4,
                        QuestionId = 1,
                        //IsCorrect = Enums.AnswerType.NotCorrect
                    }

                }
            }

            };
        }

    }
}

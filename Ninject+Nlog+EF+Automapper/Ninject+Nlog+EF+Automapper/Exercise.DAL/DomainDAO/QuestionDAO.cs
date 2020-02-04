using System.Collections.Generic;

namespace Exercise.DAL.DomainDTO
{
    public class QuestionDAO
    {
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public List<AnswerDAO> Answers;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public int AssestId { get; set; }
        public List<Answer> Answers;

        public Question(int id, string questionText, int position, int assestId)
        {
            this.Id = id;
            this.QuestionText = questionText;
            this.Position = position;
            this.AssestId = assestId;
            this.Answers = new List<Answer>();
        }
    }
}

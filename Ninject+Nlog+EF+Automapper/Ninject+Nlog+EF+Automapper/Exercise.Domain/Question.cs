using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class Question
    {
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public List<Answer> Answers;

    }
}

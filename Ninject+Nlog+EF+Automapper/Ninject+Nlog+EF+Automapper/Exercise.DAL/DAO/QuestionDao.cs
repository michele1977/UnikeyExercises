using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL.DAO
{
    public class QuestionDao
    {
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public List<AnswerDao> Answers;
    }
}

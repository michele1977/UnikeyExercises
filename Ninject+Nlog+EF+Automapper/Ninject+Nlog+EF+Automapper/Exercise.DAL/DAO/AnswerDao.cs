using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.DAL.Enums;

namespace Exercise.DAL.DAO
{
    public class AnswerDao
    {
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public AnswerDaoType IsCorrect { get; set; }
    }
}

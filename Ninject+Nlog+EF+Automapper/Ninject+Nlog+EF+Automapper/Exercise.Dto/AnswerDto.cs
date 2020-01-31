using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Domain.Enums;

namespace Exercise.Dto
{
    public class AnswerDto
    {
        public AnswerDto(Answer answer)
        {
            this.AnswerText = answer.AnswerText;
            this.Position = answer.Position;
            this.QuestionId = answer.QuestionId;
            this.IsCorrect = answer.IsCorrect;
        }
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public int QuestionId { get; set; }
        public AnswerType IsCorrect { get; set; }
    }
}

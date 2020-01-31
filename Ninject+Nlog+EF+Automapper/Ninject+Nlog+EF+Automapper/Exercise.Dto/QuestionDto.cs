using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Domain;

namespace Exercise.Dto
{
    class QuestionDto
    {
        public QuestionDto(Question question)
        {
            this.QuestionText = question.QuestionText;
            this.Position = question.Position;
            this.AssestId = question.AssestId;
            this.Answers = question.Answers.Select(a => new AnswerDto(a)).ToList();
        }
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public int AssestId { get; set; }

        public List<AnswerDto> Answers { get; set; }
    }
}

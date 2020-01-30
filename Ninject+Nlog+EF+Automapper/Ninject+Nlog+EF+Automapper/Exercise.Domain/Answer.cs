using Exercise.Domain.Enums;

namespace Exercise.Domain
{
    public class Answer
    {
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public AnswerType IsCorrect { get; set; }
    }
}

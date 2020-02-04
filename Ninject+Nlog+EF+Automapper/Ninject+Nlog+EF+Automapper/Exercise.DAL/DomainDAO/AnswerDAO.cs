using Exercise.Domain.Enums;

namespace Exercise.DAL.DomainDTO
{
    public class AnswerDAO
    {
        public string AnswerText { get; set; }
        public int Position { get; set; }
        public AnswerType IsCorrect { get; set; }
    }
}
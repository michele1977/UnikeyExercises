using Exercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Dto
{
    class AssestmentDto
    {
        public AssestmentDto(Assestment assestment)
        {
            this.Title = assestment.Title;
            this.CreationDate = assestment.CreationDate;
            this.Questions = assestment.Questions.Select(a => new QuestionDto(a)).ToList();
        }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}

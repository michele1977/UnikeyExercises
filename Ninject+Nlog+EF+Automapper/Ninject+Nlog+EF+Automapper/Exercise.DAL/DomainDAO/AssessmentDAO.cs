using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.DAL.DomainDTO
{
    public class AssessmentDAO
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public List<QuestionDAO> Questions;
    }
}

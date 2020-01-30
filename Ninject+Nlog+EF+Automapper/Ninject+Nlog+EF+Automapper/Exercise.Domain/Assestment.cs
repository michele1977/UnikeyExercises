using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain
{
    public class Assesment
    {
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Question> Questions;

    }
}

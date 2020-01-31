using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Domain;

namespace Exercise.Business
{
    public interface IMyService
    {
        void Create(Assesment assesment);
        Assesment Read(int id);

        void Update(Assesment assesment);
        void Delete(int id);
        List<Assesment> GetTestList(string text);
    }
}

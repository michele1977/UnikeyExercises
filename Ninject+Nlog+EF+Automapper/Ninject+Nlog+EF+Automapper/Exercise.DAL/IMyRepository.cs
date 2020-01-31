using System.Collections.Generic;
using Exercise.Domain;

namespace Exercise.DAL
{
    public interface IMyRepository
    {
        void Create(Assestment assestment);
        Assestment Read(int id);
        void Update(Assestment assestment);
        void Delete(int id);
        List<Assestment> GetTestList(string text);


    }
}

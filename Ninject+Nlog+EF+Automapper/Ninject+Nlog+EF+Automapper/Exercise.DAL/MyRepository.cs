using System.Collections.Generic;
using Exercise.Domain;

namespace Exercise.DAL
{
    public interface IMyRepository
    {
        void Create(Assesment assestment);
        Assesment Read(int id);
        void Update(Assesment assestment);
        void Delete(int id);
        List<Assesment> GetTestList(string text);
    }
}

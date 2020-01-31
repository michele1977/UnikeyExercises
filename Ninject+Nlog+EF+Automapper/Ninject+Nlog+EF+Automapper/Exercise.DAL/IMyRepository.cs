using System.Collections.Generic;
using Exercise.DAL.DAO;
using Exercise.Domain;

namespace Exercise.DAL
{
    public interface IMyRepository
    {
        void Create(Assesment assesment);
        AssesmentDao Read(int id);
        void Update(Assesment assesment);
        void Delete(int id);
        List<AssesmentDao> GetTestList(string text);
    }
}

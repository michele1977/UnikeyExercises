using System;
using System.Collections.Generic;
using Ninject_Exercise.Domain;

namespace Ninject_Exercise.DAL
{
    public class MyRepository
    {
        static List<DomainObject> _myDb = new List<DomainObject>();

        public void Create(DomainObject objectToInsert)
        {
            throw new NotImplementedException();
        }
        public DomainObject Read(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(DomainObject objectToUpdate)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}

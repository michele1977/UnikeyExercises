using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject_Exercise.Business;
using Ninject_Exercise.Domain;

namespace Ninject_Exercise.Tests
{
    [TestClass]
    public class BusinessTests
    {
        public BusinessTests()
        {
            //Add here  Configurations
        }
        static DomainObject GetSampleObject()
        {
            var returned = new DomainObject()
            {
                Prop1 = "Prop 1",
                Prop2 = new Random().Next(),
                Prop3 = DateTime.Now
            };
            return returned;
        }

        [TestMethod]
        public void Business_Create_OK()
        {
            var service = new MyService();
            var objectToAdd = GetSampleObject();
            service.Create(objectToAdd);
            var objectRead = service.Read(objectToAdd.Id);
            Assert.AreEqual(objectToAdd, objectRead);
        }
        [TestMethod]
        public void Business_Read_OK()
        {
        }
        [TestMethod]
        public void Business_Update_OK()
        {
        }
        [TestMethod]
        public void Business_Delete_OK()
        {
        }
    }
}

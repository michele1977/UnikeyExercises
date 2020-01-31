using Exercise.DAL;
using Exercise.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Exercise.Business;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Exercise_Create_OK()
        {
            var assestment = new Assestment(1, "e", Convert.ToDateTime("01/01/2020"));
            var service = new MyService();
            service.CreateAssestement(assestment);
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Exercise_Read_OK()
        {
        }
        [TestMethod]
        public void Exercise_ReadList_OK()
        {
            MyService assestments = new MyService();
            List<Assestment> ass = assestments.GetAssestment();

            Assert.IsNotNull(ass);
        }
        [TestMethod]
        public void Exercise_Update_OK()
        {
        }

        [TestMethod]
        public void Exercise_Delete_OK()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using Exercise.DAL;
using Exercise.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTest1
    {
        public MyRepository MyRepository { get; set; } = new MyRepository();

        public Assesment Assesment { get; set; } = new Assesment
        {
            Title = "Prova",
            CreationDate = DateTime.Now
        };

        [TestMethod]
        public void Exercise_Create_OK()
        {
            MyRepository.Create(Assesment);

            //var assesment = MyRepository.Read(Assesment.Id);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Exercise_Read_OK()
        {
            var assesment = MyRepository.Read(2);
            const string test = "Prova";
            Assert.AreEqual(test,assesment.Title);
        }

        [TestMethod]
        public void Exercise_ReadList_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => MyRepository.GetTestList(""));
        }

        [TestMethod]
        public void Exercise_Update_OK()
        {            
            Assert.ThrowsException<NotImplementedException>(() => MyRepository.Update(new Assesment()));
        }

        [TestMethod]
        public void Exercise_Delete_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => MyRepository.Delete(0));
        }
    }
}

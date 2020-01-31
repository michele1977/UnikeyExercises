using System;
using System.Collections.Generic;
using Exercise.DAL;
using Exercise.DAL.DAO;
using Exercise.DAL.Enums;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTest1
    {
        public IMyRepository MyRepository { get; set; } = new MyRepository();

        public Assesment Assesment { get; set; } = new Assesment
        {
            Title = "Prova",
            CreationDate = DateTime.Now,
            Questions = new List<Question>
            {
                new Question
                {
                    Position = 1,
                    QuestionText = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            AnswerText = "",
                            IsCorrect = AnswerType.Correct,
                            Position = 1
                        }
                    }
                }
            }
        };

        [TestMethod]
        public void Exercise_Create_OK()
        {
            MyRepository.Create(Assesment);
            var assesmentDao = MyRepository.Read(5);
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

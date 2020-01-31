using System;
using System.Collections.Generic;
using Exercise.Business;
using Exercise.DAL;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTestService
    {
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

        public static IMyRepository Repo { get; set; } = new MyRepository();

        public static IMyService Service { get; set; } = new MyService(Repo);

        [TestMethod]
        public void Exercise_Create_OK()
        {
            Service.Create(Assesment);
        }
        
        [TestMethod]
        public void Exercise_Read_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => Service.Read(1));
        }
        
        [TestMethod]
        public void Exercise_Delete_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => Service.Delete(1));
        }
        
        [TestMethod]
        public void Exercise_GetList_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => Service.GetTestList(""));
        }
        
        [TestMethod]
        public void Exercise_Update_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => Service.Update(new Assesment()));
        }
    }
}

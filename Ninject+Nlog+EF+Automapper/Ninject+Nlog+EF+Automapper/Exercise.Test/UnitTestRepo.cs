using System;
using System.Collections.Generic;
using Exercise.Business;
using Exercise.Business.Injection;
using Exercise.DAL;
using Exercise.DAL.DAO;
using Exercise.DAL.Enums;
using Exercise.DAL.Mapper;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTestRepo
    {
        public IMyRepository MyRepository { get; set; } 

        public Assesment Assesment { get; set; } = new Assesment
        {
            Id = 9,
            Title = "BohTest",
            CreationDate = DateTime.Now,
            Questions = new List<Question>
            {
                new Question
                {
                    Id = 3,
                    Position = 2,
                    QuestionText = "Is Boh?",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Id = 2,
                            AnswerText = "Boh",
                            IsCorrect = AnswerType.Correct,
                            Position = 4
                        }
                    }
                }
            }
        };
        public IKernel Kernel { get; set; } = new StandardKernel();

        [TestMethod]
        public void Exercise_Create_OK()
        {
            KernelHelper.Initialize(Kernel, KernelTypeEnum.Repo);
            MyRepository = Kernel.Get<IMyRepository>();
            MyRepository.Create(Assesment);
            var assesmentDao = MyRepository.Read(9);
            Assert.AreEqual(3, assesmentDao.Questions[0].Id);
        }

        [TestMethod]
        public void Exercise_Read_OK()
        {
            KernelHelper.Initialize(Kernel, KernelTypeEnum.Repo);
            MyRepository = Kernel.Get<IMyRepository>();
            var assesment = MyRepository.Read(11);
            Assert.AreEqual(4, assesment.Questions[0].Id);
        }

        [TestMethod]
        public void Exercise_ReadList_OK()
        {
            Assert.ThrowsException<NotImplementedException>(() => MyRepository.GetTestList(""));
        }

        [TestMethod]
        public void Exercise_Update_OK()
        {            
            MyRepository.Update(Assesment);
        }

        [TestMethod]
        public void Exercise_Delete_OK()
        {
            MyRepository.Delete(10);
        }
    }
}

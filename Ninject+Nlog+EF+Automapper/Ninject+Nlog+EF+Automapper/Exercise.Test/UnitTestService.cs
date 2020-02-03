using System;
using System.Collections.Generic;
using AutoMapper;
using Exercise.Business;
using Exercise.Business.Injection;
using Exercise.DAL;
using Exercise.DAL.Mapper;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

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

        public IKernel Kernel { get; set; } = new StandardKernel();
        public IMyService Service { get; set; } 

        [TestMethod]
        public void Exercise_Create_OK()
        {
            KernelHelper.Initialize(Kernel, KernelTypeEnum.Service);
            Service = Kernel.Get<IMyService>();

            Service.Create(Assesment);
        }
        
        [TestMethod]
        public void Exercise_Read_OK()
        {
            KernelHelper.Initialize(Kernel);
            Service = Kernel.Get<IMyService>();
            var assesment = Service.Read(13);
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

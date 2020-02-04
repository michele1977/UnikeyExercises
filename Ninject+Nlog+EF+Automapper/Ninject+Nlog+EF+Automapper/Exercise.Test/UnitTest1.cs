using System;
using System.Collections.Generic;
using AutoMapper;
using Exercise.Business;
using Exercise.DAL;
using Exercise.DAL.AutoMapper;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Exercise.Test
{
    [TestClass]
    public class UnitTest1
    {

        MyService service;

        public UnitTest1()
        {
            var kernel = new StandardKernel(new AutoMapperModule(), new RepositoryModule());
            service = new MyService(kernel.Get<IMyRepository>());
        }

        public Assesment GetSubObject()
        {
            return new Assesment()
            {
                Title = "Andrea",
                CreationDate = DateTime.Now,
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        Position = 1,
                        QuestionText = "Andrea",
                        Answers = new List<Answer>()
                        {
                            new Answer()
                            {
                                Position = 1,
                                AnswerText = "Andrea",
                                IsCorrect = AnswerType.Correct
                            },
                            new Answer()
                            {
                                Position = 2,
                                AnswerText = "Andrea2",
                                IsCorrect = AnswerType.NotCorrect
                            }
                        }
                    },
                    new Question()
                    {
                        Position = 2,
                        QuestionText = "Andrea2",
                        Answers = new List<Answer>()
                        {
                            new Answer()
                            {
                                Position = 1,
                                AnswerText = "Andrea",
                                IsCorrect = AnswerType.Correct
                            },
                            new Answer()
                            {
                                Position = 2,
                                AnswerText = "Andrea2",
                                IsCorrect = AnswerType.NotCorrect
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void Exercise_Create_OK()
        {
            var assessment = GetSubObject();
            //service.Create(assessment);
            var assessmentAdded = service.Read(20);
             CollectionAssert.AreEquivalent(assessment.Questions[0].Answers, assessmentAdded.Questions[0].Answers);
        }

        [TestMethod]
        public void Exercise_Read_OK()
        {
        }
        [TestMethod]
        public void Exercise_ReadList_OK()
        {
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

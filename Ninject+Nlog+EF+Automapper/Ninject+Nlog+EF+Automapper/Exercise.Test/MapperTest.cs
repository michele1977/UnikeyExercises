using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Exercise.Business;
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
    public class MapperTest
    {
        public IKernel Kernel { get; set; } = new StandardKernel();
        public IMapper Mapper { get; set; }

        [TestMethod]
        public void MapperHeavy_DomainToDao_OK()
        {
            var Assesment = new Assesment
            {
                Id = 1,
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

            Kernel.Load(new List<INinjectModule>
            {
                new RepoBindings()
            });

            Mapper = Kernel.Get<IMapper>();

            var asdao = Mapper.Map<AssesmentDao>(Assesment);
            Assert.AreEqual(1, asdao.Id);
        }
        
        [TestMethod]
        public void MapperHeavy_DaoToDomain_OK()
        {
        }
    }
}

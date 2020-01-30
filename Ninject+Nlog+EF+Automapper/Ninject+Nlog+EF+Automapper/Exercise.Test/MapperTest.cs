using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Exercise.DAL.DAO;
using Exercise.DAL.Mapper;
using Exercise.Domain;
using Exercise.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.Test
{
    [TestClass]
    public class MapperTest
    {
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

            var mapConfig = new MapConfig();
            Mapper = mapConfig.Mapper;

            var asdao = Mapper.Map<AssesmentDao>(Assesment);
            Assert.AreEqual(1, asdao.Id);
        }
        
        [TestMethod]
        public void MapperHeavy_DaoToDomain_OK()
        {
        }
    }
}

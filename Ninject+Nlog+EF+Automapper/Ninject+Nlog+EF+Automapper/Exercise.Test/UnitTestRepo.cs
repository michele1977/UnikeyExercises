﻿using System;
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
    public class UnitTestRepo
    {
        public IMyRepository MyRepository { get; set; } = new MyRepository();

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

        [TestMethod]
        public void Exercise_Create_OK()
        {
            MyRepository.Create(Assesment);
            var assesmentDao = MyRepository.Read(5);
            //TODO: assert
        }

        [TestMethod]
        public void Exercise_Read_OK()
        {
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

﻿using Exercise.DAL;
using Exercise.Domain;
using Exercise.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Business
{
    public class MyService
    {
        public MyService(Assestment assestment) { }

        public MyService()
        {
        }

        //public List<AssestmentDto> GetAssestment()
        //{
        //    MyRepository assestments = new MyRepository();
        //    //List<AssestmentDto> assest = assestments.ReadAll();
            
        //    //return assest;
        //}

        public void CreateAssestement(Assestment assestment)
        {
            MyRepository repository = new MyRepository();
            repository.Create(assestment);
        }
    }
}

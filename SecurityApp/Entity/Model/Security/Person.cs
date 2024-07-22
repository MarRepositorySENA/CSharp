﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {

        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        
        public string email { get; set; }

        public string gender { get; set; }

        public string document { get; set; }

        public string typeDocument { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public DateTime birthDate { get; set; }


        public bool state { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime createdBy { get; set; }

        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }

        public DateTime deletedAt { get; set; }
        public DateTime deletedBy { get; set; }




    }
}

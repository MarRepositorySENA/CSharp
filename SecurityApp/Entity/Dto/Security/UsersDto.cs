﻿using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class UsersDto
    {
        public int Id { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        public int personId { get; set; }
        public bool state { get; set; }


    }
}

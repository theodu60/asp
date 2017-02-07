﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime age { get; set; }

        public virtual AccessToken AccessToken { get; set; }
     }
}

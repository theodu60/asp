using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muscu.Models
{
    public class Users
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string img { get; set; }
        public DateTime age { get; set; }
    }
}
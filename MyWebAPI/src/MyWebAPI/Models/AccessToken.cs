using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class AccessToken
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public virtual Users Users { get; set; }

    }
}

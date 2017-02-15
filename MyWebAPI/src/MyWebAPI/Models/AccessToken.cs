using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class AccessToken
    {
        [ForeignKey("Users")]
        public int Id { get; set; }
        public string Token { get; set; }
        public virtual Users Users { get; set; }
    }
}

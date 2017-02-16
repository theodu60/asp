using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Models
{
    public class Story
    {
//        [ForeignKey("UsersId")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}

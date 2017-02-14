using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class Users
    {
        public Users()
        {
            Story = new List<Story>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}
        public virtual ICollection<Story> Story { get; set; }
        public virtual AccessToken AccessToken { get; set; }
    }
}

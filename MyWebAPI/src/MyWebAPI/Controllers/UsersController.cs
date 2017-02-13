using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        public readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        // GET api/users
        [HttpGet]
        public IEnumerable<Users> All()
        {
            var user = _context.Users.ToList();
            return user;
        }
        // POST api/users
        [HttpPost]
        public String Login([FromBody]Users value)
        {
           
            var user = _context.Users.FirstOrDefault(u => u.Email == value.Email && u.Password == value.Password);
            if (user != null)
                return "ok";
            return "notok";
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult One(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public void Register([FromBody]Users value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Users value)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.Users.Add(value);
            _context.SaveChanges();
 
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}

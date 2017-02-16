using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StoryController : Controller
    {

        public readonly MyDbContext _context;

        public StoryController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Story> All([FromQuery] string token)
        {
            var accesstoken = _context.AccessToken.FirstOrDefault(a => a.Token == token);
            if (accesstoken != null)
            {
                var story = _context.Story.ToList();
                for (int i = 0; i < story.Count; i++)
                {
                    story[i].Users = _context.Users.FirstOrDefault(u => u.Id == story[i].UsersId);
                }
                return story;
            }
            else
            {
                return null;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery] string token)
        {

            var accesstoken = _context.AccessToken.FirstOrDefault(a => a.Token == token);
            if (accesstoken != null)
            {
                var userstory = _context.Story.FirstOrDefault(u => u.Id == id);
                if (userstory != null)
                    return Ok(userstory);
            }
            return NotFound();



        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Story value, [FromQuery] string token)
        {

            var accesstoken = _context.AccessToken.FirstOrDefault(a => a.Token == token);
            if (accesstoken != null)
            {
                if (value != null)
                {
                    _context.Story.Add(value);
                    _context.SaveChanges();
                }
            }
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Story value, [FromQuery] string token)
        { 
            var accesstoken = _context.AccessToken.FirstOrDefault(a => a.Token == token);
            if (accesstoken != null)
            {
                var story = _context.Story.FirstOrDefault(u => u.Id == id);
                _context.Story.Remove(story);
                _context.SaveChanges();
                _context.Story.Add(value);
                _context.SaveChanges();
            }
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromQuery] string token)
        {
            var accesstoken = _context.AccessToken.FirstOrDefault(a => a.Token == token);
            if (accesstoken != null)
            {
                var story = _context.Story.FirstOrDefault(u => u.Id == id);
                _context.Story.Remove(story);
                _context.SaveChanges();
            }
        }
    }
}

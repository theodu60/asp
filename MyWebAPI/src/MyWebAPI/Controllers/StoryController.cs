﻿using System;
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
        public IEnumerable<Story> All()
        {
            var story = _context.Story.ToList();
            return story;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userstory = _context.Story.FirstOrDefault(u => u.Id == id);
            if (userstory != null)
                return Ok(userstory);
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Story value)
        {
            if (value != null)
            {
                _context.Story.Add(value);
                _context.SaveChanges();
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

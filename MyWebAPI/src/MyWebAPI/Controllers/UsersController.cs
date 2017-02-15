﻿using System;
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
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // POST api/users
        [HttpPost]
        public String Login([FromBody]Users value)
        {
           
            var user = _context.Users.FirstOrDefault(u => u.Email == value.Email && u.Password == value.Password);
            if (user != null)
            {
                var alreadyToken = _context.AccessToken.FirstOrDefault(u => u.Id == user.Id);
                if (alreadyToken != null)
                {
                    _context.AccessToken.Remove(alreadyToken);
                }
                _context.SaveChanges();
            
                user.AccessToken = new AccessToken();
                user.AccessToken.Id = user.Id;
                user.AccessToken.Token = RandomString(10);
                _context.Users.Update(user);
                _context.SaveChanges();

                return user.AccessToken.Token;
            }
            return "notok";
        }
        // GET api/users
        [HttpGet("{id}")]
        public void Logout(int id)
        {
                var alreadyToken = _context.AccessToken.FirstOrDefault(u => u.Id == id);
                if (alreadyToken != null)
                {
                    _context.AccessToken.Remove(alreadyToken);
                    _context.SaveChanges();
                }
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

        // POST api/users
        [HttpPut("{id}")]
        public void addStory(int id, [FromBody]Story value)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Story.Add(value);
                _context.SaveChanges();
            }
        }
        // PUT api/users/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]Users value)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Story()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult loginuser(string email, string password)
        {
            Dictionary<string, string> content = new Dictionary<string, string>();
            content.Add("email", email);
            content.Add("password", password);
            string result = JsonConvert.SerializeObject(content);
            System.Diagnostics.Debug.WriteLine(result);
            _service.Post(email, password);

            return RedirectToAction("Users", "Users");
        }

        public IActionResult Users(int id)
        {
            return View(_service.Get(id));
        }

        /*public IActionResult Register(string name, string email, string password, string confirm_password)
        {
            Dictionary<string, string> content = new Dictionary<string, string>();
            content.Add("name", name);
            //content.Add("email", email);
            //if(password == confirm_password) 
            //content.Add("password", password);
            string result = JsonConvert.SerializeObject(content);
            System.Diagnostics.Debug.WriteLine(result);
            _service.Post(result);

            return RedirectToAction("Index", "Home");
        }*/

        public IActionResult Error()
        {
            return View();
        }
    }
}

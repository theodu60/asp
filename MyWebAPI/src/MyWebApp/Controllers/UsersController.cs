using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

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

        public IActionResult Users(int id)
        {
            return View(_service.Get(id));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

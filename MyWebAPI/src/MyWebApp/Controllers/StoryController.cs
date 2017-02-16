using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Controllers
{
    public class StoryController : Controller
    {
        private readonly StoryService _context;

        public StoryController(StoryService context)
        {
            _context = context;
        }

        public IActionResult Story(int id)
        {
            return View(_context.Get(id));
        }

        public IActionResult Story()
        {
            return View(_context.Get());
        }

    }
}

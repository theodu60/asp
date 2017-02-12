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
        public IActionResult Story()
        {
            return View();
        }
    }
}

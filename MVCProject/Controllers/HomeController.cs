using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        FacebookContext db;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, FacebookContext _db)
        {
            _logger = logger;

            db = _db;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        [HttpPost]
        public void Create(Post p)
        {
           
            db.Posts.Add(p);
            db.SaveChanges();
        }



    }
}

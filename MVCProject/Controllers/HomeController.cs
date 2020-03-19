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

        public IActionResult Index(int id)
        {
            PostViewModel obj = new PostViewModel() { 
                commentLst = db.Comments.Where(c=>c.IsDeleted == false && c.PostId == id).ToList(), postLst = db.Posts.Where(p=>p.IsDeleted == false).ToList()
            };

            return View(obj);
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
        public void Create(Post p)
        {
           
            db.Posts.Add(p);
            db.SaveChanges();
        }

        [HttpPost]
        public void AddComment(Comment c)
        {

            db.Comments.Add(c);
            db.SaveChanges();
        }



        public IActionResult GetAllComments(int id)
        {
            return View(db.Comments.Where(c=>c.PostId == id && c.IsDeleted == false).ToList());
        }

    }
}

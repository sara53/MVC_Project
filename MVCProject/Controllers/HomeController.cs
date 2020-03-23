using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //PostViewModel obj = new PostViewModel() { 
            //    commentLst = db.Comments.Where(c=>c.IsDeleted == false && c.PostId == id).ToList(),
            //    postLst = db.Posts.Where(p=>p.IsDeleted == false).ToList()
            //};
            var user = db.Users.Include(u => u.Posts).SingleOrDefault(u => u.UserId == 2);
            user.FriendRequestReceivers = db.FriendRequests
                .Where(r => r.ReceiverId == user.UserId && r.State == FriendRequestState.Accepted)
                .Include("Sender")
                .Include("Receiver").ToList();
            user.FriendRequestSenders = db.FriendRequests
                .Where(r => r.SenderId == user.UserId && r.State == FriendRequestState.Accepted)
                .Include("Sender")
                .Include("Receiver").ToList();
            //var _post = db.Posts
            //.Include(p => p.Comments)
            //.Include(l => l.Likes)
            //.Where(p => user.FriendRequestReceivers.Any(f => f.Sender == p.User));
            List<Post> posts = new List<Post>();
            foreach (var item in user.FriendRequestReceivers)
            {
                posts.AddRange(db.Posts.Where(p => p.UserId == item.SenderId).ToList());
            }
            foreach (var item in user.FriendRequestSenders)
            {
                posts.AddRange(db.Posts.Where(p => p.UserId == item.ReceiverId).ToList());
            }
            posts.AddRange(user.Posts);
            posts.OrderBy(p => p.PostDateTime);
            // return View(db.Posts.Include(p => p.Comments).Include(l => l.Likes).ToList());
            return View(posts);
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

        [HttpPost]
        public void Like(Like l)
        {

            var _checkFound = db.Likes.SingleOrDefault(f => f.PostId == l.PostId);
            if(_checkFound == null)
            {
                db.Likes.Add(l);
                db.SaveChanges();
            }
            else
            {
                if (_checkFound.IsLiked == true)
                    _checkFound.IsLiked = false;
                else
                    _checkFound.IsLiked = true;

                db.SaveChanges();
            }
             
        }

 
        public List<Like> getLiked()
        {

            return db.Likes.Where(l => l.IsLiked == true).ToList();
        }


        //public IActionResult GetAllComments(int id)
        //{
        //    return View(db.Comments.Where(c=>c.PostId == id && c.IsDeleted == false).ToList());
        //}

    }
}

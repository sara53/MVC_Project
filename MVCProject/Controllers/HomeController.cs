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
          


            var user = db.Users.Include(u => u.Posts).Include(u=>u.Comments).Include(u => u.Likes).SingleOrDefault(u => u.UserId == 2);


            user.FriendRequestReceivers = db.FriendRequests
                .Where(r => r.ReceiverId == user.UserId && r.State == FriendRequestState.Accepted)
                .Include("Sender")
                .Include("Receiver").ToList();

            user.FriendRequestSenders = db.FriendRequests
                .Where(r => r.SenderId == user.UserId && r.State == FriendRequestState.Accepted)
                .Include("Sender")
                .Include("Receiver").ToList();
           
            List<Post> posts = new List<Post>();
            

            foreach (var item in user.FriendRequestReceivers)
            {
                posts.AddRange(db.Posts.Where(p => p.UserId == item.SenderId).Include(p => p.Comments).Include(l => l.Likes).ToList());
            }
            foreach (var item in user.FriendRequestSenders)
            {
                posts.AddRange(db.Posts.Where(p => p.UserId == item.ReceiverId).Include(p => p.Comments).Include(l => l.Likes).ToList());
            }



            posts.AddRange(user.Posts);



            foreach (var item in posts)
            {
                foreach (var i in item.Likes)
                {
                    i.User = db.Users.SingleOrDefault(u => u.UserId == i.UserId);
                }
            }


           
            //posts.AddRange(db.Posts.Include(p => p.Comments).Include(l => l.Likes));

            posts.OrderBy(p => p.PostDateTime);

            List<User> friendList = new List<User>();
            foreach (var item in user.FriendRequestReceivers)
            {
                friendList.Add(item.Sender);
            }
            foreach (var item in user.FriendRequestSenders)
            {
                friendList.Add(item.Receiver);
            }
            PostViewModel obj = new PostViewModel()
            {
                UserFriends = friendList,
                postsLst = posts,
                user = user
            };

            // return View(db.Posts.Include(p => p.Comments).Include(l => l.Likes).ToList());
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
        public ActionResult Create(Post p)
        {
           
            db.Posts.Add(p);
            db.SaveChanges();
            return Json(p.PostId);
        }

        [HttpPost]
        public ActionResult AddComment(Comment c)
        {

            db.Comments.Add(c);
            db.SaveChanges();

            return Json(c.PostId);
        }

        [HttpPost]
        public void Like(Like l)
        {

            var _checkFound = db.Likes.SingleOrDefault(f => f.PostId == l.PostId && f.UserId == l.UserId);
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


        public ActionResult RemovePost(Post p)
        {
            var result = db.Posts.SingleOrDefault(post => post.PostId == p.PostId);
            if (result != null)
            {
                result.IsDeleted = true;
                db.SaveChanges();
            }

            return Json(p.PostId);
        }

        public ActionResult RemoveComment(Comment c)
        {
            var result = db.Comments.SingleOrDefault(Comment => Comment.CommentId == c.CommentId);
            if (result != null)
            {
                result.IsDeleted = true;
                db.SaveChanges();
            }
            return Json(c.PostId);
        }

        }
    }

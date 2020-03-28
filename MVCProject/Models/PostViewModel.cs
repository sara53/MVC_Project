using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class PostViewModel
    {

        public User user { get; set; }

        public List<User> UserFriends { get; set; }

        public List<Post> postsLst { get; set; }
    }
}

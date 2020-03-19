using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class PostViewModel
    {
        public List<Post> postLst { get; set; }
        public List<Comment> commentLst { get; set; }
    }
}

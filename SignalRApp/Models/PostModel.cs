using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRApp.Models
{
    public class PostModel
    {
        public PostModel()
        {
            PostCollection = new List<tblPost>();
        }
        private List<tblPost> PostCollection { get; set; }
        public class tblPost
        {
            public int PostID { get; set; }
            public string Post { get; set; }
            public int AuthorID { get; set; }
            public string DatePosted { get; set; }


        }
    }
}
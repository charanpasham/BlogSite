using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRApp.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            AuthorCollection = new List<tblAuthor>(); 
        }
        public List<tblAuthor> AuthorCollection { get; set; }
        public class tblAuthor
        {
         
            public string UserID { get; set; }
            public string Password { get; set; }
        }
    }
}
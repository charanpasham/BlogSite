using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using SignalRApp.DataAccessLayer;
using System.Data;
using System.Web.SessionState;

namespace SignalRApp.Repository
{
  
    public class Repo
    {
        private string ConnectionString;
        private DataAccess dal;
        public Repo()
        {
            dal = new DataAccess();
            ConnectionString = WebConfigurationManager.ConnectionStrings["BlogSite"].ConnectionString;
        }
        
        public bool CompareWithAuthor(string UserID, string Password)
        {
            bool valid = false;
            DataTable dtAuthor = new DataTable();
            dtAuthor = dal.ValidateUser(ConnectionString);
            DataRow dr = dtAuthor.Rows[0];
            string dbUserID = dr["UserID"].ToString();
            string dbPassword = dr["Password"].ToString();
            if(UserID == dbUserID && Password == dbPassword)
            {
                valid = true;
            }
            return valid;
        }
    }
}
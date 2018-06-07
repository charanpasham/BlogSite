using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRApp.Models;
using SignalRApp.Repository;
using System.Web.SessionState;

namespace SignalRApp.Controllers
{
    
    public class HomeController : Controller
    {
        Repo rp = new Repo();

        #region LoginAuthentication
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserID"] != null)
                return RedirectToAction("AdminHome");

            return View();
        }
        [HttpPost]
        public ActionResult Login(SignalRApp.Models.AuthorModel model)
        {
            bool valid = rp.CompareWithAuthor(model.AuthorCollection[0].UserID, model.AuthorCollection[0].Password);
            if (valid)
            {
                Session["UserID"] = model.AuthorCollection[0].UserID;
                return RedirectToAction("AdminHome");
            }
            else
            {
                TempData["message"] = "User name or password is not valid, try again!";
                return RedirectToAction("Login");
            }

        }
        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            return RedirectToAction("Login");
        }
        #endregion

        #region AfterLoginPages
        public ActionResult AdminHome()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        #endregion

        #region ClientPages
        public ActionResult Blog()
        {
            return View();
        }
        #endregion

        #region SignalRRelatedStuff
        public ActionResult Chat()
        {
            return View();
        }

        #endregion
    }
}
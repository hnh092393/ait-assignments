using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class LogInViewController : Controller
    {
        LogInWSReference.LogInClient logInService = new LogInWSReference.LogInClient();


        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        // validate user
        public ActionResult ValidateUser(Models.UserViewDTO userView)
        {
            // create user object based on user input
            LogInWSReference.UserDTO user = new LogInWSReference.UserDTO();
            user.UserName = userView.UserName;
            user.Password = userView.Password;

            // check if user object exists in database
            bool isValidUser = logInService.ValidateUser(user);
            if (!isValidUser)
            {
                userView.LogInErrorMessage = "Invalid username or password!";
                return View("Index", userView);
            }
            else
            {
                // create new session
                Session["UID"] = logInService.GetUID(userView.UserName);
                Session["UserName"] = userView.UserName;
                return RedirectToAction("Index", "MediaView");
            }
        }

        // log out
        public ActionResult LogOut()
        {
            Session.Remove("UID");
            Session.Remove("UserName");
            return RedirectToAction("Index", "MediaView");
        }
    }
}
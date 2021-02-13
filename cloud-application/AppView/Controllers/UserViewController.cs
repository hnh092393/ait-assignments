using AppView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppView.Controllers
{
    public class UserViewController : Controller
    {
        UserWSReference.UserClient userClient = new UserWSReference.UserClient();

        public ActionResult Index()
        {
            UserWSReference.UserDTO[] userList = userClient.GetAllUser();
            List<UserViewDTO> userViewList = new List<UserViewDTO>();
            foreach (UserWSReference.UserDTO user in userList)
            {
                userViewList.Add(new UserViewDTO(user.UID, user.UserName, user.Password, user.UserLevel, user.UserEmail));
            }
            ViewData["UserList"] = userViewList;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // add user to database
        public ActionResult AddUser(UserViewDTO userView)
        {
            UserWSReference.UserDTO user = new UserWSReference.UserDTO
            {
                UID = userView.UID,
                UserName = userView.UserName,
                Password = userView.Password,
                UserLevel = userView.UserLevel,
                UserEmail = userView.UserEmail
            };
            if (userClient.IsUserInserted(user))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // delete user
        public ActionResult Delete(int ID)
        {
            userClient.IsUserDeleted(ID);
            return RedirectToAction("Index");
        }

        // edit user
        public ActionResult Edit(int ID, string userName, string password, int userLevel, string userEmail)
        {
            UserViewDTO userView = new UserViewDTO(ID, userName, password, userLevel, userEmail);
            ViewData["User"] = userView;
            return View();
        }

        // save user after editing
        public ActionResult saveUser(UserViewDTO userView)
        {
            if (userView.UserName == null || userView.Password == null || userView.UserLevel == 0 || userView.UserEmail == null || userView.UID == 0)
            {
                ViewData["User"] = userView;
                return View("Edit");
            }
            else
            {
                UserWSReference.UserDTO user = new UserWSReference.UserDTO
                {
                    UID = userView.UID,
                    UserName = userView.UserName,
                    Password = userView.Password,
                    UserLevel = userView.UserLevel,
                    UserEmail = userView.UserEmail
                };
                if (userClient.IsUserUpdated(user))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit");
                }
            }
        }
    }
}
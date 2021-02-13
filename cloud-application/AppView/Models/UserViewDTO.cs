using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppView.Models
{
    public class UserViewDTO
    {
        public int UID { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string UserName { get; set; }

        // [MinLength(5)]
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
        public int UserLevel { get; set; }
        public string UserEmail { get; set; }
        public string LogInErrorMessage { get; set; }

        public UserViewDTO() { }

        public UserViewDTO(int uID, string userName, string password, int userLevel, string userEmail)
        {
            UID = uID;
            UserName = userName;
            Password = password;
            UserLevel = userLevel;
            UserEmail = userEmail;
        }
    }
}
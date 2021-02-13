using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class UserDTO
    {
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }
        public string UserEmail { get; set; }

        public UserDTO() { }

        public UserDTO(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public UserDTO(int uID, string userName, string password, int userLevel, string userEmail)
        {
            UID = uID;
            UserName = userName;
            Password = password;
            UserLevel = userLevel;
            UserEmail = userEmail;
        }
    }
}

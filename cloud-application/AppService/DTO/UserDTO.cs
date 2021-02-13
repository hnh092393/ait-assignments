using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AppService
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public int UID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int UserLevel { get; set; }

        [DataMember]
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
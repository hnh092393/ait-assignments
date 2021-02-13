using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserImp.svc or UserImp.svc.cs at the Solution Explorer and start debugging.
    public class UserImpl : IUser
    {
        AppController.IUserController userController = new AppController.UserControllerImpl();
        public bool IsUserInserted(UserDTO user)
        {
            AppController.UserDTO userFromController = new AppController.UserDTO
            {
                UserName = user.UserName,
                Password = user.Password,
                UserLevel = user.UserLevel,
                UserEmail = user.UserEmail,
                UID = user.UID
            };

            return userController.IsUserInserted(userFromController);
        }

        public bool IsUserDeleted(int ID)
        {
            return userController.IsUserDeleted(ID);
        }

        public List<UserDTO> GetAllUser()
        {
            List<AppController.UserDTO> userControllerList = userController.GetAllUser();
            List<UserDTO> userList = new List<UserDTO>();
            foreach (AppController.UserDTO user in userControllerList)
            {
                userList.Add(new UserDTO(user.UID, user.UserName, user.Password, user.UserLevel, user.UserEmail));
            }

            return userList;
        }

        public bool IsUserUpdated(UserDTO user)
        {
            AppController.UserDTO userFromController = new AppController.UserDTO
            {
                UID = user.UID,
                UserName = user.UserName,
                Password = user.Password,
                UserLevel = user.UserLevel,
                UserEmail = user.UserEmail
            };

            return userController.IsUserUpdated(userFromController); ;
        }
    }
}

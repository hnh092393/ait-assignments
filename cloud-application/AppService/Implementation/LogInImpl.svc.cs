using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginImp.svc or LoginImp.svc.cs at the Solution Explorer and start debugging.
    public class LogInImpl : ILogIn
    {
        AppController.ILogInController logInController = new AppController.LogInControllerImpl();
        public int GetUID(string userName)
        {
            int uID = logInController.GetUID(userName);
            return uID;
        }

        public bool ValidateUser(UserDTO user)
        {
            AppController.UserDTO userFromController = new AppController.UserDTO(user.UserName, user.Password);
            return logInController.ValidateUser(userFromController);
        }
    }
}

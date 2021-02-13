using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface ILogInController
    {
        bool ValidateUser(UserDTO user);
        int GetUID(string userName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IUserController
    {
        List<UserDTO> GetAllUser();
        bool IsUserInserted(UserDTO user);
        bool IsUserUpdated(UserDTO user);
        bool IsUserDeleted(int ID);
    }
}

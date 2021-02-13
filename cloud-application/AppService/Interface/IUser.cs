using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        List<UserDTO> GetAllUser();

        [OperationContract]
        bool IsUserInserted(UserDTO user);

        [OperationContract]
        bool IsUserUpdated(UserDTO user);

        [OperationContract]
        bool IsUserDeleted(int ID);
    }
}

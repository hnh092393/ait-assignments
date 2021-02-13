using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface ILogIn
    {
        [OperationContract]
        bool ValidateUser(UserDTO user);

        [OperationContract]
        int GetUID(string userName);
    }
}

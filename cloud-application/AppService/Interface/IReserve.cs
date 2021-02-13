using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface IReserve
    {
        [OperationContract]
        List<KeyValuePair<int, int>> GetReservedData();

        [OperationContract]
        bool IsReservedInserted(int uID, int mediaID, string reservedDate);

        [OperationContract]
        bool IsReservedDeleted(int mediaID);

        [OperationContract]
        List<ReserveDTO> GetReservedInfo();
    }
}

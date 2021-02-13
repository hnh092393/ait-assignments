using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IReserveController
    {
        List<KeyValuePair<int, int>> GetReservedData();
        bool IsReservedInserted(int uID, int mediaID, string reservedDate);
        bool IsReservedDeleted(int mediaID);
        List<ReserveDTO> GetReservedInfo();
    }
}

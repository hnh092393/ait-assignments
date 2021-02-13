using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface IBorrow
    {
        [OperationContract]
        List<KeyValuePair<int, int>> GetBorrowData();

        [OperationContract]
        bool IsBorrowInserted(int uID, int mediaID, string borrowDate, string returnDate);

        [OperationContract]
        bool IsBorrowUpdated(string actualReturnDate, int mediaID);

        [OperationContract]
        List<BorrowDTO> GetBorrowInfo();
    }
}

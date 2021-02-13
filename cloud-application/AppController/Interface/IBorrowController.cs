using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IBorrowController
    {
        List<KeyValuePair<int, int>> GetBorrowData();
        List<BorrowDTO> GetBorrowInfo();
        bool IsBorrowInserted(int uID, int mediaID, string borrowDate, string returnDate);
        bool IsBorrowUpdated(string actualReturnDate, int mediaID);
    }

    
}

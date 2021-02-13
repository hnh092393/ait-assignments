using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BorrowedMediaImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BorrowedMediaImp.svc or BorrowedMediaImp.svc.cs at the Solution Explorer and start debugging.
    public class BorrowImpl : IBorrow
    {
        AppController.IBorrowController borrowController = new AppController.BorrowControllerImpl();

        public List<KeyValuePair<int, int>> GetBorrowData()
        {
            List<KeyValuePair<int, int>> borrowList = new List<KeyValuePair<int, int>>();
            borrowList = borrowController.GetBorrowData();
            return borrowList;
        }

        public bool IsBorrowInserted(int UID, int MediaID, string BorrowDate, string ReturnDate)
        {
            return borrowController.IsBorrowInserted(UID, MediaID, BorrowDate, ReturnDate);
        }

        public List<BorrowDTO> GetBorrowInfo()
        {
            List<BorrowDTO> borrowList = new List<BorrowDTO>();
            List<AppController.BorrowDTO> borrowControllerList = new List<AppController.BorrowDTO>();
            borrowControllerList = borrowController.GetBorrowInfo();
            foreach(AppController.BorrowDTO borrow in borrowControllerList)
            {
                borrowList.Add(new BorrowDTO(borrow.UserName, borrow.Title, borrow.BorrowDate, borrow.ReturnDate, borrow.ActualReturnDate));
            }

            return borrowList;
        }

        public bool IsBorrowUpdated(string ActualReturnDate, int MediaID)
        {
            return borrowController.IsBorrowUpdated(ActualReturnDate, MediaID);
        }
    }
}

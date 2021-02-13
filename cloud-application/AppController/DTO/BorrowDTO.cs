using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class BorrowDTO
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
        public string ActualReturnDate { get; set; }

        public BorrowDTO(string userName, string title, string borrowDate, string returnDate, string actualReturnDate)
        {
            UserName = userName;
            Title = title;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
            ActualReturnDate = actualReturnDate;
        }
    }
}

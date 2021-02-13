using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [DataContract]
    public class BorrowDTO
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string BorrowDate { get; set; }

        [DataMember]
        public string ReturnDate { get; set; }

        [DataMember]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class ReserveDTO
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string ReservedDate { get; set; }

        public ReserveDTO(string userName, string title, string reservedDate)
        {
            UserName = userName;
            Title = title;
            ReservedDate = reservedDate;
        }
    }
}

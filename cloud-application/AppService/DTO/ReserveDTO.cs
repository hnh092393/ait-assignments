using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [DataContract]
    public class ReserveDTO
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ReserveDate { get; set; }

        public ReserveDTO(string userName, string title, string reserveDate)
        {
            UserName = userName;
            Title = title;
            ReserveDate = reserveDate;
        }
    }
}

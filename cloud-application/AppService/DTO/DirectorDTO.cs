using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [DataContract]
    public class DirectorDTO
    {
        [DataMember]
        public int DID { get; set; }

        [DataMember]
        public string DirectorName { get; set; }

        public DirectorDTO(int dID, string directorName)
        {
            DID = dID;
            DirectorName = directorName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [DataContract]
    public class GenreDTO
    {
        [DataMember]
        public int GID { get; set; }

        [DataMember]
        public string GenreName { get; set; }

        public GenreDTO(int gID, string genreName)
        {
            GID = gID;
            GenreName = genreName;
        }
    }
}

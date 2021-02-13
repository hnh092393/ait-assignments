using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{ 
    [DataContract]
    public class LanguageDTO
    {
        [DataMember]
        public int LID { get; set; }

        [DataMember]
        public string LanguageName { get; set; }

        public LanguageDTO(int lID, string languageName)
        {
            LID = lID;
            LanguageName = languageName;
        }
    }
}

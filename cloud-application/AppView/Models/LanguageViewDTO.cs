using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppView.Models
{
    public class LanguageViewDTO
    {
        public int LID { get; set; }
        public string LanguageName { get; set; }

        public LanguageViewDTO() { }

        public LanguageViewDTO(int lID, string languageName)
        {
            LID = lID;
            LanguageName = languageName;
        }
    }
}
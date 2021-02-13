using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppView.Models
{
    public class DirectorViewDTO
    {
        public int DID { get; set; }
        public string DirectorName { get; set; }

        public DirectorViewDTO() { }

        public DirectorViewDTO(int dID, string directorName)
        {
            DID = dID;
            DirectorName = directorName;
        }
    }
}
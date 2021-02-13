using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppView.Models
{
    public class GenreViewDTO
    {
        public int GID { get; set; }
        public string GenreName { get; set; }

        public GenreViewDTO() { }

        public GenreViewDTO(int gID, string genreName)
        {
            GID = gID;
            GenreName = genreName;
        }
    }
}
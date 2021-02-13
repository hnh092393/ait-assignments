using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class MediaDTO
    {
        public int MediaID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public int PublishYear { get; set; }
        public decimal Budget { get; set; }

        public MediaDTO() { }

        public MediaDTO(int mediaID, string title, string genre, string director, string language, int publishYear, decimal budget)
        {
            MediaID = mediaID;
            Title = title;
            Genre = genre;
            Director = director;
            Language = language;
            PublishYear = publishYear;
            Budget = budget;
        }
    }
}

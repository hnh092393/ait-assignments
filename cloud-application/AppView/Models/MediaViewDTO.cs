using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppView.Models
{
    public class MediaViewDTO
    {
        public int MediaID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public int PublishYear { get; set; }
        public decimal Budget { get; set; }

        public MediaViewDTO() { }

        public MediaViewDTO(int mediaID, string title, string genre, string director, string language, int publishYear, decimal budget)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace AppService
{
    [DataContract]
    public class MediaDTO
    {
        [DataMember]
        public int MediaID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Genre { get; set; }
        [DataMember]
        public string Director { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int PublishYear { get; set; }
        [DataMember]
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
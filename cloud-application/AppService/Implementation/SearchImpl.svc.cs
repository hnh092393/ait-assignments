using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{ 
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SearchImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SearchImp.svc or SearchImp.svc.cs at the Solution Explorer and start debugging.
    public class SearchImpl : ISearch
    {
        AppController.ISearchController searchController = new AppController.SearchControllerImpl();
        public List<MediaDTO> Search(string searchType, string searchText)
        {
            List<MediaDTO> mediaList = new List<MediaDTO>();
            List<AppController.MediaDTO> mediaControllerList = searchController.Search(searchType, searchText);
            foreach (AppController.MediaDTO media in mediaControllerList)
            {
                mediaList.Add(new MediaDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget));
            }
            return mediaList;
        }
    }
}

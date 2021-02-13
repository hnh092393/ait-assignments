using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Media" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Media.svc or Media.svc.cs at the Solution Explorer and start debugging.
    public class MediaImpl : IMedia
    {

        AppController.IMediaController mediaController = new AppController.MediaControllerImpl();
        public bool IsMediaInserted(MediaDTO media)
        {
            AppController.MediaDTO mediaFromController = new AppController.MediaDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget);
            return mediaController.IsMediaInserted(mediaFromController);
        }

        public bool IsMediaDeleted(int ID)
        {
            return mediaController.IsMediaDeleted(ID);
        }

        public List<MediaDTO> GetAllMedia()
        {
            List<AppController.MediaDTO> mediaControllerList = mediaController.GetAllMedia();
            List<MediaDTO> mediaList = new List<MediaDTO>();
            foreach (AppController.MediaDTO media in mediaControllerList)
            {
                mediaList.Add(new MediaDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget));
            }

            return mediaList;
        }

        public bool IsMediaUpdated(MediaDTO media)
        {
            AppController.MediaDTO mediaFromController = new AppController.MediaDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget);

            return mediaController.IsMediaUpdated(mediaFromController);
        }
    }
}

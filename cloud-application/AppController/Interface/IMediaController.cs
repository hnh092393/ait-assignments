using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IMediaController
    {
        List<MediaDTO> GetAllMedia();
        bool IsMediaInserted(MediaDTO media);
        bool IsMediaUpdated(MediaDTO media);
        bool IsMediaDeleted(int ID);
    }
}

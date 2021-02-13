using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMedia" in both code and config file together.
    [ServiceContract]
    public interface IMedia
    {
        [OperationContract]
        List<MediaDTO> GetAllMedia();

        [OperationContract]
        bool IsMediaInserted(MediaDTO media);

        [OperationContract]
        bool IsMediaUpdated(MediaDTO media);

        [OperationContract]
        bool IsMediaDeleted(int ID);
    }
}

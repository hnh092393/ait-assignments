using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface IDirector
    {
        [OperationContract]
        List<DirectorDTO> GetAllDirector();

        [OperationContract]
        bool IsDirectorInserted(DirectorDTO director);

        [OperationContract]
        bool IsDirectorUpdated(DirectorDTO director);

        [OperationContract]
        bool IsDirectorDeleted(int ID);
    }
}

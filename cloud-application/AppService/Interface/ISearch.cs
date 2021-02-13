using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        [FaultContract(typeof(List<MediaDTO>))]
        List<MediaDTO> Search(string searchType, string searchText);
    }
}

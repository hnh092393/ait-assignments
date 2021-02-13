using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    [ServiceContract]
    public interface IGenre
    {
        [OperationContract]
        List<GenreDTO> GetAllGenre();

        [OperationContract]
        bool IsGenreInserted(GenreDTO genre);

        [OperationContract]
        bool IsGenreUpdated(GenreDTO genre);

        [OperationContract]
        bool IsGenreDeleted(int ID);
    }
}

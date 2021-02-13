using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IDirectorController
    {
        List<DirectorDTO> GetAllDirector();
        bool IsDirectorInserted(DirectorDTO director);
        bool IsDirectorUpdated(DirectorDTO director);
        bool IsDirectorDeleted(int ID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public interface IGenreController
    {
        List<GenreDTO> GetAllGenre();
        bool IsGenreInserted(GenreDTO genre);
        bool IsGenreUpdated(GenreDTO genre);
        bool IsGenreDeleted(int ID);
    }
}

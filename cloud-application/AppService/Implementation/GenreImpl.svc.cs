using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GenreImp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GenreImp.svc or GenreImp.svc.cs at the Solution Explorer and start debugging.
    public class GenreImpl : IGenre
    {
        AppController.IGenreController genreController = new AppController.GenreControllerImpl();
        public bool IsGenreInserted(GenreDTO genre)
        {
            AppController.GenreDTO genreFromController = new AppController.GenreDTO
            {
                GenreName = genre.GenreName
            };
            return genreController.IsGenreInserted(genreFromController);
        }

        public bool IsGenreDeleted(int ID)
        {
            return genreController.IsGenreDeleted(ID);
        }

        public List<GenreDTO> GetAllGenre()
        {
            List<AppController.GenreDTO> genreControllerList = genreController.GetAllGenre();
            List<GenreDTO> genreList = new List<GenreDTO>();
            foreach (AppController.GenreDTO genre in genreControllerList)
            {
                genreList.Add(new GenreDTO(genre.GID, genre.GenreName));
            }

            return genreList;
        }

        public bool IsGenreUpdated(GenreDTO genre)
        {
            AppController.GenreDTO genreFromController = new AppController.GenreDTO
            {
                GID = genre.GID,
                GenreName = genre.GenreName
            };

            return genreController.IsGenreUpdated(genreFromController);
        }
    }
}

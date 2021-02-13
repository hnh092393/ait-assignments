using AppModel;
using AppModel.MediaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class GenreControllerImpl : IGenreController
    {
        MediaDataSet.TabGenreDataTable tabGenreDataTable = new MediaDataSet.TabGenreDataTable();

        TabGenreTableAdapter tabGenreTableAdapter = new TabGenreTableAdapter();


        // get all genre records
        public List<GenreDTO> GetAllGenre()
        {
            // list for storing genre objects
            List<GenreDTO> genreList = new List<GenreDTO>();

            try
            {
                // get all rows in the table using query
                tabGenreTableAdapter.Fill(tabGenreDataTable);

                // converts rows into objects
                foreach (DataRow genreRow in tabGenreDataTable.Rows)
                {
                    GenreDTO genre = new GenreDTO
                    {
                        GID = (int)genreRow[0],
                        GenreName = (string)genreRow[1]
                    };
                    genreList.Add(genre);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return genreList;
        }

        public bool IsGenreDeleted(int ID)
        {
            // delete genre from TabGenre
            tabGenreTableAdapter.DeleteGenre(ID);
            return true;
        }

        // add new genre row into Genre table
        public bool IsGenreInserted(GenreDTO newGenre)
        {

            try
            {
                // insert row using query
                tabGenreTableAdapter.InsertGenre(newGenre.GenreName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // update a genre row
        public bool IsGenreUpdated(GenreDTO updatedGenre)
        {
            try
            {
                // update row using query
                tabGenreTableAdapter.UpdateGenre(updatedGenre.GenreName, updatedGenre.GID);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

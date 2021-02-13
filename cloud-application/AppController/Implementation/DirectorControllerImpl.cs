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
    public class DirectorControllerImpl : IDirectorController
    {
        TabDirectorTableAdapter tabDirectorTableAdapter = new TabDirectorTableAdapter();
        MediaDataSet.TabDirectorDataTable tabDirectorDataTable = new MediaDataSet.TabDirectorDataTable();



        // get all director records
        public List<DirectorDTO> GetAllDirector()
        {
            // list for storing director objects
            List<DirectorDTO> directorList = new List<DirectorDTO>();


            try
            {
                // get all rows in the table using query
                tabDirectorTableAdapter.Fill(tabDirectorDataTable);

                // convert rows into objects
                foreach (DataRow directorRow in tabDirectorDataTable.Rows)
                {
                    DirectorDTO director = new DirectorDTO
                    {
                        DID = (int)directorRow[0],
                        DirectorName = (string)directorRow[1]
                    };

                    directorList.Add(director);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return directorList;
        }

        public bool IsDirectorDeleted(int ID)
        {
            // delete director from TabDirector
            tabDirectorTableAdapter.DeleteDirector(ID);
            return true;
        }

        // add new director row into Director table
        public bool IsDirectorInserted(DirectorDTO newDirector)
        {
            try
            {
                // insert row using query
                tabDirectorTableAdapter.InsertDirector(newDirector.DirectorName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // update a director row
        public bool IsDirectorUpdated(DirectorDTO updatedDirector)
        {
            try
            {
                // update row using query
                tabDirectorTableAdapter.UpdateDirector(updatedDirector.DirectorName, updatedDirector.DID);
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

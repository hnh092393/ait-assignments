using AppModel;
using AppModel.MediaDataSetTableAdapters;
using AppModel.UserDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{

    public class MediaControllerImpl : IMediaController
    {
        MediaDataSet.TabMediaDataTable tabMediaDataTable = new MediaDataSet.TabMediaDataTable();
        TabMediaTableAdapter tabMediaTableAdapter = new TabMediaTableAdapter();

        // get all media records
        public List<MediaDTO> GetAllMedia()
        {
            // list for storing media objects
            List<MediaDTO> mediaList = new List<MediaDTO>();



            try
            {
                // get all rows in the table using query
                tabMediaTableAdapter.Fill(tabMediaDataTable);
                foreach (DataRow mediaRow in tabMediaDataTable.Rows)
                {

                    MediaDTO media = new MediaDTO
                    {
                        MediaID = Convert.ToInt32(mediaRow[0]),
                        Title = mediaRow[1].ToString(),
                        Genre = mediaRow[4].ToString(),
                        Director = mediaRow[6].ToString(),
                        Language = mediaRow[4].ToString(),
                        PublishYear = Convert.ToInt32(mediaRow[2]),
                        Budget = Convert.ToDecimal(mediaRow[3])
                    };

                    mediaList.Add(media);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return mediaList;
        }

        public bool IsMediaDeleted(int ID)
        {
            // delete media from TabMedia
            tabMediaTableAdapter.DeleteMedia(ID);

            // delete borrow record from TabBorrow
            TabBorrowTableAdapter tabBorrowTableAdapter = new TabBorrowTableAdapter();
            tabBorrowTableAdapter.DeleteBorrow(ID);

            // delete reserve record from TabReserved
            TabReservedTableAdapter tabReservedTableAdapter = new TabReservedTableAdapter();
            tabReservedTableAdapter.DeleteReserved(ID);

            return true;
        }

        // add new media row into Media table
        public bool IsMediaInserted(MediaDTO newMedia)
        {

            int dID = GetDID(newMedia.Director);
            int gID = GetGID(newMedia.Genre);
            int lID = GetLID(newMedia.Language);
            try
            {
                if (dID != -1 && gID != -1 && lID != -1)
                {
                    // insert row using query
                    tabMediaTableAdapter.InsertMedia(newMedia.Title, gID, dID, lID, newMedia.PublishYear, newMedia.Budget);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // update a media row
        public bool IsMediaUpdated(MediaDTO updatedMedia)
        {
            // get stored info from other tables
            int newDID = GetDID(updatedMedia.Director);
            int newGID = GetGID(updatedMedia.Genre);
            int newLID = GetLID(updatedMedia.Language);

            try
            {
                if (newDID != -1 && newGID != -1 && newLID != -1)
                {
                    // update row using query
                    tabMediaTableAdapter.UpdateMedia(updatedMedia.Title, newGID, newDID, newLID, updatedMedia.PublishYear, updatedMedia.Budget, updatedMedia.MediaID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        // get director ID based on director name
        public static int GetDID(string directorName)
        {
            int dID = -1;

            MediaDataSet.TabDirectorDataTable tabDirectorDataTable = new MediaDataSet.TabDirectorDataTable();
            TabDirectorTableAdapter tabDirectorTableAdapter = new TabDirectorTableAdapter();

            try
            {
                // retrieve data from database
                tabDirectorTableAdapter.SelectDirector(tabDirectorDataTable, directorName);

                // convert data into int
                dID = (int)tabDirectorDataTable.Rows[0]["DID"];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(directorName + " cannot be found in the database.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dID;
        }

        // get genre ID based on genre name 
        public static int GetGID(string genreName)
        {
            int gID = -1;

            MediaDataSet.TabGenreDataTable tabGenreDataTable = new MediaDataSet.TabGenreDataTable();
            TabGenreTableAdapter tabGenreTableAdapter = new TabGenreTableAdapter();

            try
            {
                // retrieve data from database
                tabGenreTableAdapter.SelectGenre(tabGenreDataTable, genreName);

                // convert data into int
                gID = (int)tabGenreDataTable.Rows[0]["GID"];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(genreName + " cannot be found in the database.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return gID;
        }

        // get language ID based on language name
        public static int GetLID(string languageName)
        {
            int lID = -1;

            MediaDataSet.TabLanguageDataTable tabLanguageDataTable = new MediaDataSet.TabLanguageDataTable();
            TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();

            try
            {
                // retrieve data from database
                tabLanguageTableAdapter.SelectLanguage(tabLanguageDataTable, languageName);

                // convert data into int
                lID = (int)tabLanguageDataTable.Rows[0]["LID"];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(languageName + " cannot be found in the database.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lID;
        }
    }
}

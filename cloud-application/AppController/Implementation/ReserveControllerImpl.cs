using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AppModel;
using AppModel.MediaDataSetTableAdapters;
using AppModel.UserDataSetTableAdapters;

namespace AppController
{
    public class ReserveControllerImpl : IReserveController
    {
        UserDataSet.TabReservedDataTable tabReservedDataTable = new UserDataSet.TabReservedDataTable();
        TabReservedTableAdapter tabReservedTableAdapter = new TabReservedTableAdapter();

        // get the list of reserved media, including additional info
        public List<ReserveDTO> GetReservedInfo()
        {
            List<ReserveDTO> ReservedMediaList = new List<ReserveDTO>();
            try
            {
                //Query get reservation records
                tabReservedTableAdapter.SelectReserved(tabReservedDataTable);
                foreach (DataRow reservedRow in tabReservedDataTable.Rows)
                {
                    int uID = (int)reservedRow["UID"];
                    int mediaID = (int)reservedRow["MediaID"];
                    string title = "";
                    string userName = "";

                    // get title of reserved media
                    MediaDataSet.TabMediaDataTable tabMediaDataTable = new MediaDataSet.TabMediaDataTable();
                    TabMediaTableAdapter tabMediaTableAdapter = new TabMediaTableAdapter();
                    tabMediaTableAdapter.SelectMediaByMediaID(tabMediaDataTable, mediaID);
                    foreach (DataRow mediaRow in tabMediaDataTable.Rows)
                    {
                        title = (string)mediaRow["Title"];
                    }

                    // get name of user who reserved the media
                    UserDataSet.TabUserDataTable tabUserDataTable = new UserDataSet.TabUserDataTable();
                    TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                    tabUserTableAdapter.SelectUserByUID(tabUserDataTable, uID);
                    foreach (DataRow userRow in tabUserDataTable.Rows)
                    {
                        userName = (string)userRow["UserName"];
                    }

                    ReservedMediaList.Add(new ReserveDTO(userName, title, reservedRow["ReservedDate"].ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ReservedMediaList;
        }

        // get the list of borrowed media, including user ID and media ID
        public List<KeyValuePair<int, int>> GetReservedData()
        {
            List<KeyValuePair<int, int>> ReservedMediaList = new List<KeyValuePair<int, int>>();
            try
            {
                // get data from Reserved table
                tabReservedTableAdapter.SelectReserved(tabReservedDataTable);
                foreach (DataRow reservedRow in tabReservedDataTable.Rows)
                {
                    ReservedMediaList.Add(new KeyValuePair<int, int>((int)reservedRow["UID"], (int)reservedRow["MediaID"]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ReservedMediaList;
        }

        // insert data when a media is reserved
        public bool IsReservedInserted(int uID, int mediaID, string reservedDate)
        {
            try
            {
                // insert row using query
                tabReservedTableAdapter.InsertReserved(uID, mediaID, reservedDate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // delete data when a media reserve is removed 
        public bool IsReservedDeleted(int mediaID)
        {
            try
            {
                // delete row using query
                tabReservedTableAdapter.DeleteReserved(mediaID);
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

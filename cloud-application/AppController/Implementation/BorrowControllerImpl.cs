using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModel;
using AppModel.MediaDataSetTableAdapters;
using AppModel.UserDataSetTableAdapters;

namespace AppController
{ 
    public class BorrowControllerImpl : IBorrowController
    {
        // data table and adapter for retrieving data from AppModel
        UserDataSet.TabBorrowDataTable tabBorrowDataTable = new UserDataSet.TabBorrowDataTable();
        TabBorrowTableAdapter tabBorrowTableAdapter = new TabBorrowTableAdapter();

        // get the list of borrowed media, including user ID and media ID
        public List<KeyValuePair<int, int>> GetBorrowData()
        {
            // list of borrowed media with raw data
            List<KeyValuePair<int, int>> BorrowedMediaList = new List<KeyValuePair<int, int>>();

            try
            {
                // get data from Borrow Table
                tabBorrowTableAdapter.SelectBorrow(tabBorrowDataTable);

                // assign each data row to an item of BorrowedMediaList
                foreach (DataRow borrowRow in tabBorrowDataTable.Rows)
                {
                    //string DefaultReturnDate = "1/1/2000 12:00:00 AM";
                    //string ActualReturnDate = Row["ActualReturnDate"].ToString();
                    //if (ActualReturnDate == DefaultReturnDate)
                    //{
                    //}

                    BorrowedMediaList.Add(new KeyValuePair<int, int>((int)borrowRow["UID"], (int)borrowRow["MediaID"]));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return BorrowedMediaList;
        }

        // get the list of borrowed media, including additional information
        public List<BorrowDTO> GetBorrowInfo()
        {
            // list of borrowed media with full info
            List<BorrowDTO> BorrowedMediaList = new List<BorrowDTO>();

            try
            {
                // get data from Borrow Table
                tabBorrowTableAdapter.SelectBorrow(tabBorrowDataTable);

                // assign each data row to an item of BorrowedMediaList
                foreach (DataRow borrowRow in tabBorrowDataTable.Rows)
                {
                    int uID = (int)borrowRow["UID"];
                    int mediaID = (int)borrowRow["MediaID"];
                    string title = "";
                    string userName = "";

                    // get title of borrowed media
                    MediaDataSet.TabMediaDataTable tabMediaDataTable = new MediaDataSet.TabMediaDataTable();
                    TabMediaTableAdapter tabMediaTableAdapter = new TabMediaTableAdapter();
                    tabMediaTableAdapter.SelectMediaByMediaID(tabMediaDataTable, mediaID);
                    foreach (DataRow mediaRow in tabMediaDataTable.Rows)
                    {
                        title = (string)mediaRow["Title"];
                    }

                    // get name of user who borrowed the media
                    UserDataSet.TabUserDataTable tabUserDataTable = new UserDataSet.TabUserDataTable();
                    TabUserTableAdapter UserAdapter = new TabUserTableAdapter();
                    UserAdapter.SelectUserByUID(tabUserDataTable, uID);
                    foreach (DataRow userRow in tabUserDataTable.Rows)
                    {
                        userName = (string)userRow["UserName"];
                    }

                    BorrowedMediaList.Add(new BorrowDTO(userName, title, borrowRow["BorrowDate"].ToString(), borrowRow["ReturnDate"].ToString(), borrowRow["ActualReturnDate"].ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return BorrowedMediaList;
        }

        // insert data when a media is borrowed
        public bool IsBorrowInserted(int UID, int MediaId, string BorrowDate, string ReturnDate)
        {
            try
            {
                // add new borrowed media to borrow table
                tabBorrowTableAdapter.InsertBorrow(UID, MediaId, BorrowDate, ReturnDate);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // change data when a media is returned
        public bool IsBorrowUpdated(string ActualReturnDate, int MediaID)
        {
            try
            {
                // set actual return date
                tabBorrowTableAdapter.UpdateBorrow(ActualReturnDate, MediaID);
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

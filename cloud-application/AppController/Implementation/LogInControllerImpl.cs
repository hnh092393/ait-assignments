using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModel;
using AppModel.UserDataSetTableAdapters;

namespace AppController
{
    public class LogInControllerImpl : ILogInController
    {
        UserDataSet.TabUserDataTable tabUserDataTable = new UserDataSet.TabUserDataTable();
        TabUserTableAdapter tabUserAdapter = new TabUserTableAdapter();

        // get user ID based on user name
        public int GetUID(string userName)
        {
            int uID = -1;

            try
            {
                // get UID using query
                tabUserAdapter.SelectUserByUserName(tabUserDataTable, userName);
                foreach (DataRow Row in tabUserDataTable.Rows)
                {
                    uID = (int)Row["UID"];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return uID;
        }

        public bool ValidateUser(UserDTO user)
        {
            int numberOfUser = 0;
            try
            {
                // count number of users that have same username and password
                numberOfUser = (int)tabUserAdapter.CountUser(user.UserName, user.Password);

                // log in is valid if there is a matched record
                if (numberOfUser != 0)
                {
                    return true;
                }
            }
            catch ( SystemException e)
            {
                Console.WriteLine("Cannot connect to the database" + e.Message);
            }

            return false;
        }
    }
}

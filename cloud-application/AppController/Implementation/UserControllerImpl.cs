using AppModel;
using AppModel.UserDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class UserControllerImpl : IUserController
    {
        TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
        UserDataSet.TabUserDataTable tabUserDataTable = new UserDataSet.TabUserDataTable();


        // get all user records
        public List<UserDTO> GetAllUser()
        {
            // list for storing user objects
            List<UserDTO> userList = new List<UserDTO>();

            try
            {
                // get all rows in the table using query
                tabUserTableAdapter.Fill(tabUserDataTable);

                // convert rows into objects
                foreach (DataRow userRow in tabUserDataTable.Rows)
                {

                    UserDTO user = new UserDTO
                    {
                        UID = (int)userRow[0],
                        UserName = (string)userRow[1],
                        Password = (string)userRow[2],
                        UserLevel = (int)userRow[3],
                        UserEmail = (string)userRow[4]
                    };
                    userList.Add(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return userList;
        }

        public bool IsUserDeleted(int ID)
        {
            // delete user from TabUser
            tabUserTableAdapter.DeleteUser(ID);
            return true;
        }

        // add new user row into User table
        public bool IsUserInserted(UserDTO newUser)
        {

            try
            {
                //if (!newUser.UserName.ToLower().Contains("admin") || !newUser.UserName.ToLower().Contains("user") || !newUser.UserName.ToLower().Contains("sup"))
                //{
                //    MessageBox.Show("User Name must contain 'user' or 'admin' or 'sup' ");
                //    return false;
                //}
                //else
                //{
                //}

                // insert row using query
                tabUserTableAdapter.InsertUser(newUser.UserName, newUser.Password, newUser.UserLevel, newUser.UserEmail);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool IsUserUpdated(UserDTO updatedUser)
        {
            try
            {
                // update row using query
                tabUserTableAdapter.UpdateUser(updatedUser.UserName, updatedUser.Password, updatedUser.UserLevel, updatedUser.UserEmail, updatedUser.UID);
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

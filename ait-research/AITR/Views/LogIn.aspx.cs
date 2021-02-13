using AITR.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR.Views
{
    public partial class LogIn : System.Web.UI.Page
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            // ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }



        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (DbUtilities.ValidateUser(username, password))
                {
                    Session["Username"] = username;
                    Response.Redirect("~/Views/Search.aspx");
                }
                else
                {
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }

            }

        }
    }
}
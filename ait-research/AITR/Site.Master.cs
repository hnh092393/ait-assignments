using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(null != Session["Username"])
            {
                btnLogIn.Text = "Log Out";
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            // cancel the current session
            Session.Abandon();

            // return to log in page
            Response.Redirect("LogIn.aspx");
        }
    }
}
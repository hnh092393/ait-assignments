using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR.Views
{
    public partial class End : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Thank you, " + Session["UFirstName" + " !"];
        }

        protected void btnLogInPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LogIn.aspx");
        }

        protected void btnRegisterPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }

        protected void btnAnswerPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Result.aspx");
        }
    }
}
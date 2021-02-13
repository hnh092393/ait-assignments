using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR.UserControls
{
    public partial class TextBoxUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // change question content
        public void SetQuestion(string text)
        {
            lblQuestion.Text = text;
        }

        // retrieve answer content
        public string GetAnswer()
        {
            return txtAnswer.Text;
        }
    }
}
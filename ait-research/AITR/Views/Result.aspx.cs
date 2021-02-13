using AITR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR.Views
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Answer> answerList = (List<Models.Answer>)Session["AnswerList"];
            foreach (Answer answer in answerList)
            {
                TableRow row = new TableRow();

                //Create a column question id
                TableCell questionCell = new TableCell();
                questionCell.Text = answer.QuestionID.ToString();
                //Add a column to table
                row.Cells.Add(questionCell);

                TableCell answerCell = new TableCell();
                answerCell.Text = answer.AnswerContent;
                //Add a column to table
                row.Cells.Add(answerCell);

                tblAnswer.Rows.Add(row);
               
            }
        }

    }
}
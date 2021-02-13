using AITR.Models;
using AITR.Utilities;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace AITR.Views
{
    public partial class Register : System.Web.UI.Page
    {
        public object DAUtilities { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // hide calendar if this is an initial load
                calendar.Visible = false;
            }
        }

        // when calendar button is clicked
        protected void btnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            // show or hide the calendar
            if (calendar.Visible)
            {
                calendar.Visible = false;
            }
            else
            {
                calendar.Visible = true;
            }
        }

        // when a date on the calendar is selected
        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            // show the selected date on the corresponding textbox
            txtDOB.Text = calendar.SelectedDate.ToShortDateString();

            // hide the calendar
            calendar.Visible = false;
        }

        // when submit button is clicked
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // check if all fields are filled
            if (Page.IsValid)
            {
                // retrieve a list of respondent from current session
                List<Respondent> respondentList = (List<Respondent>)Session["respondentList"];

                // if there is no respondent list in the session
                if (respondentList == null)
                {
                    // create a respondent list
                    respondentList = new List<Respondent>();

                    // save the list to the current session
                    Session["respondentList"] = respondentList;
                }

                // generate a new respondent based on user inputs
                Respondent respondent = new Respondent
                {
                    RespondentFirstName = txtFirstName.Text,
                    RespondentLastName = txtLastName.Text,
                    RespondentEmail = txtEmail.Text,
                    RespondentPhone = txtPhone.Text,
                    RespondentDOB = txtDOB.Text,
                };

                // add the respondent to the list
                respondentList.Add(respondent);

                // insert respondent into database
                DbUtilities.InsertRespondent(respondent);
            }
        }
    }
}
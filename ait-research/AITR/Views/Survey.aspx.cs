using AITR.Models;
using AITR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR.Views
{
    public partial class Survey : System.Web.UI.Page
    {
        private int nextQuestionID = 1;

        // present question and corresponding options in the placeholder
        protected void Page_Load(object sender, EventArgs e)
        {
            Stack<int> nextQuestionIDs = (Stack<int>)Session["NextQIDs"];
            if (nextQuestionIDs == null)
            {
                nextQuestionIDs = new Stack<int>();

                nextQuestionIDs.Push(1);
                Session["NextQIDs"] = nextQuestionIDs;
            }

            if (nextQuestionIDs.Count() > 0)
            {
                // get the first element out of the stack
                nextQuestionID = nextQuestionIDs.Peek();
            }

            Question question = DbUtilities.GetQuestion(nextQuestionID);
            lblQuestion.Text = question.QuestionContent;

            if (question != null)
            {
                if ("textbox".Equals(question.QuestionType))
                {
                    TextBox answerTextbox = new TextBox();
                    answerTextbox.ID = "txtOption";
                    phQuestion.Controls.Add(answerTextbox);

                    Session["QTypeID"] = answerTextbox.ID;
                }
                else if ("checkbox".Equals(question.QuestionType))
                {
                    CheckBoxList checkBoxList = new CheckBoxList();
                    checkBoxList.ID = "cblOption";
                    List<Option> options = DbUtilities.GetOptionList(nextQuestionID);

                    foreach (Option option in options)
                    {
                        ListItem item = new ListItem(option.OptionContent);
                        if (option.NextQuestionID != null)
                        {
                            item.Attributes.Add("NextQID", option.NextQuestionID.ToString());
                        }
                        checkBoxList.Items.Add(item);
                    }
                    Session["QTypeID"] = checkBoxList.ID;
                    phQuestion.Controls.Add(checkBoxList);
                }
                else if ("radio".Equals(question.QuestionType))
                {
                    RadioButtonList radioList = new RadioButtonList();
                    radioList.ID = "rblOption";
                    List<Option> options = DbUtilities.GetOptionList(nextQuestionID);

                    foreach (Option option in options)
                    {
                        ListItem item = new ListItem(option.OptionContent);
                        if (option.NextQuestionID != null)
                        {
                            item.Attributes.Add("NextQID", option.NextQuestionID.ToString());
                        }
                        radioList.Items.Add(item);
                    }
                    Session["QTypeID"] = radioList.ID;
                    phQuestion.Controls.Add(radioList);
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Stack<int> nextQuestionIDs = (Stack<int>)Session["NextQIDs"];
            int currentQuestionID = nextQuestionIDs.Pop();

            Question question = DbUtilities.GetQuestion(currentQuestionID);
            if (question.NextQuestionID != null)
            {
                if (!nextQuestionIDs.Contains((int)question.NextQuestionID))
                {
                    nextQuestionIDs.Push((int)question.NextQuestionID);
                }
            }

            Session["NextQIDs"] = nextQuestionIDs;

            // access question answer from session
            List<Answer> answers = (List<Answer>)Session["AnswerList"];
            if (answers == null)
            {
                answers = new List<Answer>();
                Session["AnswerList"] = answers;
            }

            // access the current question from placeholder 
            Control controls = phQuestion.FindControl(Session["QTypeID"].ToString());
            if (controls is TextBox)
            {
                TextBox txtOption = (TextBox)controls;
                // put answer to session 
                Session["Answer"] = txtOption.Text;
                DbUtilities.InsertAnswer(currentQuestionID, txtOption.Text);

                Answer answer = new Answer();
                answer.AnswerContent = txtOption.Text; ;
                answer.QuestionID = currentQuestionID;
                answers.Add(answer);
            }
            else if (controls is CheckBoxList)
            {
                CheckBoxList checkBoxList = (CheckBoxList)controls;
                foreach (ListItem checkBox in checkBoxList.Items)
                {
                    if (checkBox.Selected)
                    {
                        Answer answer = new Answer();
                        answer.AnswerContent = checkBox.Text;
                        answer.QuestionID = currentQuestionID;
                        answers.Add(answer);

                        if (checkBox.Attributes["NextQID"] != null)
                        {
                            nextQuestionIDs.Push(int.Parse(checkBox.Attributes["NextQID"]));
                        }
                        DbUtilities.InsertAnswer(currentQuestionID, checkBox.Text);
                    }

                }
            }
            else if (controls is RadioButtonList)
            {
                RadioButtonList radioList = (RadioButtonList)controls;
                foreach (ListItem radio in radioList.Items)
                {
                    if (radio.Selected)
                    {
                        Answer answer = new Answer();
                        answer.AnswerContent = radio.Text;
                        answer.QuestionID = currentQuestionID;
                        answers.Add(answer);

                        if (radio.Attributes["NextQID"] != null)
                        {
                            nextQuestionIDs.Push(int.Parse(radio.Attributes["NextQID"]));
                        }
                        DbUtilities.InsertAnswer(currentQuestionID, radio.Text);
                    }
                }
            }

            if (nextQuestionIDs.Count() == 0)
            {
                Response.Redirect("~/Views/End.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Survey.aspx");
            }
        }
    }
}
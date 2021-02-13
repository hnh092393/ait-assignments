using AITR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AITR.Utilities
{
    public class DbUtilities
    {
        // get database credentials
        public static String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // get question objects from database
        public static Question GetQuestion(int questionID)
        {
            // connection closed no matter what happens
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // query to select rows with given ID
                String query = "select * from [Question] where QID = " + questionID;

                // command for getting data
                SqlCommand command = new SqlCommand(query, connection);

                // make connection to database
                connection.Open();

                // execute the command
                SqlDataReader reader = command.ExecuteReader();

                // true if number of rows > 0
                if (reader.Read())
                {
                    Question question = new Question
                    {
                        QuestionID = (int)reader["QID"],
                        QuestionContent = (string)reader["QContent"].ToString(),
                        QuestionType = (string)reader["QType"].ToString(),

                        // null-able if this is the final question
                        NextQuestionID = reader["QNext"] as int?,
                    };

                    return question;
                }
            }

            return null;
        }

        // get a list of options corresponding to a question
        public static List<Option> GetOptionList(int questionID)
        {
            List<Option> options = new List<Option>();

            // connection closed no matter what happens
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // query to select rows with given question ID
                String query = "select * from [Option] where QID = " + questionID;

                // make connection to database
                connection.Open();

                // command for getting data
                SqlCommand command = new SqlCommand(query, connection);



                // execute the command 
                SqlDataReader reader = command.ExecuteReader();

                // keep reading rows till the end
                while (reader.Read())
                {
                    // create new option for each iteration
                    Option option = new Option
                    {
                        OptionID = (int)reader["OID"],
                        OptionContent = (string)reader["OContent"].ToString(),
                        QuestionID = (int)reader["QID"],

                        // null-able if this is the final option of the final question
                        NextQuestionID = reader["QNext"] as int?,
                    };

                    // add the option to list each iteration
                    options.Add(option);
                }
                return options;
            }
        }

        // record answers to database
        public static void InsertAnswer(int questionID, string answer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // query to insert new answer rows
                string query = "insert into [Answer] (AContent, QID) values (@answer, @questionID)";

                SqlCommand command = new SqlCommand(query, connection);

                // make connection to database
                connection.Open();

                // execute command
                command.Parameters.AddWithValue("@answer", answer);
                command.Parameters.AddWithValue("@questionID", questionID);
                command.ExecuteNonQuery();
            }
        }

        // validate staff login
        public static bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // query to count records that have the same user-name and password
                string query = "select count(*) from [User] where UUsername = @username and UPassword = @password";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                // add parameter values to the query
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // run command the count
                int userCount = (int)command.ExecuteScalar();

                // return true if a matched record is found
                return (userCount == 1);
            }
        }



        // retrieve all respondents
        public static void GetAllUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from [Respondent]";
            }
        }

        // insert new respondent to database
        public static void InsertRespondent(Respondent respondent)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into [Respondent] (RIP, RFirstName, RLastName, REmail, RDOB, RPhone) values (@ipAddress, @firstName, @lastName, @email, @dob, @phone)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                command.Parameters.AddWithValue("@ipAddress", GetUserIP());
                command.Parameters.AddWithValue("@firstName", respondent.RespondentFirstName);
                command.Parameters.AddWithValue("@lastName", respondent.RespondentLastName);
                command.Parameters.AddWithValue("@email", respondent.RespondentEmail);
                command.Parameters.AddWithValue("@dob", respondent.RespondentDOB);
                command.Parameters.AddWithValue("@phone", respondent.RespondentPhone);

                command.ExecuteNonQuery();
            }
        }

        protected static string GetUserIP()
        {
            string userIP = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                userIP = HttpContext.Current.Request.UserHostAddress;
            }
            return userIP;
        }

    }
}
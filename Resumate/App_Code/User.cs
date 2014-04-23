using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataLayer;


namespace UserLayer
{
    public class user
    {
        private string id;
        private string username;
        private string password;
        private string email;
        private string firstName;
        private string middleName;
        private string lastName;
        private string homeAddress;
        private string phoneAddress;
        private string faxNumber;
        private string mobileNumber;
        private string homePage;

        public user()
        {
            id = "";
            username = "";
            password = "";
            email = "";
            firstName = "";
            middleName = "";
            lastName = "";
            homeAddress = "";
            phoneAddress = "";
            faxNumber = "";
            mobileNumber = "";
            homePage = "";
        }

        // adds the user to the databse (sign up)
        public bool AddUser(string username, string password, string email)
        {
            DataLayer.SQLConnection conn = new SQLConnection();

            string sql = "INSERT INTO users (username, password, email) VALUES ('" 
                + username + "','" + password + "','" + email + "')";

            if(conn.ExcuteAction(sql)>0)
                return true;
            else
                return false;
        }



        // try to locate the user using a pair of username and password
        public bool IsFound(string username, string password)
        {

            DataLayer.SQLConnection conn = new SQLConnection();

            DataTableCollection userInfo = conn.ExcuteSelect("SELECT * FROM users WHERE username = '"
                + username + "' AND password ='" + password + "'");

            if (userInfo[0].Rows.Count < 1)
                return false;
            else
                return true;
        }



        // returns true if the given username is used by another user and false otherwise
        public bool usernameExists(string username)
        {

            DataLayer.SQLConnection conn = new SQLConnection();

            DataTableCollection userInfo = conn.ExcuteSelect("SELECT * FROM users WHERE username = '"
                + username + "'");

            if (userInfo[0].Rows.Count < 1)
                return false;
            else
                return true;
        }


        // returns true if the given email is used by another user and false otherwise
        public bool emailExists(string email)
        {

            DataLayer.SQLConnection conn = new SQLConnection();

            DataTableCollection userInfo = conn.ExcuteSelect("SELECT * FROM users WHERE email = '"
                + email + "'");

            if (userInfo[0].Rows.Count < 1)
                return false;
            else
                return true;
        }




        // returns a dictionary of the user's info using username
        public DataTableCollection getUserInfoByUsername(string username)
        {
            DataLayer.SQLConnection conn = new SQLConnection();

            return conn.ExcuteSelect("SELECT * FROM users WHERE username = '" + username + "'");
        }



        // returns a dictionary of the user's info using userID
        public DataTableCollection getUserInfoByID(string userID)
        {
            DataLayer.SQLConnection conn = new SQLConnection();

            return conn.ExcuteSelect("SELECT * FROM users WHERE id = '" + userID + "'");
        }


        public void PopulateUserObjectByID(string id)
        {
            DataTableCollection TableFromSQL = this.getUserInfoByID(id);

            for (int i = 0; i < TableFromSQL[0].Rows[0].ItemArray.Length; i++)
            {
                string value = TableFromSQL[0].Rows[0].ItemArray[i].ToString();
                string key = TableFromSQL[0].Columns[i].ColumnName;

                if (key.Equals("id")) id = value;
                else if (key.Equals("username")) username = value;
                else if (key.Equals("password")) password = value;
                else if (key.Equals("email")) email = value;
                else if (key.Equals("firstName")) firstName = value;
                else if (key.Equals("middleName")) middleName = value;
                else if (key.Equals("lastName")) lastName = value;
                else if (key.Equals("homeAddress")) homeAddress = value;
                else if (key.Equals("phoneAddress")) phoneAddress = value;
                else if (key.Equals("faxNumber")) faxNumber = value;
                else if (key.Equals("mobileNumber")) mobileNumber = value;
                else if (key.Equals("homePage")) homePage = value;
                else { }
            }
        }


        // return a customized grreting message based on the user current status (logged in or not) 
        public string GetGreeting(bool loggedIn)
        {
            if (!loggedIn)
            {
                return "Welcome Guest!";
            }
            else
            {
                if (firstName.Length > 0 && lastName.Length > 0)
                    return "Welcome " + firstName + " " + lastName + "! <span style='color:#000000'>|</span> <a href='Info.aspx'>User Info</a> <span style='color:#000000'>|</span> <a href='Logout.aspx'>Logout</a>";
                else if (firstName.Length > 0)
                    return "Welcome " + firstName + "! <span style='color:#000000'>|</span> <a href='Info.aspx'>User Info</a> <span style='color:#000000'>|</span> <a href='Logout.aspx'>Logout</a>";
                else if (lastName.Length > 0)
                    return "Welcome " + lastName + "! <span style='color:#000000'>|</span> <a href='Info.aspx'>User Info</a> <span style='color:#000000'>|</span> <a href='Logout.aspx'>Logout</a>";
                else
                    return "Welcome Member! <span style='color:#000000'>|</span> <a href='Info.aspx'>User Info</a> <span style='color:#000000'>|</span> <a href='Logout.aspx'>Logout</a>";
            }
        }
    }
}
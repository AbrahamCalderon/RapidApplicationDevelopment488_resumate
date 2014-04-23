using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserLayer;
using DataLayer;


public partial class MyAccount : System.Web.UI.Page
{
    private user thisUser = new user();

    protected void Page_Load(object sender, EventArgs e)
    {        
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
        // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            layout_welcomeCenter.InnerHtml = thisUser.GetGreeting(false);
            Response.Redirect("Default.aspx");
        }
        else
        {
            // GATHER THIS USER'S INFO (IF LOGGED IN)
            thisUser.PopulateUserObjectByID(Session["userID"].ToString());
            layout_welcomeCenter.InnerHtml = thisUser.GetGreeting(true);
        }


        // ONCE PAGE IS LOADED, INQURE THE DATABASE TO COLLECT LIST OF RESUMES FOR THIS USER
        DataLayer.SQLConnection conn = new SQLConnection();
        DataTableCollection TableFromSQL = conn.ExcuteSelect("SELECT * FROM resumes WHERE userID = '" 
            + Session["userID"].ToString() + "'");

        int resumesFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisResumeID = "";
            string thisResumeDate = "";
            string thisResumeName = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
               string key = TableFromSQL[0].Columns[j].ColumnName;

               if (key.Equals("id"))
                   thisResumeID = value;
               else if (key.Equals("name"))
                   thisResumeName = value;
               else if (key.Equals("dateCreated"))
                   thisResumeDate = value;
               else { }
            }

            resumesFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + resumesFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisResumeName +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisResumeDate +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='DeleteResume.aspx?id=" + thisResumeID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></td>";
        }

        if (resumesFound < 1)
            list = "<tr><td colspan='4'>You currently have (0) resumes in your profile</td></tr>";

        myAccount_listWrapper.InnerHtml = "<table class='myAccount_viewTable' cellpadding='4' cellspacing='0' bgcolor='#ffffff' border='1'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td> "
            + "<td class='myAccount_viewTableHeaderCell' width='60%'>Name</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Delete</td></tr>" + list + "</table>";
    }
}
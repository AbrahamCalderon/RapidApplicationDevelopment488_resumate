using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserLayer;
using DataLayer;

public partial class Customize : System.Web.UI.Page
{
    private user thisUser = new user();
    SQLConnection sc = new SQLConnection();

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

            populateResumesList();
        }
    }

    protected void populateResumesList()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT name, id FROM resumes WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY dateCreated DESC");


        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisName = "";
            string thisID = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisID = value;
                else
                    thisName = value;
            }

            ResumesDropDownList.Items.Add(new ListItem(thisName, thisID));
        }   
    }

    protected void LoadResume(object sender, EventArgs e)
    {
        Session["openResumeID"] = ResumesDropDownList.SelectedItem.Value;
        Response.Redirect("EditResume.aspx");
    }
}
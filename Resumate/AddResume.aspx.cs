using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class AddResume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
        // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            Response.Redirect("MyAccount.aspx#List");
        }
    }
    protected void Add(object sender, EventArgs e)
    {
        if (name.Text.Length < 1)
        {
            errorLabe.Text = "Enter Network Name";
            name.Focus();
        }
        else
        {
            errorLabe.Text = "";
            SQLConnection sc = new SQLConnection();
            string userID = Session["userID"].ToString();
            string date = DateTime.Now.ToString("yyyy-MM-dd"); ;

            Utilities.ConvertIn(this);

            sc.ExcuteAction("INSERT INTO resumes (userID, name, templateID, dateCreated)" +
            " VALUES ('" + userID + "', '"
            + name.Text + "', '"
            + "0" + "', '"
            + date + "')");

            Response.Redirect("MyAccount.aspx#List");
        }
    }
}
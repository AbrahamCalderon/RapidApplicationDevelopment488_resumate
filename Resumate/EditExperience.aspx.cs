using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class EditExperiences : System.Web.UI.Page
{
    SQLConnection sc = new SQLConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
        // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            Response.Redirect("Create.aspx#Experiances");
        }

        if (!Page.IsPostBack)
        {
            PopulateExperienceData();
        }
    }

    protected void Update(object sender, EventArgs e)
    {
        // Validate the page.
        Page.Validate();

        // If the page is valid, send the user to the next step.
        if (Page.IsValid)
        {
            Utilities.ConvertIn(this);

            sc.ExcuteAction("UPDATE experiances SET " +
                "title='" + title.Text.ToString() +
                "', description='" + description.Text.ToString() +
                "' where id=" + Request.QueryString["id"] + " AND userID=" + Session["userID"]);

            Response.Redirect("Create.aspx#Experiances");
        }
    }

    private void PopulateExperienceData()
    {
        DataSet ds = sc.ExcuteSelectDS("select * from experiances where id=" + Request.QueryString["id"]);

        DataRow results = ds.Tables[0].Rows[0];
        title.Text = results["title"].ToString();
        description.Text = results["description"].ToString();

        Utilities.ConvertOut(this);
    }
}
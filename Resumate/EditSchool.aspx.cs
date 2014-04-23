using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class EditSchool : System.Web.UI.Page
{
    SQLConnection sc = new SQLConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
        // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            Response.Redirect("Create.aspx#Education");
        }

        if (!Page.IsPostBack)
        {
            PopulateSchoolData();
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

            sc.ExcuteAction("UPDATE schools SET " +
                "school='" + name.Text.ToString() +
                "', degree='" + degree.Text.ToString() +
                "', major='" + major.Text.ToString() +
                "', gpa='" + gpa.Text.ToString() +
                "', startDate='" + startDate.Text.ToString() +
                "', endDate='" + endDate.Text.ToString() +
                "', city='" + city.Text.ToString() +
                "', state='" + state.Text.ToString() +
                "', country='" + country.Text.ToString() +
                "' where id=" + Request.QueryString["id"] + " AND userID=" + Session["userID"]);

            Response.Redirect("Create.aspx#Education");
        }
    }

    private void PopulateSchoolData()
    {
        DataSet ds = sc.ExcuteSelectDS("select * from schools where id=" + Request.QueryString["id"]);

        DataRow results = ds.Tables[0].Rows[0];
        name.Text = results["school"].ToString();
        degree.Text = results["degree"].ToString();
        major.Text = results["major"].ToString();
        gpa.Text = results["gpa"].ToString();
        startDate.Text = results["startDate"].ToString();
        endDate.Text = results["endDate"].ToString();
        city.Text = results["city"].ToString();
        state.Text = results["state"].ToString();
        country.Text = results["country"].ToString();

        Utilities.ConvertOut(this);
    }
}
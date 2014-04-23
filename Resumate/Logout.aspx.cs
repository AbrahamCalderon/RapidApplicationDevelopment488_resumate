using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USER IS AUTHINICATED.
        // IF USER IS AUTHINICATED, SIGN OFF
        if (Session["authenticated"] != null && (string)Session["authenticated"] == "YES")
        {
            Session["authenticated"] = "NO";
        }

        Response.Redirect("Default.aspx");
    }
}
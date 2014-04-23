﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class DeleteResume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
        // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            Response.Redirect("MyAccount.aspx#List");
        }
        else
        {
            SQLConnection sc = new SQLConnection();
            string id = Request.QueryString["id"];

            if (id.Length > 0)
            {
                string userID = Session["userID"].ToString();
                sc.ExcuteAction("DELETE FROM resumes WHERE userID = '" + userID + "' AND id = '" + id + "'");
            }

            Response.Redirect("MyAccount.aspx#List");
        }
    }
}
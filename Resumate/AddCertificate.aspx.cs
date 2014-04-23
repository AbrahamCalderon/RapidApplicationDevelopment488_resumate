using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class AddCertificate : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

      // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
      // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
      if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
      {
          Response.Redirect("Create.aspx#Certificates");
      }
   }

   protected void Add(object sender, EventArgs e)
   {
      if (title.Text.Length < 1)
      {
         errorLabe.Text = "Enter Title";
         title.Focus();
      }
      else if (description.Text.Length < 1)
      {
         errorLabe.Text = "Enter Desription";
         description.Focus();
      }
      else if (dateObtained.Text.Length < 1)
      {
         errorLabe.Text = "Enter Date Obtained";
         dateObtained.Focus();
      }
      else
      {
         errorLabe.Text = "";
         SQLConnection sc = new SQLConnection();
         string userID = Session["userID"].ToString();

         Utilities.ConvertIn(this);

         sc.ExcuteAction("INSERT INTO certificates (userID, title, description, dateObtained)" +
         " VALUES ('" + userID + "', '"
         + title.Text + "', '"
         + description.Text + "', '"
         + dateObtained.Text + "')");

         Response.Redirect("Create.aspx#Certificates");
      }
   }
}
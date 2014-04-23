using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class AddSocialNetwork : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

      // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
      // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
      if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
      {
          Response.Redirect("Create.aspx#Social");
      }
   }

   protected void Add(object sender, EventArgs e)
   {
      if (name.Text.Length < 1)
      {
         errorLabe.Text = "Enter Network Name";
         name.Focus();
      }
      else if (profileID.Text.Length < 1)
      {
         errorLabe.Text = "Enter Network Profile ID";
         profileID.Focus();
      }
      else
      {
         errorLabe.Text = "";
         SQLConnection sc = new SQLConnection();
         string userID = Session["userID"].ToString();

         Utilities.ConvertIn(this);

         sc.ExcuteAction("INSERT INTO socialNetworks (userID, networkName, networkProfileID)" +
         " VALUES ('" + userID + "', '"
         + name.Text + "', '"
         + profileID.Text + "')");

         Response.Redirect("Create.aspx#Social");
      }
   }
}
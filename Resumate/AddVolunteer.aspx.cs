using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;

public partial class AddVolunteer : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {

      // WHEN THIS PAGE LOADS, CHECK TO SEE IF USE IS AUTHINICATED.
      // IF USER IS NOT AUTHINICATED, REDIRECT TO LOGIN PAGE, ELSE SHOW PAGE
      if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
      {
          Response.Redirect("Create.aspx#Volunteering");
      }
   }

   protected void Add(object sender, EventArgs e)
   {
      if (company.Text.Length < 1)
      {
         errorLabe.Text = "Enter Company";
         company.Focus();
      }
      else if (position.Text.Length < 1)
      {
         errorLabe.Text = "Enter Position";
         position.Focus();
      }
      else if (description.Text.Length < 1)
      {
         errorLabe.Text = "Enter Description";
         description.Focus();
      }
      else if (startDate.Text.Length < 1)
      {
         errorLabe.Text = "Enter Start Date";
         startDate.Focus();
      }
      else if (endDate.Text.Length < 1)
      {
         errorLabe.Text = "Enter End Date or (Present)";
         endDate.Focus();
      }
      else if (city.Text.Length < 1)
      {
         errorLabe.Text = "Enter City";
         city.Focus();
      }
      else if (state.Text.Length < 1)
      {
         errorLabe.Text = "Enter State";
         state.Focus();
      }
      else if (country.Text.Length < 1)
      {
         errorLabe.Text = "Enter Country";
         country.Focus();
      }
      else
      {
         errorLabe.Text = "";
         SQLConnection sc = new SQLConnection();
         string userID = Session["userID"].ToString();

         Utilities.ConvertIn(this);

         sc.ExcuteAction("INSERT INTO volunteering (userID, company, position, description, startDate, endDate, city, state, country)" +
         " VALUES ('" + userID + "', '"
         + company.Text + "', '"
         + position.Text + "', '"
         + description.Text + "', '"
         + startDate.Text + "', '"
         + endDate.Text + "', '"
         + city.Text + "', '"
         + state.Text + "', '"
         + country.Text + "')");

         Response.Redirect("Create.aspx#Volunteering");
      }
   }
}
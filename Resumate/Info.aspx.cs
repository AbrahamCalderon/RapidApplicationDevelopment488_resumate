using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using DataLayer;
using UserLayer;

public partial class Info : System.Web.UI.Page
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
        }
        if (!Page.IsPostBack)
        {
           populateAuthorizationInfo();
        }
    }

    protected void SaveChanges(object sender, EventArgs e)
    {
       //Page.Validate();
       if (!isValidPassword(infoPassword.Text))
       {
            lostErrorLabel.Text = "Invalid password";
            infoPassword.Focus();
       }
       else if (!isValidEmail(infoEmailAddress.Text))
       {
          lostErrorLabel.Text = "Invalid email address";
          infoPassword.Focus();
       }
       else if (!(infoPassword.Text).Equals(infoPassword2.Text))
       {
          lostErrorLabel.Text = "Passwords must match";
          infoPassword.Focus();
       }
       // If the page is valid, send the user to the next step.
       else
       {
           Utilities.ConvertIn(this);

          // TODO: save the information to the user's account.
          sc.ExcuteAction("UPDATE users SET password='" + infoPassword.Text + "', email='"
              + infoEmailAddress.Text + "' WHERE id=" + Session["userID"]);
          Response.Redirect("Default.aspx");
       }
       
    }

    protected bool isValidPassword(string password)
    {
       // password should be 3 to 16 letters, numbers, underscores, or hyphens
       string pattern = @"^[a-z0-9_-]{6,18}$";

       Regex regex = new Regex(pattern);
       return regex.IsMatch(password);
    }

    protected bool isValidEmail(string email)
    {
       string pattern = @"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$";
       Regex regex = new Regex(pattern);
       return regex.IsMatch(email);
    }

    private void populateAuthorizationInfo()
    {
       DataSet ds = sc.ExcuteSelectDS("SELECT * FROM users WHERE id=" + Session["userID"]);
       DataRow results = ds.Tables[0].Rows[0];
       infoUsername.Text = results["username"].ToString();
       infoEmailAddress.Text = results["email"].ToString();

       Utilities.ConvertOut(this);
    }
}
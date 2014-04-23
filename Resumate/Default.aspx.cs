using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using UserLayer;
using DataLayer;
using System.Net;
using System.Net.Mail;



public partial class _Default : System.Web.UI.Page
{
    private user thisUser = new user();

    protected void Page_Load(object sender, EventArgs e)
    {
        // WHEN THIS PAGE LOADS, CHECK TO SEE IF USER IS AUTHINICATED.
        // IF USER IS AUTHINICATED, REDIRECT TO MyAccount PAGE, ELSE SHOW PAGE
        if (Session["authenticated"] != null && (string)Session["authenticated"] == "YES")
        {
            Response.Redirect("MyAccount.aspx");
        }

        // GET CUSTOMIZED GREETING
        layout_welcomeCenter.InnerHtml = thisUser.GetGreeting(false);


        // SHOW MESSAGE TO THE USER IF RESET PASSWORD SUCCEEDED
        if (Session["lostPasswordMsg"] != null && (string)Session["lostPasswordMsg"] != "")
        {
            lostErrorLabel.Text = (string)Session["lostPasswordMsg"];
            Session["lostPasswordMsg"] = "";
        }
        else
        {
            lostErrorLabel.Text = "";
        }

    }

    protected void doLogin(object sender, EventArgs e)
    {
        string login_username = loginUsername.Text;
        string login_password = loginPassword.Text;

        if (!isValidUsername(login_username))
        {
            loginErrorLabel.Text = "Invalid username";
        }
        else if (!isValidPassword(login_password))
        {
            loginErrorLabel.Text = "Invalid password";
        }
        else
        {
            if (thisUser.IsFound(login_username, login_password))
            {
                loginErrorLabel.Text = "";
                DataTableCollection TableFromSQL = thisUser.getUserInfoByUsername(login_username);

                for (int i = 0; i < TableFromSQL[0].Rows[0].ItemArray.Length; i++)
                {
                    string value = TableFromSQL[0].Rows[0].ItemArray[i].ToString();
                    string key = TableFromSQL[0].Columns[i].ColumnName;

                    if (key.Equals("id"))
                    {
                        Session["userID"] = value;
                        Session["authenticated"] = "YES";
                    }
                }

                Response.Redirect("MyAccount.aspx");
            }
            else
            {
                loginErrorLabel.Text = "Invalid Username/Password";
            }
        }
    }

    protected void doSignup(object sender, EventArgs e)
    {
        string signup_username = signupUsername.Text;
        string signup_password = signupPassword.Text;
        string signup_email = signupEmail.Text;

        if (!isValidUsername(signup_username))
        {
            signupErrorLabel.Text = "Invalid username";
        }
        else if (!isValidPassword(signup_password))
        {
            signupErrorLabel.Text = "Invalid password";
        }
        else if (!isValidEmail(signup_email))
        {
            signupErrorLabel.Text = "Invalid e-mail address";
        }
        else if (thisUser.usernameExists(signup_username))
        {
            signupErrorLabel.Text = "username already taken";
        }
        else if (thisUser.emailExists(signup_email))
        {
            signupErrorLabel.Text = "e-mail already used";
        }
        else
        {
            signupErrorLabel.Text = "";
            thisUser.AddUser(signup_username, signup_password, signup_email);

            DataTableCollection TableFromSQL = thisUser.getUserInfoByUsername(signup_username);

            for (int i = 0; i < TableFromSQL[0].Rows[0].ItemArray.Length; i++)
            {
                string value = TableFromSQL[0].Rows[0].ItemArray[i].ToString();
                string key = TableFromSQL[0].Columns[i].ColumnName;

                if (key.Equals("id"))
                {
                    Session["userID"] = value;
                    Session["authenticated"] = "YES";
                }
            }

            Response.Redirect("MyAccount.aspx");
        }
    }

    protected void getLostPassword(object sender, EventArgs e)
    {
        string lost_email = lostEmail.Text;

        if ((!isValidEmail(lost_email)) || (!thisUser.emailExists(lost_email)))
        {
            lostErrorLabel.Text = "Invalid e-mail address";
            lostSubmitButton.Attributes["data-temp"] = "";
        }
        else
        {
            lostSubmitButton.Attributes["data-temp"] = "YES";

            SQLConnection sc = new SQLConnection();
            DataSet ds = sc.ExcuteSelectDS("SELECT password, username FROM users WHERE email='" + lost_email + "'");

            DataRow results = ds.Tables[0].Rows[0];
            string password = results["password"].ToString();
            string username = results["username"].ToString();
            string body = "Dear Memeber\n\n Upon your request, here is the password to your " +
                "Resumate account:\n\n" + password + "\n\nPlease Keep in mind that your username is:" + username
              + "\n\nRegards,\n"
              + "Resumate Support Team";

            Session["lostPasswordMsg"] = sendEmail(lost_email, body);

            Response.Redirect("Default.aspx");
        }
    }


    // Vialidators
    protected bool isValidUsername(string username)
    {
        // password should be 4 to 22 letters, numbers, underscores, or hyphens
        string pattern = @"^[a-z0-9_-]{4,22}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(username);
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


    protected string sendEmail(string email, string body)
    {
        string toReturn = "PAssword Sent Successfully";

        var fromAddress = new MailAddress("resumate.rad844@gmail.com", "Resumate");
        var toAddress = new MailAddress(email, email);
        const string fromPassword = "aAeE@613";
        const string subject = "Lost Password";
      
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }

        return toReturn;
    }

    protected void signupUsername_TextChanged(object sender, EventArgs e)
    {

    }
    protected void lostEmail_TextChanged(object sender, EventArgs e)
    {

    }
}

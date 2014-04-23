using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using UserLayer;
using DataLayer;

public partial class Publish : System.Web.UI.Page
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
            populateResumesList();
        }
    }

    protected void populateResumesList()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT name, id FROM resumes WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY name ASC");

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisName = "";
            string thisID = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisID = value;
                else
                    thisName = value;
            }

            resumesList.Items.Add(new ListItem(thisName, thisID));
        }
    }


    protected void ExportFile(object sender, EventArgs e)
    {
        if(resumesList.Items.Count > 0)
        {
            string content = "";
            string block = "";
            string resumeID = resumesList.SelectedItem.Value;
            string option = optionsList.SelectedItem.Value;
            bool isValid = true;

            DataTableCollection SchoolsTable = sc.ExcuteSelect("SELECT school, degree, major, gpa, startDate," +
                " endDate, city, state, country, 'schools' AS elementType FROM schools WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'schools' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection JobsTable = sc.ExcuteSelect("SELECT company, position, description, startDate," +
                " endDate, city, state, country, 'jobs' AS elementType FROM jobs WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'jobs' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection VolunteeringTable = sc.ExcuteSelect("SELECT company, position, description, startDate," +
                " endDate, city, state, country, 'volunteering' AS elementType FROM volunteering WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'volunteering' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection TrainingsTable = sc.ExcuteSelect("SELECT company, position, description, startDate," +
                " endDate, city, state, country, 'trainings' AS elementType FROM trainings WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'trainings' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection ExperiancesTable = sc.ExcuteSelect("SELECT title," +
                " description, 'experiances' AS elementType FROM experiances WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'experiances' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection CertificatesTable = sc.ExcuteSelect("SELECT title, dateObtained," +
                " description, 'certificates' AS elementType FROM certificates WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'certificates' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection AwardsTable = sc.ExcuteSelect("SELECT title, dateObtained," +
                " description, 'awards' AS elementType FROM awards WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'awards' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection SocialProfilesTable = sc.ExcuteSelect("SELECT NetworkName," +
                " networkProfileID, 'socialNetworks' AS elementType FROM socialNetworks WHERE id " +
                "IN(SELECT contentID FROM resume_content WHERE contentType = 'socialNetworks' AND userID = '" +
                Session["userID"].ToString() + "' AND resumeID = '" + resumeID + "') ORDER BY viewOrder ASC");

            DataTableCollection userInfoTable = sc.ExcuteSelect("SELECT firstName," +
                " middleName, lastName, email, homeAddress, phoneNumber, mobileNumber, faxNumber, homePage,"
            +" 'userInfo' AS elementType FROM users WHERE id = '" + Session["userID"].ToString() + "'");

            if (option.Equals("xml"))
            {
                content += ToXML("userInfo", userInfoTable);
                content += ToXML("schools", SchoolsTable);
                content += ToXML("jobs", JobsTable);
                content += ToXML("trainings", TrainingsTable);
                content += ToXML("volunteering", VolunteeringTable);
                content += ToXML("experiances", ExperiancesTable);
                content += ToXML("certificates", CertificatesTable);
                content += ToXML("awards", AwardsTable);
                content += ToXML("profiles", SocialProfilesTable);

                content = "<?xml version='1.0'?>\n<resume>" + content + "</resume>";
            }
            else if ((option.Equals("html")) || (option.Equals("pdf")))
            {
                block = ToHTML("userInfo", userInfoTable); if (block != null) content += "<br><h1>Personal Information</h1>" + block;
                block = ToHTML("school", SchoolsTable); if (block != null) content += "<br><h1>Education</h1>" + block;
                block = ToHTML("jobs", JobsTable); if (block != null) content += "<br><h1>Work</h1>" + block;
                block = ToHTML("trainings", TrainingsTable); if (block != null) content += "<br><h1>Trainings</h1>" + block;
                block = ToHTML("volunteering", VolunteeringTable); if (block != null) content += "<br><h1>Volunteering</h1>" + block;
                block = ToHTML("experiances", ExperiancesTable); if (block != null) content += "<br><h1>Other Experiances</h1>" + block;
                block = ToHTML("certificates", CertificatesTable); if (block != null) content += "<br><h1>Certificates</h1>" + block;
                block = ToHTML("awards", AwardsTable); if (block != null) content += "<br><h1>Awards</h1>" + block;
                block = ToHTML("profiles", SocialProfilesTable); if (block != null) content += "<br><h1>Scoial Networks</h1>" + block;

                content = 
                        "<html>" +
                        "	<head>" +
                        "		<meta charset='utf-8'>" +
                        "		<title>Resumate - My Resume</title>" +
                        "	</head>" +
                        "	<body>"                
                        + content + 
                        "	</body>"+ 
                        "	</html>";
            }
            else if (option.Equals("html2")) // need to change so that it prints paragraphs instead of tables
            {
                block = ToHTMLAdvanced("userInfo", userInfoTable); if (block != null) content += "<br><h1>Personal Information</h1>" + block;
                block = ToHTMLAdvanced("school", SchoolsTable); if (block != null) content += "<br><h1>Education</h1>" + block;
                block = ToHTMLAdvanced("jobs", JobsTable); if (block != null) content += "<br><h1>Work</h1>" + block;
                block = ToHTMLAdvanced("trainings", TrainingsTable); if (block != null) content += "<br><h1>Trainings</h1>" + block;
                block = ToHTMLAdvanced("volunteering", VolunteeringTable); if (block != null) content += "<br><h1>Volunteering</h1>" + block;
                block = ToHTMLAdvanced("experiances", ExperiancesTable); if (block != null) content += "<br><h1>Other Experiances</h1>" + block;
                block = ToHTMLAdvanced("certificates", CertificatesTable); if (block != null) content += "<br><h1>Certificates</h1>" + block;
                block = ToHTMLAdvanced("awards", AwardsTable); if (block != null) content += "<br><h1>Awards</h1>" + block;
                block = ToHTMLAdvanced("profiles", SocialProfilesTable); if (block != null) content += "<br><h1>Scoial Networks</h1>" + block;

                content =
                        "<html>" +
                        "	<head>" +
                        "		<meta charset='utf-8'>" +
                        "		<title>Resumate - My Resume</title>" +
                        "	</head>" +
                        "	<body>"
                        + content +
                        "	</body>" +
                        "	</html>";

                option = "html";
            }
            else if (option.Equals("txt"))
            {
                block = ToTXT("userInfo", userInfoTable); if (block != null) content += "Personal Information:\n\n" + block;
                block = ToTXT("school", SchoolsTable); if (block != null) content += "Education:\n\n" + block;
                block = ToTXT("jobs", JobsTable); if (block != null) content += "Work:\n\n" + block;
                block = ToTXT("trainings", TrainingsTable); if (block != null) content += "Trainings:\n\n" + block;
                block = ToTXT("volunteering", VolunteeringTable); if (block != null) content += "Volunteering:\n\n" + block;
                block = ToTXT("experiances", ExperiancesTable); if (block != null) content += "Other Experiances:\n\n" + block;
                block = ToTXT("certificates", CertificatesTable); if (block != null) content += "Certificates:\n\n" + block;
                block = ToTXT("awards", AwardsTable); if (block != null) content += "Awards:\n\n" + block;
                block = ToTXT("profiles", SocialProfilesTable); if (block != null) content += "Scoial Networks:\n\n" + block;
            }
            else
            {
                exportErrorLabel.Text = "Invalid request";
                isValid = false;
            }

            // force downloading the file
            if (isValid)
            {
                string attach = "attachment; filename=Resumate_" + resumeID + "." + option;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.AddHeader("content-disposition", attach);
                HttpContext.Current.Response.Write(content);
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }
        }
        else{
            exportErrorLabel.Text = "Invalid request";
        }
    }




    // convert to xml
    public static string ToXML(string type, DataTableCollection TableFromSQL)
    {
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = SplitCamelcase(TableFromSQL[0].Columns[j].ColumnName);

                if (j < TableFromSQL[0].Rows[i].ItemArray.Length - 1) // do not include the last column
                list += "     <" + key + ">" + value + "</" + key + ">\n";
            }

        }

     
        return "\n<element type='" + type + "'>\n" + list + "</element>\n";

    }


    
    // convert to html (paragraph based)
    public static string ToHTMLAdvanced(string type, DataTableCollection TableFromSQL)
    {
        string newType = char.ToUpper(type[0]) + type.Substring(1);
        string list = "";
        string group = "";
        int found = 0;

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = SplitCamelcase(TableFromSQL[0].Columns[j].ColumnName);

                string newKey = char.ToUpper(key[0]) + key.Substring(1);

                if (j < TableFromSQL[0].Rows[i].ItemArray.Length - 1) // do not include the last column
                group += "     <tr>\n          <td>" + newKey + ":</td>\n          <td>" + value + "</td>\n     </tr>\n";

            }
            found++;
            list += "<table cellpadding='5' cellspacing='0'>\n" + group + "</table>\n<br>\n\n";
            group = "";
        }
        

        if (found > 0)
            return list;
        else
            return null;

    }



    // convert to html
    public static string ToHTML(string type, DataTableCollection TableFromSQL)
    {
        string newType = char.ToUpper(type[0]) + type.Substring(1);
        string list = "";
        string group = "";
        double counter = 0.0;
        string bgColor = "";
        int found = 0;

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = SplitCamelcase(TableFromSQL[0].Columns[j].ColumnName);

                if (counter % 2.0 == (double)0)
                    bgColor = "f2f2f2";
                else
                    bgColor = "dadada";

                string newKey = char.ToUpper(key[0]) + key.Substring(1);

                if (j < TableFromSQL[0].Rows[i].ItemArray.Length - 1) // do not include the last column
                group += "     <tr>\n          <td bgcolor='" + bgColor + "'>" + newKey + ":</td>\n          <td bgcolor ='" + bgColor + "'>" + value + "</td>\n     </tr>\n";

                counter++;
            }
            found++;
            list += "<table border='1' cellpadding='5' cellspacing='0'>\n" + group + "</table>\n<br>\n\n";
            group = "";
        }
        

        if (found > 0)
            return list;
        else
            return null;

    }


    // convert to plain text
    public static string ToTXT(string type, DataTableCollection TableFromSQL)
    {
        string list = "";
        int found = 0;

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = SplitCamelcase(TableFromSQL[0].Columns[j].ColumnName);

                if (j < TableFromSQL[0].Rows[i].ItemArray.Length - 1) // do not include the last column
                list += key + ": " + value + "\n";
            }
            found++;
            list += "\n\n";
        }

        if (found > 0)
            return list;
        else
            return null;
    }


    // Split Camelcase
    public static string SplitCamelcase(string input)
    {
        return Regex.Replace(input, "(\\B[A-Z])", " $1");
    }
}
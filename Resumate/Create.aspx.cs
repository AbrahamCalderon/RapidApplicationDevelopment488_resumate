using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserLayer;
using DataLayer;

public partial class Create : System.Web.UI.Page
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
            PopulateUserData();
            populateEducationData();
            populateWorkData();
            populateExperianceData();
            populateCertificatesData();
            populateAwardsData();
            populateTrainingData();
            populateVolunteeringData();
            populateSocialNetworkingData();
        }
    }


    // save basic info
    protected void SaveChanges(object sender, EventArgs e)
    {
        // Validate the page.
        Page.Validate();

        // If the page is valid, send the user to the next step.
        if (Page.IsValid)
        {
            Utilities.ConvertIn(this);

            // TODO: save the information to the user's account.
            sc.ExcuteAction("UPDATE users SET firstName='" + infoFirstName.Text + "', middleName='"
                + infoMiddleName.Text + "', lastName='" + infoLastName.Text + "', homeAddress='"
                + infoHomeAddress.Text + "', phoneNumber='" + infoPhoneNumber.Text + "', faxNumber='"
                + infoFaxNumber.Text + "', mobileNumber='" + infoMobileNumber.Text + "', homePage='"
                + infoHomePage.Text + "' WHERE id=" + Session["userID"]);

            Utilities.ConvertOut(this);
        }
    }



    // populate user data
    private void PopulateUserData()
    {
        DataSet ds = sc.ExcuteSelectDS("SELECT * FROM users WHERE id=" + Session["userID"]);

        DataRow results = ds.Tables[0].Rows[0];
        infoFirstName.Text = results["firstName"].ToString();
        infoMiddleName.Text = results["middleName"].ToString();
        infoLastName.Text = results["lastName"].ToString();
        infoHomeAddress.Text = results["homeAddress"].ToString();
        infoPhoneNumber.Text = results["phoneNumber"].ToString();
        infoFaxNumber.Text = results["faxNumber"].ToString();
        infoMobileNumber.Text = results["mobileNumber"].ToString();
        infoHomePage.Text = results["homePage"].ToString();

        Utilities.ConvertOut(this);
    }

    // -------------------------------------------- Populate Education Data 
    public void populateEducationData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM schools WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisSchoolID = "";
            string thisSchoolName = "";
            string thisSchoolDegree = "";
            string thisSchoolMajor = "";
            string thisSchoolGPA = "";
            string thisSchoolStartDate = "";
            string thisSchoolEndDate = "";
            string thisSchoolCity = "";
            string thisSchoolState = "";
            string thisSchoolCountry = "";


            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisSchoolID = value;
                else if (key.Equals("school"))
                    thisSchoolName = value;
                else if (key.Equals("degree"))
                    thisSchoolDegree = value;
                else if (key.Equals("major"))
                    thisSchoolMajor = value;
                else if (key.Equals("gpa"))
                    thisSchoolGPA = value;
                else if (key.Equals("startDate"))
                    thisSchoolStartDate = value;
                else if (key.Equals("endDate"))
                    thisSchoolEndDate = value;
                else if (key.Equals("city"))
                    thisSchoolCity = value;
                else if (key.Equals("state"))
                    thisSchoolState = value;
                else if (key.Equals("country"))
                    thisSchoolCountry = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolName +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolDegree +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolMajor +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolGPA +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolStartDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolEndDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolCity +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolState +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSchoolCountry +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditSchool.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisSchoolID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteSchool.aspx?id=" + thisSchoolID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='11'>You currently have (0) schools in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Name</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Degree</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Major</td>"
            + "<td class='myAccount_viewTableHeaderCell'>GPA</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Start Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>End Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>City</td>"
            + "<td class='myAccount_viewTableHeaderCell'>State</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Country</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_1.InnerHtml = list;
    }

    // -------------------------------------------- Populate Work Data 
    public void populateWorkData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM jobs WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisJobID = "";
            string thisJobCompany = "";
            string thisJobPosition = "";
            string thisJobDescription = "";
            string thisJobStartDate = "";
            string thisJobEndDate = "";
            string thisJobCity = "";
            string thisJobState = "";
            string thisJobCountry = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisJobID = value;
                else if (key.Equals("company"))
                    thisJobCompany = value;
                else if (key.Equals("position"))
                    thisJobPosition = value;
                else if (key.Equals("description"))
                    thisJobDescription = value;
                else if (key.Equals("startDate"))
                    thisJobStartDate = value;
                else if (key.Equals("endDate"))
                    thisJobEndDate = value;
                else if (key.Equals("city"))
                    thisJobCity = value;
                else if (key.Equals("state"))
                    thisJobState = value;
                else if (key.Equals("country"))
                    thisJobCountry = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobCompany +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobPosition +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobStartDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobEndDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobCity +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobState +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisJobCountry +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditJob.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisJobID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteJob.aspx?id=" + thisJobID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='10'>You currently have (0) jobs in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Company</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Position</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Start Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>End Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>City</td>"
            + "<td class='myAccount_viewTableHeaderCell'>State</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Country</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_2.InnerHtml = list;
    }

    // -------------------------------------------- Populate Experience Data 
    public void populateExperianceData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM experiances WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisExperienceID = "";
            string thisExperienceTitle = "";
            string thisExperienceDescription = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisExperienceID = value;
                else if (key.Equals("title"))
                    thisExperienceTitle = value;
                else if (key.Equals("description"))
                    thisExperienceDescription = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisExperienceTitle +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisExperienceDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditExperience.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisExperienceID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteExperiance.aspx?id=" + thisExperienceID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='4'>You currently have (0) experiences in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Title</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_3.InnerHtml = list;
    }

    // -------------------------------------------- Populate Certificates Data
    public void populateCertificatesData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM certificates WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisCertificatesID = "";
            string thisCertificatesTitle = "";
            string thisCertificatesDescription = "";
            string thisCertificatesDateObtained = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisCertificatesID = value;
                else if (key.Equals("title"))
                    thisCertificatesTitle = value;
                else if (key.Equals("description"))
                    thisCertificatesDescription = value;
                else if (key.Equals("dateObtained"))
                    thisCertificatesDateObtained = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisCertificatesTitle +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisCertificatesDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisCertificatesDateObtained +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditCertificate.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisCertificatesID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteCertificate.aspx?id=" + thisCertificatesID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='5'>You currently have (0) certificates in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Title</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Date Obtained</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_4.InnerHtml = list;
    }

    // -------------------------------------------- Populate Awards Data
    public void populateAwardsData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM awards WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisAwardsID = "";
            string thisAwardsTitle = "";
            string thisAwardsDescription = "";
            string thisAwardsDateObtained = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisAwardsID = value;
                else if (key.Equals("title"))
                    thisAwardsTitle = value;
                else if (key.Equals("description"))
                    thisAwardsDescription = value;
                else if (key.Equals("dateObtained"))
                    thisAwardsDateObtained = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisAwardsTitle +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisAwardsDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisAwardsDateObtained +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditAward.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisAwardsID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteAward.aspx?id=" + thisAwardsID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='5'>You currently have (0) awards in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Title</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Date Obtained</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_5.InnerHtml = list;
    }

    // -------------------------------------------- Populate Training Data
    public void populateTrainingData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM trainings WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisTrainingID = "";
            string thisTrainingCompany = "";
            string thisTrainingPosition = "";
            string thisTrainingDescription = "";
            string thisTrainingStartDate = "";
            string thisTrainingEndDate = "";
            string thisTrainingCity = "";
            string thisTrainingState = "";
            string thisTrainingCountry = "";


            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisTrainingID = value;
                else if (key.Equals("company"))
                    thisTrainingCompany = value;
                else if (key.Equals("position"))
                    thisTrainingPosition = value;
                else if (key.Equals("description"))
                    thisTrainingDescription = value;
                else if (key.Equals("startDate"))
                    thisTrainingStartDate = value;
                else if (key.Equals("endDate"))
                    thisTrainingEndDate = value;
                else if (key.Equals("city"))
                    thisTrainingCity = value;
                else if (key.Equals("state"))
                    thisTrainingState = value;
                else if (key.Equals("country"))
                    thisTrainingCountry = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingCompany +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingPosition +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingStartDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingEndDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingCity +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingState +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisTrainingCountry +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditTraining.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisTrainingID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteTraining.aspx?id=" + thisTrainingID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='10'>You currently have (0) trainings in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Company</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Position</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Start Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>End Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>City</td>"
            + "<td class='myAccount_viewTableHeaderCell'>State</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Country</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_6.InnerHtml = list;
    }

    // -------------------------------------------- Populate Volunteering Data
    public void populateVolunteeringData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM volunteering WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisVolunteeringID = "";
            string thisVolunteeringCompany = "";
            string thisVolunteeringPosition = "";
            string thisVolunteeringDescription = "";
            string thisVolunteeringStartDate = "";
            string thisVolunteeringEndDate = "";
            string thisVolunteeringCity = "";
            string thisVolunteeringState = "";
            string thisVolunteeringCountry = "";


            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisVolunteeringID = value;
                else if (key.Equals("company"))
                    thisVolunteeringCompany = value;
                else if (key.Equals("position"))
                    thisVolunteeringPosition = value;
                else if (key.Equals("description"))
                    thisVolunteeringDescription = value;
                else if (key.Equals("startDate"))
                    thisVolunteeringStartDate = value;
                else if (key.Equals("endDate"))
                    thisVolunteeringEndDate = value;
                else if (key.Equals("city"))
                    thisVolunteeringCity = value;
                else if (key.Equals("state"))
                    thisVolunteeringState = value;
                else if (key.Equals("country"))
                    thisVolunteeringCountry = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringCompany +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringPosition +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringDescription +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringStartDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringEndDate +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringCity +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringState +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisVolunteeringCountry +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditVolunteer.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisVolunteeringID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteVolunteer.aspx?id=" + thisVolunteeringID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='10'>You currently have (0) volunteer experiences in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Company</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Position</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Description</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Start Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>End Date</td>"
            + "<td class='myAccount_viewTableHeaderCell'>City</td>"
            + "<td class='myAccount_viewTableHeaderCell'>State</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Country</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_7.InnerHtml = list;
    }

    // -------------------------------------------- Populate Social Networking Data
    public void populateSocialNetworkingData()
    {
        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT * FROM socialNetworks WHERE userID = '"
            + Session["userID"].ToString() + "' ORDER BY viewOrder ASC");

        int itemsFound = 0;
        string list = "";

        for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
        {
            string thisSocialNetworkID = "";
            string thisSocialNetworkName = "";
            string thisSocialNetworkProfileID = "";

            for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
            {
                string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                string key = TableFromSQL[0].Columns[j].ColumnName;

                if (key.Equals("id"))
                    thisSocialNetworkID = value;
                else if (key.Equals("networkName"))
                    thisSocialNetworkName = value;
                else if (key.Equals("networkProfileID"))
                    thisSocialNetworkProfileID = value;
                else { }
            }

            itemsFound++;

            list += "<tr><td class='myAccount_viewTableInnerCell'>" + itemsFound +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSocialNetworkName +
                "</td><td class='myAccount_viewTableInnerCell'>" + thisSocialNetworkProfileID +
                "</td><td class='myAccount_viewTableInnerCell'>" +
                "<a href='EditSocialNetwork.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450&id=" + thisSocialNetworkID + "' class='lightbox'><img class='step_icon' src='images/icon_edit.png' title='Edit' alt='Edit'></a>&nbsp;&nbsp;" +
                "<a href='DeleteSocialNetwork.aspx?id=" + thisSocialNetworkID +
                "'><img class='step_icon' src='images/icon_delete.png' title='Delete' alt='Delete'></a></td></tr>";
        }

        if (itemsFound < 1)
            list = "<tr><td colspan='4'>You currently have (0) social networks in your profile</td></tr>";

        list = "<table class='myAccount_viewTable' border='1' cellpadding='10' cellspacing='0'><tr>"
            + "<td class='myAccount_viewTableHeaderCell'>ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Name</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Profile ID</td>"
            + "<td class='myAccount_viewTableHeaderCell'>Options</td>"
            + list + "</tr></table>";

        steps_contentWrapper_8.InnerHtml = list;
    }
}
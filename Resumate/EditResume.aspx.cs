using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserLayer;
using DataLayer;

public partial class EditResume : System.Web.UI.Page
{
    SQLConnection sc = new SQLConnection();
    private string resumeGlobalID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["authenticated"] == null || (string)Session["authenticated"] != "YES")
        {
            Response.Redirect("Customize.aspx");
        }
        else
        {
            if (Session["openResumeID"] != null && (string)Session["openResumeID"] != "")
            {
                populateResumesInfo((string)Session["openResumeID"]);
            }
            else
            {
                Response.Redirect("Customize.aspx");
            }
        }
    }

    protected void populateResumesInfo(string resumeID)
    {
        resumeGlobalID = resumeID;
        string userID = Session["userID"].ToString();
        string resumeName = "";

        DataTableCollection TableFromSQL = sc.ExcuteSelect("SELECT name, templateID FROM resumes WHERE userID = '"+userID+"' AND id = '"+resumeID+"'");

        if (TableFromSQL[0].Rows.Count > 0)
        {
            resumeName = TableFromSQL[0].Rows[0].ItemArray[0].ToString();
            string resumeTemplateID = TableFromSQL[0].Rows[0].ItemArray[1].ToString();

            // populate check lists
            generateCheckList(resumeID, userID, "awards", "title");
            generateCheckList(resumeID, userID, "certificates", "title");
            generateCheckList(resumeID, userID, "experiances", "title");
            generateCheckList(resumeID, userID, "jobs", "company");
            generateCheckList(resumeID, userID, "schools", "school");
            generateCheckList(resumeID, userID, "socialNetworks", "networkName");
            generateCheckList(resumeID, userID, "trainings", "company");
            generateCheckList(resumeID, userID, "volunteering", "company");
        }
        else
        {
            // resume not found
            Response.Redirect("Customize.aspx");
        }

        resumeNameLabel.Text = "<h1>Add elements to (" + resumeName + "):</h1>";
    }


    protected void generateCheckList(string resumeID, string userID, string tableName, string columnName)
    {
        string sql = "(SELECT t.id As id, t." + columnName + " AS name, 'yes' AS checked FROM " +
            tableName + " t WHERE t.userID = '" + userID + "' AND t.id IN (SELECT contentID FROM resume_content WHERE userID = '" +
            userID + "' AND contentType = '" + tableName + "'))"
             + "UNION (SELECT t.id As id, t." + columnName + " AS name, 'no' AS checked FROM " +
            tableName + " t WHERE t.userID = '" + userID + "' AND t.id NOT IN (SELECT contentID FROM resume_content WHERE userID = '" +
            userID + "' AND contentType = '" + tableName + "'))";

        DataTableCollection TableFromSQL = sc.ExcuteSelect(sql);

        if (TableFromSQL.Count > 0 && TableFromSQL[0].Rows.Count > 0)
        {

            for (int i = 0; i < TableFromSQL[0].Rows.Count; i++)
            {
                string isChecked = "";
                string thisID = "";
                string thisTitle = "";

                for (int j = 0; j < TableFromSQL[0].Rows[i].ItemArray.Length; j++)
                {
                    string value = TableFromSQL[0].Rows[i].ItemArray[j].ToString();
                    string key = TableFromSQL[0].Columns[j].ColumnName;

                    if (key.Equals("id"))
                        thisID = value;
                    else if (key.Equals("name"))
                        thisTitle = value;
                    else
                        isChecked = value;
                }

                ListItem newItem = new ListItem(thisTitle, thisID);

                if (isChecked.Equals("yes"))
                    newItem.Selected = true;


                if (tableName.Equals("schools"))
                {

                    CheckBoxListSchools.Items.Add(newItem);
                }
                else if (tableName.Equals("jobs"))
                {
                    CheckBoxListjobs.Items.Add(newItem);
                }
                else if (tableName.Equals("experiances"))
                {
                    CheckBoxListExperiances.Items.Add(newItem);
                }
                else if (tableName.Equals("trainings"))
                {
                    CheckBoxListTrainings.Items.Add(newItem);
                }
                else if (tableName.Equals("certificates"))
                {
                    CheckBoxListCertificates.Items.Add(newItem);
                }
                else if (tableName.Equals("volunteering"))
                {
                    CheckBoxListVolunteering.Items.Add(newItem);
                }
                else if (tableName.Equals("awards"))
                {
                    CheckBoxListAwards.Items.Add(newItem);
                }
                else
                {
                    CheckBoxListSocial.Items.Add(newItem);
                }
            }
        }
        else
        {
            // no elements found for this resume, show error msg
            if (tableName.Equals("schools"))
                LabelListSchools.Text = "You have not added any schools yet";
            else if (tableName.Equals("jobs"))
                LabelListJobs.Text = "You have not added any jobs yet";
            else if (tableName.Equals("experiances"))
                LabelListExperiances.Text = "You have not added any experiances yet";
            else if (tableName.Equals("trainings"))
                LabellistTrainings.Text = "You have not added any trainings yet";
            else if (tableName.Equals("certificates"))
                LabellistCertificates.Text = "You have not added any certificates yet";
            else if (tableName.Equals("volunteering"))
                LabelListVolunteering.Text = "You have not added any volunteering experiances yet";
            else if (tableName.Equals("awards"))
                LabelListAwards.Text = "You have not added any awards yet";
            else
                LabelListSocial.Text = "You have not added any profiles yet";
        }
    }

    protected void SaveResume(object sender, EventArgs e)
    {
        processCheckListBox("schools", CheckBoxListSchools);
        processCheckListBox("jobs", CheckBoxListjobs);
        processCheckListBox("experiances", CheckBoxListExperiances);
        processCheckListBox("trainings", CheckBoxListTrainings);
        processCheckListBox("certificates", CheckBoxListCertificates);
        processCheckListBox("volunteering", CheckBoxListVolunteering);
        processCheckListBox("awards", CheckBoxListAwards);
        processCheckListBox("socialNetworks", CheckBoxListSocial);

        Session["openResumeID"] = "";

        Response.Redirect("Publish.aspx");
    }

    protected void processCheckListBox(string tableName, CheckBoxList thischeckBoxList)
    {
        foreach (ListItem item in thischeckBoxList.Items)
        {
            string thisID = item.Value.ToString();

            if(item.Selected)
            {
                sc.ExcuteAction("DELETE FROM resume_content WHERE userID = '" + Session["userID"].ToString()
                    + "' AND contentID = '" + thisID + "' AND resumeID = '"
                    + resumeGlobalID + "' AND contentType = '" + tableName + "'");

                sc.ExcuteAction("INSERT INTO resume_content (resumeID, contentID, contentType, userID)"
                + " VALUES ('" + resumeGlobalID + "','" + thisID + "','" + tableName + "','"
                + Session["userID"].ToString() + "')");
            }
        }
    }
}
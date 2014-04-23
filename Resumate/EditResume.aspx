<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditResume.aspx.cs" Inherits="EditResume" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 3</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
</head>

<body>
	<form id="form1" runat="server">
	<div class="layout_wrapper">
        <div id="layout_welcomeCenter" class="layout_welcomeCenter" runat="server"></div>
	    <div class="layout_header">
	    	<div class="layout_stepWrapperActive" data-url="Default.aspx">
	    		<div class="layout_stepIcon_01">
	    			<div class="layout_stepTitle">Be a Member</div>
	    		</div>
	    	</div>
	    	
	    	<div class="layout_stepWrapperActive" data-url="Create.aspx">
	    		<div class="layout_stepIcon_02">
	    			<div class="layout_stepTitle">Create</div>
	    		</div>
	    	</div>
	    	
	    	<div class="layout_stepWrapper" data-url="Customize.aspx">
	    		<div class="layout_stepIcon_03a">
	    			<div class="layout_stepTitle">Customize</div>
	    		</div>
	    	</div>
	    	
	    	<div class="layout_stepWrapperActive" data-url="Publish.aspx">
	    		<div class="layout_stepIcon_04">
	    			<div class="layout_stepTitle">Publish</div>
	    		</div>
	    	</div>
	    	
	    	<div class="cleaner"></div>
	    </div>
	    <div class="layout_body">
            <!-- BODY STARTS -->
            <asp:Label ID="resumeNameLabel" runat="server"></asp:Label>
            <div>
                <h1>Schools</h1>
                <asp:CheckBoxList ID="CheckBoxListSchools" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListSchools" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Jobs</h1>
                <asp:CheckBoxList ID="CheckBoxListjobs" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListJobs" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Experiances</h1>
                <asp:CheckBoxList ID="CheckBoxListExperiances" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListExperiances" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Certificates</h1>
                <asp:CheckBoxList ID="CheckBoxListCertificates" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabellistCertificates" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Trainings</h1>
                <asp:CheckBoxList ID="CheckBoxListTrainings" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabellistTrainings" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Volunteering Experiances</h1>
                <asp:CheckBoxList ID="CheckBoxListVolunteering" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListVolunteering" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Awards</h1>
                <asp:CheckBoxList ID="CheckBoxListAwards" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListAwards" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br /><br />
                <h1>Social Netowrk Profiles</h1>
                <asp:CheckBoxList ID="CheckBoxListSocial" runat="server"></asp:CheckBoxList>
                <asp:Label ID="LabelListSocial" runat="server" class="default_errorLabel"></asp:Label>
                <br /><br />
                <div style="text-align:right">
                    <asp:Button ID="SaveResumeButton" runat="server" Text="Save" onclick="SaveResume" />
                </div>
            </div>
            <!-- BODY ENDS -->
	    </div>
	    <div class="layout_footer">
	    	<div class="layout_copyrightsWrapper">Resumate&copy;&nbsp;All rights reserved.</div>
	    	<div class="layout_linksWrapper">
	    		<a href="Terms.aspx">Terms of Use</a>
	    		&nbsp;|&nbsp;
	    		<a href="Privacy.aspx">Privacy Policy</a>
	    		&nbsp;|&nbsp;
	    		<a href="Team.aspx">About Us</a>
	    	</div>
	    	<div class="cleaner"></div>
	    </div>
    </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Publish.aspx.cs" Inherits="Publish" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 4</title>
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
	    	
	    	<div class="layout_stepWrapperActive" data-url="Customize.aspx">
	    		<div class="layout_stepIcon_03">
	    			<div class="layout_stepTitle">Customize</div>
	    		</div>
	    	</div>
	    	
	    	<div class="layout_stepWrapper" data-url="Publish.aspx">
	    		<div class="layout_stepIcon_04a">
	    			<div class="layout_stepTitle">Publish</div>
	    		</div>
	    	</div>
	    	
	    	<div class="cleaner"></div>
	    </div>
	    <div class="layout_body">
            <!-- BODY STARTS -->
                <h1>Select a Resume to Export:</h1>
                <asp:DropDownList ID="resumesList" runat="server" class='resumeSelector'></asp:DropDownList>
                <br />
                <br />
                <asp:DropDownList ID="optionsList" runat="server"  class='resumeSelector'>
                    <asp:ListItem Value="pdf">PDF</asp:ListItem>
                    <asp:ListItem Value="html">HTML</asp:ListItem>
                    <asp:ListItem Value="html2">HTML (Printer Friendly)</asp:ListItem>
                    <asp:ListItem Value="xml">XML</asp:ListItem>
                    <asp:ListItem Value="txt">Plain Text</asp:ListItem>
                </asp:DropDownList>
                    <br />
	            <br />
                <asp:Button ID="ExportButton" runat="server" Text="Export" class="resumeButton" onclick="ExportFile" />
                <asp:Label ID="exportErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
                <div ID="test" runat="server"></div>
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


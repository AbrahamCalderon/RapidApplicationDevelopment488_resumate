<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Info" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 2</title>
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
	    	
	    	<div class="layout_stepWrapper" data-url="Create.aspx">
	    		<div class="layout_stepIcon_02a">
	    			<div class="layout_stepTitle">Create</div>
	    		</div>
	    	</div>
	    	
	    	<div class="layout_stepWrapperActive" data-url="Customize.aspx">
	    		<div class="layout_stepIcon_03">
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
                <table class="steps_tableWrapper" cellpadding="5" cellspacing="0"> 
                    <tr>
                        <td class="steps_tableCellA_1">
                            Username:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoUsername" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellB_1">
                            New Password:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoPassword" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellA_1">
                            Confirm New Password:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoPassword2" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellB_1">
                            Email Address:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoEmailAddress" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                </table>
                <br /><br />
                <table class="steps_tableWrapper" cellpadding="5" cellspacing="0"> 
                    <tr>
                        <td class="steps_tableCellC_2">
                            <asp:Label ID="lostErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
                        </td>
                        <td class="steps_tableCellC_1">
                            <asp:Button ID="saveAccountInfo" runat="server" Text="Save Changes" onclick="SaveChanges" />
                        </td>
                    </tr>
                </table>
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
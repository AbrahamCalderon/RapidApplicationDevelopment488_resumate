<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 1</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
    </head>

<body>
	<div class="layout_wrapper">
        <div id="layout_welcomeCenter" class="layout_welcomeCenter" runat="server"></div>
	    <div class="layout_header">
	    	<div class="layout_stepWrapper" data-url="Default.aspx">
	    		<div class="layout_stepIcon_01a">
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
	    	
	    	<div class="layout_stepWrapperActive" data-url="Publish.aspx">
	    		<div class="layout_stepIcon_04">
	    			<div class="layout_stepTitle">Publish</div>
	    		</div>
	    	</div>
	    	
	    	<div class="cleaner"></div>
	    </div>
	    <div class="layout_body">
            <!-- BODY STARTS -->
            <div class="test"></div>
            <form id="pageForm" runat="server">


            <div class="default_note01">
                <div class="default_noteContent">   
                   <span class="default_noteTitle">Already a Member?</span><br />

                    <table  class="default_noteTable" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="default_noteTableCell">
                                Username:
                            </td>
                            <td style="width:100%">
                                <asp:TextBox ID="loginUsername" runat="server" class="defaukt_formInput" 
                                     Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="default_noteTableCell">
                                Password:
                            </td>
                            <td style="width:100%">
                               <asp:TextBox ID="loginPassword" runat="server" TextMode = "Password" 
                                    class="defaukt_formInput" Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="default_noteTableSubmitButton">
                       <asp:Button ID="loginSubmitButton" runat="server" Text="Login" onclick="doLogin" />
                    </div>
                    <asp:Label ID="loginErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
               </div> 
            </div>

            <div class="default_note02">
                <div class="default_noteContent">      
                   <span class="default_noteTitle">Not a Member?</span><br />
                    <table  class="default_noteTable" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="default_noteTableCell">
                                Username:
                            </td>
                            <td style="width:100%">
                                <asp:TextBox ID="signupUsername" runat="server" class="defaukt_formInput" 
                                     Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="default_noteTableCell">
                                Password:
                            </td>
                            <td style="width:100%">
                                <asp:TextBox ID="signupPassword" runat="server" TextMode = "Password" 
                                    class="defaukt_formInput" Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="default_noteTableCell">
                                Email:
                            </td>
                            <td style="width:100%">
                                <asp:TextBox ID="signupEmail" runat="server" class="defaukt_formInput" 
                                     Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <div class="default_noteTableSubmitButton">
                       <asp:Button ID="signupSubmitButton" runat="server" Text="Signup" 
                            onclick="doSignup" Width="69px" />
                    </div>
                    <asp:Label ID="signupErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
                    
                </div>
            </div>

            <div class="default_note03">
                <div class="default_noteContent">  
                   <span class="default_noteTitle">Lost Password?<br />
                    </span><br />
                   <table  class="default_noteTable" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="default_noteTableCell">
                                Your Email: 
                            </td>
                            <td style="width:100%">
                                <asp:TextBox ID="lostEmail" runat="server" class="defaukt_formInput" 
                         ontextchanged="lostEmail_TextChanged" Width="82px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                   
                   <div class="default_noteTableSubmitButton">
                        <asp:Button ID="lostSubmitButton" runat="server" Text="Retrieve" onclick="getLostPassword" data-temp = "" />
                   </div>
                   <asp:Label ID="lostErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
                </div>
            </div>

            <div class="cleaner"></div>
            </form>
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
</body>
</html>


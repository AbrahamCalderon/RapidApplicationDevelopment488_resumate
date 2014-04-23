<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Create" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 2</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
    <script src="js/popup.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="skins/popup/popup.css" />
    <script type="text/javascript">$('.lightbox').lightbox();</script>
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

                <!-- BLOCK STARTS -->
                <h1>Basic Information</h1>
                <table class="steps_tableWrapper" cellpadding="5" cellspacing="0"> 
                    <tr>
                        <td class="steps_tableCellA_1">
                            First Name:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoFirstName" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellB_1">
                            Middle Name:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoMiddleName" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellA_1">
                            Last Name:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoLastName" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellB_1">
                            Home Address:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoHomeAddress" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellA_1">
                            Phone Number:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoPhoneNumber" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>                    
                    <tr>
                        <td class="steps_tableCellB_1">
                            Fax Number:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoFaxNumber" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellA_1">
                            Mobile Number:
                        </td>
                        <td class="steps_tableCellA_2">
                            
                                <asp:TextBox ID="infoMobileNumber" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="steps_tableCellB_1">
                            Home Page:
                        </td>
                        <td class="steps_tableCellB_2">
                            
                                <asp:TextBox ID="infoHomePage" runat="server" class="defaukt_formInput" 
                                     Width="661px" Height="38px"></asp:TextBox>
                            
                        </td>
                    </tr>
                </table>
                <br />
                <table class="steps_tableWrapper" cellpadding="5" cellspacing="0"> 
                    <tr>
                        <td class="steps_tableCellC_2">
                            <asp:Label ID="lostErrorLabel" runat="server" class="default_errorLabel"></asp:Label>
                        </td>
                        <td class="steps_tableCellC_1">
                            <asp:Button ID="saveAccountInfo" runat="server" Text="Update Basic Information" onclick="SaveChanges" />
                        </td>
                    </tr>
                </table>
                <!-- BLOCK ENDS -->
                

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddSchool.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Education">Education</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_1" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddJob.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Work">Work</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_2" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddExperiance.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Experiances">Experiances</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_3" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddCertificate.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Certificates">Certificates</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_4" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddAward.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Awards">Awards</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_5" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddTraining.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Trainings">Trainings</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_6" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddVolunteer.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Volunteering">Volunteering</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_7" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

                <!-- BLOCK STARTS -->
                <div>
                    <br /><br />
                    <div style="float:left; height:50px;">
                        <a href="AddSocialNetwork.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                            <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                        </a>
                    </div>
                    <div style="float:left; height:50px;">
                        <h1><a name="Social">Social Network Profiles</a></h1>
                    </div>
                    <div style="clear:both"></div>
                </div>
                <div id="steps_contentWrapper_8" class="steps_contentWrapper" runat="server"></div>
                <!-- BLOCK ENDS -->

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
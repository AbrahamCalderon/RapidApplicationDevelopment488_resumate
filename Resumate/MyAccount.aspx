<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - Step 1</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
        <script src="js/popup.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="skins/popup/popup.css" />
    <script type="text/javascript">$('.lightbox').lightbox();</script>
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

            <!-- BLOCK STARTS -->
            <div>
                <br /><br />
                <div style="float:left; height:50px;">
                    <a href="AddResume.aspx?lightbox&#91;width&#93;=550&amp;lightbox&#91;height&#93;=450" class="lightbox">
                        <img class='step_icon' src='images/icon_add.png' title='Add' alt='Add' />
                    </a>
                </div>
                <div style="float:left; height:50px;">
                    <h1><a name="List">My Resumes</a></h1>
                </div>
                <div style="clear:both"></div>
            </div>
            <div id="myAccount_listWrapper" class="myaccount_listWrapper" runat="server"></div>
            <!-- BLOCK ENDS -->
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


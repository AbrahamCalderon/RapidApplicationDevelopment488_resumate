﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customize.aspx.cs" Inherits="Customize" %>

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
            <h1>Choose a resume to customize:</h1>
            <div style="float:left">
                <asp:DropDownList ID="ResumesDropDownList" runat="server" class='resumeSelector'></asp:DropDownList>
            </div>
            <div style="float:left; margin-left:30px;">
                <asp:Button ID="LoadResumeButton" runat="server" Text="Load & Customize" class='resumeButton' onclick='LoadResume'/>
            </div>
            <div class="cleaner"></div>
	        <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="a1" runat="server"></asp:Label>
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


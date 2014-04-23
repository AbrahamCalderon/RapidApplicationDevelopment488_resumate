<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Resumate - About Uss</title>
    <link href="css/style.css" rel="stylesheet">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
</head>

<body>
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
	    	
	    	<div class="layout_stepWrapperActive" data-url="Publish.aspx">
	    		<div class="layout_stepIcon_04">
	    			<div class="layout_stepTitle">Publish</div>
	    		</div>
	    	</div>
	    	
	    	<div class="cleaner"></div>
	    </div>
	    <div class="layout_body">
            <!-- BODY STARTS -->
                    <h2>Abdul Almutairi</h2>
                     <h3>M.S. Software Engineering<br />Loyola University of Chicago</h3>
                    <br /><br />
                    <h2>Abraham Calderon</h2>
                     <h3>M.S. Computer Science<br />Loyola University of Chicago</h3>
                    <br /><br />
                    <h2>Eric Burns</h2>
                     <h3>M.S. Computer Science<br />Loyola University of Chicago</h3>
                    <br /><br />
                    <h2>Eyad Fallatah</h2>
                    <h3>M.S. Software Engineering<br />Loyola University of Chicago</h3>
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
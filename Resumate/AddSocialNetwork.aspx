<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSocialNetwork.aspx.cs" Inherits="AddSocialNetwork" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<meta charset="utf-8">
    <title>Add</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/functions.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            font-size: small;
            font-family: Tahoma;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <br /><br />
    <form id="form1" runat="server">
        <table cellpadding="5" cellspacing="0" border="1" style="width:450px; margin:0px auto;">
        
                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Social Network Name:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="name" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                Social Network Profile ID:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="profileID" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>                        
                   </table>
        <center>
            <br />
            <asp:Button ID="add" runat="server" Text="Add" onclick="Add" />
            <br />
            <asp:Label ID="errorLabe" runat="server" style="color:#ff0000"></asp:Label>
        </center>
    </form>
</body>
</html>


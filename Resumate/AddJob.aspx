<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddJob.aspx.cs" Inherits="AddJob" %>

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
                                Company</td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="company" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                Position:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="position" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>
                        <tr>
                           <td style="background-color:#f2f2f2" class="style1">
                                Description:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="description" runat="server" Height="43px" Width="269px" 
                                   TextMode="MultiLine"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Start Date:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="startDate" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>
                        

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                End Date:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="endDate" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                City:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="city" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                State:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="state" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Country:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="country" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
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

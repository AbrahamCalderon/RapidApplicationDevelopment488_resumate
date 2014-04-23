<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSocialNetwork.aspx.cs" Inherits="EditSocialNetwork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="5" cellspacing="0" border="1" style="width:450px; margin:0px auto;">
        
                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Social Network Name:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="name" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvSocialNetworkName" runat="server" ControlToValidate="name" Display="None" ErrorMessage="Social Network Name is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                Social Network Profile ID:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="profileID" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvSocialNetworkProfileID" runat="server" ControlToValidate="profileID" Display="None" ErrorMessage="Social Network Profile ID is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>                        
                   </table>
        <center>
            <br />
            <asp:Button ID="update" runat="server" Text="Update" onclick="Update" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />
        </center>
    </form>
</body>
</html>

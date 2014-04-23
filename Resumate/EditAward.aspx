<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAward.aspx.cs" Inherits="EditAward" %>

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
                                Title:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="title" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="title" Display="None" ErrorMessage="Title is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                Description:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="description" runat="server" Height="24px" Width="269px" 
                                   TextMode="MultiLine"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="description" Display="None" ErrorMessage="Description is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Date Obtained:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="dateObtained" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvDateObtained" runat="server" ControlToValidate="dateObtained" Display="None" ErrorMessage="Date Obtained is missing."></asp:RequiredFieldValidator>
                         
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

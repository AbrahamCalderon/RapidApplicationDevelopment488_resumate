<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSchool.aspx.cs" Inherits="EditSchool" %>

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
                                Name:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="name" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="name" Display="None" ErrorMessage="School name is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                Degree:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="degree" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvDegree" runat="server" ControlToValidate="degree" Display="None" ErrorMessage="Degree is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Major:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="major" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvMajor" runat="server" ControlToValidate="major" Display="None" ErrorMessage="Major is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                GPA:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="gpa" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvGPA" runat="server" ControlToValidate="gpa" Display="None" ErrorMessage="GPA is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Start Date:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="startDate" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ControlToValidate="startDate" Display="None" ErrorMessage="Start Date is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                End Date:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="endDate" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="endDate" Display="None" ErrorMessage="End Date is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                City:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="city" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="city" Display="None" ErrorMessage="City is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#dadada" class="style1">
                                State:
                            </td>
                            <td style="background-color:#dadada">
                         
                                <asp:TextBox ID="state" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="state" Display="None" ErrorMessage="State is missing."></asp:RequiredFieldValidator>
                         
                            </td>
                        </tr>

                        <tr>
                            <td style="background-color:#f2f2f2" class="style1">
                                Country:
                            </td>
                            <td style="background-color:#f2f2f2">
                         
                                <asp:TextBox ID="country" runat="server" Height="20px" Width="269px"></asp:TextBox>
                         
                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="country" Display="None" ErrorMessage="Country is missing."></asp:RequiredFieldValidator>
                         
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

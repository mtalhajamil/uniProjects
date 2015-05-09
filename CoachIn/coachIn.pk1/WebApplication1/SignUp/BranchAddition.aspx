<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchAddition.aspx.cs" Inherits="WebApplication1.SignUp.BranchAddition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Add A New Branch</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="AddBranchContainer">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Add A Branch To My Coaching
                </div>
                <table>
                    <tr>
                        <td>
                            <h2>Campus Name:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Name" runat="server" CssClass="inputBox"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Address:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Address" runat="server" CssClass="inputBox"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Contact1:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Contact1" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Contact2:(Optional)</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Contact2" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="bigRow">
                            <h2>Details:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Details" runat="server" CssClass="inputBox" TextMode="MultiLine"></asp:TextBox>
                        </td>

                    </tr>
                </table>
                <asp:Button ID="Finish" CssClass="Finish" runat="server" Text="Submit Branch Details" OnClick="Finish_Click" />

                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>
                <br />
                <br />
                CoachIn.pk allows you to advertise your coaching in a most unique, sophiticated and effective way!!!
                <!-- end .SignUpRight -->
            </div>

            <!-- end .AddBranchContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>


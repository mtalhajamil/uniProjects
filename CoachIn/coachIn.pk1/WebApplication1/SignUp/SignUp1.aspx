<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp1.aspx.cs" Inherits="WebApplication1.UserPages.SignUp1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Registration Step 1</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <div class="SignUpContainer">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Register My Coaching
                </div>
                <table>
                    <tr>
                        <td>
                            <h2>Coaching Name:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Name" runat="server" CssClass="inputBox"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Address:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Address" runat="server" CssClass="inputBox"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Contact1:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Contact1" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Contact2:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Contact2" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Attach your Logo:</h2>
                        </td>
                        <td>

                            <asp:FileUpload ID="img" runat="server" Width="296px" EnableTheming="true" />

                        </td>

                    </tr>
                </table>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="74px" ImageUrl="../img/next.png" Style="float: right;" Width="138px" OnClick="ImageButton1_Click" />

                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>
                <br />
                <br />
                CoachIn.pk allows you to advertise your coaching in a most unique and effective way!!!
                <!-- end .SignUpRight -->
            </div>

            <!-- end .SignUpContainer -->
        </div>
<customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

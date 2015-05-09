<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp3.aspx.cs" Inherits="WebApplication1.UserPages.SignUp3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Registration Step 3</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>


        <div class="SignUpContainer">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Register My Coaching
                </div>
                <asp:Image ID="Image1" runat="server" Width="200px" Style="float: right;" />
                <table>
                    <tr>
                        <td style="width: 250px">
                            <h2>What You Want To Say About Your Institute?</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Details" runat="server" CssClass="inputBoxBig" TextMode="MultiLine"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 250px">
                            <h2>When do you want us to call you for verification (please provide a suitable date and time):</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="vertime" runat="server" CssClass="inputBoxBig" TextMode="DateTime"></asp:TextBox>
                        </td>

                    </tr>

                </table>
                <asp:Button ID="Finish" CssClass="Finish" runat="server" Text="Finish" OnClick="Finish_Click" />
                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>
                <br />
                <br />
                You can decorate your profile and introduce caching packages to attract visitors !!
                <!-- end .SignUpRight -->
            </div>

            <!-- end .SignUpContainer -->
        </div>
<customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>


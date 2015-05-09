<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebApplication1.SignUp.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Login</title>
   
</head>



<body>
    <form id="form1" runat="server">

        <customControls:Header ID="Header1" runat="server"></customControls:Header>


        <div class="SignInContainer">

            <div class="SignInLeft">

                <div class="leftSignInHeaderstrip" >
                    What's New?
                </div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/elearning_image.jpg" Height="301px" Width="449px" />
                 Now you can receive all the website updates on your mobile phone as well, all you need to do is just to follow us on twitter !!
               
                <!-- end .SignUpRight -->
            </div>

            <div class="SignInRight">

                <div class="rightSignInHeaderstrip">
                    Login
                </div>
                <br />
                <br />
                <br />
                <br />
                <table style="float: right;">
                    <tr>
                        <td>
                            <h2>Email Address:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Email" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h2>Password:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Password" runat="server" CssClass="inputSignInBox" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../img/login.gif" Style="float: right;" Width="138px" CssClass="Image" OnClick="ImageButton1_Click" TabIndex="1" />

                <!-- end .SignUpLeft -->
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Red" style="float:right" >Forgot Password??</asp:LinkButton>
            </div>
            <!-- end .SignInContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

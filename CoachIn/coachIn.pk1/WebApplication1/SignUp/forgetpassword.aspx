<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="WebApplication1.SignUp.forgetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/decoration.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <link href="../css/design.css" rel="stylesheet" type="text/css" />
    <title>Forgot Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div style="background-color: black">
            <asp:Label runat="server" Text="Label" CssClass="contact">Give your Email Address: </asp:Label>
            <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="inputSearchBox"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="My Password" CssClass="DetailButton" OnClick="Button1_Click" /><br />
        <asp:Label ID="Label1" Font-Bold="True" ForeColor="Red" runat="server" Visible="False">Password has been mailed to you!</asp:Label>

    </form>
</body>
</html>

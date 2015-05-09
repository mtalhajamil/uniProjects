<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerStrip.ascx.cs" Inherits="WebApplication1.Controls.WebUserControl1" %>

<link href="../css/signIn.css" type="text/css" rel="stylesheet" />

<asp:Panel runat="server" ID="LogoutStrip">
    <div id="Div1" runat="server" class="headerStrip">
        <asp:Label ID="LogIn" runat="server"></asp:Label>
        <asp:Button ID="Logout" runat="server" Text="Logout" CssClass="headerStripButton" OnClick="Logout_Click" />
        <asp:Button ID="CoachingPage" runat="server" Text="My Coaching Profile" CssClass="headerStripButton" OnClick="CoachingPage_Click" />
    </div>
</asp:Panel>

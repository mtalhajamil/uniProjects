<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebApplication1.Controls.header" %>

<link href="../css/style.css" rel="stylesheet" type="text/css" />
<link href="../css/design.css" rel="stylesheet" type="text/css" />
<link href="../css/decoration.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function doPostBack(o) {
        __doPostBack(o.id, '');
    }
</script>

<div class="header">
    <div id="logo">
        <h1><a href="#" target="_parent"></a></h1>
    </div>
    
    <nav id="mainNav" role="navigation" >
        <ul>
            <li>blank</li>
            <li>blank</li>
            <li>blank</li>
            <li><a href="/UserPages/FrontPage.aspx">Home</a></li>
            <li><a href="/UserPages/CoachingDisplay.aspx">Coachings</a></li>
            <li><a href="/UserPages/GeneralNews.aspx">News</a></li>
            <li><a href="/UserPages/Searching.aspx">Search</a></li>

        </ul>
    </nav>
    
    <div style="float: right; margin-top: 70px; font-family: 'High Tower Text'; color: #b6ff00; margin-left: 0px; margin-right:40px;">
        <asp:Button ID="Register" Text="[Register My Coaching]" runat="server" CssClass="headerButtons" OnClick="Register_Click" TabIndex="-1" />
        <asp:Button ID="SignIn" Text="[SignIn]" runat="server" CssClass="headerButtons" OnClick="SignIn_Click" TabIndex="-2" />
        Search:
        <asp:TextBox ID="Searching" CssClass="inputHeaderSearchBox" runat="server" onkeyup="doPostBack(this);" OnTextChanged="Searching_TextChanged"></asp:TextBox>
    </div>
    <!-- header -->
</div>

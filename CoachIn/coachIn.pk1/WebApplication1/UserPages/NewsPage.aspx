<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsPage.aspx.cs" Inherits="WebApplication1.NewsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet" />
    <title>Coaching News</title>
</head>



<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="container">
            <div class="announceContent">


                <asp:Label runat="server" ID="Heading" CssClass="centerHeading">
                        <h1>Coaching News</h1>
                </asp:Label>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="announceContent">
                            Filter News:
                            <br />
                            <asp:CheckBox runat="server" Text="Matric" ID="Matric" AutoPostBack="True" />
                            <br />
                            <asp:CheckBox runat="server" Text="Intermediate" ID="Intermediate" AutoPostBack="True" />
                            [
                            <asp:CheckBox runat="server" Text="PreEngineering" ID="PreEngineering" AutoPostBack="True" />
                            <asp:CheckBox runat="server" Text="PreMedical" ID="PreMedical" AutoPostBack="True" />
                            <asp:CheckBox runat="server" Text="Commerce" ID="Commerce" AutoPostBack="True" />
                            ]
                        </div>

                        <asp:Repeater ID="newsRepeater" runat="server" OnItemDataBound="newsRepeater_ItemDataBound">
                            <ItemTemplate>
                                <div class="Announcement">
                                    <h4>
                                        <asp:label runat="server" ID="NewsDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:label>
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                                    </h4>
                                    <%# DataBinder.Eval(Container.DataItem,"Info")%>
                                    <h5>Authenticity</h5>
                                    <%# DataBinder.Eval(Container.DataItem,"Authenticity")%>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!-- end .announceContent -->
            </div>
            <!-- end .container -->
        </div>
        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:coachingPageConnection %>" SelectCommand="SELECT * FROM [Coaching]"></asp:SqlDataSource>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementPage.aspx.cs" Inherits="WebApplication1.AnnouncementPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet" />
    <title>Branch Announcements</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>

        <div class="container">
            <div class="announceContent">


                <asp:Label runat="server" ID="Heading" CssClass="centerHeading">
                        <h1>Branch Announcements</h1>
                </asp:Label>
                <div class="Announcement">
                    Filter Announcements:
                            <br />
                    <asp:CheckBox runat="server" Text="Matric" ID="MatricCheck" AutoPostBack="True" />
                    <br />
                    <asp:CheckBox runat="server" Text="Intermediate" ID="IntermediateCheck" AutoPostBack="True" />
                    [
                            <asp:CheckBox runat="server" Text="PreEngineering" ID="PreEngineeringCheck" AutoPostBack="True" />
                    <asp:CheckBox runat="server" Text="PreMedical" ID="PreMedicalCheck" AutoPostBack="True" />
                    <asp:CheckBox runat="server" Text="Commerce" ID="CommerceCheck" AutoPostBack="True" />
                    ]
                </div>

                <asp:Repeater ID="announcementRepeater" runat="server" OnItemDataBound="announcementRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="Announcement">
                            <h4>
                                <asp:label runat="server" ID="AnnouncementDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:label>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                            </h4>
                            <%# DataBinder.Eval(Container.DataItem,"Notification")%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- end .announceContent -->
            </div>
            <!-- end .container -->
        </div>
        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:coachingPageConnection %>" SelectCommand="SELECT * FROM [Coaching]"></asp:SqlDataSource>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

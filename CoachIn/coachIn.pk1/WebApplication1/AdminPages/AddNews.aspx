<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="WebApplication1.AdminPages.AddNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet">
    <title>Add News</title>
</head>



<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="container">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="course">
                        <asp:Label runat="server" ID="Label1" CssClass="centerHeading">
                        <h1>Add News</h1>
                        </asp:Label>

                        <label>News Tittle:</label>
                        <asp:TextBox runat="server" ID="Tittle"></asp:TextBox>
                        <label>Today's Date:</label>
                        <asp:Label runat="server" ID="date"></asp:Label>
                        <label>Current Time:</label>
                        <asp:Label runat="server" ID="time"></asp:Label>
                        <br />
                        <label>News:</label>
                        <asp:TextBox runat="server" ID="News" TextMode="MultiLine" CssClass="SimpleTextBox"></asp:TextBox>
                        <br />

                        News For:
                        <br />
                        <asp:CheckBox runat="server" Text="News For Every One" ID="All" AutoPostBack="true" OnCheckedChanged="All_CheckedChanged" />
                        <br />
                        <asp:CheckBox runat="server" Text="Matric" ID="Matric" AutoPostBack="false" />
                        <br />
                        <asp:CheckBox runat="server" Text="Intermediate" ID="Intermediate" AutoPostBack="false" />
                        [
                <asp:CheckBox runat="server" Text="PreEngineering" ID="PreEngineering" AutoPostBack="false" />
                        <asp:CheckBox runat="server" Text="PreMedical" ID="PreMedical" AutoPostBack="false" />
                        <asp:CheckBox runat="server" Text="Commerce" ID="Commerce" AutoPostBack="false" />
                        ]
                <br />
                        <br />
                        Is This News General?
                <asp:RadioButtonList ID="GeneralNews" runat="server">
                    <asp:ListItem ID="Yes" runat="server" Value="1" Text="This news will be displayed as a general news for all students"/>
                    <asp:ListItem ID="Not" runat="server" Value="0" Text="It will be specific for this coaching & will be displayed in all Branches" />
                </asp:RadioButtonList>
                        <br />
                        <label>What Is The Authenticity Of This News?</label>
                        <asp:TextBox runat="server" ID="Authenticity" TextMode="MultiLine" CssClass="SimpleTextBox"></asp:TextBox>
                        <asp:Label runat="server" ID="Warning" CssClass="contact"></asp:Label>
                        <asp:Button runat="server" CssClass="postButton" ID="Post" Text="Post News" Width="100%" Style="background-color: ghostwhite;" OnClick="Post_Click" />

                    </div>



                    <div class="announceContent">

                        <div class="Announcement">
                            Filter News:
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
                        <asp:Repeater ID="newsRepeater" runat="server" OnItemDataBound="newsRepeater_ItemDataBound" OnItemCommand="newsRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="Announcement">
                                    <asp:Panel runat="server" ID="NewsPanel">
                                        <h4>
                                            <asp:Label runat="server" ID="NewsDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:Label>
                                            <br />
                                            <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                                        </h4>
                                        <%# AddLineBreaks(DataBinder.Eval(Container.DataItem,"Info"))%>
                                        <h5>Authenticity</h5>
                                        <%# DataBinder.Eval(Container.DataItem,"Authenticity")%>
                                        <asp:Button ID="deleteNews" runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"NewsID")%>' CssClass="DetailButton" UseSubmitBehavior="false" Text="Delete News" />
                                    </asp:Panel>
                                    <asp:Label runat="server" ID="msg" Visible="true" CssClass="contact"></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                        <!-- end .announceContent -->
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- end .container -->
        </div>
        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:coachingPageConnection %>" SelectCommand="SELECT * FROM [Coaching]"></asp:SqlDataSource>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

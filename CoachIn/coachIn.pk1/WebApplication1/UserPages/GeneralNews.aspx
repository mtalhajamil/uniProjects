<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralNews.aspx.cs" Inherits="WebApplication1.UserPages.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/news.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet" />
    <title>Coaching News</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="newsContainer">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="newsUpperContainer">
                        <asp:Label runat="server" ID="Heading" CssClass="centerHeading">
                        <h1>General News Posted By Coaching Centers</h1>
                        </asp:Label>


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

                    <div class="newsLeft">
                        <asp:Repeater ID="newsRepeater" runat="server" OnItemDataBound="newsRepeater_ItemDataBound">
                            <ItemTemplate>
                                <div class="NewsShow">
                                    <asp:Panel runat="server" ID="NewsPanel">
                                        <h3>Posted By:  <%# DataBinder.Eval(Container.DataItem,"Name")%></h3>
                                        <h4>
                                            <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                                        </h4>
                                        <%# DataBinder.Eval(Container.DataItem,"Info")%>
                                        <h5>Authenticity:</h5>
                                        <%# DataBinder.Eval(Container.DataItem,"Authenticity")%>
                                        <br />
                                        <h4>Posted At:<asp:Label runat="server" ID="NewsDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:Label></h4>
                                    </asp:Panel>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="newsRight">
                <a class="twitter-timeline" href="https://twitter.com/SectionA_Info" data-widget-id="456516016307056640">Tweets by @SectionA_Info</a>
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
            </div>


            <!-- end .newsContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

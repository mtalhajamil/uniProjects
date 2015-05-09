<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachingPage.aspx.cs" Inherits="WebApplication1.CoachingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/design.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet" />
    <title>Coaching Profile</title>
</head>



<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <customControls:Header runat="server"></customControls:Header>
                <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
                <div class="container">
                    <div class="sidebar1">
                        <img src="ImgHandler.ashx?i=<%=coachID %>" alt="Coaching Image" width="100%" id="Img1" style="background-color: transparent; display: block;" />
                        <!-- end .sidebar1 -->
                    </div>
                    <div class="content">
                        <h1>
                            <asp:Label runat="server" ID="Heading">
                            </asp:Label></h1>
                        <h2>Description</h2>
                        <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="Description" cssclass="description"></asp:Label></pre>
                        </div>
                        <h2>Branches:</h2>

                        <asp:Repeater runat="server" ID="branchRepeater" OnItemCommand="branchRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="boxes">
                                    <asp:Button ID="Button1" CssClass="Button1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") + "\n Address:" + DataBinder.Eval(Container.DataItem,"Address") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' CommandName="buy" UseSubmitBehavior="False" />
                                </div>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>

                        <h3>Comments:</h3>


                        <div class="comments">
                            <label>Name:</label>
                            <asp:TextBox runat="server" ID="Name"></asp:TextBox>
                            <label>Email:</label>
                            <asp:TextBox runat="server" ID="Email"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                            <asp:Label runat="server" ID="Warning" CssClass="contact"></asp:Label>
                            <asp:Button runat="server" CssClass="postButton" ID="Post" Text="Post Comment" OnClick="Post_Click" />

                            <br />
                            <br />


                            <asp:Repeater runat="server" ID="commentRepeater" OnItemDataBound="commentRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <div class="posted">
                                        Posted By<asp:Label ID="Admin" runat="server"></asp:Label>: <b>
                                            <asp:Label ID="LabelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label></b> (<%# DataBinder.Eval(Container.DataItem, "EmailAddress") %>)
                                <br />
                                        <i>Comment:</i> <%# DataBinder.Eval(Container.DataItem, "Text") %>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>


                            <!-- end .comments -->
                        </div>

                        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:coachingPageConnection %>" SelectCommand="SELECT * FROM [Coaching]"></asp:SqlDataSource>

                        <!-- end .content -->
                    </div>
                    <div class="sidebar2">
                        <h4>News: </h4>
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
                        <asp:Button runat="server" CssClass="announceButton" Text="View All" ID="news_display" OnClick="news_display_Click" />
                        <!-- end .sidebar2 -->
                    </div>

                    <!-- end .container -->
                </div>

                <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

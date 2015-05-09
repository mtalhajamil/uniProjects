<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachingAdmin.aspx.cs" Inherits="WebApplication1.AdminPages.CoachingAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet" />
    <title>Coaching Profile</title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="container">

            <div class="sidebar1">
                <img src="ImgHandler.ashx?i=<%=coachID %>" alt="Coaching Image" width="100%" id="Img1" style="background-color: transparent; display: block;" />
                <asp:Button ID="EditPic" CssClass="announceButton" Text="Change Picture" runat="server" OnClick="EditPic_Click" />
                <asp:FileUpload ID="ChangePicture" runat="server" />
                <asp:Button ID="Upload" CssClass="announceButton" Text="Upload" runat="server" OnClick="Upload_Click" />
                <!-- end .sidebar1 -->
            </div>
            <div class="content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1>
                            <asp:Label runat="server" ID="Heading">
                            </asp:Label></h1>
                        <h2>Description</h2>
                        <div style="padding-left:20px;">
                        <pre><asp:Label runat="server" ID="Description" cssclass="description"></asp:Label></pre>
                        </div>
                        <asp:TextBox ID="DescEdit" runat="server" CssClass="EditTextBox" TextMode="MultiLine" onfocus="this.value = this.value;"></asp:TextBox>
                        <asp:Button ID="Edit" runat="server" CssClass="Edit" Text="Edit" OnClick="Edit_Click" />
                        <asp:Button ID="Submit" runat="server" CssClass="Edit" Text="Done" OnClick="Submit_Click" />



                        <h2>Branches:</h2>

                        <asp:Repeater runat="server" ID="branchRepeater" OnItemCommand="branchRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="boxes">
                                    <asp:Button ID="Button1" CssClass="Button1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") + "\n Address:" + DataBinder.Eval(Container.DataItem,"Address") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' CommandName="buy" UseSubmitBehavior="False" />
                                    <asp:Button ID="Delete1" runat="server" Text="Delete Branch" CssClass="DetailButton" UseSubmitBehavior="false" CommandName="delete1" />
                                    <asp:Label runat="server" CssClass="contact" ID="warning1" Visible="false">Are Sure you want to delete this branch?</asp:Label>
                                    <asp:Button ID="Delete2" runat="server" Text="I am sure" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="delete2" />
                                    <asp:Label runat="server" CssClass="contact" ID="warning2" Visible="false">It will be permanently deleted including all courses offered with this branch </asp:Label>
                                    <asp:Button ID="Delete3" runat="server" Text="Delete It" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="delete3" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' />
                                    <asp:Label runat="server" CssClass="contact" ID="warning3" Visible="false">Your Branch Is Removed </asp:Label>
                                    <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="cancel" />
                                </div>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="AddNewBranch" CssClass="DetailButton" runat="server" Text="Add A New Branch To Your Coaching" OnClick="AddNewBranch_Click" />

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <h3>Comments:</h3>
                        <div class="comments">
                            <label>Reply To Comments:</label>
                            <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                            <asp:Label runat="server" ID="Warning" CssClass="contact"></asp:Label>
                            <asp:Button runat="server" CssClass="postButton" ID="Post" Text="Post Comment" Width="100%" Style="background-color: ghostwhite;" OnClick="Comment_click" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>


                <!-- end .content -->
            </div>
            <div class="sidebar2">
                <h4>News: </h4>
                <asp:Repeater ID="newsRepeater" runat="server" OnItemDataBound="newsRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="Announcement">
                            <h4>
                                <asp:Label runat="server" ID="NewsDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:Label>
                                <br />
                                <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                            </h4>
                            <%# DataBinder.Eval(Container.DataItem,"Info")%>
                            <h5>Authenticity</h5>
                            <%# DataBinder.Eval(Container.DataItem,"Authenticity")%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Button runat="server" CssClass="announceButton" Text="Add News" ID="news_add" OnClick="news_add_Click" />
                <asp:Button runat="server" CssClass="announceButton" Text="View All" ID="news_display" OnClick="news_display_Click" />
                <!-- end .sidebar2 -->
            </div>


            <!-- end .container -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

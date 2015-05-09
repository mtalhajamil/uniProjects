<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Searching.aspx.cs" Inherits="WebApplication1.UserPages.Searching" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/news.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <script src="../script/jquery.min.js"></script>
    <title>Search!</title>
</head>

<script type="text/javascript">
    function doPostBack(o) {
        __doPostBack(o.id, '');
    }
    
    $(document).ready(function(){
        $('html,body').animate({ scrollTop: $('#PointA').offset().top }, 5000);
    });

    function MyFunction(){
        $('html,body').animate({ scrollTop: $('#PointA').offset().top }, 1);
    };
</script>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <div class="searchUpperContainer">
                    <asp:Label runat="server" ID="Heading" CssClass="centerHeading">
                        <h1>Search Your Faviourite Teacher<br />Subject Of Interest<br />Or Coaching Branches In your Area</h1>
                    </asp:Label>
                    <h4>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True">By Teacher</asp:ListItem>
                            <asp:ListItem>By Address</asp:ListItem>
                            <asp:ListItem>By Subject</asp:ListItem>
                        </asp:RadioButtonList></h4>
                    <asp:TextBox ID="Teacher" CssClass="inputSearchPageBox"  runat="server" onkeyup="doPostBack(this);" onfocus="this.value = this.value;"></asp:TextBox>
                    <asp:Label ID="SearchBy" runat="server" Text="Label"></asp:Label>
                    <a id="PointA"></a>
                </div>
                <div class="searchContainer">
                     
                    <asp:Panel ID="PanelTeacher" runat="server">
                        <asp:Repeater ID="RepTeacher" runat="server" OnItemCommand="RepTeacher_ItemCommand">
                            <ItemTemplate>
                                <div class="SearchShow">
                                    
                                    <asp:Label ID="Label1" CssClass="searchrespect" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Teacher") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label2" Text="Is Teaching " runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SubjectName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label4" Text="In the Course Named ' " runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CourseName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>

                                    <asp:Label ID="Label6" Text="' at " runat="server"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CampusName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <br />
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CoachingID") %>' CommandName="btn" UseSubmitBehavior="false" CausesValidation="false">
                                        <asp:Image ID="Image1" ImageAlign="Middle" runat="server" CssClass="tileSearch" ImageUrl='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                    </asp:LinkButton>
                                    <br />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>



                    <asp:Panel ID="PanelAddress" runat="server">
                        <asp:Repeater ID="RepeaterAddress" runat="server" OnItemCommand="RepTeacher_ItemCommand">
                            <ItemTemplate>
                                <div class="SearchShow">
                                    <asp:Label ID="Label9" CssClass="searchrespect" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CampusName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label10" Text="Of " runat="server"></asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label12" Text="Is located at " runat="server"></asp:Label>
                                    <asp:Label ID="Label13" runat="server" CssClass="searchrespect" Text='<%# DataBinder.Eval(Container.DataItem,"Address") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <br />
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CoachingID") %>' CommandName="btn" UseSubmitBehavior="false" CausesValidation="false">
                                        <asp:Image ID="Image2" ImageAlign="Middle" runat="server" CssClass="tile" ImageUrl='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                    </asp:LinkButton>
                                    <br />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                    <asp:Panel ID="PanelSubject" runat="server">
                        <asp:Repeater ID="RepeaterSubject" runat="server" OnItemCommand="RepTeacher_ItemCommand">
                            <ItemTemplate>
                                <div class="SearchShow">
                                    <asp:Label ID="Label14" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Teacher") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label15" Text="Is Teaching " runat="server"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" CssClass="searchrespect" Text='<%# DataBinder.Eval(Container.DataItem,"SubjectName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label17" Text="In the Course Named ' " runat="server"></asp:Label>
                                    <asp:Label ID="Label18" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CourseName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label19" Text="' at " runat="server"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <asp:Label ID="Label21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CampusName") %>' UseSubmitBehavior="false" CausesValidation="false"></asp:Label>
                                    <br />
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CoachingID") %>' CommandName="btn" UseSubmitBehavior="false" CausesValidation="false">
                                    <asp:Image ID="Image3" ImageAlign="Middle" runat="server" CssClass="tile" ImageUrl='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                    </asp:LinkButton>
                                    <br />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

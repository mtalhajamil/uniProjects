<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoachingDisplay.aspx.cs" Inherits="WebApplication1.UserPages.CoachingDispaly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/decoration.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <link href="../css/design.css" rel="stylesheet" type="text/css" />
    <title>Coaching Centers</title>
    <script type="text/javascript">
        function doPostBack(o) {
            __doPostBack(o.id, '');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID="HeaderStrip" runat="server"></customControls:headerStrip>
        <br />
        <div class="tileContainer">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="stripBar">Search Coaching Centers By Name:</div>
                    <asp:TextBox ID="Search" CssClass="inputSearchBox" runat="server" onkeyup="doPostBack(this);" onfocus="this.value = this.value;"></asp:TextBox>
                    <br />

                    <div style="height: 100%; background-color: transparent; text-align: center; position: relative; display: inline-block; width: 100%;">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CssClass="LinkButton" runat="server" CommandName="btn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CoachingID") %>' UseSubmitBehavior="false" CausesValidation="false">
                                <div class="outlineBox">
                                        <img class="tile" src='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                </div>
                                    </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="height: 500px; background-color: transparent;"></div>

            <!-- end .container -->
        </div>
        <customControls:Footer runat="server"></customControls:Footer>

    </form>
</body>
</html>


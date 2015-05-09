<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/news.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <link href="../css/decoration.css" rel="stylesheet" type="text/css" />
    <title>Get Out Of Here</title>

</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <div class="container">

            <asp:Label runat="server" ID="Heading" CssClass="centerHeading">
                        <h1>Requests</h1>
            </asp:Label>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="requests" runat="server" OnItemCommand="requests_ItemCommand">
                        <ItemTemplate>
                            <div class="subject">
                                <table>
                                    <tr>
                                        <td>
                                            <b>Name:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Email Address:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAdress" runat="server" Text='<%#Eval("EmailAddress") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Email Address2:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EmailAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Contact:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Contact1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Address:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Address") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Matric:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Matric") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Intermediate:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("Intermediate") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>PreEngineering:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("PreEngineering") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>PreMedical:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("PreMedical") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Commerce:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("Commerce") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Picture:</b>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image3" ImageAlign="Middle" runat="server" CssClass="tileSearch" Style="width:200px;height:auto;" ImageUrl='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Contact Details:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("ContactDetails") %>' />
                                        </td>
                                    </tr>
                                </table>

                                <asp:Button Text="Accept" CssClass="DetailButton" ID="lnkEdit" runat="server" CommandArgument='<%#Eval("CoachingID") %>' CommandName="Accept"></asp:Button>
                                <asp:Button Text="Delete" CssClass="DetailButton" ID="lnkDelete" runat="server" CommandArgument='<%#Eval("CoachingID") %>' CommandName="delete" OnClientClick="return confirm('Are you sure you want to delete?')"></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:Label runat="server" ID="Label5" CssClass="centerHeading">
                        <h1>Accepted</h1>
                    </asp:Label>

                    <asp:Repeater ID="Accepted" runat="server" OnItemCommand="Accepted_ItemCommand">
                        <ItemTemplate>
                            <div class="subject">
                                <table>
                                    <tr>
                                        <td>
                                            <b>ID:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("CoachingID") %>' />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <b>Name:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Description:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("Discription") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Email Address:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAdress" runat="server" Text='<%#Eval("EmailAddress") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Email Address2:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EmailAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Password:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("Password") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Contact:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Contact1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Matric:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("Matric") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Intermediate:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("Intermediate") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>PreEngineering:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("PreEngineering") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>PreMedical:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("PreMedical") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Commerce:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("Commerce") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Picture:</b>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image3" ImageAlign="Middle" Style="width:200px;height:auto;" runat="server" CssClass="tileSearch" ImageUrl='<%# "data:image/png;base64,"+ Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Photo"),0,((byte[])DataBinder.Eval(Container.DataItem,"Photo")).Length) %>' />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button Text="Delete" CssClass="DetailButton" ID="lnkDelete" runat="server" CommandArgument='<%#Eval("CoachingID") %>' CommandName="delete" OnClientClick="return confirm('Are you sure you want to delete?')"></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- end .container -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

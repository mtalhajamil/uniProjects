<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp2.aspx.cs" Inherits="WebApplication1.UserPages.SignUp2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Registration Step 2</title>
</head>



<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>

        <div class="SignUpContainer2">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Register My Coaching
                </div>
                <asp:Image ID="Image1" runat="server" Width="200px" Style="float: right;" />
                <table>
                    <tr>
                        <td>
                            <h2>Email Address:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Email1" runat="server" CssClass="inputBox" TextMode="Email"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Alternate Email Address:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Email2" runat="server" CssClass="inputBox" TextMode="Email"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Password:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="Pass" runat="server" CssClass="inputBox" TextMode="Password"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Retype Password:</h2>
                        </td>
                        <td>
                            <asp:TextBox ID="ChkPass" runat="server" CssClass="inputBox" TextMode="Password"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Do you teach matriculation?</h2>
                        </td>
                        <td>

                            <asp:CheckBox ID="matric" runat="server" Text="Matriculation" AutoPostBack="False" />

                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Do you teach intermediate?</h2>
                        </td>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <td>

                                    <asp:CheckBox ID="inter" runat="server" Text="Intermediate" OnCheckedChanged="inter_CheckedChanged" AutoPostBack="True" />
                                    <br />
                                    <asp:CheckBox ID="eng" runat="server" Text="PreEngineering" Visible="False" AutoPostBack="False" />
                                    <br />
                                    <asp:CheckBox ID="med" runat="server" Text="PreMedical" Visible="False" AutoPostBack="False" />
                                    <br />
                                    <asp:CheckBox ID="comm" runat="server" Text="Commerce" Visible="False" AutoPostBack="False" />
                                </td>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </tr>
                </table>

                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../img/next.png" Style="float: right;" Width="138px" OnClick="ImageButton1_Click" />
                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>
                <br />
                <br />
                Thousands or even more people can search and visit your profile !!
                <!-- end .SignUpRight -->
            </div>

            <!-- end .SignUpContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

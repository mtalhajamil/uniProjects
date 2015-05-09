<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="WebApplication1.SignUp.AddSubject" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <title>Add A New Subject In Your Course</title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="AddSubjectContainer">

            <div class="SignUpLeft">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="leftHeaderstrip">
                            Add A Subject To My Course
                        </div>
                        <br />
                        <h2>Subject:</h2>
                        <asp:TextBox ID="SubjectName" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                        <h2>Teacher: (Sir/Mamdam)</h2>
                        <asp:TextBox ID="Teacher" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                        <h2>Seats Remaining:</h2>
                        <asp:TextBox ID="Seats" runat="server" CssClass="inputSignInBox" TextMode="Number"></asp:TextBox>
                        <h2>Class To Start On:</h2>
                        <br />
                        <asp:Calendar ID="StartCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <h2>Class Duration: (minutes)</h2>
                        <asp:TextBox ID="Duration" runat="server" CssClass="inputSignInBox" TextMode="Number"></asp:TextBox>
                        <h2>Fee Per Month: RS</h2>
                        <asp:TextBox ID="Fees" runat="server" CssClass="inputSignInBox" TextMode="Number"></asp:TextBox>
                        <h2>LumpSum: RS</h2>
                        <asp:TextBox ID="Fees_LumpSum" runat="server" CssClass="inputSignInBox" TextMode="Number"></asp:TextBox>

                        <h3>Set Days & Timmings:</h3>

                        <table border="0">
                            <tr>
                                <td>Monday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="MonCheck" OnCheckedChanged="MonCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="MonText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Tuesday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="TueCheck" OnCheckedChanged="TueCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="TueText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Wednesday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="WedCheck" OnCheckedChanged="WedCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="WedText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Thursday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="ThursCheck" OnCheckedChanged="ThursCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="ThursText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Friday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="FriCheck" OnCheckedChanged="FriCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="FriText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Saturday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="SatCheck" OnCheckedChanged="SatCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="SatText" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Sunday:</td>
                                <td>
                                    <asp:CheckBox runat="server" AutoPostBack="true" ID="SunCheck" OnCheckedChanged="SunCheck_CheckedChanged" /></td>
                                <td>
                                    <asp:TextBox runat="server" CssClass="EditSingleBox" ID="SunText" Visible="false"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label runat="server" CssClass="contact" ID="subjectAdded" Visible="false"></asp:Label>
                <asp:Button ID="Finish" CssClass="Finish" runat="server" Text="Add This Subject To My Course" OnClick="Finish_Click" />
                <asp:Button ID="AddAnother" CssClass="Finish" runat="server" Text="Add This Subject & One More Subject" OnClick="AddAnother_Click" />

                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>

                <!-- end .SignUpRight -->
            </div>

            <!-- end .AddCourseContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

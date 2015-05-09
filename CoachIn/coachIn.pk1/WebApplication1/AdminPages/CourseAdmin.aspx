<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAdmin.aspx.cs" Inherits="WebApplication1.AdminPages.CourseAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" rel="stylesheet" type="text/css" />
    <title>Course Selected</title>
</head>



<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="container">
            <div class="announceContent">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="course">
                            <asp:Panel runat="server" ID="CourseDisplay">
                                <table>
                                    <tr>
                                        <td>
                                            <h3>
                                                <asp:Label runat="server" ID="Name"></asp:Label></h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="FeesL">Fees Per Month(Including All Subjects): </asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="FeePerMonth"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="LumpSumL">If you give it all together(A Lumpsum): </asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="LumpSum"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="DetailsL">Furthur Details: </asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Details"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="CourseL">Course For: </asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="LabelMatric"></asp:Label>
                                            <asp:Label runat="server" ID="LabelPreEngineering"></asp:Label>
                                            <asp:Label runat="server" ID="LabelPreMedical"></asp:Label>
                                            <asp:Label runat="server" ID="LabelCommerce"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button runat="server" ID="Edit" Text="Make Changes" CssClass="DetailButton" OnClick="Edit_Click" />
                                <br />

                            </asp:Panel>
                            <asp:Panel runat="server" ID="EditCourse">
                                <asp:Label runat="server" ID="NameLabel">Name:</asp:Label><asp:TextBox runat="server" ID="EditName" CssClass="EditFonts"></asp:TextBox>
                                <br />
                                <asp:Label runat="server" ID="FeesLabel">Fees Per Month(Including All Subjects): </asp:Label><asp:TextBox runat="server" ID="EditFees" CssClass="EditFonts"></asp:TextBox>
                                <br />
                                <asp:Label runat="server" ID="LumpSumLabel">If you give it all together(A Lumpsum): </asp:Label><asp:TextBox runat="server" ID="EditLumpSum" CssClass="EditFonts"></asp:TextBox>
                                <br />
                                <asp:Label runat="server" ID="DetailsLabel">Furthur Details: </asp:Label><asp:TextBox runat="server" ID="EditDetails" CssClass="EditTextBoxWithBorder" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <asp:Label runat="server" ID="CourseLabel">Course For: </asp:Label>
                                <br />
                                <asp:CheckBox runat="server" Text="Matric" ID="Matric" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate" ID="Intermediate" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate PreEngineering" ID="PreEngineering" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate PreMedical" ID="PreMedical" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate Commerce" ID="Commerce" AutoPostBack="false" />

                                <asp:Button runat="server" ID="Submit" Text="OK" CssClass="announceButton" OnClick="Submit_Click" />
                            </asp:Panel>
                            <asp:Repeater runat="server" ID="subjectRepeater" OnItemDataBound="subjectRepeater_ItemDataBound" OnItemCommand="subjectRepeater_ItemCommand">
                                <ItemTemplate>
                                    <div class="subject">
                                        <asp:Panel runat="server" ID="subjectShow">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <h4>
                                                        Subject:</td>
                                                    <td>
                                                        <asp:TextBox ID="SubjectName" runat="server" CssClass="EditTextDisables" Text='<%# DataBinder.Eval(Container.DataItem,"SubjectName") %>'></asp:TextBox></h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Teacher: (Sir/Mamdam)</td>
                                                    <td>
                                                        <asp:TextBox ID="Teacher" runat="server" CssClass="EditTextDisables" Text='<%#DataBinder.Eval(Container.DataItem,"Teacher")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Seats Remaining:</td>
                                                    <td>
                                                        <asp:TextBox ID="Seats" runat="server" CssClass="EditTextDisables" Text='<%#DataBinder.Eval(Container.DataItem,"SeatsRemaining")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Class To Start On:</td>
                                                    <td>
                                                        <asp:TextBox ID="Start" runat="server" CssClass="EditTextDisables" Text='<%#DataBinder.Eval(Container.DataItem,"StartDate")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Class Duration: (minutes)</td>
                                                    <td>
                                                        <asp:TextBox ID="Duration" runat="server" CssClass="EditTextDisables" Text='<%# DataBinder.Eval(Container.DataItem,"Duration")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Fee Per Month: </td>
                                                    <td>RS<asp:TextBox ID="Fees" runat="server" CssClass="EditTextDisables" Text='<%#DataBinder.Eval(Container.DataItem,"Fees")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>LumpSum: </td>
                                                    <td>RS<asp:TextBox ID="LumpSum" runat="server" CssClass="EditTextDisables" Text='<%#DataBinder.Eval(Container.DataItem,"[Lump Sum]")%>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel runat="server" ID="DayDiv">
                                                <h5>Days & Timmings:</h5>
                                                <table border="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Monday" Text='<%# DataBinder.Eval(Container.DataItem,"Monday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Mon_time" Text='<%# DataBinder.Eval(Container.DataItem,"Mon_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Tuesday" Text='<%# DataBinder.Eval(Container.DataItem,"Tuesday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Tues_time" Text='<%# DataBinder.Eval(Container.DataItem,"Tues_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Wednesday" Text='<%# DataBinder.Eval(Container.DataItem,"Wednesday") %>'></asp:Label>
                                                        </td>


                                                        <td>
                                                            <asp:Label runat="server" ID="Wed_time" Text='<%# DataBinder.Eval(Container.DataItem,"Wed_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Thursday" Text='<%# DataBinder.Eval(Container.DataItem,"Thursday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Thurs_time" Text='<%# DataBinder.Eval(Container.DataItem,"Thurs_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Friday" Text='<%# DataBinder.Eval(Container.DataItem,"Friday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Fri_time" Text='<%# DataBinder.Eval(Container.DataItem,"Fri_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Saturday" Text='<%# DataBinder.Eval(Container.DataItem,"Saturday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Sat_time" Text='<%# DataBinder.Eval(Container.DataItem,"Sat_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="Sunday" Text='<%# DataBinder.Eval(Container.DataItem,"Sunday") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="Sun_time" Text='<%# DataBinder.Eval(Container.DataItem,"Sun_time") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="CheckDiv">

                                            <br />
                                            <h5>Days & Timmings:</h5>
                                            <table border="0">
                                                <tr>
                                                    <td>Monday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="MonCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="MonText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Tuesday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="TueCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="TueText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Wednesday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="WedCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="WedText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Thursday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="ThursCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="ThursText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Friday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="FriCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="FriText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Saturday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="SatCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="SatText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Sunday:</td>
                                                    <td>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="SunCheck" /></td>
                                                    <td>
                                                        <asp:TextBox runat="server" CssClass="EditSingleBox" ID="SunText"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>

                                        <asp:Button ID="Edit" runat="server" CssClass="announceButton" Text="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SubjectID")%>' CommandName="Edit" UseSubmitBehavior="False" />
                                        <asp:Button ID="Submit" runat="server" CssClass="announceButton" Text="Submit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SubjectID")%>' CommandName="Submit" UseSubmitBehavior="False" />
                                        <asp:Button ID="Delete1" runat="server" Text="Delete This Subject" CssClass="DetailButton" UseSubmitBehavior="false" CommandName="delete1" />
                                        <asp:Label runat="server" CssClass="contact" ID="warning1" Visible="false">Are Sure you want to delete this subject?</asp:Label>
                                        <asp:Button ID="Delete2" runat="server" Text="I am sure" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="delete2" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SubjectID")%>' />
                                        <asp:Label runat="server" CssClass="contact" ID="warning2" Visible="false">Your Subject Is Removed </asp:Label>
                                        <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="cancel" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="course">
                                <h4>Add Another Subject:</h4>
                                <br />
                                Subject:
                                    <asp:TextBox ID="SubjectName" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                                Teacher: (Sir/Mamdam)
                                        <asp:TextBox ID="Teacher" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                                <br />
                                Seats Remaining:
                                        <asp:TextBox ID="Seats" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                                <br />
                                Class To Start On:<br />
                                        <asp:Calendar ID="StartCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                            <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                                <br />
                                Class Duration: (minutes)
                                        <asp:TextBox ID="Duration" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                                <br />
                                Fee Per Month: RS<asp:TextBox ID="Fees" runat="server" CssClass="inputSignInBox"></asp:TextBox>
                                <br />
                                LumpSum: RS<asp:TextBox ID="Fees_LumpSum" runat="server" CssClass="inputSignInBox"></asp:TextBox>

                                <h5>Set Days & Timmings:</h5>
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
                                <asp:Label runat="server" CssClass="contact" ID="subjectAdded" Visible="false"></asp:Label>
                                <asp:Button runat="server" ID="AddSubject" Text="Submit Subject Details" CssClass="DetailButton" OnClick="AddSubject_Click" />
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <!-- end .announceContent -->
        </div>
        <!-- end .container -->
        </div>
        <asp:SqlDataSource ID="CoachIn" runat="server" ConnectionString="<%$ ConnectionStrings:coachingPageConnection %>" SelectCommand="SELECT * FROM [Coaching]"></asp:SqlDataSource>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

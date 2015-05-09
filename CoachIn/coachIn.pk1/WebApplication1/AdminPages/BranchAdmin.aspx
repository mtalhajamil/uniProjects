<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchAdmin.aspx.cs" Inherits="WebApplication1.AdminPages.BranchAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <link href="../css/signIn.css" type="text/css" rel="stylesheet">
    <title>Branch Profile</title>
</head>

<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <customControls:Header ID="Header1" runat="server"></customControls:Header>
                <customControls:headerStrip ID="HeaderStrip" runat="server"></customControls:headerStrip>
                <div class="container">

                    <div class="sidebar1">
                        <img src="ImgHandler.ashx?i=<%=select %>" alt="Coaching Image" width="100%" id="Img1" style="background-color: transparent; display: block;" />

                        <br />
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
                        <asp:Button runat="server" CssClass="announceButton" Text="View All" ID="news_display" OnClick="news_display_Click" />
                        <!-- end .sidebar1 -->
                    </div>
                    <div class="content">
                        <h1>
                            <asp:Label runat="server" ID="Heading">
                            </asp:Label>
                            <asp:Button ID="Edit2" runat="server" CssClass="Edit" Text="Edit" OnClick="Edit2_Click" /></h1>
                        <asp:TextBox ID="HeadingEdit" runat="server" CssClass="EditBigBox" onfocus="this.value = this.value;"></asp:TextBox>
                        <asp:Button ID="Submit2" runat="server" CssClass="Edit" Text="Done" OnClick="Submit2_Click" />

                        <br />
                        <asp:Label runat="server" ID="Contact" CssClass="contact"></asp:Label>
                        <asp:Button ID="Edit" runat="server" CssClass="Edit" Text="Edit" OnClick="Edit_Click" />
                        <asp:Label runat="server" ID="ContactLabel1" CssClass="contact" Text="Contact1: "></asp:Label>
                        <asp:TextBox ID="ContactEdit1" runat="server" CssClass="EditSingleBox" onfocus="this.value = this.value;"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" ID="ContactLabel2" CssClass="contact" Text="Contact2:"></asp:Label>
                        <asp:TextBox ID="ContactEdit2" runat="server" CssClass="EditSingleBox" onfocus="this.value = this.value;"></asp:TextBox>
                        <asp:Button ID="Submit" runat="server" CssClass="Edit" Text="Done" OnClick="Submit_Click" />
                        <br />
                        <label class="contact">Address:</label>
                        <asp:Label runat="server" CssClass="contact" ID="Address">
                        </asp:Label>
                        <asp:Button ID="Edit3" runat="server" CssClass="Edit" Text="Edit" OnClick="Edit3_Click" />
                        <asp:TextBox ID="AddressEdit" runat="server" CssClass="EditSingleBox" onfocus="this.value = this.value;"></asp:TextBox>
                        <asp:Button ID="Submit3" runat="server" CssClass="Edit" Text="Done" OnClick="Submit3_Click" />
                        <br />
                        <h2>Description</h2>

                        <div style="padding-left: 20px;">
                            <pre><asp:Label runat="server" ID="Description" cssclass="description"></asp:Label></pre>
                        </div>
                        <asp:TextBox ID="DescEdit" runat="server" CssClass="EditTextBox" TextMode="MultiLine" onfocus="this.value = this.value;"></asp:TextBox>
                        <asp:Button ID="Edit4" runat="server" CssClass="Edit" Text="Edit" OnClick="Edit4_Click" />
                        <asp:Button ID="Submit4" runat="server" CssClass="Edit" Text="Done" OnClick="Submit4_Click" />

                        <h2>Courses Offered:</h2>
                        <asp:Button ID="AddNewCourses" runat="server" CssClass="DetailButton" Text="Add New Course" OnClick="AddNewCourses_Click" />
                        <div class="course">
                            Filter Courses:
                            <br />
                            <asp:CheckBox runat="server" Text="Matric" ID="Matric" AutoPostBack="True" />
                            <br />
                            <asp:CheckBox runat="server" Text="Intermediate" ID="Intermediate" AutoPostBack="True" />
                            [
                            <asp:CheckBox runat="server" Text="PreEngineering" ID="PreEngineering" AutoPostBack="True" />
                            <asp:CheckBox runat="server" Text="PreMedical" ID="PreMedical" AutoPostBack="True" />
                            <asp:CheckBox runat="server" Text="Commerce" ID="Commerce" AutoPostBack="True" />
                            ]
                        </div>

                        <asp:Repeater runat="server" ID="courseRepeater" OnItemCommand="courseRepeater_ItemCommand" OnItemDataBound="courseRepeater_ItemDataBound">
                            <ItemTemplate>
                                <div class="course">
                                    <asp:Panel ID="courseShow" runat="server">
                                        <h3><%# DataBinder.Eval(Container.DataItem,"Name") %></h3>
                                        <asp:Button runat="server" ID="EditCourse" CssClass="DetailButton" Text="Edit Course Details/Add,Remove or Edit Subjects" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CourseID") %>' UseSubmitBehavior="False" />
                                        Fees Per Month(Including All Subjects): RS <%#DataBinder.Eval(Container.DataItem,"[Fee/Month]") %>
                                        <br />
                                        If you give it all together(A Lumpsum): RS <%#DataBinder.Eval(Container.DataItem,"LumpSum") %>
                                        <br />
                                        Furthur Details: <%# DataBinder.Eval(Container.DataItem,"Details") %>
                                        <br />
                                        Course For:
                                    <asp:Label runat="server" ID="MatricLabel" Text='<%# DataBinder.Eval(Container.DataItem,"Matric") %>'></asp:Label>
                                        <asp:Label runat="server" ID="PreEngineeringLabel" Text='<%# DataBinder.Eval(Container.DataItem,"PreEngineering") %>'></asp:Label>
                                        <asp:Label runat="server" ID="PreMedicalLabel" Text='<%# DataBinder.Eval(Container.DataItem,"PreMedical") %>'></asp:Label>
                                        <asp:Label runat="server" ID="CommerceLabel" Text='<%# DataBinder.Eval(Container.DataItem,"Commerce") %>'></asp:Label>

                                        <asp:Button runat="server" ID="displaySubject" CssClass="DetailButton" Text="Show Details" CommandName="display" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CourseID") %>' UseSubmitBehavior="False" />
                                    </asp:Panel>
                                    <asp:Button ID="Delete1" runat="server" Text="Delete This Course" CssClass="DetailButton" UseSubmitBehavior="false" CommandName="delete1" />
                                    <asp:Label runat="server" CssClass="contact" ID="warning1" Visible="false">Are Sure you want to delete this course?</asp:Label>
                                    <asp:Button ID="Delete2" runat="server" Text="I am sure" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="delete2" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CourseID")%>' />
                                    <asp:Label runat="server" CssClass="contact" ID="warning2" Visible="false">Your Course Is Removed </asp:Label>
                                    <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="DetailButton" Visible="false" UseSubmitBehavior="false" CommandName="cancel" />
                                    <asp:Repeater runat="server" ID="subjectRepeater" OnItemDataBound="subjectRepeater_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="subject">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4>
                                                                <%# DataBinder.Eval(Container.DataItem,"SubjectName") %>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Teacher: Sir/Mamdam</td>
                                                        <td><%# " " + DataBinder.Eval(Container.DataItem,"Teacher")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Seats Remaining:</td>
                                                        <td><%#DataBinder.Eval(Container.DataItem,"SeatsRemaining")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Class To Start On:</td>
                                                        <td>
                                                            <asp:Label runat="server" ID="DateChange" Text='<%#DataBinder.Eval(Container.DataItem,"StartDate")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Class Duration:</td>
                                                        <td><%# DataBinder.Eval(Container.DataItem,"Duration") + " " + "minutes"%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Fee Per Month:</td>
                                                        <td><%# "RS " + DataBinder.Eval(Container.DataItem,"Fees")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>LumpSum:</td>
                                                        <td><%# "RS " + DataBinder.Eval(Container.DataItem,"[Lump Sum]")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h5>Days & Timmings:</h5>
                                                        </td>
                                                    </tr>
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
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- end .content -->
                    </div>

                    <div class="sidebar2">
                        <h4>Announcements:</h4>
                        <asp:Repeater ID="announcementRepeater" runat="server" OnItemDataBound="announcementRepeater_ItemDataBound">
                            <ItemTemplate>
                                <div class="Announcement">
                                    <h4>
                                        <asp:Label runat="server" ID="AnnouncementDate" Text='<%# DataBinder.Eval(Container.DataItem,"Date")%>'></asp:Label>
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem,"Tittle")%>
                                    </h4>
                                    <%# DataBinder.Eval(Container.DataItem,"Notification")%>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button runat="server" CssClass="announceButton" Text="Add New" ID="announcement_add" OnClick="announcement_add_Click" />
                        <asp:Button runat="server" CssClass="announceButton" Text="View All" ID="announcement_display" OnClick="announcement_display_Click" />
                        <!-- end .sidebar2 -->
                    </div>


                    <!-- end .container -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>



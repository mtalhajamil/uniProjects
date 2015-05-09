<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseAddition.aspx.cs" Inherits="WebApplication1.SignUp.CourseAddition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Add A New Course</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID ="HeaderStrip" runat="server"></customControls:headerStrip>
        <div class="AddCourseContainer">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Add A Course To My Branch
                </div>
                <table>
                    <tr>
                        <td>
                            <h2>Course Name:</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Name" runat="server" CssClass="inputBox"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Fees/Month(Rupees):</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Fees" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>LumpSum Fees<br />(Total Fees If Paid Together):</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="LumpSum" runat="server" CssClass="inputBox" TextMode="Number"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <h2>Furthur Details</h2>
                        </td>
                        <td class="bigRow">
                            <asp:TextBox ID="Details" runat="server" CssClass="inputBoxBig" TextMode="MultiLine"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="bigRow">
                            <h2>Course For:</h2>
                        </td>
                        <td>
                            <h3>Matric:</h3>
                            <asp:CheckBox runat="server" Text="Matric" ID="Matric" AutoPostBack="false" />
                                <br />
                                <h3>Imtermediate:</h3>
                                <asp:CheckBox runat="server" Text="Intermediate PreEngineering" ID="PreEngineering" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate PreMedical" ID="PreMedical" AutoPostBack="false" />
                                <br />
                                <asp:CheckBox runat="server" Text="Intermediate Commerce" ID="Commerce" AutoPostBack="false" />
                        </td>

                    </tr>
                </table>
                <asp:Button ID="Finish" CssClass="Finish" runat="server" Text="Submit Course Details" OnClick="Finish_Click" />

                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Why Should I Register?
                </div>
                <br />
                <br />
                CoachIn.pk allows you to advertise your coaching in a most unique, sophisticated and effective way!!!
                <!-- end .SignUpRight -->
            </div>

            <!-- end .AddCourseContainer -->
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>


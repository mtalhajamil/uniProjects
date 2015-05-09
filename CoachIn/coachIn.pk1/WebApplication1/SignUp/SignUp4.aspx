<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp4.aspx.cs" Inherits="WebApplication1.SignUp.SignUp4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/signUp.css" rel="stylesheet" type="text/css" />
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <title>Thank You!</title>
</head>



<body>
    <form id="form1" runat="server">
        <customControls:Header ID="Header1" runat="server"></customControls:Header>


        <div class="SignUpContainer">

            <div class="SignUpLeft">

                <div class="leftHeaderstrip">
                    Thank You For Registering!
                    You will soon recieve a Verification Call.
                    JazakAllah
                    
                </div>

                <!-- end .SignUpLeft -->
            </div>
            <div class="SignUpRight">

                <div class="rightHeaderstrip">
                    Process Of Verification
                </div>
                <br />
                <br />
                Each and every detail you have provided would be verified by our team , and in case of positive result your coaching will be registered to CoachIn.pk
                <!-- end .SignUpRight -->
            </div>

            <!-- end .SignUpContainer -->
        </div>
<customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>

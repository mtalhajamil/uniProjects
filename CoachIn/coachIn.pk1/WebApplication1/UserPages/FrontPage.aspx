<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="WebApplication1.UserPages.FrontPage" %>

<!doctype html>
<html>
<head>
    <link rel="icon" sizes="16x16" href="../img/favicon.ico" />
    <link href="../css/decoration.css" rel="stylesheet" type="text/css" />
    <link href="../css/design.css" type="text/css" rel="stylesheet">
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <link href="../css/front.css" type="text/css" rel="stylesheet">
    <link href="../css/JQueryStyle.css" type="text/css" rel="stylesheet">
    <meta charset="utf-8">
    <title>Home</title>
</head>

<body>

    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <!-- use jssor.slider.mini.js (39KB) or jssor.sliderc.mini.js (31KB, with caption, no slideshow) or jssor.sliders.mini.js (26KB, no caption, no slideshow) instead for release -->
    <!-- jssor.slider.mini.js = jssor.sliderc.mini.js = jssor.sliders.mini.js = (jssor.core.js + jssor.utils.js + jssor.slider.js) -->
    <script type="text/javascript" src="../js/jssor.core.js"></script>
    <script type="text/javascript" src="../js/jssor.utils.js"></script>
    <script type="text/javascript" src="../js/jssor.slider.js"></script>
    <script type="text/javascript" src="../js/JQuery.js"></script>

    <form runat="server" id="form1">



        <customControls:Header ID="Header1" runat="server"></customControls:Header>
        <customControls:headerStrip ID="HeaderStrip" runat="server"></customControls:headerStrip>


        <div class="frontContainer">
            
            <br />
            <div class="Slider">
                <div id="slider1_container" style="position: relative; top: 0px; left: 0px; width: 1100px; height: 350px; margin: 0 auto;">
                    <!-- Slides Container -->
                    <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1100px; height: 350px; overflow: hidden;">
                        <div>
                            <div id="sliderh1_container" class="sliderh1" style="position: relative; top: 0px; left: 0px; width: 1100px; height: 350px;">

                                <!-- Slides Container -->
                                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1100px; height: 350px; overflow: hidden;">
                                    <div style="height: auto">
                                        <img u="image" src="../im1/01.jpg" style="height: auto" />
                                    </div>
                                    <div style="height: auto">
                                        <img u="image" src="../im1/02.jpg" style="height: auto" />
                                    </div>
                                    <div style="height: auto">
                                        <img u="image" src="../im1/03.jpg" style="height: auto" />
                                    </div>
                                    <div style="height: auto">
                                        <img u="image" src="../im1/04.jpg" style="height: auto" />
                                    </div>
                                    <div style="height: auto">
                                        <img u="image" src="../im1/05.jpg" style="height: auto" />
                                    </div>
                                    <div style="height: auto">
                                        <img u="image" src="../im1/06.jpg" style="height: auto" />
                                    </div>
                                </div>
                                <!-- Navigator Skin Begin -->
                                <!-- navigator container -->
                                <div u="navigator" class="jssorn03" style="position: absolute; bottom: 10px; right: 10px;">
                                    <!-- navigator item prototype -->
                                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                                        <numbertemplate></numbertemplate>
                                    </div>
                                </div>
                                <!-- Navigator Skin End -->
                            </div>
                        </div>
                        <div>
                            <div id="sliderh2_container" class="sliderh2" style="position: relative; top: 0px; left: 0px; width: 1100px; height: 350px;">

                                <!-- Slides Container -->
                                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1100px; height: 350px; overflow: hidden;">
                                    <div>
                                        <img u="image" src="../im1/04.jpg" />
                                    </div>
                                    <div>
                                        <img u="image" src="../im1/05.jpg" />
                                    </div>
                                    <div>
                                        <img u="image" src="../im1/06.jpg" />
                                    </div>
                                </div>
                                <!-- Navigator Skin Begin -->
                                <!-- navigator container -->
                                <div u="navigator" class="jssorn03" style="position: absolute; bottom: 10px; right: 10px;">
                                    <!-- navigator item prototype -->
                                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                                        <numbertemplate></numbertemplate>
                                    </div>
                                </div>
                                <!-- Navigator Skin End -->
                            </div>
                        </div>
                        <div>
                            <div id="sliderh3_container" class="sliderh3" style="position: relative; top: 0px; left: 0px; width: 1100px; height: 350px;">

                                <!-- Slides Container -->
                                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1100px; height: 350px; overflow: hidden;">
                                    <div>
                                        <img u="image" src="../im1/01.jpg" />
                                    </div>
                                    <div>
                                        <img u="image" src="../im1/02.jpg" />
                                    </div>
                                </div>
                                <!-- Navigator Skin Begin -->
                                <!-- navigator container -->
                                <div u="navigator" class="jssorn03" style="position: absolute; bottom: 10px; right: 10px;">
                                    <!-- navigator item prototype -->
                                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                                        <numbertemplate></numbertemplate>
                                    </div>
                                </div>
                                <!-- Navigator Skin End -->
                            </div>
                        </div>
                    </div>
                    <!-- Navigator Skin Begin -->
                    <!-- jssor slider navigator skin 02 -->
                    <!-- navigator container -->
                    <div u="navigator" class="jssorn02" style="position: absolute; bottom: 8px; left: 6px;">
                        <!-- navigator item prototype -->
                        <div u="prototype" style="POSITION: absolute; WIDTH: 21px; HEIGHT: 21px; text-align: center; line-height: 21px; color: White; font-size: 12px;">
                            <numbertemplate></numbertemplate>
                        </div>
                    </div>
                    <!-- Navigator Skin End -->
                    <a style="display: none" href="http://www.jssor.com">jQuery Slideshow</a>
                </div>
                <br />
                
              
                <div class="linkDiv">
                    <table>
                        <tr>
                            <td>
                                <div class="shapesDiv">
                                    <a href="/UserPages/CoachingDisplay.aspx">
                                        <img src="../img/logo_coaching.jpg" class="imageset"></a>
                                    <div class="stripBar">Visit Coaching Centers</div>
                                </div>
                            </td>
                            <td>
                                <div class="shapesDiv">
                                    <a href="/UserPages/GeneralNews.aspx">
                                        <img src="../img/logo_news.jpg" class="imageset"></a>
                                    <div class="stripBar">View Latest News</div>
                                </div>
                            </td>
                            <td>
                                <div class="shapesDiv">
                                    <a href="/SignUp/SignUp1.aspx">
                                        <img src="../img/logo_register.png" class="imageset"></a>
                                    <div class="stripBar">Register Your Coaching</div>
                                </div>
                            </td>
                            <td>
                                <div class="shapesDiv">
                                    <a href="/UserPages/Searching.aspx">
                                        <img src="../img/logo_search.png" class="imageset"></a>
                                    <div class="stripBar">Search!</div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
        </div>
        <customControls:Footer ID="Footer1" runat="server"></customControls:Footer>
    </form>
</body>
</html>





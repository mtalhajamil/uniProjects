using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Controls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] != null)
                LogIn.Text = "Logged In: CoachingID = " + Session["CoachingID"].ToString();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["CoachingID"] = null;
            Response.Redirect("~/SignUp/SignIn.aspx");
        }

        protected void CoachingPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/CoachingAdmin.aspx");
        }
    }
}
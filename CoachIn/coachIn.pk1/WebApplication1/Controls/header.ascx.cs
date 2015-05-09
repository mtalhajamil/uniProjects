using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Controls
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp/SignUp1.aspx");
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignUp/SignIn.aspx");
        }

        protected void Searching_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPages/Searching.aspx");
        }
    }
}
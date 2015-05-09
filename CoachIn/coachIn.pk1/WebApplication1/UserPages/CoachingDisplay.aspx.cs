using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserPages
{
    public partial class CoachingDispaly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            Search.Focus();

            string cmdToFilter = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
            {
                if (string.IsNullOrWhiteSpace(Search.Text) == true)
                    cmdToFilter = "SELECT * FROM [Coaching]";
                else
                    cmdToFilter = "SELECT * from Coaching where Name Like '%" + Search.Text + "%' ORDER BY Name";

                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdToFilter, cnn))
                {
                    SqlDataReader reader = cmd2.ExecuteReader();
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    cnn.Close();
                }
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
            {
                Response.Redirect("~/UserPages/CoachingPage.aspx?value=" + e.CommandArgument.ToString());

            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserPages
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            setRepForNews(); //Setting Repeater For Announcements
        }

        protected void newsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label NewsDate = (Label)R.FindControl("NewsDate");
            NewsDate.Text = flipDateSame(NewsDate.Text.ToString());

        }

        protected string flipDateSame(string date)
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            int count = 0;
            for (int i = 0; i < date.Length; i++)
            {
                char a = date[i];
                if (a == '/' || a == ':' || a == ' ')
                    count++;
                if (count == 0 && !(a == '/' || a == ':'))
                    s1 = s1 + a;

                if (count == 1 && !(a == '/' || a == ':'))
                    s2 = s2 + a;

                if (count > 1 && !(a == '/'))
                    s3 = s3 + a;
            }
            return s2 + "/" + s1 + "/" + s3;
        }

        protected void setRepForNews()
        {
            SqlConnection newsLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForNews = "";

            if (IntermediateCheck.Checked || MatricCheck.Checked || CommerceCheck.Checked || PreEngineeringCheck.Checked || PreMedicalCheck.Checked)
            {
                cmdForNews = "SELECT C.Name, N.Tittle, N.Date, N.Info, N.General, N.Authenticity, N.Matric, N.Intermediate, N.PreEngineering, N.Commerce From News N inner Join Coaching C on N.CoachingID=C.CoachingID WHERE General = 1 ";
                int count = 0;
                if (MatricCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (N.Matric = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR N.Matric = 1 ";
                    count++;
                }
                if (IntermediateCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (N.Intermediate = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR N.Intermediate = 1 ";
                    count++;
                }
                if (PreEngineeringCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (N.PreEngineering = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR N.PreEngineering = 1 ";
                    count++;
                }
                if (PreMedicalCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (N.PreMedical = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR N.PreMedical = 1 ";
                    count++;
                }
                if (CommerceCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (N.Commerce = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR N.Commerce = 1 ";
                    count++;
                }


                cmdForNews = cmdForNews + ") ORDER BY Date DESC";
            }

            else

                cmdForNews = "SELECT C.Name, N.Tittle, N.Date, N.Info, N.General, N.Authenticity, N.Matric, N.Intermediate, N.PreEngineering, N.Commerce From News N inner Join Coaching C on N.CoachingID=C.CoachingID WHERE General = 1 ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(cmdForNews, newsLink);
            newsLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            newsRepeater.DataSource = reader;
            newsRepeater.DataBind();
            newsLink.Close();
        }
    }
}
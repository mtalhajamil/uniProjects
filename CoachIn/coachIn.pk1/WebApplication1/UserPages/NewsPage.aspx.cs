using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            string CoachingId = Request["value"].ToString();
            setRepForNews(CoachingId); //Setting Repeater For Announcements
        }

        protected void setRepForNews(string CoachingId)
        {
            SqlConnection newsLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForNews = "";

            if (Intermediate.Checked || Matric.Checked || Commerce.Checked || PreEngineering.Checked || PreMedical.Checked)
            {
                cmdForNews = "SELECT * FROM News WHERE CoachingID = " + CoachingId.ToString() + " ";
                int count = 0;
                if (Matric.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (Matric = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR Matric = 1 ";
                    count++;
                }
                if (Intermediate.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (Intermediate = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR Intermediate = 1 ";
                    count++;
                }
                if (PreEngineering.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (PreEngineering = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR PreEngineering = 1 ";
                    count++;
                }
                if (PreMedical.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (PreMedical = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR PreMedical = 1 ";
                    count++;
                }
                if (Commerce.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (Commerce = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR Commerce = 1 ";
                    count++;
                }


                cmdForNews = cmdForNews + ") ORDER BY Date DESC";
            }

            else

                cmdForNews = "SELECT * FROM [News] WHERE CoachingID = " + CoachingId.ToString() + "ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(cmdForNews, newsLink);
            newsLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            newsRepeater.DataSource = reader;
            newsRepeater.DataBind();
            newsLink.Close();
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
    }
}
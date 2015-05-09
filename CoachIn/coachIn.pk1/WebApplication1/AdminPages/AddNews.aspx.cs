using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.AdminPages
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected string CoachingId;
        protected string dbDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sstt");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CoachingId = Session["CoachingID"].ToString(); //Reciving coachingID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }
            if (IsPostBack != true)
                setRepForNews(CoachingId); //Setting Repeater For Announcements

            GeneralNews.SelectedIndex = 1;
            date.Text = DateTime.Now.ToString("dd/MM/yyyy") + "     ";
            time.Text = DateTime.Now.ToString("hh:mm");
        }

        protected void setRepForNews(string CoachingId)
        {
            SqlConnection newsLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForNews = "";

            if (IntermediateCheck.Checked || MatricCheck.Checked || CommerceCheck.Checked || PreEngineeringCheck.Checked || PreMedicalCheck.Checked)
            {
                cmdForNews = "SELECT * FROM News WHERE CoachingID = " + CoachingId.ToString() + " ";
                int count = 0;
                if (MatricCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (Matric = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR Matric = 1 ";
                    count++;
                }
                if (IntermediateCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (Intermediate = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR Intermediate = 1 ";
                    count++;
                }
                if (PreEngineeringCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (PreEngineering = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR PreEngineering = 1 ";
                    count++;
                }
                if (PreMedicalCheck.Checked)
                {
                    if (count == 0)
                        cmdForNews = cmdForNews + "AND (PreMedical = 1 ";
                    else
                        cmdForNews = cmdForNews + "OR PreMedical = 1 ";
                    count++;
                }
                if (CommerceCheck.Checked)
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

        protected void Post_Click(object sender, EventArgs e)
        {
            string checking = GeneralNews.SelectedValue;
            bool General = false;
            if (checking == "0")
                General = true;
            else
                General = false;


            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForAddingNews = "INSERT INTO News(CoachingID,Tittle,Info,General,Authenticity,Matric,Intermediate,PreEngineering,PreMedical,Commerce,Date) VALUES (@CoachingID,@Tittle,@Info,@General,@Authenticity,@Matric,@Intermediate,@PreEngineering,@PreMedical,@Commerce,@Date)";
            SqlCommand sqlCmdComment = new SqlCommand(cmdForAddingNews, link);
            sqlCmdComment.Parameters.AddWithValue("CoachingID", CoachingId);
            sqlCmdComment.Parameters.AddWithValue("Tittle", Tittle.Text);
            sqlCmdComment.Parameters.AddWithValue("Info", News.Text);
            sqlCmdComment.Parameters.AddWithValue("General", General);
            sqlCmdComment.Parameters.AddWithValue("Authenticity", Authenticity.Text);
            sqlCmdComment.Parameters.AddWithValue("Matric", Matric.Checked);
            sqlCmdComment.Parameters.AddWithValue("Intermediate", Intermediate.Checked);
            sqlCmdComment.Parameters.AddWithValue("PreEngineering", PreEngineering.Checked);
            sqlCmdComment.Parameters.AddWithValue("PreMedical", PreMedical.Checked);
            sqlCmdComment.Parameters.AddWithValue("Commerce", Commerce.Checked);
            sqlCmdComment.Parameters.AddWithValue("Date", dbDate);
            link.Open();

            if (Tittle.Text == "" || News.Text == "")
                Warning.Text = "Please don't leave Titlle or News text area empty";
            else
            {
                sqlCmdComment.ExecuteNonQuery();
                Warning.Text = "News Added";
                Tittle.Text = "";
                News.Text = "";
                Authenticity.Text = "";
            }
            link.Close();
            setRepForNews(CoachingId); //Setting Repeater For Announcements

        }

        protected void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                Matric.Checked = true;
                Intermediate.Checked = true;
                PreEngineering.Checked = true;
                PreMedical.Checked = true;
                Commerce.Checked = true;

            }
            else
            {
                Matric.Checked = false;
                Intermediate.Checked = false;
                PreEngineering.Checked = false;
                PreMedical.Checked = false;
                Commerce.Checked = false;

            }
        }

        protected void newsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label NewsDate = (Label)R.FindControl("NewsDate");
            NewsDate.Text = flipDateSame(NewsDate.Text.ToString());
            Label msg = (Label)R.FindControl("msg");
            msg.Visible = false;

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

        protected void newsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem R = e.Item;
            Panel NewsPanel = (Panel)R.FindControl("NewsPanel");
            Label msg = (Label)R.FindControl("msg");
            switch (e.CommandName)
            {
                case "Delete":
                    SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string cmdForRemovingNews = "DELETE FROM News WHERE NewsID = " + e.CommandArgument.ToString();
                    SqlCommand sqlCmdNews = new SqlCommand(cmdForRemovingNews, link);
                    link.Open();
                    sqlCmdNews.ExecuteNonQuery();
                    link.Close();
                    msg.Visible = true;
                    msg.Text = "News Deleted";
                    NewsPanel.Visible = false;
                    break;
            }
        }

        protected static string AddLineBreaks(object qualDescription)
        {
            if (qualDescription == null)
            {
                return "";
            }
            return qualDescription.ToString().Replace(Environment.NewLine, "<br/>");
        }

    }
}
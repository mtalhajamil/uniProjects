using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CoachingPage : System.Web.UI.Page
    {
        protected string coachName = "";
        protected string coachID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            coachID = Request["value"].ToString();

            displayCoachingData(coachID); //Display All Coaching Data
            settingRepForBranch(coachID); //Set Repeater For Coaching Branches
            displayComments(coachID);
            setRepForNews(); //Setting Repeater For News
        }

        protected void setRepForNews()
        {
            SqlConnection newsLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "SELECT TOP 6 * FROM [News] WHERE CoachingID = " + coachID.ToString() + "ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(str, newsLink);
            newsLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            newsRepeater.DataSource = reader;
            newsRepeater.DataBind();
            newsLink.Close();

            str = "SELECT  COUNT(News.CoachingID) From News WHERE CoachingID = " + coachID.ToString();
            newsLink.Open();
            sqlCommand = new SqlCommand(str, newsLink);
            reader = sqlCommand.ExecuteReader();
            double count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            newsLink.Close();

            if (count == 0)
                news_display.Text = "No News";

        }

        protected void displayComments(string coachID)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());

            string cmdForComments = "SELECT * FROM [Comments] WHERE CoachingID = " + coachID.ToString();
            SqlCommand sqlCmdComment = new SqlCommand(cmdForComments, link);

            link.Open();

            SqlDataReader reader = sqlCmdComment.ExecuteReader();

            commentRepeater.DataSource = reader;
            commentRepeater.DataBind();
        }

        protected void settingRepForBranch(string coachID)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());

            string cmdForBranch = "SELECT * FROM [Branch] WHERE CoachingID = " + coachID.ToString();
            SqlCommand sqlCmdBranch = new SqlCommand(cmdForBranch, link);

            link.Open();

            SqlDataReader reader = sqlCmdBranch.ExecuteReader();

            branchRepeater.DataSource = reader;
            branchRepeater.DataBind();

            link.Close();
        }

        protected void displayCoachingData(string coachID)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "SELECT * FROM [Coaching] WHERE CoachingID = " + coachID.ToString();
            SqlCommand sqlCommand = new SqlCommand(str, link);
            link.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();


            Heading.Text = (reader["Name"].ToString());
            coachName = (reader["Name"].ToString());
            Description.Text = (reader["Discription"].ToString());



            link.Close();
        }

        protected void Post_Click(object sender, EventArgs e)
        {

            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());

            string cmdForComments = "INSERT INTO Comments (CoachingID,Text,Name,EmailAddress)VALUES('" + coachID.ToString()
                + "','" + Comment.Text.ToString() + "','" + Name.Text.ToString() + "','" + Email.Text.ToString() + "')";
            SqlCommand sqlCmdComment = new SqlCommand(cmdForComments, link);
            link.Open();

            if (Comment.Text.ToString() == "")
                Warning.Text = "Please don't leave the text area empty";
            else
            {
                sqlCmdComment.ExecuteNonQuery();
                Warning.Text = "Comment Posted At The End";
            }

            Email.Text = "";
            Name.Text = "";
            Comment.Text = "";

            displayComments(coachID);

        }

        protected void branchRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "buy":


                    //get command argument here
                    string coachingIdCatch = e.CommandArgument.ToString();
                    Response.Redirect("~/UserPages/BranchPage.aspx?value=" + coachingIdCatch);
                    break;
            }

        }

        protected void news_display_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPages/NewsPage.aspx?value=" + coachID);
        }

        protected void commentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label match = (Label)R.FindControl("LabelName");
            Label temp = (Label)R.FindControl("Admin");
            if (match.Text == coachName)
            {
                temp.Text = " Coaching Admin";
            }
            
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
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

    public partial class BranchPage : System.Web.UI.Page
    {
        protected string toAnnouncement = "";
        protected string warning = "";
        protected string select;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            string BranchId = Request["value"].ToString(); //Reciving branchID from coaching page
            toAnnouncement = BranchId;

            branchData(BranchId); //Setting branch Information
            setRepForCourses(BranchId); //Setting Repeater For Course along with subject Display
            setRepForAnnouncement(BranchId); //Setting Repeater For Announcements
            setRepForNews(); //Setting Repeater For News

        }

        protected void setRepForNews()
        {
            SqlConnection newsLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "SELECT TOP 6 * FROM [News] WHERE CoachingID = " + select.ToString() + "ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(str, newsLink);
            newsLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            newsRepeater.DataSource = reader;
            newsRepeater.DataBind();
            newsLink.Close();

            str = "SELECT  COUNT(News.CoachingID) From News WHERE CoachingID = " + select.ToString();
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

        protected void setRepForAnnouncement(string BranchId)
        {
            SqlConnection announcementLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "SELECT TOP 6 * FROM [Announcement] WHERE BranchID = " + BranchId.ToString() + "ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(str, announcementLink);
            announcementLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            announcementRepeater.DataSource = reader;
            announcementRepeater.DataBind();
            announcementLink.Close();


            str = "SELECT  COUNT(Announcement.BranchID) From Announcement WHERE BranchID = " + BranchId.ToString();
            announcementLink.Open();
            sqlCommand = new SqlCommand(str, announcementLink);
            reader = sqlCommand.ExecuteReader();
            double count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            announcementLink.Close();

            if (count == 0)
                announcement_display.Text = "No Announcements";

        }

        protected void setRepForCourses(string BranchId)
        {
            using (SqlConnection CourseSubLink = new SqlConnection())
            {
                CourseSubLink.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString();
                string cmdForCourse = "";


                if (Intermediate.Checked || Matric.Checked || Commerce.Checked || PreEngineering.Checked || PreMedical.Checked)
                {
                    cmdForCourse = "SELECT * FROM Course WHERE BranchID = " + BranchId.ToString() + " ";
                    int count = 0;
                    if (Matric.Checked)
                    {
                        if (count == 0)
                            cmdForCourse = cmdForCourse + "AND (Matric = 1 ";
                        else
                            cmdForCourse = cmdForCourse + "OR Matric = 1 ";
                        count++;
                    }
                    if (Intermediate.Checked)
                    {
                        if (count == 0)
                            cmdForCourse = cmdForCourse + "AND (Intermediate = 1 ";
                        else
                            cmdForCourse = cmdForCourse + "OR Intermediate = 1 ";
                        count++;
                    }
                    if (PreEngineering.Checked)
                    {
                        if (count == 0)
                            cmdForCourse = cmdForCourse + "AND (PreEngineering = 1 ";
                        else
                            cmdForCourse = cmdForCourse + "OR PreEngineering = 1 ";
                        count++;
                    }
                    if (PreMedical.Checked)
                    {
                        if (count == 0)
                            cmdForCourse = cmdForCourse + "AND (PreMedical = 1 ";
                        else
                            cmdForCourse = cmdForCourse + "OR PreMedical = 1 ";
                        count++;
                    }
                    if (Commerce.Checked)
                    {
                        if (count == 0)
                            cmdForCourse = cmdForCourse + "AND (Commerce = 1 ";
                        else
                            cmdForCourse = cmdForCourse + "OR Commerce = 1 ";
                        count++;
                    }


                    cmdForCourse = cmdForCourse + ") ORDER BY CourseID DESC";
                }

                else
                    cmdForCourse = "SELECT * FROM Course WHERE BranchID = " + BranchId.ToString() + " ORDER BY CourseID DESC";
                SqlCommand sqlCmdCourse = new SqlCommand(cmdForCourse, CourseSubLink);
                CourseSubLink.Open();
                SqlDataReader reader = sqlCmdCourse.ExecuteReader();
                courseRepeater.DataSource = reader;
                courseRepeater.DataBind();
                CourseSubLink.Close();
            }
        }

        protected void branchData(string BranchId)
        {
            SqlConnection branchLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "SELECT * FROM [Branch] WHERE BranchID = " + BranchId.ToString();
            SqlCommand sqlCommand = new SqlCommand(str, branchLink);
            branchLink.Open();
            SqlDataReader branchReader = sqlCommand.ExecuteReader();
            branchReader.Read();
            select = branchReader["CoachingID"].ToString();
            Heading.Text = branchReader["Name"].ToString();
            Description.Text = branchReader["Description"].ToString();
            Address.Text = branchReader["Address"].ToString();
            Contact.Text = "Contact: " + branchReader["Contact1"].ToString();
            if (branchReader["Contact2"].ToString() != "")
                Contact.Text += " , " + branchReader["Contact2"].ToString();
            branchLink.Close();
        }


        protected void courseRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


            switch (e.CommandName)
            {
                case "display":
                    //get command argument here

                    string searchSub = e.CommandArgument.ToString();
                    RepeaterItem R = e.Item;
                    Repeater subjectRepeater = (Repeater)R.FindControl("subjectRepeater");

                    SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string cmdForSubjects = "SELECT * FROM Subject WHERE CourseID = " + searchSub.ToString();
                    SqlCommand sqlCmdSubjects = new SqlCommand(cmdForSubjects, link);
                    link.Open();
                    SqlDataReader reader = sqlCmdSubjects.ExecuteReader();
                    subjectRepeater.DataSource = reader;
                    subjectRepeater.DataBind();
                    link.Close();

                    break;
            }

        }

        protected void subjectRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;

            Label DateChange = (Label)R.FindControl("DateChange");
            DateChange.Text = flipDate(DateChange.Text.ToString());

            Label Monday = (Label)R.FindControl("Monday");
            Label Mon_time = (Label)R.FindControl("Mon_time");

            if (Monday.Text.ToString() != "True")
                Mon_time.Text = "";
            if (Monday.Text.ToString() == "True")
                Monday.Text = "  Monday ";
            else
                Monday.Text = "";

            Label Tuesday = (Label)R.FindControl("Tuesday");
            Label Tues_time = (Label)R.FindControl("Tues_time");

            if (Tuesday.Text.ToString() != "True")
                Tues_time.Text = "";
            if (Tuesday.Text.ToString() == "True")
                Tuesday.Text = "  Tuesday ";
            else
                Tuesday.Text = "";

            Label Wednesday = (Label)R.FindControl("Wednesday");
            Label Wed_time = (Label)R.FindControl("Wed_time");

            if (Wednesday.Text.ToString() != "True")
                Wed_time.Text = "";
            if (Wednesday.Text.ToString() == "True")
                Wednesday.Text = "  Wednesday ";
            else
                Wednesday.Text = "";

            Label Thursday = (Label)R.FindControl("Thursday");
            Label Thurs_time = (Label)R.FindControl("Thurs_time");

            if (Thursday.Text.ToString() != "True")
                Thurs_time.Text = "";
            if (Thursday.Text.ToString() == "True")
                Thursday.Text = "  Thursday ";
            else
                Thursday.Text = "";

            Label Friday = (Label)R.FindControl("Friday");
            Label Fri_time = (Label)R.FindControl("Fri_time");

            if (Friday.Text.ToString() != "True")
                Fri_time.Text = "";
            if (Friday.Text.ToString() == "True")
                Friday.Text = "  Friday ";
            else
                Friday.Text = "";

            Label Saturday = (Label)R.FindControl("Saturday");
            Label Sat_time = (Label)R.FindControl("Sat_time");

            if (Saturday.Text.ToString() != "True")
                Sat_time.Text = "";
            if (Saturday.Text.ToString() == "True")
                Saturday.Text = "  Saturday ";
            else
                Saturday.Text = "";

            Label Sunday = (Label)R.FindControl("Sunday");
            Label Sun_time = (Label)R.FindControl("Sun_time");

            if (Sunday.Text.ToString() != "True")
                Sun_time.Text = "";
            if (Sunday.Text.ToString() == "True")
                Sunday.Text = "  Sunday ";
            else
                Sunday.Text = "";
        }

        protected void courseRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Repeater subjectRepeater = (Repeater)R.FindControl("subjectRepeater");
            Label Matric = (Label)R.FindControl("MatricLabel");
            if (Matric.Text.ToString() == "True")
                Matric.Text = " Matric;";
            else
                Matric.Text = " ";

            Label PreEngineering = (Label)R.FindControl("PreEngineeringLabel");
            if (PreEngineering.Text.ToString() == "True")
                PreEngineering.Text = " Inter-PreEngineering;";
            else
                PreEngineering.Text = " ";

            Label PreMedical = (Label)R.FindControl("PreMedicalLabel");
            if (PreMedical.Text.ToString() == "True")
                PreMedical.Text = " Inter-PreMedical;";
            else
                PreMedical.Text = " ";

            Label Commerce = (Label)R.FindControl("CommerceLabel");
            if (Commerce.Text.ToString() == "True")
                Commerce.Text = " Inter-Commerce;";
            else
                Commerce.Text = " ";
        }

        protected void announcement_display_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPages/AnnouncementPage.aspx?value=" + toAnnouncement);
        }

        protected void news_display_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPages/NewsPage.aspx?value=" + select);
        }

        protected string flipDate(string date)
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

                if (count == 2 && !(a == '/' || a == ':'))
                    s3 = s3 + a;
            }
            return s2 + "/" + s1 + "/" + s3;
        }

        protected void newsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label NewsDate = (Label)R.FindControl("NewsDate");
            NewsDate.Text = flipDateSame(NewsDate.Text.ToString());
        }

        protected void announcementRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label AnnouncementDate = (Label)R.FindControl("AnnouncementDate");
            AnnouncementDate.Text = flipDateSame(AnnouncementDate.Text.ToString());
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
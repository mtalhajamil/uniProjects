using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.SignUp
{
    public partial class AddSubject : System.Web.UI.Page
    {
        protected string OpenCourseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            StartCalendar.SelectedDate = DateTime.Now;
            try
            {
                OpenCourseID = Session["CourseID"].ToString(); //Reciving courseID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }
        }

        protected void MonCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (MonCheck.Checked == true)
                MonText.Visible = true;
            else
                MonText.Visible = false;
        }

        protected void TueCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TueCheck.Checked == true)
                TueText.Visible = true;
            else
                TueText.Visible = false;
        }

        protected void WedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (WedCheck.Checked == true)
                WedText.Visible = true;
            else
                WedText.Visible = false;
        }

        protected void ThursCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ThursCheck.Checked == true)
                ThursText.Visible = true;
            else
                ThursText.Visible = false;
        }

        protected void FriCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (FriCheck.Checked == true)
                FriText.Visible = true;
            else
                FriText.Visible = false;
        }

        protected void SatCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SatCheck.Checked == true)
                SatText.Visible = true;
            else
                SatText.Visible = false;
        }

        protected void SunCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SunCheck.Checked == true)
                SunText.Visible = true;
            else
                SunText.Visible = false;
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            if (SubjectName.Text == "" || Duration.Text == "" || Teacher.Text == "" || Fees.Text == "" || Fees_LumpSum.Text == "" || Seats.Text == "")
            {
                subjectAdded.Visible = true;
                subjectAdded.Text = "Please Fill All Feilds";
            }
            else
            {
                SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                string str = "INSERT into Subject (CourseID,SubjectName,Duration,Teacher,Fees,[Lump Sum],StartDate,SeatsRemaining,Mon_time,Tues_time,Wed_time,Thurs_time,Fri_time,Sat_time,Sun_time,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday) values (@CourseID,@SubjectName,@Duration,@Teacher,@Fees,@LumpSum,@StartDate,@Seats,@Mon_time,@Tues_time,@Wed_time,@Thurs_time,@Fri_time,@Sat_time,@Sun_time,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday)";
                SqlCommand sqlCommand = new SqlCommand(str, link);
                sqlCommand.Parameters.AddWithValue("SubjectName", SubjectName.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Duration", Duration.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Teacher", Teacher.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Fees", Fees.Text.ToString());
                sqlCommand.Parameters.AddWithValue("LumpSum", Fees_LumpSum.Text.ToString());
                sqlCommand.Parameters.AddWithValue("StartDate", StartCalendar.SelectedDate.ToString());
                sqlCommand.Parameters.AddWithValue("Seats", Seats.Text.ToString());
                sqlCommand.Parameters.AddWithValue("CourseID", OpenCourseID);
                sqlCommand.Parameters.AddWithValue("Mon_time", MonText.Text);
                sqlCommand.Parameters.AddWithValue("Tues_time", TueText.Text);
                sqlCommand.Parameters.AddWithValue("Wed_time", WedText.Text);
                sqlCommand.Parameters.AddWithValue("Thurs_time", ThursText.Text);
                sqlCommand.Parameters.AddWithValue("Fri_time", FriText.Text);
                sqlCommand.Parameters.AddWithValue("Sat_time", SatText.Text);
                sqlCommand.Parameters.AddWithValue("Sun_time", SunText.Text);
                sqlCommand.Parameters.AddWithValue("Monday", MonCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Tuesday", TueCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Wednesday", WedCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Thursday", ThursCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Friday", FriCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Saturday", SatCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Sunday", SunCheck.Checked);

                link.Open();
                sqlCommand.ExecuteNonQuery();
                link.Close();

                SubjectName.Text = "";
                Duration.Text = "";
                Teacher.Text = "";
                Fees.Text = "";
                Fees_LumpSum.Text = "";
                
                Seats.Text = "";
                MonCheck.Checked = false;
                TueCheck.Checked = false;
                WedCheck.Checked = false;
                ThursCheck.Checked = false;
                FriCheck.Checked = false;
                SatCheck.Checked = false;
                SunCheck.Checked = false;

                Response.Redirect("~/AdminPages/BranchAdmin.aspx");
            }
        }

        protected void AddAnother_Click(object sender, EventArgs e)
        {

            try
            {
                OpenCourseID = Session["CourseID"].ToString(); //Reciving courseID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }

            if (SubjectName.Text == "" || Duration.Text == "" || Teacher.Text == "" || Fees.Text == "" || Fees_LumpSum.Text == "" || Seats.Text == "")
            {
                subjectAdded.Visible = true;
                subjectAdded.Text = "Please Fill All Feilds";
            }
            else
            {
                SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                string str = "INSERT into Subject (CourseID,SubjectName,Duration,Teacher,Fees,[Lump Sum],StartDate,SeatsRemaining,Mon_time,Tues_time,Wed_time,Thurs_time,Fri_time,Sat_time,Sun_time,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday) values (@CourseID,@SubjectName,@Duration,@Teacher,@Fees,@LumpSum,@StartDate,@Seats,@Mon_time,@Tues_time,@Wed_time,@Thurs_time,@Fri_time,@Sat_time,@Sun_time,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday,@Sunday)";
                SqlCommand sqlCommand = new SqlCommand(str, link);
                sqlCommand.Parameters.AddWithValue("SubjectName", SubjectName.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Duration", Duration.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Teacher", Teacher.Text.ToString());
                sqlCommand.Parameters.AddWithValue("Fees", Fees.Text.ToString());
                sqlCommand.Parameters.AddWithValue("LumpSum", Fees_LumpSum.Text.ToString());
                sqlCommand.Parameters.AddWithValue("StartDate", StartCalendar.SelectedDate.ToString());
                sqlCommand.Parameters.AddWithValue("Seats", Seats.Text.ToString());
                sqlCommand.Parameters.AddWithValue("CourseID", OpenCourseID);
                sqlCommand.Parameters.AddWithValue("Mon_time", MonText.Text);
                sqlCommand.Parameters.AddWithValue("Tues_time", TueText.Text);
                sqlCommand.Parameters.AddWithValue("Wed_time", WedText.Text);
                sqlCommand.Parameters.AddWithValue("Thurs_time", ThursText.Text);
                sqlCommand.Parameters.AddWithValue("Fri_time", FriText.Text);
                sqlCommand.Parameters.AddWithValue("Sat_time", SatText.Text);
                sqlCommand.Parameters.AddWithValue("Sun_time", SunText.Text);
                sqlCommand.Parameters.AddWithValue("Monday", MonCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Tuesday", TueCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Wednesday", WedCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Thursday", ThursCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Friday", FriCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Saturday", SatCheck.Checked);
                sqlCommand.Parameters.AddWithValue("Sunday", SunCheck.Checked);

                link.Open();
                sqlCommand.ExecuteNonQuery();
                link.Close();

                SubjectName.Text = "";
                Duration.Text = "";
                Teacher.Text = "";
                Fees.Text = "";
                Fees_LumpSum.Text = "";
                
                Seats.Text = "";
                MonCheck.Checked = false;
                TueCheck.Checked = false;
                WedCheck.Checked = false;
                ThursCheck.Checked = false;
                FriCheck.Checked = false;
                SatCheck.Checked = false;
                SunCheck.Checked = false;
                
                Response.Redirect("~/SignUp/SubjectAddition.aspx");
            }
        }
    }
}
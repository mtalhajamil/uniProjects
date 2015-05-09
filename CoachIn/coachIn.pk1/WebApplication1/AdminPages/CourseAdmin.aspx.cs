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
    public partial class CourseAdmin : System.Web.UI.Page
    {
        protected string OpenCourseID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OpenCourseID = Session["CourseID"].ToString(); //Reciving courseID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }

            OpenCourseID = Session["CourseID"].ToString();

            setInitialDisplay();
            setCourseDetails(OpenCourseID);//set course repeater
            if (IsPostBack != true)
                setSubjectRepeater(OpenCourseID);//set subject repeater
        }

        protected void setSubjectRepeater(string OpenCourseID)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForSubjects = "SELECT * FROM Subject WHERE CourseID = " + OpenCourseID.ToString();
            SqlCommand sqlCmdSubjects = new SqlCommand(cmdForSubjects, link);
            link.Open();
            SqlDataReader reader = sqlCmdSubjects.ExecuteReader();
            subjectRepeater.DataSource = reader;
            subjectRepeater.DataBind();
            link.Close();
        }

        protected void setInitialDisplay()
        {
            CourseDisplay.Visible = true;
            EditCourse.Visible = false;
        }

        protected void setCourseDetails(string CourseID)
        {
            using (SqlConnection CourseSubLink = new SqlConnection())
            {
                CourseSubLink.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString();
                string cmdForCourse = "";

                cmdForCourse = "SELECT * FROM Course WHERE CourseID = " + CourseID.ToString();
                SqlCommand sqlCmdCourse = new SqlCommand(cmdForCourse, CourseSubLink);
                CourseSubLink.Open();
                SqlDataReader reader = sqlCmdCourse.ExecuteReader();
                reader.Read();
                Name.Text = reader["Name"].ToString();
                FeePerMonth.Text = reader["Fee/Month"].ToString();
                LumpSum.Text = reader["LumpSum"].ToString();
                Details.Text = reader["Details"].ToString();
                LabelMatric.Text = reader["Matric"].ToString();
                LabelPreEngineering.Text = reader["PreEngineering"].ToString();
                LabelPreMedical.Text = reader["PreMedical"].ToString();
                LabelCommerce.Text = reader["Commerce"].ToString();
                CourseSubLink.Close();

                if (LabelMatric.Text.ToString() == "True")
                    LabelMatric.Text = " Matric;";
                else
                    LabelMatric.Text = " ";


                if (LabelPreEngineering.Text.ToString() == "True")
                    LabelPreEngineering.Text = " Inter-PreEngineering;";
                else
                    LabelPreEngineering.Text = " ";


                if (LabelPreMedical.Text.ToString() == "True")
                    LabelPreMedical.Text = " Inter-PreMedical;";
                else
                    LabelPreMedical.Text = " ";

                if (LabelCommerce.Text.ToString() == "True")
                    LabelCommerce.Text = " Inter-Commerce;";
                else
                    LabelCommerce.Text = " ";
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {

            CourseDisplay.Visible = false;
            EditCourse.Visible = true;

            EditName.Text = Name.Text;
            EditFees.Text = FeePerMonth.Text;
            EditLumpSum.Text = LumpSum.Text;
            EditDetails.Text = Details.Text;

            if (LabelMatric.Text == " Matric;")
                Matric.Checked = true;
            if (LabelPreEngineering.Text == " Inter-PreEngineering;")
                PreEngineering.Checked = true;
            if (LabelPreMedical.Text == " Inter-PreMedical;")
                PreMedical.Checked = true;
            if (LabelCommerce.Text == " Inter-Commerce;")
                Commerce.Checked = true;
            if (PreEngineering.Checked == true || PreMedical.Checked == true || Commerce.Checked == true)
                Intermediate.Checked = true;
            else
                Intermediate.Checked = false;
            EditDetails.Focus();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection courseLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "UPDATE Course SET Name = @Name , [Fee/Month] = @Fee , LumpSum = @LumpSum , Details = @Details , Matric = @Matric , Intermediate = @Intermediate , PreEngineering = @PreEngineering , PreMedical = @PreMedical , Commerce = @Commerce WHERE CourseID = @CourseID";
            SqlCommand sqlCommand = new SqlCommand(str, courseLink);
            sqlCommand.Parameters.AddWithValue("CourseID", OpenCourseID);
            sqlCommand.Parameters.AddWithValue("Name", EditName.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Fee", EditFees.Text.ToString());
            sqlCommand.Parameters.AddWithValue("LumpSum", EditLumpSum.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Details", EditDetails.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Matric", Matric.Checked);
            sqlCommand.Parameters.AddWithValue("Intermediate", Intermediate.Checked);
            sqlCommand.Parameters.AddWithValue("PreEngineering", PreEngineering.Checked);
            sqlCommand.Parameters.AddWithValue("PreMedical", PreMedical.Checked);
            sqlCommand.Parameters.AddWithValue("Commerce", Commerce.Checked);

            courseLink.Open();
            sqlCommand.ExecuteNonQuery();
            courseLink.Close();

            setCourseDetails(OpenCourseID);//set course repeater
        }

        protected void subjectRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem R = e.Item;
            Button Submit = (Button)R.FindControl("Submit");
            Button Edit = (Button)R.FindControl("Edit");

            TextBox SubjectName = (TextBox)R.FindControl("SubjectName");
            TextBox Teacher = (TextBox)R.FindControl("Teacher");
            TextBox Seats = (TextBox)R.FindControl("Seats");
            TextBox Start = (TextBox)R.FindControl("Start");
            TextBox Duration = (TextBox)R.FindControl("Duration");
            TextBox Fees = (TextBox)R.FindControl("Fees");
            TextBox LumpSum = (TextBox)R.FindControl("LumpSum");
            Panel DayDiv = (Panel)R.FindControl("DayDiv");
            Panel CheckDiv = (Panel)R.FindControl("CheckDiv");

            Label Mon_time = (Label)R.FindControl("Mon_time");
            Label Tues_time = (Label)R.FindControl("Tues_time");
            Label Wed_time = (Label)R.FindControl("Wed_time");
            Label Thurs_time = (Label)R.FindControl("Thurs_time");
            Label Fri_time = (Label)R.FindControl("Fri_time");
            Label Sat_time = (Label)R.FindControl("Sat_time");
            Label Sun_time = (Label)R.FindControl("Sun_time");

            CheckBox MonCheck = (CheckBox)R.FindControl("MonCheck");
            CheckBox TueCheck = (CheckBox)R.FindControl("TueCheck");
            CheckBox WedCheck = (CheckBox)R.FindControl("WedCheck");
            CheckBox ThursCheck = (CheckBox)R.FindControl("ThursCheck");
            CheckBox FriCheck = (CheckBox)R.FindControl("FriCheck");
            CheckBox SatCheck = (CheckBox)R.FindControl("SatCheck");
            CheckBox SunCheck = (CheckBox)R.FindControl("SunCheck");

            TextBox MonText = (TextBox)R.FindControl("MonText");
            TextBox TueText = (TextBox)R.FindControl("TueText");
            TextBox WedText = (TextBox)R.FindControl("WedText");
            TextBox ThursText = (TextBox)R.FindControl("ThursText");
            TextBox FriText = (TextBox)R.FindControl("FriText");
            TextBox SatText = (TextBox)R.FindControl("SatText");
            TextBox SunText = (TextBox)R.FindControl("SunText");

            Button Delete1 = (Button)R.FindControl("Delete1");
            Button Delete2 = (Button)R.FindControl("Delete2");
            Button Cancel = (Button)R.FindControl("Cancel");
            Label warning1 = (Label)R.FindControl("warning1");
            Label warning2 = (Label)R.FindControl("warning2");
            Panel subjectShow = (Panel)R.FindControl("subjectShow");

            switch (e.CommandName)
            {

                case "delete1":
                    Delete1.Visible = false;
                    Delete2.Visible = true;
                    warning1.Visible = true;
                    Cancel.Visible = true;
                    break;

                case "delete2":
                    Delete1.Visible = false;
                    Delete2.Visible = false;
                    warning1.Visible = false;
                    warning2.Visible = true;
                    subjectShow.Visible = false;
                    Cancel.Visible = false;
                    Edit.Visible = false;

                    string SubjectID = e.CommandArgument.ToString();
                    SqlConnection link1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string cmdForDelete = "DELETE FROM Subject WHERE SubjectID = " + SubjectID.ToString();
                    SqlCommand sqlCmdDelete = new SqlCommand(cmdForDelete, link1);
                    link1.Open();
                    sqlCmdDelete.ExecuteNonQuery();
                    link1.Close();

                    break;

                case "cancel":
                    Delete1.Visible = true;
                    Delete2.Visible = false;
                    warning1.Visible = false;
                    warning2.Visible = false;
                    Cancel.Visible = false;

                    break;

                case "Edit":
                    //get command argument here                    
                    Submit.Style["display"] = "inherit";
                    Edit.Style["display"] = "none";
                    SubjectName.Enabled = true;
                    SubjectName.CssClass = "EditSingleBox";
                    Teacher.Enabled = true;
                    Teacher.CssClass = "EditSingleBox";
                    Seats.Enabled = true;
                    Seats.CssClass = "EditSingleBox";
                    Start.Enabled = true;
                    Start.CssClass = "EditSingleBox";
                    Duration.Enabled = true;
                    Duration.CssClass = "EditSingleBox";
                    Fees.Enabled = true;
                    Fees.CssClass = "EditSingleBox";
                    LumpSum.Enabled = true;
                    LumpSum.CssClass = "EditSingleBox";
                    DayDiv.Visible = false;
                    CheckDiv.Visible = true;
                    SubjectName.Focus();

                    if (Mon_time.Text != "")
                    {
                        MonCheck.Checked = true;
                        MonText.Text = Mon_time.Text;
                    }
                    if (Tues_time.Text != "")
                    {
                        TueCheck.Checked = true;
                        TueText.Text = Tues_time.Text;
                    }
                    if (Wed_time.Text != "")
                    {
                        WedCheck.Checked = true;
                        WedText.Text = Wed_time.Text;
                    }
                    if (Thurs_time.Text != "")
                    {
                        ThursCheck.Checked = true;
                        ThursText.Text = Thurs_time.Text;
                    }
                    if (Fri_time.Text != "")
                    {
                        FriCheck.Checked = true;
                        FriText.Text = Fri_time.Text;
                    }
                    if (Sat_time.Text != "")
                    {
                        SatCheck.Checked = true;
                        SatText.Text = Sat_time.Text;
                    }
                    if (Sun_time.Text != "")
                    {
                        SunCheck.Checked = true;
                        SunText.Text = Sun_time.Text;
                    }

                    //if (MonCheck.Checked == false)
                    //    MonText.Visible = false;
                    //else
                    //    MonText.Visible = true;

                    //if (TueCheck.Checked == false)
                    //    TueText.Visible = false;
                    //else
                    //    TueText.Visible = true;

                    //if (WedCheck.Checked == false)
                    //    WedText.Visible = false;
                    //else
                    //    WedText.Visible = true;

                    //if (ThursCheck.Checked == false)
                    //    ThursText.Visible = false;
                    //else
                    //    ThursText.Visible = true;

                    //if (FriCheck.Checked == false)
                    //    FriText.Visible = false;
                    //else
                    //    FriText.Visible = true;

                    //if (SatCheck.Checked == false)
                    //    SatText.Visible = false;
                    //else
                    //    SatText.Visible = true;

                    //if (SunCheck.Checked == false)
                    //    SunText.Visible = false;
                    //else
                    //    SunText.Visible = true;

                    break;

                case "Submit":

                    if (MonCheck.Checked == false)
                    {
                        MonText.Text = null;
                    }
                    if (TueCheck.Checked == false)
                    {
                        TueText.Text = null;
                    }
                    if (WedCheck.Checked == false)
                    {
                        WedText.Text = null;
                    }
                    if (ThursCheck.Checked == false)
                    {
                        ThursText.Text = null;
                    }
                    if (FriCheck.Checked == false)
                    {
                        FriText.Text = null;
                    }
                    if (SatCheck.Checked == false)
                    {
                        SatText.Text = null;
                    }
                    if (SunCheck.Checked == false)
                    {
                        SunText.Text = null;
                    }




                    string searchSub = e.CommandArgument.ToString();
                    SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string str = "UPDATE Subject SET SubjectName = @SubjectName, Duration = @Duration , Teacher = @Teacher, Fees = @Fees, [Lump Sum] = @LumpSum, StartDate = @StartDate , SeatsRemaining = @Seats , Mon_time = @Mon_time , Tues_time = @Tues_time , Wed_time = @Wed_time , Thurs_time = @Thurs_time , Fri_time = @Fri_time , Sat_time = @Sat_time , Sun_time = @Sun_time , Monday = @Monday , Tuesday = @Tuesday , Wednesday = @Wednesday , Thursday = @Thursday , Friday = @Friday , Saturday = @Saturday , Sunday = @Sunday WHERE SubjectID = @SubjectID";
                    SqlCommand sqlCommand = new SqlCommand(str, link);
                    sqlCommand.Parameters.AddWithValue("SubjectName", SubjectName.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("Duration", Duration.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("Teacher", Teacher.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("Fees", Fees.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("LumpSum", LumpSum.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("StartDate", flipDate(Start.Text.ToString()));
                    sqlCommand.Parameters.AddWithValue("Seats", Seats.Text.ToString());
                    sqlCommand.Parameters.AddWithValue("SubjectID", searchSub);
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

                    Submit.Style["display"] = "none";
                    Edit.Style["display"] = "inherit";

                    setSubjectRepeater(OpenCourseID);//set subject repeater

                    break;
            }
        }

        protected void subjectRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;

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

            TextBox SubjectName = (TextBox)R.FindControl("SubjectName");
            TextBox Teacher = (TextBox)R.FindControl("Teacher");
            TextBox Seats = (TextBox)R.FindControl("Seats");
            TextBox Start = (TextBox)R.FindControl("Start");
            TextBox Duration = (TextBox)R.FindControl("Duration");
            TextBox Fees = (TextBox)R.FindControl("Fees");
            TextBox LumpSum = (TextBox)R.FindControl("LumpSum");
            Panel DayDiv = (Panel)R.FindControl("DayDiv");
            Panel CheckDiv = (Panel)R.FindControl("CheckDiv");
            SubjectName.Enabled = false;
            Teacher.Enabled = false;
            Seats.Enabled = false;
            Start.Enabled = false;
            Duration.Enabled = false;
            Fees.Enabled = false;
            LumpSum.Enabled = false;
            CheckDiv.Visible = false;
            DayDiv.Visible = true;
            Button Submit = (Button)R.FindControl("Submit");
            Button Edit = (Button)R.FindControl("Edit");

            Start = (TextBox)R.FindControl("Start");
            Start.Text = flipDate(Start.Text.ToString());

            Submit.Style["display"] = "none";
            Edit.Style["display"] = "inherit";
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

        protected void AddSubject_Click(object sender, EventArgs e)
        {
            if (SubjectName.Text == "" || Duration.Text == "" || Teacher.Text == "" || Fees.Text == "" || Fees_LumpSum.Text == "" || StartCalendar.SelectedDate.ToString() == "" || Seats.Text == "")
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
                StartCalendar.SelectedDate = DateTime.Now;
                Seats.Text = "";
                MonCheck.Checked = false;
                TueCheck.Checked = false;
                WedCheck.Checked = false;
                ThursCheck.Checked = false;
                FriCheck.Checked = false;
                SatCheck.Checked = false;
                SunCheck.Checked = false;
                subjectAdded.Visible = true;
                subjectAdded.Text = "Subject Added";
                setSubjectRepeater(OpenCourseID);
            }

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
    }
}
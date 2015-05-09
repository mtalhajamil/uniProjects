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
    public partial class Searching : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;
            
            SearchBy.Text = "Searching By: " + RadioButtonList1.SelectedItem.Text;
            if (RadioButtonList1.SelectedItem.Text == "By Teacher")
            {
                PanelAddress.Style["display"] = "none";
                PanelTeacher.Style["display"] = "initial";
                PanelSubject.Style["display"] = "none";
                SearchTeacher();
            }
            if (RadioButtonList1.SelectedItem.Text == "By Address")
            {
                PanelSubject.Style["display"] = "none";
                PanelAddress.Style["display"] = "initial";
                PanelTeacher.Style["display"] = "none";
                SearchAddress();
            }
            if (RadioButtonList1.SelectedItem.Text == "By Subject")
            {
                PanelSubject.Style["display"] = "initial";
                PanelAddress.Style["display"] = "none";
                PanelTeacher.Style["display"] = "none";
                SearchSubject();
            }


        }

        private void SearchTeacher()
        {

            string cmdForBranch = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
            {
                //if (string.IsNullOrWhiteSpace(Teacher.Text) == true)
                //    cmdForBranch = "SELECT Co.Name, S.Teacher,S.SubjectName,B.CampusName,C.CourseName,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where S.Teacher Like '%!%' ";
                //else
                cmdForBranch = "SELECT Co.Name, S.Teacher,S.SubjectName,B.Name AS CampusName,C.Name AS CourseName,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where S.Teacher Like '%" + Teacher.Text + "%' ";

                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdForBranch, cnn))
                {

                    SqlDataReader reader = cmd2.ExecuteReader();

                    RepTeacher.DataSource = reader;
                    RepTeacher.DataBind();
                    cnn.Close();
                }
            } Teacher.Focus();
            if (IsPostBack == true) 
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MyFunction();</script>", false);

        }
        private void SearchSubject()
        {

            string cmdForBranch = null;

            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
            {
                //if (string.IsNullOrWhiteSpace(Teacher.Text) == true)
                //    cmdForBranch = "SELECT Co.Name, S.Teacher,S.SubjectName,B.CampusName,C.CourseName,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where S.Teacher Like '%!%' ";
                //else
                cmdForBranch = "SELECT Co.Name, S.Teacher,S.SubjectName,B.Name AS CampusName,C.Name AS CourseName,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where S.SubjectName Like '%" + Teacher.Text + "%' ";

                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdForBranch, cnn))
                {

                    SqlDataReader reader = cmd2.ExecuteReader();

                    RepeaterSubject.DataSource = reader;
                    RepeaterSubject.DataBind();
                    cnn.Close();
                }
            } Teacher.Focus();
            if (IsPostBack == true)
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MyFunction();</script>", false);

        }
        private void SearchAddress()
        {

            string cmdForBranch = null;
            using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
            {
                //if (string.IsNullOrWhiteSpace(Teacher.Text) == true)
                //    cmdForBranch = "SELECT Co.Name, S.Teacher,S.SubjectName,B.CampusName,C.CourseName,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where S.Teacher Like '%!%' ";
                //else
                cmdForBranch = "SELECT Co.Name,B.Name AS CampusName,B.Address,Co.CoachingID,Co.Photo From Subject S inner Join Course C on S.CourseID=C.CourseID inner Join Branch B on C.BranchID=B.BranchID inner Join Coaching Co on B.CoachingID=Co.CoachingID where B.Address Like '%" + Teacher.Text + "%' ";

                cnn.Open();
                using (SqlCommand cmd2 = new SqlCommand(cmdForBranch, cnn))
                {

                    SqlDataReader reader = cmd2.ExecuteReader();

                    RepeaterAddress.DataSource = reader;
                    RepeaterAddress.DataBind();
                    cnn.Close();
                }
            } Teacher.Focus();
            if (IsPostBack == true)
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>MyFunction();</script>", false);

        }
        protected void RepTeacher_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btn")
                Response.Redirect("~/UserPages/CoachingPage.aspx?value=" + e.CommandArgument.ToString());
        }
    }
}
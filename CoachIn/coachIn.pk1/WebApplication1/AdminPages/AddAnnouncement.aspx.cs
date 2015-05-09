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
    public partial class AddAnnouncement : System.Web.UI.Page
    {
        protected string BranchId;
        protected string dbDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sstt");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BranchId = Session["BranchID"].ToString(); //Reciving branchID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }
            if (IsPostBack != true)
                setRepForAnnouncement(BranchId); //Setting Repeater For Announcements
            date.Text = DateTime.Now.ToString("dd/MM/yyyy") + "     ";
            time.Text = DateTime.Now.ToString("hh:mm");
        }

        protected void setRepForAnnouncement(string BranchId)
        {
            SqlConnection announcementLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForAnnouncement = "";


            if (IntermediateCheck.Checked || MatricCheck.Checked || CommerceCheck.Checked || PreEngineeringCheck.Checked || PreMedicalCheck.Checked)
            {
                cmdForAnnouncement = "SELECT * FROM Announcement WHERE BranchID = " + BranchId.ToString() + " ";
                int count = 0;
                if (MatricCheck.Checked)
                {
                    if (count == 0)
                        cmdForAnnouncement = cmdForAnnouncement + "AND (Matric = 1 ";
                    else
                        cmdForAnnouncement = cmdForAnnouncement + "OR Matric = 1 ";
                    count++;
                }
                if (IntermediateCheck.Checked)
                {
                    if (count == 0)
                        cmdForAnnouncement = cmdForAnnouncement + "AND (Intermediate = 1 ";
                    else
                        cmdForAnnouncement = cmdForAnnouncement + "OR Intermediate = 1 ";
                    count++;
                }
                if (PreEngineeringCheck.Checked)
                {
                    if (count == 0)
                        cmdForAnnouncement = cmdForAnnouncement + "AND (PreEngineering = 1 ";
                    else
                        cmdForAnnouncement = cmdForAnnouncement + "OR PreEngineering = 1 ";
                    count++;
                }
                if (PreMedicalCheck.Checked)
                {
                    if (count == 0)
                        cmdForAnnouncement = cmdForAnnouncement + "AND (PreMedical = 1 ";
                    else
                        cmdForAnnouncement = cmdForAnnouncement + "OR PreMedical = 1 ";
                    count++;
                }
                if (CommerceCheck.Checked)
                {
                    if (count == 0)
                        cmdForAnnouncement = cmdForAnnouncement + "AND (Commerce = 1 ";
                    else
                        cmdForAnnouncement = cmdForAnnouncement + "OR Commerce = 1 ";
                    count++;
                }


                cmdForAnnouncement = cmdForAnnouncement + ") ORDER BY Date DESC";
            }
            else
                cmdForAnnouncement = "SELECT * FROM [Announcement] WHERE BranchID = " + BranchId.ToString() + "ORDER BY Date DESC";
            SqlCommand sqlCommand = new SqlCommand(cmdForAnnouncement, announcementLink);
            announcementLink.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            announcementRepeater.DataSource = reader;
            announcementRepeater.DataBind();
            announcementLink.Close();
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForAddingAnnouncements = "INSERT INTO Announcement(BranchID,Tittle,Notification,Matric,Intermediate,PreEngineering,PreMedical,Commerce,Date) VALUES (@BranchID,@Tittle,@Notification,@Matric,@Intermediate,@PreEngineering,@PreMedical,@Commerce,@Date)";
            SqlCommand sqlCmdAnnouncement = new SqlCommand(cmdForAddingAnnouncements, link);
            sqlCmdAnnouncement.Parameters.AddWithValue("BranchID", BranchId);
            sqlCmdAnnouncement.Parameters.AddWithValue("Tittle", Tittle.Text);
            sqlCmdAnnouncement.Parameters.AddWithValue("Notification", Notification.Text);
            sqlCmdAnnouncement.Parameters.AddWithValue("Matric", Matric.Checked);
            sqlCmdAnnouncement.Parameters.AddWithValue("Intermediate", Intermediate.Checked);
            sqlCmdAnnouncement.Parameters.AddWithValue("PreEngineering", PreEngineering.Checked);
            sqlCmdAnnouncement.Parameters.AddWithValue("PreMedical", PreMedical.Checked);
            sqlCmdAnnouncement.Parameters.AddWithValue("Commerce", Commerce.Checked);
            sqlCmdAnnouncement.Parameters.AddWithValue("Date", dbDate);
            link.Open();

            if (Tittle.Text == "" || Notification.Text == "")
                Warning.Text = "Please don't leave Titlle or Announcement text area empty";
            else
            {
                sqlCmdAnnouncement.ExecuteNonQuery();
                Warning.Text = "Announcement Added";
                Tittle.Text = "";
                Notification.Text = "";
            }
            link.Close();
            setRepForAnnouncement(BranchId); //Setting Repeater For Announcements

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

        protected void announcementRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem R = e.Item;
            Label AnnouncementDate = (Label)R.FindControl("AnnouncementDate");
            AnnouncementDate.Text = flipDateSame(AnnouncementDate.Text.ToString());
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

        protected void announcementRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem R = e.Item;
            Panel AnnouncementPanel = (Panel)R.FindControl("AnnouncementPanel");
            Label msg = (Label)R.FindControl("msg");
            switch (e.CommandName)
            {
                case "Delete":
                    SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string cmdForRemovingAnnouncements = "DELETE FROM Announcement WHERE AnnouncementID = " + e.CommandArgument.ToString();
                    SqlCommand sqlCmdAnnouncement = new SqlCommand(cmdForRemovingAnnouncements, link);
                    link.Open();
                    sqlCmdAnnouncement.ExecuteNonQuery();
                    link.Close();
                    msg.Visible = true;
                    msg.Text = "Announcement Deleted";
                    AnnouncementPanel.Visible = false;
                    break;
            }
        }


    }
}
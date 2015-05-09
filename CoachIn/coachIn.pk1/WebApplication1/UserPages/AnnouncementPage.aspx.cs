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
    public partial class AnnouncementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoachingID"] == null)
                HeaderStrip.Visible = false;

            string BranchId = Request["value"].ToString();
            setRepForAnnouncement(BranchId); //Setting Repeater For Announcements
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
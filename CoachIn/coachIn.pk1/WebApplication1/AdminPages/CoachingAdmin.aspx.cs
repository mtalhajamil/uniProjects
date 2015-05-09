using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.AdminPages
{
    public partial class CoachingAdmin : System.Web.UI.Page
    {
        protected string CoachingName = "";
        protected string CoachingEmail = "";
        protected string coachID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                coachID = Session["CoachingID"].ToString(); //Reciving coachingID from coaching page
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }

            if (IsPostBack != true)
            {
                ChangePicture.Visible = false;
                ChangePicture.Style["Display"] = "none";
                Upload.Style["Display"] = "none";
                EditPic.Style["Display"] = "initial";
            }

            DescEdit.Style["display"] = "none";
            Description.Style["Display"] = "initial";
            Submit.Style["display"] = "none";
            Edit.Style["Display"] = "initial";

            ChangePicture.Style["Display"] = "initial";

            Session["CoachingID"] = coachID;
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
            Description.Text = (reader["Discription"].ToString());
            CoachingName = (reader["Name"].ToString());
            CoachingEmail = (reader["EmailAddress"].ToString());
            link.Close();
        }

        protected void Comment_click(object sender, EventArgs e)
        {

            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());

            string cmdForComments = "INSERT INTO Comments (CoachingID,Text,Name,EmailAddress)VALUES('" + coachID.ToString()
                + "',@Comment,@CoachingName,@CoachingEmail)";
            SqlCommand sqlCmdComment = new SqlCommand(cmdForComments, link);
            sqlCmdComment.Parameters.AddWithValue("CoachingName", CoachingName);
            sqlCmdComment.Parameters.AddWithValue("CoachingEmail", CoachingEmail);
            sqlCmdComment.Parameters.AddWithValue("Comment", Comment.Text.ToString());
            link.Open();
            if (Comment.Text.ToString() == "")
                Warning.Text = "Please don't leave the text area empty";
            else
            {
                sqlCmdComment.ExecuteNonQuery();
                Warning.Text = "Comment Posted At The End";
            }
            Comment.Text = "";
            displayComments(coachID);

        }

        protected void branchRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem R = e.Item;
            Repeater branchRepeater = (Repeater)R.FindControl("branchRepeater");
            Button Delete1 = (Button)R.FindControl("Delete1");
            Button Delete2 = (Button)R.FindControl("Delete2");
            Button Delete3 = (Button)R.FindControl("Delete3");
            Button Cancel = (Button)R.FindControl("Cancel");
            Button Button1 = (Button)R.FindControl("Button1");
            Label warning1 = (Label)R.FindControl("warning1");
            Label warning2 = (Label)R.FindControl("warning2");
            Label warning3 = (Label)R.FindControl("warning3");
            switch (e.CommandName)
            {
                case "buy":
                    //get command argument here
                    Session["BranchID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/AdminPages/BranchAdmin.aspx");
                    break;

                case "delete1":
                    //get command argument here
                    Delete2.Visible = true;
                    Delete1.Visible = false;
                    warning1.Visible = true;
                    Cancel.Visible = true;
                    break;

                case "delete2":
                    //get command argument here
                    Delete3.Visible = true;
                    Delete1.Visible = false;
                    Delete2.Visible = false;
                    warning1.Visible = false;
                    warning2.Visible = true;
                    Cancel.Visible = true;
                    break;

                case "delete3":
                    //get command argument here
                    Delete3.Visible = false;
                    Delete1.Visible = false;
                    warning2.Visible = false;
                    warning3.Visible = true;
                    Cancel.Visible = false;
                    Button1.Visible = false;
                    string branchID = e.CommandArgument.ToString();

                    SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
                    string str = "DELETE FROM [Branch] WHERE BranchID = " + branchID.ToString();
                    SqlCommand sqlCommand = new SqlCommand(str, link);
                    link.Open();
                    sqlCommand.ExecuteNonQuery();
                    link.Close();

                    break;

                case "Cancel":
                    //get command argument here
                    Delete3.Visible = false;
                    Delete3.Visible = false;
                    Delete1.Visible = true;
                    warning2.Visible = false;
                    warning1.Visible = false;
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
            if (match.Text == CoachingName)
            {
                temp.Text = " Coaching Admin";
            }

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (ChangePicture.FileContent.Length > 1)
            {
                byte[] ImageData = ChangePicture.FileBytes;

                using (SqlConnection Connection = new SqlConnection())
                {
                    Connection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString();
                    Connection.Open();
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Connection;
                    Cmd.CommandText = "Update Coaching SET Photo = @Image WHERE CoachingID = @ID";
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandTimeout = 100;
                    Cmd.Parameters.AddWithValue("Image", ImageData);
                    Cmd.Parameters.AddWithValue("ID", coachID);
                    int r = Cmd.ExecuteNonQuery();
                }
            }

            displayCoachingData(coachID); //Display All Coaching Data
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Description.Style["Display"] = "none";
            DescEdit.Style["Display"] = "initial";
            DescEdit.Text = Description.Text;
            DescEdit.Focus();
            Edit.Style["Display"] = "none";
            Submit.Style["Display"] = "initial";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection link = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string cmdForComments = "UPDATE Coaching SET Discription = @Description WHERE CoachingID = @CoachingID";
            SqlCommand sqlCmdComment = new SqlCommand(cmdForComments, link);
            sqlCmdComment.Parameters.AddWithValue("Description", DescEdit.Text);
            sqlCmdComment.Parameters.AddWithValue("CoachingID", coachID);
            link.Open();
            sqlCmdComment.ExecuteNonQuery();
            displayCoachingData(coachID);
        }

        protected void news_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/AddNews.aspx");
        }

        protected void EditPic_Click(object sender, EventArgs e)
        {
            ChangePicture.Visible = true;
            ChangePicture.Style["Display"] = "initial";
            Upload.Style["Display"] = "initial";
            EditPic.Style["Display"] = "none";
        }

        protected void AddNewBranch_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SignUp/BranchAddition.aspx");
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
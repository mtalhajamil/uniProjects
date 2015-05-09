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
    public partial class CourseAddition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            string branch = "";
            try
            {
                branch = Session["BranchID"].ToString();
            }
            catch
            {
                Response.Redirect("~/SignUp/SignIn.aspx");
            }

            SqlConnection courseLink = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
            string str = "INSERT INTO Course (BranchID,Name,[Fee/Month],LumpSum,Details,Matric,Intermediate,PreEngineering,PreMedical,Commerce) values (@BranchID,@Name,@Fee,@LumpSum,@Details,@Matric,@Intermediate,@PreEngineering,@PreMedical,@Commerce)";
            SqlCommand sqlCommand = new SqlCommand(str, courseLink);
            sqlCommand.Parameters.AddWithValue("BranchID", branch);
            sqlCommand.Parameters.AddWithValue("Name", Name.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Fee", Fees.Text.ToString());
            sqlCommand.Parameters.AddWithValue("LumpSum", LumpSum.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Details", Details.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Matric", Matric.Checked);
            sqlCommand.Parameters.AddWithValue("Intermediate", PreEngineering.Checked | PreMedical.Checked | Commerce.Checked);
            sqlCommand.Parameters.AddWithValue("PreEngineering", PreEngineering.Checked);
            sqlCommand.Parameters.AddWithValue("PreMedical", PreMedical.Checked);
            sqlCommand.Parameters.AddWithValue("Commerce", Commerce.Checked);

            courseLink.Open();
            sqlCommand.ExecuteNonQuery();
            courseLink.Close();

            str = "SELECT CourseID FROM Course WHERE Name = @Name AND [Fee/Month] = @Fee AND LumpSum = @LumpSum";
            sqlCommand = new SqlCommand(str, courseLink);
            sqlCommand.Parameters.AddWithValue("Name", Name.Text.ToString());
            sqlCommand.Parameters.AddWithValue("Fee", Fees.Text.ToString());
            sqlCommand.Parameters.AddWithValue("LumpSum", LumpSum.Text.ToString());
            courseLink.Open();
            SqlDataReader courseReader = sqlCommand.ExecuteReader();
            courseReader.Read();
            Session["CourseID"] = courseReader["CourseID"].ToString();
            courseLink.Close();
            Response.Redirect("~/SignUp/SubjectAddition.aspx");
            
        }
    }
}
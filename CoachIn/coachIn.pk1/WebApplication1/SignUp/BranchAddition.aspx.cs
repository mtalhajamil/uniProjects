using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.SignUp
{
    public partial class BranchAddition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Finish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Details.Text) == true || string.IsNullOrWhiteSpace(Name.Text) == true || string.IsNullOrWhiteSpace(Address.Text) == true || string.IsNullOrWhiteSpace(Contact1.Text) == true)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incomplete Information')", true);
            else
            {
                string sql = null;
                string sql2 = null;
                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
                {
                    sql2 = "select count(*) from Branch where (CoachingID=@id AND Name=@Name) OR Address=@Address";
                    sql = "insert into Branch (CoachingID,Name,Address,Contact1,Contact2,Description) values (@id,@Name,@Address,@Contact1,@Contact2,@Details)";
                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {

                        cmd2.Parameters.AddWithValue("@Name", Name.Text);
                        cmd2.Parameters.AddWithValue("@Address", Address.Text);
                        cmd2.Parameters.AddWithValue("@Contact", Contact1.Text);
                        int isPresent = (int)cmd2.ExecuteScalar();
                        if (isPresent > 0)
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Request not sent, a record similar to this already exist')", true);
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand(sql, cnn))
                            {
                                cmd.Parameters.AddWithValue("@id", Session["CoachingID"].ToString());
                                cmd.Parameters.AddWithValue("@Name", Name.Text);
                                cmd.Parameters.AddWithValue("@Address", Address.Text);
                                cmd.Parameters.AddWithValue("@Contact1", Contact1.Text);
                                cmd.Parameters.AddWithValue("@Contact2", Contact2.Text);
                                cmd.Parameters.AddWithValue("@Details", Details.Text);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("~/AdminPages/CoachingAdmin.aspx");
                            }
                        }
                    }
                }
            }
        }
    }
}
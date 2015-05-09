using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.SignUp
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = ImageButton1.ID;
            LinkButton1.Attributes.Add("onclick", "window.open('forgetpassword.aspx','','height=300,width=600');return false");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text) == true || string.IsNullOrWhiteSpace(Password.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email or Password cannot be left empty')", true);

            }
            else
            {
                string sql2 = null;
                string admin = null;

                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
                {
                    int isPresent = 0;
                    sql2 = "select count(*) from Coaching where EmailAddress=@Email AND Password=@Password  ";
                    admin = "select * from Coaching where EmailAddress=@Email AND Password=@Password";
                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {

                        cmd2.Parameters.AddWithValue("@Email", Email.Text);
                        cmd2.Parameters.AddWithValue("@Password", Password.Text);
                        isPresent = (int)cmd2.ExecuteScalar();

                    }
                    if (isPresent <= 0)
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Email Address or Password')", true);
                    else
                    {
                        using (SqlCommand cmd3 = new SqlCommand(admin, cnn))
                        {

                            cmd3.Parameters.AddWithValue("@Email", Email.Text);
                            cmd3.Parameters.AddWithValue("@Password", Password.Text);
                            SqlDataReader reader = cmd3.ExecuteReader();
                            reader.Read();
                            Session["CoachingID"] = reader["CoachingID"];
                            Response.Redirect("~/AdminPages/CoachingAdmin.aspx");
                        }

                    }


                }
            }
        }
    }
}
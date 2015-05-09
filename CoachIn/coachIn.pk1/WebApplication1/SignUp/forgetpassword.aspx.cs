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
    public partial class forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            email.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please provide your registered email address')", true);

            }
            else
            {
                string sql2 = null;
                string sql3 = null;
                string connectionString = WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString();
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    sql2 = "select count(*) from Coaching where  EmailAddress=@Email  ";
                    sql3 = "select * from Coaching where EmailAddress=@Email  ";
                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {
                        cmd2.Parameters.AddWithValue("@Email", email.Text);
                        int isPresent = (int)cmd2.ExecuteScalar();
                        if (isPresent == 0)
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email not registered')", true);
                        else
                        {


                            /////////////////
                            using (SqlCommand cmd3 = new SqlCommand(sql3, cnn))
                            {
                                cmd3.Parameters.AddWithValue("@Email", email.Text);
                                SqlDataReader reader = cmd3.ExecuteReader();
                                reader.Read();
                                string password = "Your Passowrd is : " + reader["Password"].ToString();
                                //email
                                try
                                {
                                    MailMessage objMail = new MailMessage("mudassirbaig93@gmail.com", "mudassirbaig93@yahoo.com", "Password", password);
                                    NetworkCredential objNC = new NetworkCredential("mudassirbaig93@gmail.com", "03343753618");
                                    SmtpClient objsmtp = new SmtpClient("smtp.gmail.com", 587);
                                    objsmtp.EnableSsl = true;
                                    objsmtp.Credentials = objNC;
                                    objsmtp.Send(objMail);
                                    Label1.Text = "Password has been mailed to you!";
                                    Label1.Visible = true;

                                }
                                catch
                                {
                                    Label1.Text = "Please check your internet connection";
                                    Label1.Visible = true;
                                }

                            }
                        }

                    }
                }
            }
        }
    }
}
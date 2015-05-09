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

namespace WebApplication1.UserPages
{
    public partial class SignUp3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])Session["imagedata"], 0, ((Byte[])Session["imagedata"]).Length);
            
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Details.Text) == true || string.IsNullOrWhiteSpace(vertime.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please provide details and suitable date time')", true);

            }
            else
            {
                Byte[] Imgdata = (Byte[])Session["imagedata"];
                string name = Session["Name"].ToString();
                string address = Session["Address"].ToString();
                string contact1 = Session["Contact1"].ToString();
                string contact2 = Session["Contact2"].ToString();
                string img = @"~\img\" + Session["img"].ToString();
                string email = Session["Email"].ToString();
                string email2 = Session["Email2"].ToString();
                string password = Session["Password"].ToString();
                string matric = Session["Matric"].ToString();
                string inter = Session["Intermediate"].ToString();
                string eng = Session["PreEngineering"].ToString();
                string med = Session["PreMedical"].ToString();
                string comm = Session["Commerce"].ToString();
                string sql = null;
                string sql2 = null;

                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString()))
                {
                    sql = "insert into Verification (Name,Address,EmailAddress,EmailAddress2,Password,Contact1,Contact2,Matric,Intermediate,PreEngineering,PreMedical,Commerce,Details,Photo,ContactDetails) values (@Name,@Address,@Email,@Email2,@Password,@Contact1,@Contact2,@Matric,@Intermediate,@PreEngineering,@PreMedical,@Commerce,@Details,@imagedata,@contactdetail)";
                    sql2 = "select count(*) from Verification where Name=@Name OR Address=@Address OR EmailAddress=@Email  ";

                    cnn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(sql2, cnn))
                    {
                        cmd2.Parameters.AddWithValue("@Name", name);
                        cmd2.Parameters.AddWithValue("@Address", address);
                        cmd2.Parameters.AddWithValue("@Email", email);
                        int isPresent = (int)cmd2.ExecuteScalar();
                        if (isPresent > 0)
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Request not sent, a record similar to this already exist')", true);
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand(sql, cnn))
                            {
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Address", address);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@Email2", email2);

                                cmd.Parameters.AddWithValue("@Password", password);
                                cmd.Parameters.AddWithValue("@Contact1", contact1);
                                cmd.Parameters.AddWithValue("@Contact2", contact2);
                                cmd.Parameters.AddWithValue("@Matric", matric);
                                cmd.Parameters.AddWithValue("@Intermediate", inter);
                                cmd.Parameters.AddWithValue("@PreEngineering", eng);
                                cmd.Parameters.AddWithValue("@PreMedical", med);
                                cmd.Parameters.AddWithValue("@Commerce", comm);

                                cmd.Parameters.AddWithValue("@Details", Details.Text);
                                cmd.Parameters.AddWithValue("@imagedata", Imgdata);
                                cmd.Parameters.AddWithValue("@contactdetail", vertime.Text);
                                cmd.ExecuteNonQuery();

                            }

                            //MailMessage objMail = new MailMessage("mudassirbaig93@gmail.com", "mudassirbaig93@yahoo.com", "vs mail", "New coaching Registration Request");
                            //NetworkCredential objNC = new NetworkCredential("mudassirbaig93@gmail.com", "03343753618");
                            //SmtpClient objsmtp = new SmtpClient("smtp.gmail.com", 587);
                            //objsmtp.EnableSsl = true;
                            //objsmtp.Credentials = objNC;
                            //objsmtp.Send(objMail);

                            Server.Transfer("SignUp4.aspx");
                        }

                    }


                }


            }
        }
    }
}
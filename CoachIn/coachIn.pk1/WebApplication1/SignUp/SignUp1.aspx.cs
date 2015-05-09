using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserPages
{
    public partial class SignUp1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (img.HasFile == false || string.IsNullOrWhiteSpace(Name.Text) == true || string.IsNullOrWhiteSpace(Address.Text) == true || string.IsNullOrWhiteSpace(Contact1.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name,Adress,Contact1 and Logo must be filled')", true);

            }
            else
            {
                if (img.HasFile)
                {
                    string extention = System.IO.Path.GetExtension(img.FileName);

                    if (extention != ".jpg" && extention != ".png" && extention != ".jpeg" && extention != ".gif" && extention != ".JPG" && extention != ".PNG" && extention != ".JPEG" && extention != ".GIF")
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only jpg,jpeg,png andgif files are allowed')", true);

                    else
                    {

                        Session["imagedata"] = img.FileBytes;
                        Session["Name"] = Name.Text;
                        Session["Address"] = Address.Text;
                        Session["Contact1"] = Contact1.Text;
                        Session["Contact2"] = Contact2.Text;
                        Session["img"] = img.FileName;
                        Server.Transfer("SignUp2.aspx");

                    }
                }


            }
        }

    }
}
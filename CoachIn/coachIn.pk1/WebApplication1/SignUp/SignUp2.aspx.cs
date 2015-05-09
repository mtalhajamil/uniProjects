using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.UserPages
{
    public partial class SignUp2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])Session["imagedata"], 0, ((Byte[])Session["imagedata"]).Length);
        }
        protected void inter_CheckedChanged(object sender, EventArgs e)
        {
            if (inter.Checked)
            {
                eng.Visible = true;
                med.Visible = true;
                comm.Visible = true;
            }

            if (!inter.Checked)
            {
                eng.Visible = false;
                med.Visible = false;
                comm.Visible = false;
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Pass.Text) == true || string.IsNullOrWhiteSpace(ChkPass.Text) == true || string.IsNullOrWhiteSpace(Email1.Text) == true || string.IsNullOrWhiteSpace(Email2.Text) == true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email or Password enteries cannot be left empty')", true);

            }
            else
            {
                if (Pass.Text != ChkPass.Text)
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password mismatch')", true);
                else
                {
                    Session["Email"] = Email1.Text;
                    Session["Email2"] = Email2.Text;
                    Session["Password"] = Pass.Text;
                    Session["Matric"] = matric.Checked;
                    Session["Intermediate"] = inter.Checked;
                    Session["PreEngineering"] = eng.Checked;
                    Session["PreMedical"] = med.Checked;
                    Session["Commerce"] = comm.Checked;
                    Server.Transfer("SignUp3.aspx");
                }
            }
        }

    }
}

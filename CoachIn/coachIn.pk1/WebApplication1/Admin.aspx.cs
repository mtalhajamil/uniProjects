using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["value"].ToString() != "or@cle93")
                 Response.Redirect("~/UserPages/CoachingDisplay.aspx");

            if (!IsPostBack)
            {
                BindRepeater();
                BindAccepted();
            }


        }

        private void BindAccepted()
        {
            SqlCommand cmd = new SqlCommand("Select * from Coaching", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            Accepted.DataSource = ds;
            Accepted.DataBind();
            con.Close();
        }

        protected void BindRepeater()
        {
            SqlCommand cmd = new SqlCommand("Select * from Verification", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            requests.DataSource = ds;
            requests.DataBind();
            con.Close();
        }


        protected void requests_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertSql = "INSERT INTO dbo.Coaching([Name],[EmailAddress],[EmailAddress2],[Password],[Contact1],[Contact2],[Photo],[Matric],[Intermediate],[PreEngineering],[PreMedical],[Commerce]) ";
                insertSql += "SELECT [Name],[EmailAddress],[EmailAddress2],[Password],[Contact1],[Contact2],[Photo],[Matric],[Intermediate],[PreEngineering],[PreMedical],[Commerce] FROM Verification ";
                insertSql += "WHERE CoachingID=@CoachingID";


                SqlCommand cmd = new SqlCommand(insertSql, con);
                cmd.Parameters.AddWithValue("@CoachingID", e.CommandArgument);
                string insertSql2 = "DELETE FROM Verification WHERE CoachingID=@CoachingID";
                SqlCommand cmd2 = new SqlCommand(insertSql2, con);
                cmd2.Parameters.AddWithValue("@CoachingID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                BindRepeater();
            }

            if (e.CommandName == "delete")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from Verification where CoachingID = @CoachingID", con);
                cmd.Parameters.AddWithValue("@CoachingID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                BindRepeater();
            }

        }


        protected void Accepted_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from Coaching where CoachingID = @CoachingID", con);
                cmd.Parameters.AddWithValue("@CoachingID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                BindAccepted();
            }
        }
    }
}
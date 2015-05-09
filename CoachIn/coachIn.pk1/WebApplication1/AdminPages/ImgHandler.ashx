<%@ WebHandler Language="C#" Class="ImgHandler" %>

using System;
using System.Web;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class ImgHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
       string ImageId = context.Request["i"].ToString();
       context.Response.ContentType = "image/Jpeg";
       DrawImage(context, ImageId);
    }

    
    private void DrawImage(HttpContext context, string imageId)
    {
        using (SqlConnection Connection = new SqlConnection())
        {
            Connection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["coachingPageConnection"].ToString();
            Connection.Open();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Connection;
            Cmd.CommandText = "Select * From Coaching where CoachingID = " + imageId.ToString();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandTimeout = 100;
           // Cmd.Parameters.AddWithValue("@ImageId", imageId);
            SqlDataAdapter Adp = new SqlDataAdapter(Cmd);
            DataSet Ds = new DataSet();
            Adp.Fill(Ds);
            byte[] ImageData = (byte[])(Ds.Tables[0].Rows[0]["Photo"]);

            MemoryStream Ms = new MemoryStream(ImageData);
            Bitmap Bmp = new Bitmap(Ms);
            Bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Bmp.Dispose();
            Ms.Dispose();
        }        
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
}
<%@ WebHandler Language="C#" Class="Uploader" %>

using System;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class Uploader : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            context.Response.ContentType = "text/plain";
            string recordid = context.Request.QueryString["recordid"].ToString();
            string username = recordid;


            if (context.Request.QueryString["recordid"].ToString() != "")
            {

                string dirFullPath = HttpContext.Current.Server.MapPath("~/Upload/");
                string[] files;
                int numFiles;

                string str_image = "";
                if ((context.Request.QueryString["recordid"].ToString() != ""))
                {

                    HttpFileCollection fil = context.Request.Files;
                    for (int s = 0; s < fil.Count; s++)
                    {
                        HttpPostedFile file = context.Request.Files[s];
                        string fileName = file.FileName;
                        string fileExtension = file.ContentType;
                        files = System.IO.Directory.GetFiles(dirFullPath);
                        numFiles = files.Length;
                        numFiles = numFiles + 1;


                        /////// Image Path Get ///////

                        fileExtension = Path.GetExtension(fileName);
                        str_image = username + "_" + numFiles.ToString() + fileExtension;

                        /////// Image Path Get End ///////

                        string pathToSave = HttpContext.Current.Server.MapPath("~/Upload/") + str_image;
                        file.SaveAs(pathToSave);

                        // img size  ////
                        //System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        //int height = img.Height;
                        //int width = img.Width;
                        //decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);
                        int height = 0;
                        int width = 0;
                        decimal size = 0;
                        // image size end   //

                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Prime"].ToString());
                        con.Open();
                        DateTime dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        string month = dt.Month.ToString() + "/" + dt.Year.ToString();
                        string date = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
                        SqlCommand cmd = new SqlCommand("insert into tbl_uploads(imgname,imgpath,imgheight,imgwidth,imgsize,date1,month1,Record_ID) values('" + str_image.ToString() + "','" + "~/Upload/" + str_image.ToString() + "','"+height.ToString()+"','"+width.ToString()+"','"+size.ToString()+"','"+date.ToString()+"','"+month.ToString()+"','"+recordid.ToString()+"')", con);
                        cmd.ExecuteNonQuery();

                        context.Response.Write(str_image);

                    }

                }
            }
        }
        catch (Exception ex)
        {

            context.Response.Write("ERROR: "+ex.Message);
        }
    }




    public bool IsReusable {
        get {
            return false;
        }


    }



}
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageID.App_Code;

namespace ImageID
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fu.HasFile)
            {
                lblStatus.Text = "No File Selected";
                return;
            }
            // Correct file type ? via ContentType property // NOT an image, bailout
            if (fu.PostedFile.ContentType != "image/jpeg" && fu.PostedFile.ContentType != "image/png" && fu.PostedFile.ContentType != "image/gif")
            {
                lblStatus.Text = "Not a picture, gimme a picture";
                return;
            }

            //MapPath() to construct a full path into your Uploads directory appending his UserName.
            string destDir = MapPath("~/Images"); // destination directory
            string fileName = fu.FileName; // user's file name !! careful..
            Session["filename"] = fileName;
            Session["destDir"] = destDir;

            // NOTE : file name is your APP's choice ! You Pick
            string savePath = destDir + @"\" + fileName;
            //string[] files = Directory.GetFiles(destDir);

            //see if directory exists, if not, create it
            try
            {
                // Determine whether the directory exists.
                if (!(Directory.Exists(destDir)))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(destDir);
                }
                else //if it exists, are there files in it?
                {
                    if (Directory.GetFiles(destDir).Length == 0) //no files, then save
                    {
                        try
                        {
                            fu.SaveAs(savePath);

                            lblStatus.Text = API.CallAPI(savePath);
                        }
                        catch (Exception exc)
                        {
                            lblStatus.Text = "File save exception : " + exc.Message;
                            return;
                        }
                    }
                    else //there's files, deelete it
                    {
                        try
                        {
                            File.Delete(Directory.GetFiles(destDir)[0]);
                            fu.SaveAs(savePath);
                            lblStatus.Text = API.CallAPI(savePath);
                        }
                        catch (Exception exc)
                        {
                            lblStatus.Text = "File save exception : " + exc.Message;
                            return;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                lblStatus.Text = $"The process failed: {exception}";
            }

            FileInfo fi = new FileInfo(savePath);

            //show the image
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

            string relative = $"/Images/{fi.Name}";

            img.ImageUrl = relative;
            img.CssClass = "imgClass";

            ph.Controls.Add(img);

            //lblStatus.Text = "File Upload Successful";
        }
    }
}
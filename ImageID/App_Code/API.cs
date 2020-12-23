using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Cloudmersive.APIClient.NET.ImageRecognition.Api;
using Cloudmersive.APIClient.NET.ImageRecognition.Client;
using Cloudmersive.APIClient.NET.ImageRecognition.Model;
using System.IO;

namespace ImageID.App_Code
{
    public class API
    {
        public static string CallAPI(string relative)
        {
            // Configure API key authorization: Apikey
            Configuration.Default.AddApiKey("Apikey", "4f84b15b-62fb-4d35-9014-92ef67496abe");

            var apiInstance = new RecognizeApi();

            //FileInfo fi = new FileInfo((string)Session["filename"]);
            //string[] files = Directory.GetFiles((string)Session["dirPath"]);
            //string relative = $"~/{fi.Directory.Parent.Name}/{fi.Name}";

            var imageFile = new System.IO.FileStream(relative, System.IO.FileMode.Open); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Describe an image in natural language
                ImageDescriptionResponse result = apiInstance.RecognizeDescribe(imageFile);
                imageFile.Close();
                return result.BestOutcome.Description;
                //return result.ToString();
            }
            catch (Exception e)
            {
                return "Exception when calling RecognizeApi.RecognizeDescribe: " + e.Message;
            }
        }
    }
}
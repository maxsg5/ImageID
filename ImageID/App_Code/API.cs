using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Cloudmersive.APIClient.NET.ImageRecognition.Api;
using Cloudmersive.APIClient.NET.ImageRecognition.Client;
using Cloudmersive.APIClient.NET.ImageRecognition.Model;

namespace ImageID.App_Code
{
    public class API
    {
        public static void CallAPI()
        {
            // Configure API key authorization: Apikey
            Configuration.Default.AddApiKey("Apikey", "YOUR_API_KEY");

            var apiInstance = new RecognizeApi();
            var imageFile = new System.IO.FileStream("C:\\temp\\inputfile", System.IO.FileMode.Open); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Describe an image in natural language
                ImageDescriptionResponse result = apiInstance.RecognizeDescribe(imageFile);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RecognizeApi.RecognizeDescribe: " + e.Message);
            }
        }
    }
}
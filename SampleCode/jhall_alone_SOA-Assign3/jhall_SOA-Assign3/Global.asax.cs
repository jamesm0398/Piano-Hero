/*###############################################################
 *  File:           Global.asmx.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           Global
 *  Purpose:        Handles all inputs and outputs from the soap services
 * ##############################################################*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace jhall_SOA_Assign3
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }
        /*################################################################
         * Function:    Application_BeginRequest
         * Description: Allows for testing incomming http stream
         * Parameters:  
         *      object sender:
         *      EventArgs e:
         * return:      N/A 
         *################################################################*/
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Create byte array to hold request bytes
            byte[] inputStream = new byte[HttpContext.Current.Request.ContentLength];

            // Read entire request inputstream
            HttpContext.Current.Request.InputStream.Read(inputStream, 0, inputStream.Length);

            //Set stream back to beginning
            HttpContext.Current.Request.InputStream.Position = 0;

            //Get  XML request
            string requestString = ASCIIEncoding.ASCII.GetString(inputStream);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
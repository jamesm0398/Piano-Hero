/*###############################################################
 *  File:           LogService.asmx.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           LogService
 *  Purpose:        Base class for SOAP services that provides logging
 * ##############################################################*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace jhall_SOA_Assign3
{
    /// <summary>
    /// Summary description for LogService
    /// </summary>
   
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
   
    public class LogService : System.Web.Services.WebService
    {
        public string logFilePaths = "./Logs/";
        Guid ClientTransactionId;
        string appName;
        /*################################################################
         * Function:    InitLogService
         * Description: Sets logging file path
         * Parameters:  string logFileName: path of logging
         * return:      N/A 
         *################################################################*/
        public void InitLogService(string appName, string logFileName)
        {
            logFilePaths += logFileName;
            ClientTransactionId = Guid.NewGuid();
            this.appName = appName;
        }
        /*################################################################
         * Function:    LogEvent
         * Description: Generic logging 
         * Parameters:  
         *  string msg: a log message
         * return:      N/A 
         *################################################################*/
        private string LogEvent( string msg)
        {
            return Log.Event(appName ,logFilePaths, msg, ClientTransactionId);
        }

        /*################################################################
         * Function:    LogServiceAccessed
         * Description: Special case log messgae
         * Parameters:  N/A
         * return:      N/A 
         *################################################################*/
        public void LogServiceAccessed()
        {
           LogEvent("Accessed @");
        }
        /*################################################################
         * Function:    LogServiceDone
         * Description: Special case log messgae
         * Parameters:  N/A
         * return:      N/A 
         *################################################################*/
        public void LogServiceDone(string val)
        {
            LogEvent("returned val:"+val+" Done @");
        }
        /*################################################################
         * Function:   LogServiceError
         * Description: Special case log messgae for errors
         * Parameters:  N/A
         * return:      N/A 
         *################################################################*/
        public string LogServiceError(string error)
        {
            return LogEvent(error);
        }
        /*################################################################
         * Function:    Application_BeginRequest
         * Description: dOES NOTHING
         * Parameters: 
         *  Object s, EventArgs e;
         * return:      N/A 
         *################################################################*/
        protected void Application_BeginRequest(Object s, EventArgs e)
        {

        }
    }
}

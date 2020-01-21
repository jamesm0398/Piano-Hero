/*###############################################################
 *  File:           Log.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           Log
 *  Purpose:        Handles all fileIO for logging
 * ##############################################################*/
 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using AesEverywhere;
namespace jhall_SOA_Assign3
{
    public static class Log
    {

        /*################################################################
         * Function:    Event
         * Description: Logs Event messages
         * Parameters:  
         *      string path: path to log to
         *      string msg: message to log
         * return:      string
         *################################################################*/
        public static string Event(string appName, string path, string msg, Guid ClientTransactionId)
        {
            try
            {
                msg = Template(msg);
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();                
                CallLogService(appName, msg.Replace(',', '.'), ClientTransactionId);
            }
            catch (Exception ex)
            {
                msg = "Panic Logging failed!!!!!!! HAHAHAHA\n" + ex.Message;
                Console.WriteLine(msg);
            }

            return msg;
           
        }
        /*################################################################
         * Function:   Template
         * Description: Formats standard template
         * Parameters:  
         *      string newMsg: messge to format
         * return:      string
         *################################################################*/
        private static string Template(string newMsg)
        {
      
               newMsg+= " ==> "+DateTime.Now.ToLongDateString().ToString() + " " 
                + DateTime.Now.ToLongTimeString().ToString() ;          

            return newMsg;
        }
        const string API_KEY = "84239dab-07f1-4ad9-a0d9-35ab0432a8c5";
        private const string DIR_GET_URL = "log/";
        private const string DIR_POST_URL = "log/search/";
        private const string BASE_URL = "http://localhost:3000/";
        const string PASSWORD = "kgu43vm5v4562c8f&(*$%3,fve4jlu5hsacv";

        private static void CallLogService(string appName, string msg, Guid ClientTransactionId)
        {
            //{"clientId":"84239dab-07f1-4ad9-a0d9-35ab0432a8c5","Stamp":1576564602,"Msg":"2019 year Dec","LocalTimeZone":"WT",
            //"ClientTransactionId":"5f96e6dd-54bf-4625-9c42-962060c9a2a5", "LogServiceInstanceId":"6b12528e-3c8d-4782-9732-40d7e49f39be" }
            
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            TimeZone localZone = TimeZone.CurrentTimeZone;
           // Guid ClientTransactionId = Guid.NewGuid();
            StringBuilder strB = new StringBuilder();
            strB.AppendFormat("\"clientId\":\"84239dab-07f1-4ad9-a0d9-35ab0432a8c5\",\"Stamp\":{0},\"AppName\":\"{1}\"," +
                "\"Msg\":\"{2}\"," +
                "\"LocalTimeZone\":\"{3}\"," +
                "\"ClientTransactionId\":\"{4}\"," +
                " \"LogServiceInstanceId\":\"{5}\"", unixTimestamp.ToString(), appName, msg, localZone.StandardName, ClientTransactionId.ToString(), Guid.NewGuid().ToString());
            strB.Insert(0, "{", 1);
            strB.Insert(strB.Length, "}", 1);

            AES256 aes = new AES256();
            string cryptedBody = aes.Encrypt(strB.ToString(), PASSWORD);
            string cryptedAPIKey = aes.Encrypt(API_KEY, PASSWORD);

            //soap sample starts here

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BASE_URL+ DIR_GET_URL +ConvertStringToHex(cryptedAPIKey, Encoding.ASCII));
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = cryptedBody.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(cryptedBody);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
        }
        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
    }
}
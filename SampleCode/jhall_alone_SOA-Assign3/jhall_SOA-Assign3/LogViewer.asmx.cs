using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;

namespace jhall_SOA_Assign3
{



    /// <summary>
    /// Summary description for LogViewer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LogViewer : LogService
    {
        public class LogEntry : Return
        {
            public string ClientId { get; set; }
            public Int64 Stamp { get; set; }
            public string Msg { get; set; }
            public string LocalTimeZone { get; set; }
            public string ClientTransactionId { get; set; }
            public string LogServiceInstanceId { get; set; }
        }

        public class ClientLogs
        {
            public LogEntry[] logEntries { get; set; }
        }

        [WebMethod]
        public ClientLogs GetAllLogs()
        {
            ClientLogs clientLogs = new ClientLogs();
            string logs = CallLogService("");
            
            return clientLogs;
        }
        private const string URL = "http://localhost:3000/log/84239dab-07f1-4ad9-a0d9-35ab0432a8c5";
        private static string CallLogService(string param)
        {
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL+param);
            request.Method = "GET";
            string response = string.Empty;
            try
            {
                using (HttpWebResponse responce = (HttpWebResponse)request.GetResponse())
                {                   
                    using (Stream webStream = responce.GetResponseStream() ?? Stream.Null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                            Console.Out.WriteLine(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
            return response;
        }
    }
}

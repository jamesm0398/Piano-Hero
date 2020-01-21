/*###############################################################
 *  File:           Case.asmx.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           Case
 *  Purpose:        Soap service to convert text cases
 * ##############################################################*
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace jhall_SOA_Assign3
{
    /// <summary>
    /// Summary description for CaseConverter
    /// </summary>
    [WebService(Namespace = "TextService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Case : LogService
    {

        public class CaseInfo : Return
        {
            public string incoming;
        }

        /*################################################################
         * Function:    CaseConvert
         * Description: Converts the case based on input flag
         * Parameters:  
         *      string incoming, uint flag: 1 to upper or 2 to upper
         * return:      CaseInfo
         *################################################################*/
        [WebMethod(Description = "Converts string to upper or lower case.")]
        public CaseInfo CaseConvert(string incoming, uint flag)
        {
            CaseInfo result = new CaseInfo();

            InitLogService("TextService", "CaseConvert.txt");
            LogServiceAccessed();

            StringBuilder b = new StringBuilder();
            b.AppendFormat("text = {0} and flag = {1} @ ", incoming, flag);
            LogServiceError(b.ToString());


            //check if flag is valid
            if (flag < 1 || flag > 2)
            {
                string error = "uint flag must be ether: 1 indicates to upper or 2 indicates to lower";
                result.error = LogServiceError(error);
                return result;
            }
            //check if string was sent
            if (incoming.Length < 1)
            {
                string error = "No string incoming value was sent";
                result.error = LogServiceError(error);
                return result;
            }



            //do case conversion
            if (flag == 1)
            {
                result.incoming = incoming.ToUpper();
            }
            else if (flag == 2)
            {
                result.incoming = incoming.ToLower();
            }
            

            LogServiceDone(result.incoming);

            return result;
        }
    }
}

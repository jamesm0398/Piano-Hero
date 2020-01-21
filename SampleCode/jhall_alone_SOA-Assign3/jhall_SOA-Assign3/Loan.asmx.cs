/*###############################################################
 *  File:           Loan.asmx.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           Loan
 *  Purpose:        Calculates monthly loan payments as a  SOAP  services
 * ##############################################################*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace jhall_SOA_Assign3
{
    /// <summary>
    /// Summary description for Loan
    /// </summary>
    [WebService(Namespace = "VinniesLoanService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Loan : LogService
    {

        public class LoanInfo : Return
        {
            public float monthlyP;
        }


        /*################################################################
         * Function:    LoanPayment
         * Description: Calculates monthly load payment
         * Parameters: 
         *      float principle: init amount loaned
         *      float rate: intrest % rate
         *      int payments: number of payments
         * return:     LoanInfo
         *################################################################*/
        [WebMethod(Description = "Calculate the amount of a loan payment")]
        public LoanInfo LoanPayment(float principle, float rate, int payments)
        {

            InitLogService("VinniesLoanService","LoanPayment.txt");
            LogServiceAccessed();

            StringBuilder b = new StringBuilder();
            b.AppendFormat("priciple = {0} , RATE = {1}, payments = {2} @ ", principle, rate, payments);
            LogServiceError(b.ToString());

            LoanInfo loanInfo = new LoanInfo();  

            if (principle <= 0 | rate < 0 | payments < 1)
            {
                loanInfo.error = LogServiceError("Invalid param service rejected request @");
                return loanInfo;
            }

            if (rate == 0)
            {
                loanInfo.error = LogServiceError("Divide by 0 @");
                return loanInfo;
            }

            try
            {
                float denominatior = (float)Math.Pow((1 + rate), payments) - 1;

                loanInfo.monthlyP = (float)(rate + rate / denominatior) * principle;
            }
            catch (Exception ex)
            {
                loanInfo.error = ex.Message;
                
            }
            

            LogServiceDone(loanInfo.monthlyP.ToString());

            return loanInfo;
        }
    }
}

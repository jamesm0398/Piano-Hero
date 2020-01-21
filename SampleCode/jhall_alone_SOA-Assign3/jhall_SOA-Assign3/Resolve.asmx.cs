/*###############################################################
 *  File:           Resolve.asmx.cs
 *  Project :       SOA 3
 *  Programmer :    John Hall
 *  Date :          17/10/2019
 *  
 *  Name:           Resolve
 *  Purpose:        SOAP  services thAt gets goe location data based on 
 *      IP address.
 * ##############################################################*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;

namespace jhall_SOA_Assign3
{
    /// <summary>
    /// Summary description for Resolve
    /// </summary>
    [WebService(Namespace = "ResolveIP")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Resolve : LogService
    {

        public class IPInfo : Return
        {
            public string City;
            public string StateProvince;
            public string Country;
            public string Organization;
            public decimal Latitude;
            public decimal Longitude;
        }



        [WebMethod]
        public IPInfo GetInfo(string ipAddress)
        {
            
            InitLogService("ResolveIP","ResolveIP.txt");

            LogServiceAccessed();

            StringBuilder b = new StringBuilder();
            b.AppendFormat("IP = {0} @", ipAddress);
            LogServiceError(b.ToString());

            IPInfo info = new IPInfo();
            IPAddress address;
            if (IPAddress.TryParse(ipAddress, out address))
            {

                var client = new IpGoeLookUp.P2GeoSoapClient();

                IpGoeLookUp.IPInformation geoinfo = null;


                try
                {
                    geoinfo = client.ResolveIP(ipAddress, "0");

                    info.City = geoinfo.City;
                    info.Country = geoinfo.Country;
                    info.Latitude = (decimal)geoinfo.Latitude;
                    info.Longitude = (decimal)geoinfo.Longitude;
                    info.Organization = geoinfo.Organization;
                    info.StateProvince = geoinfo.StateProvince;

                }
                catch (Exception ex)
                {
                    info.error = LogServiceError(ex.Message +" Failed to connect to remote service @");

                }
            }
            else
            {
                info.error = LogServiceError("Invalid ip service rejected request @");
            }

            LogServiceDone(info.City+" "+info.Country+""+info.Latitude.ToString()+
                " "+info.Longitude.ToString()+" "+info.Organization+ " "+info.StateProvince);

            return info;
        }
    }
}

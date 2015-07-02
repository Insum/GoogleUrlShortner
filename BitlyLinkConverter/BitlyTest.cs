using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitlyLinkConverter
{
    class BitlyTest
    {
        //string statusCode = string.Empty;
        //string statusText = string.Empty;
        //string shortUrl = string.Empty;
        //string longUrl = string.Empty;
        //string urlToShorten = "http://wwww.fluxbytes.com/";

        //var linkList = new ExcellHandler().ReadList();

        //using (WebClient wb = new WebClient())
        //{
        //    foreach (var link in linkList)
        //    {
        //        try
        //        {
        //            Thread.Sleep(2000);
        //            string data = string.Format("http://api.bitly.com/v3/shorten/?login={0}&apiKey={1}&longUrl={2}&format={3}",
        //           "johanapsis", // Your username
        //           "R_6a4939e7211a46dfb26319e1921b1997", // Your API key
        //           HttpUtility.UrlEncode(link), // Encode the url we want to shorten
        //           "xml");

        //            XmlDocument xmlDoc = new XmlDocument();
        //            xmlDoc.LoadXml(wb.DownloadString(data));

        //            statusCode = xmlDoc.GetElementsByTagName("status_code")[0].InnerText;
        //            statusText = xmlDoc.GetElementsByTagName("status_txt")[0].InnerText;
        //            shortUrl = xmlDoc.GetElementsByTagName("url")[0].InnerText;
        //            longUrl = xmlDoc.GetElementsByTagName("long_url")[0].InnerText;

        //            //Console.WriteLine(statusCode); // Outputs "200"
        //            //Console.WriteLine(statusText); // Outputs "OK"
        //            //Console.WriteLine(shortUrl); // Outputs "http://bit.ly/WVk1qN"
        //            //Console.WriteLine(longUrl); // Outputs "http://www.fluxbytes.com/"   

        //            var createFile = new ExcellHandler();
        //            createFile.WriteToFile(longUrl, shortUrl);
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }
        //}
    }
}

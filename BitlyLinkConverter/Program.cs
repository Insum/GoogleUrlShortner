using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;

namespace BitlyLinkConverter
{
    class Program
    {
        private static void Main(string[] args)
        {
            //string statusCode = string.Empty;
            //string statusText = string.Empty;
            //string shortUrl = string.Empty;
            //string longUrl = string.Empty;
            //string urlToShorten = "http://wwww.fluxbytes.com/";

            var linkList = new ExcellHandler().ReadList();

            using (WebClient wb = new WebClient())
            {
                foreach (var link in linkList)
                {
                    try
                    {

                        var shortUrl = GoogleUrlShortnerApi.Shorten(link);
                        //Thread.Sleep(2000);

                        var createFile = new ExcellHandler();
                        createFile.WriteToFile(link, shortUrl);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }        
    }

    public class GoogleUrlShortnerApi
    {
        //API Key from Google
        private const string key = "";

        public static string Shorten(string url)
        {
            string post = "{\"longUrl\": \"" + url + "\"}";
            string shortUrl = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);

            try
            {
                request.ServicePoint.Expect100Continue = false;
                request.Method = "POST";
                request.ContentLength = post.Length;
                request.ContentType = "application/json";
                request.Headers.Add("Cache-Control", "no-cache");

                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                    requestStream.Write(postBuffer, 0, postBuffer.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            shortUrl = Regex.Match(json, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if Google's URL Shortner is down...
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return shortUrl;
        }
    }

    class ExcellHandler 
    {
        public List<string> ReadList()
        {
            List<string> dataList = new List<string>();

            try
            {
                string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\elte\Desktop\1.xls;Extended Properties='Excel 8.0;HDR=Yes;'";
                using (OleDbConnection connection = new OleDbConnection(con))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                    using (OleDbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dataList.Add(dr[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return dataList;
        }

        public void WriteToFile(string orginalUrl, string bitlyUrl)
        {

            if (!File.Exists(@"C:\Users\elte\Desktop\test.csv"))
            {
                using (File.Create(@"C:\Users\elte\Desktop\test.csv")) { }
            }

            using (StreamWriter file = new StreamWriter(@"C:\Users\elte\Desktop\test.csv", true))
            {
                file.WriteLine(orginalUrl + ";" + bitlyUrl);
            }
        } 
    }
}

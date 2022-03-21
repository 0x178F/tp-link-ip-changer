using System;
using System.Net;

namespace TPLink_IP_Degistirme
{
    public class WebClientModemEx : WebClient
        {

            public WebClientModemEx()
            {
                this.Cookies = new CookieContainer();
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest webRequest = base.GetWebRequest(address) as HttpWebRequest;
                if (webRequest.Method == "POST")
                {
                    webRequest.ContentType = "text/plain";
                }
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                webRequest.Headers["Accept-Language"] = "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7";
                ServicePointManager.Expect100Continue = false;
                webRequest.CookieContainer = this.Cookies;
                webRequest.KeepAlive = true;
                webRequest.AllowAutoRedirect = true;
                return webRequest;


            }

            public CookieContainer Cookies { get; set; }
        }
}

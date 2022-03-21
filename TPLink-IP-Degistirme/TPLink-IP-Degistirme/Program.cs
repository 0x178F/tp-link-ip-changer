using System;
using System.Text;

namespace TPLink_IP_Degistirme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Changing ip address..");
            WebClientModemEx ex = new WebClientModemEx();
             tekrar: string oldIP = ex.DownloadString("http://ip.bablosoft.com/").ToString();
            ex.Encoding = Encoding.Default;
            ex.Headers.Add("X-Requested-With: XMLHttpRequest");
            ex.Headers.Add("Referer: http://192.168.1.1/");

            // encrypted with base 64
            string Username = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin"));
            string Pass = Convert.ToBase64String(Encoding.UTF8.GetBytes("ttnet"));

            ex.DownloadString("http://192.168.1.1/cgi/login?UserName=" + Username + "&Passwd=" + Pass + "&Action=1&LoginStatus=0");
            ex.Headers.Add("Referer: http://192.168.1.1/");
            byte[] Byte = System.Text.Encoding.ASCII.GetBytes("[ACT_PPP_DISCONN#1,1,1,0,0,0#0,0,0,0,0,0]0,0" + "\r\n");
            ex.UploadData("http://192.168.1.1/cgi?7", Byte);
            string newIP = ex.DownloadString("http://ip.bablosoft.com/").ToString();
            Console.WriteLine(newIP);
            if (oldIP == newIP)
                goto tekrar;
            Console.WriteLine("IP address has been changed.");
            System.Threading.Thread.Sleep(2000);
        }
    }
}

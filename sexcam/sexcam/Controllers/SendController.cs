using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Text;
using System.Threading;
namespace sexcam.Controllers
{
    public class SendController : ApiController
    {

        public string Get()
        {
            try
            {
                HttpWebRequest r = (HttpWebRequest)(WebRequest.Create("http://front1.omegle.com/start?rcs=1&firstevents=1&spid=&topics=%5B%22sex%22%5D&lang=en"));
                r.Method = "POST";
                r.KeepAlive = true;
                r.ServicePoint.Expect100Continue = false;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                r.Accept = "application/json";
                r.Headers.Add("Origin", "http://www.omegle.com");
                r.Referer = "http://www.omegle.com/";
                r.Headers.Add("Accept-Encoding", "gzip, deflate");
                r.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                r.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                Stream blah = r.GetResponse().GetResponseStream();
                byte[] b = new byte[1024];
                blah.Read(b, 0, b.Length);
                blah.Close();
                string binfo = Encoding.UTF8.GetString(b);
                int i = binfo.LastIndexOf("\": \"");
                int j = binfo.LastIndexOf("\"}") - i - 4;

                string id = binfo.Substring(i + 4, j);
                id = id.Replace(":", "%3A");

                while (true)
                {
                    HttpWebRequest e = (HttpWebRequest)(WebRequest.Create("http://front1.omegle.com/events"));
                    e.Method = "POST";
                    e.ServicePoint.Expect100Continue = false;
                    byte[] data = Encoding.UTF8.GetBytes("id=" + id);
                    e.ContentLength = data.Length;
                    e.KeepAlive = true;
                    e.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                    e.Accept = "application/json";
                    e.Headers.Add("Origin", "http://www.omegle.com");
                    e.Referer = "http://www.omegle.com/";
                    e.Headers.Add("Accept-Encoding", "gzip, deflate");
                    e.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    e.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    using (var stream = e.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    Stream status = e.GetResponse().GetResponseStream();
                    byte[] stat = new byte[1024];
                    status.Read(stat, 0, 1024);
                    string stats = Encoding.UTF8.GetString(stat);
                    status.Close();
                    if (stats.IndexOf("connected") != -1)
                        break;
                    Thread.Sleep(1000);
                }
                HttpWebRequest s = (HttpWebRequest)(WebRequest.Create("http://front1.omegle.com/send"));
                s.Method = "POST";
                s.ServicePoint.Expect100Continue = false;
                s.KeepAlive = true;
                s.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                s.Accept = "application/json";
                s.Headers.Add("Origin", "http://www.omegle.com");
                s.Referer = "http://www.omegle.com/";
                s.Headers.Add("Accept-Encoding", "gzip, deflate");
                s.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                s.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] sdata = Encoding.UTF8.GetBytes("msg=hot%20girsl%20on%20live%20cam%20in%20http%3A%2F%2Fadf.ly%2F16n6nD&id=" + id);
                s.ContentLength = sdata.Length;
                using (var stream = s.GetRequestStream())
                {
                    stream.Write(sdata, 0, sdata.Length);
                }
                s.GetResponse();

                HttpWebRequest d = (HttpWebRequest)(WebRequest.Create("http://front1.omegle.com/disconnect"));
                d.Method = "POST";
                d.ServicePoint.Expect100Continue = false;
                d.KeepAlive = true;
                d.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                d.Accept = "application/json";
                d.Headers.Add("Origin", "http://www.omegle.com");
                d.Referer = "http://www.omegle.com/";
                d.Headers.Add("Accept-Encoding", "gzip, deflate");
                d.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                d.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] ddata = Encoding.UTF8.GetBytes("id=" + id);
                d.ContentLength = ddata.Length;
                using (var stream = d.GetRequestStream())
                {
                    stream.Write(ddata, 0, ddata.Length);
                }
                d.GetResponse();
                return "sent";
            }
            catch (Exception e)
            {
                return e.Message + "-" + e.StackTrace;
            }


        }

    }
}
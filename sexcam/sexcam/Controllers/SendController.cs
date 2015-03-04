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
                HttpWebRequest r = (HttpWebRequest)(WebRequest.Create("http://requestmaker.com/requester.php"));
                r.Method = "POST";
                r.KeepAlive = true;
                r.ServicePoint.Expect100Continue = false;
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                r.Accept = "application/json";
                r.Headers.Add("Origin", "http://requestmaker.com");
                r.Referer = "http://requestmaker.com/";
                r.Headers.Add("Accept-Encoding", "gzip, deflate");
                r.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                r.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] rdata = Encoding.ASCII.GetBytes("url=http%3A%2F%2Ffront1.omegle.com%2Fstart%3Frcs%3D1%26firstevents%3D1%26spid%3D%26topics%3D%255B%2522sex%2522%255D%26lang%3Den&string=&type=POST&header%5B0%5D=Host%3A+front1.omegle.com&header%5B1%5D=Connection%3A+keep-alive&header%5B2%5D=Content-Length%3A+0&header%5B3%5D=Accept%3A+application%2Fjson&header%5B4%5D=Origin%3A+http%3A%2F%2Fwww.omegle.com&header%5B5%5D=User-Agent%3A+Mozilla%2F5.0+(Windows+NT+6.3%3B+WOW64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F40.0.2214.115+Safari%2F537.36&header%5B6%5D=Content-type%3A+application%2Fx-www-form-urlencoded%3B+charset%3DUTF-8&header%5B7%5D=Referer%3A+http%3A%2F%2Fwww.omegle.com%2F&header%5B8%5D=Accept-Encoding%3A+gzip%2C+deflate&header%5B9%5D=Accept-Language%3A+en-US%2Cen%3Bq%3D0.8");
                using (var stream = r.GetRequestStream())
                {
                    stream.Write(rdata, 0, rdata.Length);
                }
                Stream blah = r.GetResponse().GetResponseStream();
                byte[] b = new byte[4096];
                blah.Read(b, 0, b.Length);
                blah.Close();
                string binfo = Encoding.UTF8.GetString(b);
                binfo = binfo.Substring(binfo.LastIndexOf("\r\n\r\n")+2);
                int i = binfo.LastIndexOf("\": \"");
                int j = binfo.LastIndexOf("\"}") - i - 4;
                return binfo;
                string id = binfo.Substring(i + 4, j);
                id = id.Replace(":", "%3A");
                while (true)
                {
                    HttpWebRequest e = (HttpWebRequest)(WebRequest.Create("http://requestmaker.com/requester.php"));
                    e.Method = "POST";
                    e.KeepAlive = true;
                    e.ServicePoint.Expect100Continue = false;
                    e.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                    e.Accept = "application/json";
                    e.Headers.Add("Origin", "http://requestmaker.com");
                    e.Referer = "http://requestmaker.com/";
                    e.Headers.Add("Accept-Encoding", "gzip, deflate");
                    e.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                    e.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    byte[] data = Encoding.ASCII.GetBytes("url=http%3A%2F%2Ffront1.omegle.com%2Fevents&string=id%3D"+id.Replace("%","%25")+"&type=POST&header%5B0%5D=Host%3A+front1.omegle.com&header%5B1%5D=Connection%3A+keep-alive&header%5B2%5D=Content-Length%3A+44&header%5B3%5D=Accept%3A+application%2Fjson&header%5B4%5D=Origin%3A+http%3A%2F%2Fwww.omegle.com&header%5B5%5D=User-Agent%3A+Mozilla%2F5.0+(Windows+NT+6.3%3B+WOW64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F40.0.2214.115+Safari%2F537.36&header%5B6%5D=Content-type%3A+application%2Fx-www-form-urlencoded%3B+charset%3DUTF-8&header%5B7%5D=Referer%3A+http%3A%2F%2Fwww.omegle.com%2F&header%5B8%5D=Accept-Encoding%3A+gzip%2C+deflate&header%5B9%5D=Accept-Language%3A+en-US%2Cen%3Bq%3D0.8");
                    using (var stream = e.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    Stream status = e.GetResponse().GetResponseStream();
                    byte[] stat = new byte[4096];
                    status.Read(stat, 0, 1024);
                    string stats = Encoding.UTF8.GetString(stat);
                    status.Close();
                    stats = stats.Substring(stats.LastIndexOf("\r\n\r\n") - 2);
                    if (stats.IndexOf("connected") != -1)
                        break;
                    Thread.Sleep(1000);
                }
                HttpWebRequest s = (HttpWebRequest)(WebRequest.Create("http://requestmaker.com/requester.php"));
                s.Method = "POST";
                s.KeepAlive = true;
                s.ServicePoint.Expect100Continue = false;
                s.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                s.Accept = "application/json";
                s.Headers.Add("Origin", "http://requestmaker.com");
                s.Referer = "http://requestmaker.com/";
                s.Headers.Add("Accept-Encoding", "gzip, deflate");
                s.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                s.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] sdata = Encoding.UTF8.GetBytes("url=http%3A%2F%2Ffront1.omegle.com%2Fsend&string=msg%3Dhot%2520girsl%2520on%2520live%2520cam%2520in%2520http%253A%252F%252Fadf.ly%252F16n6nD%26id%3D" + id.Replace("%", "%25") + "&type=POST&header%5B0%5D=Host%3A+front1.omegle.com&header%5B1%5D=Connection%3A+keep-alive&header%5B2%5D=Content-Length%3A+44&header%5B3%5D=Accept%3A+application%2Fjson&header%5B4%5D=Origin%3A+http%3A%2F%2Fwww.omegle.com&header%5B5%5D=User-Agent%3A+Mozilla%2F5.0+(Windows+NT+6.3%3B+WOW64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F40.0.2214.115+Safari%2F537.36&header%5B6%5D=Content-type%3A+application%2Fx-www-form-urlencoded%3B+charset%3DUTF-8&header%5B7%5D=Referer%3A+http%3A%2F%2Fwww.omegle.com%2F&header%5B8%5D=Accept-Encoding%3A+gzip%2C+deflate&header%5B9%5D=Accept-Language%3A+en-US%2Cen%3Bq%3D0.8");
                s.ContentLength = sdata.Length;
                using (var stream = s.GetRequestStream())
                {
                    stream.Write(sdata, 0, sdata.Length);
                }
                s.GetResponse();

                HttpWebRequest d = (HttpWebRequest)(WebRequest.Create("http://requestmaker.com/requester.php"));
                d.Method = "POST";
                d.KeepAlive = true;
                d.ServicePoint.Expect100Continue = false;
                d.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                d.Accept = "application/json";
                d.Headers.Add("Origin", "http://requestmaker.com");
                d.Referer = "http://requestmaker.com/";
                d.Headers.Add("Accept-Encoding", "gzip, deflate");
                d.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                d.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] ddata = Encoding.UTF8.GetBytes("url=http%3A%2F%2Ffront1.omegle.com%2Fdisconnect&string=id%3D" + id.Replace("%", "%25") + "&type=POST&header%5B0%5D=Host%3A+front1.omegle.com&header%5B1%5D=Connection%3A+keep-alive&header%5B2%5D=Content-Length%3A+44&header%5B3%5D=Accept%3A+application%2Fjson&header%5B4%5D=Origin%3A+http%3A%2F%2Fwww.omegle.com&header%5B5%5D=User-Agent%3A+Mozilla%2F5.0+(Windows+NT+6.3%3B+WOW64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F40.0.2214.115+Safari%2F537.36&header%5B6%5D=Content-type%3A+application%2Fx-www-form-urlencoded%3B+charset%3DUTF-8&header%5B7%5D=Referer%3A+http%3A%2F%2Fwww.omegle.com%2F&header%5B8%5D=Accept-Encoding%3A+gzip%2C+deflate&header%5B9%5D=Accept-Language%3A+en-US%2Cen%3Bq%3D0.8");
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
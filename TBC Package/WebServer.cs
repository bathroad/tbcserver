using System;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Web;
using System.Xml;
using System.Data;

namespace TBC_Package
{
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        public WebServer()
        {
            _listener.Prefixes.Add("http://*:39876/");
            _listener.Start();
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                // https://stackoverflow.com/questions/8466703/httplistener-and-file-upload
                                // https://docs.microsoft.com/en-us/dotnet/api/system.net.httplistener?redirectedfrom=MSDN&view=netframework-4.8

                                string cmd = HttpUtility.ParseQueryString(ctx.Request.Url.Query).Get("command");

                                if (cmd == "events")
                                {
                                    bool events_exist = false;

                                    // Any events today or later?
                                    // https://stackoverflow.com/questions/13467230/how-to-set-time-to-midnight-for-current-day
                                    DateTime dttoday = DateTime.UtcNow.Date;    // Using date should set to midnight?
                                    // https://stackoverflow.com/questions/5955883/datetimes-representation-in-milliseconds
                                    Int64 today = (long)dttoday.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                                    string todaystr = today.ToString();             // This is a 13 digit number
                                    todaystr = today.ToString().PadRight(16, '0');  // Dates are 16 digit numbers in cal_events

                                    DataTable dt = DB.ExecuteQuery("select * from cal_events where event_start > '" + todaystr + "' order by event_start");
                                    if (dt != null)
                                        events_exist = true;

                                    // https://stackoverflow.com/questions/955611/xmlwriter-to-write-to-a-string-instead-of-to-a-file
                                    // https://stackoverflow.com/questions/955611/xmlwriter-to-write-to-a-string-instead-of-to-a-file/955698#955698
                                    using (var sw = new Utf8StringWriter())
                                    {
                                        // https://stackoverflow.com/questions/18100672/xmlwriter-writestartdocument-is-not-outputting-the-declaration-to-the-file
                                        XmlWriterSettings xwsSettings = new XmlWriterSettings();
                                        xwsSettings.CheckCharacters = false;
                                        xwsSettings.CloseOutput = true;
                                        xwsSettings.ConformanceLevel = ConformanceLevel.Document;
                                        xwsSettings.Encoding = Encoding.UTF8;
                                        xwsSettings.Indent = false;
                                        xwsSettings.NewLineHandling = NewLineHandling.None;
                                        xwsSettings.OmitXmlDeclaration = false;

                                        using (var writer = XmlWriter.Create(sw, xwsSettings))
                                        {
                                            writer.WriteStartDocument(true);
                                            writer.WriteStartElement("calendar");
                                            if (events_exist)
                                            {
                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    string title = dr["title"].ToString();
                                                    string es = dr["event_start"].ToString();
                                                    string id = dr["id"].ToString();

                                                    // https://stackoverflow.com/questions/3219160/do-you-recognize-a-16-digit-timestamp
                                                    Int64 timestamp = Int64.Parse(es);
                                                    timestamp = timestamp / 1000;   // 16 digit number needs to be reduced to a 13 one
                                                    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                                    // https://stackoverflow.com/questions/179940/convert-utc-gmt-time-to-local-time/455965
                                                    DateTime event_start = epoch.AddMilliseconds(timestamp).ToLocalTime();

                                                    string location = "unknown";
                                                    string category = "unknown";
                                                    DataTable dtp = DB.ExecuteQuery("select * from cal_properties where item_id='" + id + "'");
                                                    if (dtp != null)
                                                    {
                                                        foreach (DataRow drp in dtp.Rows)
                                                        {
                                                            string key = drp["key"].ToString();
                                                            //string val = drp["value"].ToString();
                                                            // https://stackoverflow.com/questions/285010/how-do-you-read-a-byte-array-from-a-datarow-in-c
                                                            byte[] val = (byte[])drp["value"];
                                                            // https://community.esri.com/thread/113614
                                                            string valstr = System.Text.Encoding.UTF8.GetString(val);
                                                            //Log("  " + key + "=" + valstr);
                                                            if (key == "CATEGORIES")
                                                                category = valstr;
                                                            if (key == "LOCATION")
                                                                location = valstr;
                                                        }
                                                    }
                                                    writer.WriteStartElement("event");
                                                    writer.WriteElementString("category", category);
                                                    writer.WriteElementString("title", title);
                                                    writer.WriteElementString("location", location);
                                                    writer.WriteElementString("start", event_start.ToString("yyyy-MM-ddTHH:mm:ss"));
                                                    writer.WriteEndElement();
                                                }
                                            }
                                            writer.WriteEndElement();
                                            writer.WriteEndDocument();
                                            writer.Close();
                                        }

                                        // Testing...
                                        //File.WriteAllText(@"C:\Temp\calendar.xml", sw.ToString());

                                        byte[] buf = Encoding.UTF8.GetBytes(sw.ToString());
                                        ctx.Response.ContentLength64 = buf.Length;
                                        ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                                    }
                                }
                            }

                            catch (WebException webex)
                            {
                                Console.Write(webex.Message);
                                string webexerr = "Exception Message :" + webex.Message;
                                if (webex.Status == WebExceptionStatus.ProtocolError)
                                {
                                    webexerr += ", Status Code: " + ((HttpWebResponse)webex.Response).StatusCode;
                                    webexerr += ", Status Description: " + ((HttpWebResponse)webex.Response).StatusDescription;
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.Write("A problem occurred:" + ex.Message);
                            }
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }


    }
}

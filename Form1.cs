using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBC_Package;

namespace TBC
{
    public partial class Form1 : Form
    {

        WebServer ws;
        bool wsstarted = false;

        public static string calendar = "d407c314-526d-41d9-bcd1-27b77c2ae82b";     // Shouldn't be hard-wired of course, and should not assume only one calendar

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            DB.db = @"C:\Users\dan.connectdev-pc2\AppData\Roaming\Thunderbird\Profiles\a9rlbood.default\calendar-data\local.sqlite";
            PopulateComboboxes();
        }

        private void PopulateComboboxes()
        {
            cbduration.Items.Clear();
            cbduration.Items.Add("15");
            cbduration.Items.Add("30");
            cbduration.Items.Add("45");
            cbduration.Items.Add("60");
            cbduration.Items.Add("90");
            cbduration.Items.Add("120");
            cbduration.Items.Add("240");
            cbduration.Items.Add("480");

            cbcategory.Items.Clear();
            cbcategory.Items.Add("Cecilia");
            cbcategory.Items.Add("Dan");
            cbcategory.Items.Add("Holidays");
            cbcategory.Items.Add("Mamma");
            cbcategory.Items.Add("Miscellaneous");
            cbcategory.Items.Add("Personal");
            cbcategory.Items.Add("Public Holiday");
        }

        public void Log(string s)
        {
            tblog.AppendText(s + Environment.NewLine);
        }
        private void btest_Click(object sender, EventArgs e)
        {

            // https://stackoverflow.com/questions/13467230/how-to-set-time-to-midnight-for-current-day
            DateTime dttoday = DateTime.Today;
            //Int64 today = (long)(dttoday - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            // https://stackoverflow.com/questions/5955883/datetimes-representation-in-milliseconds
            Int64 today = (long)dttoday.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            //string todaystr = today.ToString().PadRight(16, '0');
            string todaystr = today.ToString();
            //today = Int64.Parse(todaystr);      // Add the padded zeroes back to the int64
            Log("Today is " + todaystr);
            Log("");

            long between = 0;
            long hrs = 0;

            Int64 today1230 = 1570707000000;
            Int64 tomorrow1230 = 1570793400000;
            between = (tomorrow1230 - today);
            hrs = (long)between / (1000 * 60 * 60);

            //DataTable dt = DB.ExecuteQuery("select title,event_start, cal_id from cal_events");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT e.cal_id, e.title, e.event_start, e.event_end, r.icalString, e.id, e.flags, e.event_start_tz, e.event_end_tz, e.recurrence_id, e.event_stamp");
            sql.Append(" FROM cal_events e");
            sql.Append(" LEFT OUTER JOIN cal_recurrence r ON(e.id= r.item_id AND e.cal_id= r.cal_id AND e.recurrence_id IS NULL)");
            sql.Append(" ORDER BY e.id, e.recurrence_id, e.title; ");
            DataTable dt = DB.ExecuteQuery(sql.ToString());
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string title = dr["title"].ToString();
                    string es = dr["event_start"].ToString();
                    string id = dr["id"].ToString();

                    // https://stackoverflow.com/questions/3219160/do-you-recognize-a-16-digit-timestamp
                    Int64 timestamp = Int64.Parse(es);
                    timestamp = timestamp / 1000;
                    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                    //DateTime event_start = epoch.AddMilliseconds(timestamp / 1000);
                    DateTime event_start = epoch.AddMilliseconds(timestamp);

                    es = es.Substring(0, 13);   // Level playing field, use 13 digit 'numbers'
                    //Log(title + " " + event_start.ToString());

                    if (title == "Op")
                    {
                        between = (timestamp - today);
                        hrs = (long)between / (1000 * 60 * 60);
                    }

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
                    Log(title + " " + event_start.ToString() + ", category=" + category + ", location=" + location + "   hrs = " + hrs.ToString() + " (" + between.ToString() + ")");
                }



            }
        }

        private void bstart_Click(object sender, EventArgs e)
        {
            if (!wsstarted)
            {
                ws = new WebServer();
                ws.Run();
                wsstarted = true;
                bstart.Text = "Stop";
            }
            else
            {
                ws.Stop();
                wsstarted = false;
                bstart.Text = "Start";
            }
        }

        private void bsave_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.8
            // https://docs.microsoft.com/en-us/dotnet/api/system.guid.newguid?redirectedfrom=MSDN&view=netframework-4.8#System_Guid_NewGuid

            DateTime localtime;
            string dtstr = dtpstartdate.Value.ToString();
            Log(dtstr);
            localtime = DateTime.Parse(dtstr);
            Log(localtime.ToString());


            Int64 dtutc = (long)localtime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            Log(dtutc.ToString());
            

        }

        private void Form1_Load(object sender, EventArgs e)
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

            if (events_exist)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string title = dr["title"].ToString();
                    string es = dr["event_start"].ToString();
                    string ee = dr["event_end"].ToString();
                    string id = dr["id"].ToString();
                    DateTime event_start = DB.utc2dt(es);
                    DateTime event_end = DB.utc2dt(ee);

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

                    ListViewItem li = new ListViewItem(title);
                    li.SubItems.Add(event_start.ToString());
                    li.SubItems.Add(event_end.ToString());
                    li.SubItems.Add(category);
                    li.SubItems.Add(location);
                    li.SubItems.Add(id);
                    lvevents.Items.Add(li);
                }
            }
        }

        private void lvevents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem li = lvevents.SelectedItems[0];

            tbtitle.Text = li.SubItems[0].Text;
            tbid.Text = li.SubItems[5].Text;
            tblocation.Text = li.SubItems[4].Text;
            cbcategory.SelectedIndex = cbcategory.FindString(li.SubItems[3].Text);

            DateTime startdt = DateTime.Parse(li.SubItems[1].Text);
            DateTime enddt = DateTime.Parse(li.SubItems[2].Text);
            // https://stackoverflow.com/questions/4946316/showing-difference-between-two-datetime-values-in-hours
            var mins = (enddt - startdt).TotalMinutes;
            cbduration.SelectedIndex = cbduration.FindString(mins.ToString());

            Log("start=" + startdt.ToString());
            Log("end=" + enddt.ToString());
            Log("mins=" + mins.ToString());
        }
    }
}

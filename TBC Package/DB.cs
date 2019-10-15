using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace TBC_Package
{
    public static class DB
    {
        public static string db = "";

        public static DateTime utc2dt(string utc)
        {
            DateTime dt = DateTime.Now;

            Int64 timestamp = Int64.Parse(utc);
            timestamp = timestamp / 1000;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            dt = epoch.AddMilliseconds(timestamp);

            return dt;
        }

        public static DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + db))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        FillDatatable(cmd, dt);
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }                
            return dt;
        }

        private static void FillDatatable(SQLiteCommand command, DataTable dt)
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                var len = reader.FieldCount;

                // Create the DataTable columns
                for (int i = 0; i < len; i++)
                    dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));

                dt.BeginLoadData();

                var values = new object[len];

                // Add data rows
                while (reader.Read())
                {
                    for (int i = 0; i < len; i++)
                        values[i] = reader[i];

                    dt.Rows.Add(values);
                }

                dt.EndLoadData();

                reader.Close();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCalendar.Utils {
    class MonthLife {
        Sqlite s = null;
        static String tableName = "month_life";
        String sql = String.Format(@"create table if not exists {0}(
month datetime,
before varchar(10)
);
select * from {0};", TableName);
        System.Data.DataTable tb = null;

        public static string TableName { get => tableName; set => tableName = value; }
        public DataTable Tb { get => tb; set => tb = value; }

        public MonthLife(Sqlite s) {
            this.s = s;
            Tb = s.ExcuteQuery(sql);
        }

        public void Set(DateTime dt, bool before) {
            SharpLearn.Program.ShowTable(tb);
            tb.Rows.Clear();
            DataRow dr = tb.NewRow();
            dr[0] = new DateTime(dt.Year, dt.Month, 1);
            dr[1] = before ? "F" : "T";
            tb.Rows.Add(dr);
            s.SaveTable(tb, TableName);
        }

        public void Reset() {
            String resetSql = String.Format(@"delete from {0}", TableName);
            s.ExcuteNonQuery(resetSql);
        }

        public void Delete(DateTime dt) {
            String resetSql = String.Format(@"delete from {0} where month = {1}"
, TableName, new DateTime(dt.Year, dt.Month, 1).ToString().Quote());
            s.ExcuteNonQuery(resetSql);
        }

        public DataTable GetData() {
            String qrySql = String.Format(@"select * from {0} order by date(month) asc", TableName);
            return s.ExcuteQuery(qrySql);
        }

        public DateTime GetFirstData() {
            String qrySql = String.Format(@"select month from {0} order by date(month) asc LIMIT 0,1", TableName);
            return Convert.ToDateTime(s.ExcuteQuery(qrySql).Rows[0][0]);
        }
    }
}

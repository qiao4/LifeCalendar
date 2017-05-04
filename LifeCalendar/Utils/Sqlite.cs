using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace LifeCalendar.Utils {
    class Sqlite {
        string datasource = "db.db";
        bool isOpen = false;
        SQLiteConnection connection = null;
        bool disposed = false;

        public string Datasource { get => datasource; set => datasource = value; }
        public SQLiteConnection Connection { get => connection; set => connection = value; }

        public Sqlite() {
            init("");
        }

        public void init(string datasource) {
            if (datasource != "") {
                this.Datasource = datasource;
            }
            this.Connection = new SQLiteConnection("data source = " + this.Datasource + ";datetimeformat = CurrentCulture");
            this.isOpen = false;
        }

        private bool checkDbExist() {
            if (System.IO.File.Exists(Datasource))
                return true;
            else {
                System.IO.File.Create(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.datasource));
                if (System.IO.File.Exists(Datasource)) {
                    return true;
                }
            }
            return false;
        }

        public void open() {
            if (!checkDbExist()) {
                if (connection != null) {
                    SQLiteConnection.CreateFile(datasource);
                    if (!checkDbExist()) {
                        throw new Exception("file not found");
                    }
                }
            }

            if (!isOpen)
                Connection.Open();

            this.isOpen = true;
        }

        public int ExcuteNonQuery(String queryStr) {
            this.open();
            SQLiteCommand command = new SQLiteCommand(this.Connection);
            command.CommandText = queryStr;
            int rowNum = command.ExecuteNonQuery();
            //connection.Dispose();
            return rowNum;
        }

        public DataTable ExcuteQuery(String queryStr) {
            this.open();
            SQLiteCommand command = new SQLiteCommand(this.Connection);
            command.CommandText = queryStr;
            DataSet ds = new DataSet();
            DataTable tb = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(tb);
            //if(ds.Tables.Count > 0) {
            //   return ds.Tables[0];
            //}
            return tb;
            return null;
        }

        public bool SaveTable(DataTable tb, String serverTableName) {
            String sql = "insert into " + serverTableName;
            sql += "(";
            foreach(DataColumn col in tb.Columns) {
                sql += col.ColumnName + ",";
            }
            sql = sql.Remove(sql.Length-1, 1);
            sql += ")";

            sql += " values";
            //sql += "(";
            foreach (DataRow row in tb.Rows) {
                sql += "(";
                foreach (DataColumn col in tb.Columns) {
                    if(col.DataType.ToString().Equals("System.Double")
                        || col.DataType.ToString().Equals("System.Int32")) {
                        sql += row[col.ColumnName].ToString() + ",";
                    } else {
                        sql += row[col.ColumnName].ToString().Quote() + ",";
                    }
                }
                sql = sql.Remove(sql.Length - 1, 1);
                sql += ")";
            }
            sql.Remove(sql.Length - 1, 1);
            //sql += ")";

            return ExcuteNonQuery(sql) > 0;
        }

        public DataTable SelectTable(String serverTableName) {
            //TODO
            return null;
        }
    }
}


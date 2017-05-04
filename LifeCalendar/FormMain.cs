using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifeCalendar.Utils;

namespace LifeCalendar {
    public partial class FormMain : Form {
        Program p = null;
        public FormMain(Program p) {
            InitializeComponent();
            this.p = p;
        }

        private void button1_Click(object sender, EventArgs e) {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            m.Reset();
            panel1.Controls.Clear();
            AddItem();
            SetPrecent();
        }

        private void btnInit_Click(object sender, EventArgs e) {
            var form = new FormInit();
            if(form.ShowDialog() == DialogResult.OK) {
                panel1.Controls.Clear();
                AddItem();
                SetPrecent();
            }
        }

        public void AddItem() {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var data = m.GetData();
            DateTime initDate = DateTime.Now.AddYears(-20);
            initDate = new DateTime(initDate.Year, initDate.Month, 1);
            if (data.Rows.Count > 0) {
                initDate = Convert.ToDateTime(data.Rows[0]["month"]);
            }
            for(int i = 0; i < 60; i++) {
                for (int j = 0; j < 24; j++) {
                    //if (i == 0 && j == 0) {
                    //    j = initDate.Month - 1;
                    //}
                    var c = new Utils.MonthTime();
                    c.Width = panel1.Width / 25;
                    c.Height = panel1.Width / 30;
                    c.Time = initDate.AddMonths(i * 24 + j);
                    c.Before = false;
                    DataRow[] drs = data.Select("month = " + c.Time.ToString().Quote());
                    if (drs.Length > 0) {
                        c.Before = drs[0]["before"].ToString() == "T";
                    }
                    c.Location = new Point(c.Width * j, c.Height * i);
                    panel1.Controls.Add(c);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            SetPrecent();
            AddItem();
        }

        private void quickSet_Click(object sender, EventArgs e) {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var data = m.GetData();
            var curMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime initDate = DateTime.Now.AddYears(-20);
            initDate = new DateTime(initDate.Year, initDate.Month, 1);
            if (data.Rows.Count > 0) {
                initDate = Convert.ToDateTime(data.Rows[0]["month"]);
            }
            while(initDate <= curMonth.AddMonths(-1)) {
                m.Delete(initDate);
                m.Set(initDate, false);
                initDate = initDate.AddMonths(1);
            }

            panel1.Controls.Clear();
            AddItem();
        }

        void SetPrecent() {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var curMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            precent.Text = String.Format("{0:P2}"
                , (-m.GetFirstData().Subtract(curMonth).TotalDays) / (365.2422 * 80));
        }
    }
}

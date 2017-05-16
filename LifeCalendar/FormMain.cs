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
        class CellData {
            public DateTime dt;
            public bool before;

            public CellData(DateTime dt, bool before) {
                this.dt = dt;
                this.before = before;
            }

            public override string ToString() {
                return dt.ToString("yy/M");
            }
        }
        Program p = null;
        public FormMain(Program p) {
            InitializeComponent();
            this.p = p;
        }

        private void button1_Click(object sender, EventArgs e) {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            m.Reset();

            AddItem();
            SetPrecent();
        }

        private void btnInit_Click(object sender, EventArgs e) {
            var form = new FormInit();
            if (form.ShowDialog() == DialogResult.OK) {

                AddItem();
                SetPrecent();
            }
        }
        
        public void AddItem() {
            dbg_calendar.Rows.Clear();
            dbg_calendar.Rows[0].Height = 42;
            dbg_calendar.Rows.Add(39);
            int width = dbg_calendar.Width / 25;
            foreach (DataGridViewColumn col in dbg_calendar.Columns) {
                col.Width = width;
            }
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var data = m.GetData();
            DateTime initDate = DateTime.Now.AddYears(-20);
            initDate = new DateTime(initDate.Year, initDate.Month, 1);
            if (data.Rows.Count > 0) {
                initDate = Convert.ToDateTime(data.Rows[0]["month"]);
            }
            int i = 0;
            foreach (DataGridViewRow row in dbg_calendar.Rows) {
                row.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 44;
                foreach (DataGridViewCell cell in row.Cells) {
                    CellData value = new CellData(initDate.AddMonths(i++), false);
                    DataRow[] drs = data.Select("month = " + value.dt.ToString("yyyy-MM-dd").Quote());
                    if (drs.Length > 0) {
                        value.before = drs[0]["before"].ToString() == "T";
                    }
                    cell.Value = value;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            SetPrecent();
            dbg_calendar.Rows.Add(39);
            int width = dbg_calendar.Width / 25;
            foreach (DataGridViewColumn col in dbg_calendar.Columns) {
                col.Width = width;
            }
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var data = m.GetData();
            DateTime initDate = DateTime.Now.AddYears(-20);
            initDate = new DateTime(initDate.Year, initDate.Month, 1);
            if (data.Rows.Count > 0) {
                initDate = Convert.ToDateTime(data.Rows[0]["month"]);
            }
            int i = 0;
            foreach (DataGridViewRow row in dbg_calendar.Rows) {
                //https://stackoverflow.com/questions/12816860/get-screen-size-in-pixels-in-windows-form-in-c-sharp
                row.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 44;
                foreach (DataGridViewCell cell in row.Cells) {
                    CellData value = new CellData(initDate.AddMonths(i++), false);
                    DataRow[] drs = data.Select("month = " + value.dt.ToString("yyyy-MM-dd").Quote());
                    if (drs.Length > 0) {
                        value.before = drs[0]["before"].ToString() == "T";
                    }
                    cell.Value = value;
                }
            }
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
            while (initDate <= curMonth.AddMonths(-1)) {
                m.Delete(initDate);
                m.Set(initDate, false);
                initDate = initDate.AddMonths(1);
            }

            AddItem();
        }

        void SetPrecent() {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            var curMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            precent.Text = String.Format("{0:P2}"
                , (-m.GetFirstData().Subtract(curMonth).TotalDays) / (365.2422 * 80));
        }

        private void dbg_calendar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
            if (e.Value != null) {
                if ((e.Value as CellData).before) {
                    e.CellStyle.BackColor = Color.Red;
                }
                else {
                    e.CellStyle.BackColor = Color.Green;
                }
            }

        }

        private void dbg_calendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            var c = dbg_calendar.Rows[e.RowIndex].Cells[e.ColumnIndex];
            CellData data = c.Value as CellData;
            MonthLife m = new MonthLife(new Sqlite());
            m.Delete(data.dt);
            m.Set(data.dt, data.before);
            data.before = !data.before;
        }


        /// <summary>
        /// test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="https://stackoverflow.com/questions/1745272/disable-cell-highlighting-in-a-datagridview"/>
        private void dbg_calendar_SelectionChanged(object sender, EventArgs e) {
            dbg_calendar.ClearSelection();
        }
    }
}

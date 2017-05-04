using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCalendar.Utils {
    public partial class MonthTime : UserControl {
        DateTime time;
        bool before;
        public MonthTime() {
            InitializeComponent();
            this.Time = DateTime.Now.AddMonths(-1);
            this.Before = this.Time.CompareTo(DateTime.Now.AddDays(-DateTime.Now.Day)) < 0;
        }
        public MonthTime(DateTime time) {
            InitializeComponent();
            this.Time = time;
            this.Before = time.CompareTo(DateTime.Now.AddDays(-DateTime.Now.Day)) < 0;
        }
        public MonthTime(DateTime time, bool before) {
            InitializeComponent();
            this.Time = time;
            this.Before = before;
        }

        public DateTime Time {
            get {
                return time;
            }
            set {
                time = value;
                label.Text = value.ToString("yy/M");
            }
        }
        public bool Before {
            get {
                return before;
            }
            set {
                before = value;
                label.BackColor = value ? Color.Red : Color.Green;
            }
        }

        private void label_MouseDoubleClick(object sender, MouseEventArgs e) {
            MonthLife m = new MonthLife(new Sqlite());
            m.Delete(time);
            m.Set(time, before);
            Before = !Before;
        }
    }
}

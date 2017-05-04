using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCalendar {
    public partial class FormInit : Form {
        public FormInit() {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            var m = new Utils.MonthLife(new Utils.Sqlite());
            MessageBox.Show(bornDate.SelectionStart.ToString());
            m.Delete(bornDate.SelectionStart);
            m.Set(bornDate.SelectionStart, false);
            DialogResult = DialogResult.OK;
        }
    }
}

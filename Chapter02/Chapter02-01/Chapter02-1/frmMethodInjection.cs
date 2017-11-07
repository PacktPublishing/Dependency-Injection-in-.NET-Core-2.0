using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chapter02_1
{
    public partial class frmMethodInjection : Form
    {
        public frmMethodInjection()
        {
            InitializeComponent();
            this.FormClosing += frmMethodInjection_FormClosing;
            FormClosingExtended += FrmMethodInjection_FormClosingExtended;
        }

        private void FrmMethodInjection_FormClosingExtended(object sender, string e)
        {
            var ans = MessageBox.Show($"Save Closing time: ({e})?", "Notice",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                File.WriteAllText("ClosingTime.txt", e);
            }
        }
        private void Audit(string time)
        {
            var ans = MessageBox.Show($"Save Closing time: ({time})?", "Notice",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                File.WriteAllText("ClosingTime.txt", time);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMethodInjection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var res = MessageBox.Show("Confirm application exit?", "Notice",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    //FormClosingExtended?.Invoke(this, DateTime.Now.ToLongTimeString());
                    Audit(DateTime.Now.ToLongTimeString());
                else e.Cancel = true;
            }

        }
        public event EventHandler<string> FormClosingExtended;
    }
}

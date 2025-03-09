using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_certificate
{
    public partial class UpdateNameCetificate : Form
    {
        public string NewName { get; set; }
        public UpdateNameCetificate()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // This is CRUCIAL  
            Close();
        }

        private void btn_Update_Name_submit_Click(object sender, EventArgs e)
        {
            NewName = _Update_Name.Text;
            DialogResult = DialogResult.OK; // This is CRUCIAL  
            Close();
        }
    }
}

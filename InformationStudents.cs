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
    public partial class InformationStudents : UserControl
    {
        public InformationStudents()
        {
            InitializeComponent();
        }

        private void btn_DoDegree_Click(object sender, EventArgs e)
        {
            DoDegree doDegree = new DoDegree();
            doDegree.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            login loginForm = new login(); // Create a new instance each time.
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                // If login fails, close the application
                this.Close();
            }
            // Otherwise, proceed with loading the main form
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            // Handle click event if needed.
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
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
        //private Course course;
        //private Students students;

        public MainForm()
        {
            InitializeComponent();
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            login loginForm = new login();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
            //Otherwise, proceed with loading the main form
            ShowHomePage(); //Show homepage after login.
        }

        private void ShowPage(UserControl page)
        {
            panel_Desplay_Page.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel_Desplay_Page.Controls.Add(page);
        }

        private void ShowHomePage()
        {
            HomePage homePage = new HomePage();
            ShowPage(homePage);
        }

        private void ShowClassPage()
        {
            FormStudents studentsPage = new FormStudents();
            ShowPage(studentsPage);
        }

        private void ShowCoursePage()
        {
            EnrollStudents coursePage = new EnrollStudents();
            ShowPage(coursePage);
        }

        private void ShowInformationPage()
        {
            InformationStudents informationStudentsPage = new InformationStudents();
            ShowPage(informationStudentsPage);
        }

        private void btn_HomePage_Click(object sender, EventArgs e)
        {
            ShowHomePage();
        }

        private void btn_class_Click(object sender, EventArgs e)
        {
            ShowClassPage();
        }

        private void btn_Cousre_Click(object sender, EventArgs e)
        {
            ShowCoursePage();
        }

        private void btn_Close_Main_Form_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_information_student_Click(object sender, EventArgs e)
        {
            ShowInformationPage();
        }
    }
}
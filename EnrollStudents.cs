using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_certificate
{
    public partial class EnrollStudents : UserControl
    {
        // Get connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public EnrollStudents()
        {
            InitializeComponent();
        }

        private void btn_exit_fstudent_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_add_student_Click(object sender, EventArgs e)
        {
            string FirstName = txt_fname.Text;
            string LastName = txt_lname.Text;
            string Major = txt_major.Text;
            string CourseName = com_course.Text;
            string CourseDuration = course_duration.Text;
            // Ensure all required fields are filled
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Major) ||
                string.IsNullOrWhiteSpace(CourseName) ||
                string.IsNullOrWhiteSpace(CourseDuration))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL Insert Query - Now targets the correct table and column names
            string query = "INSERT INTO StudentsCourses (FirstName, LastName, Major, CourseName, CourseDuration) " +
                           "VALUES (@FirstName, @LastName, @Major, @CourseName, @CourseDuration)";

            // Establish SQL connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@Major", Major);
                        cmd.Parameters.AddWithValue("@CourseName", CourseName);
                        cmd.Parameters.AddWithValue("@CourseDuration", CourseDuration);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to enroll student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearFields()
        {
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_major.Text = "";
            com_course.SelectedIndex = -1; // Clears ComboBox selection
            course_duration.Text = "";
            txt_fname.Focus(); // Set focus back to the first field
        }

        private void txt_fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void com_course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

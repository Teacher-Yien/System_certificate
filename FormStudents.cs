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
    public partial class FormStudents : UserControl
    {
        // Get connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public FormStudents()
        {
            InitializeComponent();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Score_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_add_students_score_Click(object sender, EventArgs e)
        {
            string idText = _search_std_by_id.Text;

            if (string.IsNullOrWhiteSpace(idText) || !int.TryParse(idText, out int studentId))
            {
                MessageBox.Show("Please enter a valid student ID.");
                return;
            }

            // Fetch student details from the database  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FirstName, LastName, SubjectName, Score FROM dbo.StudentsCourses INNER JOIN dbo.StudentScores ON dbo.StudentsCourses.Id = dbo.StudentScores.StudentId WHERE dbo.StudentsCourses.Id = @StudentId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming you have fields to display the fetched data  
                                _fname.Text = reader["FirstName"].ToString();
                                _lname.Text = reader["LastName"].ToString();
                                _SubjectName.Text = reader["SubjectName"].ToString();
                                _score.Text = reader["Score"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Student not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void _search_std_by_id_TextChanged(object sender, EventArgs e)
        {
            string idText = _search_std_by_id.Text;

            // Check if the input is empty or not a valid integer  
            if (string.IsNullOrWhiteSpace(idText) || !int.TryParse(idText, out int studentId))
            {
                // Optionally, clear the fields if input invalid  
                ClearStudentFields();
                return;
            }

            // Fetch student details from the database  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT FirstName, LastName, SubjectName, Major,CourseDuration FROM dbo.StudentsCourses INNER JOIN dbo.StudentScores ON dbo.StudentsCourses.Id = dbo.StudentScores.StudentId WHERE dbo.StudentsCourses.Id = @StudentId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate fields with student data  
                                _fname.Text = reader["FirstName"].ToString();
                                _lname.Text = reader["LastName"].ToString();
                                _SubjectName.Text = reader["SubjectName"].ToString();
                                _score.Text = reader["Score"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Student not found.");
                                ClearStudentFields(); // Clear fields if not found  
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
        private void ClearStudentFields()
        {
            _fname.Clear();
            _lname.Clear();
            _SubjectName.Clear();
            _score.Clear();
        }
    }
}

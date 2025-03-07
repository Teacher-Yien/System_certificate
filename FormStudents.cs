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
            string subject = _SubjectName.Text;
            string scoreText = _score.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(idText) || !int.TryParse(idText, out int studentId))
            {
                MessageBox.Show("Please enter a valid student ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show("Please enter a subject name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(scoreText) || !int.TryParse(scoreText, out int score))
            {
                MessageBox.Show("Please enter a valid numeric score.");
                return;
            }

            // Database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 🔸 Check if the student already has a score in StudentScores
                    string checkQuery = "SELECT COUNT(*) FROM dbo.StudentScores WHERE StudentId = @StudentId AND SubjectName = @SubjectName;";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@StudentId", studentId);
                        checkCommand.Parameters.AddWithValue("@SubjectName", subject);

                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Student already has a score for this subject. Insertion not allowed.");
                            return;
                        }
                    }

                    // 🔹 Insert new score
                    string insertQuery = "INSERT INTO dbo.StudentScores (StudentId, SubjectName, Score) VALUES (@StudentId, @SubjectName, @Score);";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@StudentId", studentId);
                        insertCommand.Parameters.AddWithValue("@SubjectName", subject);
                        insertCommand.Parameters.AddWithValue("@Score", score);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Score inserted successfully!");
                            ClearStudentFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert score.");
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

            // Validate input
            if (string.IsNullOrWhiteSpace(idText) || !int.TryParse(idText, out int studentId))
            {
                ClearStudentFields();
                return;
            }

            // Fetch student details from StudentsCourses only
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT FirstName, LastName, Major, CourseName, CourseDuration " +
                                   "FROM dbo.StudentsCourses WHERE Id = @StudentId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _fname.Text = reader["FirstName"].ToString();
                                _lname.Text = reader["LastName"].ToString();
                                _SubjectName.Text = reader["CourseName"].ToString();
                                _major.Text = reader["Major"].ToString();
                                _Course_Duration.Text = reader["CourseDuration"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Student not found.");
                                ClearStudentFields();
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
        // Clear all input fields
        private void ClearStudentFields()
        {
            _search_std_by_id.Clear();
            _fname.Clear();
            _lname.Clear();
            _SubjectName.Clear();
            _score.Clear();
            _major.Clear();
            _Course_Duration.Clear();
        }
       


        private void Select_Course_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = Select_Course_Name.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCourse))
            {
                MessageBox.Show("You selected: " + selectedCourse);
            }
        }
    }
}

using Guna.UI2.WinForms;
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
using System_certificate.Models;

namespace System_certificate
{
    public partial class InformationStudents : UserControl
    {
        // Get connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public int courseID; // Declare it without initializing
        public InformationStudents()
        {
            InitializeComponent();
            table_select_create_certificate.SelectionChanged += Table_select_create_certificate_SelectionChanged;
        }
        private void Table_select_create_certificate_SelectionChanged(object sender, EventArgs e)
        {
            if (table_select_create_certificate.SelectedRows.Count > 0) // Ensure a row is selected
            {
                object cellValue = table_select_create_certificate.SelectedRows[0].Cells[0].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    courseID = id; // Store selected ID
                    
                }
                else
                {
                    MessageBox.Show("Invalid Course ID selected.");
                }
            }
        }

        private void btn_DoDegree_Click(object sender, EventArgs e)
        {
            if (table_select_create_certificate.SelectedRows.Count > 0)
            {
                // Get the selected student's name (assuming column 1 is the student's name)  
                string studentName = table_select_create_certificate.SelectedRows[0].Cells[1].Value.ToString();

                // Get the CourseID from the selected row (assuming it is in column 0)  
                // **IMPORTANT**: Adjust column index (0) if the CourseID is in a different column  
                int courseID = Convert.ToInt32(table_select_create_certificate.SelectedRows[0].Cells[0].Value);  // Assuming CourseID is in column 0  

                // Define the certificate name and issue date  
                string certificateName = table_select_create_certificate.SelectedRows[0].Cells[3].Value.ToString();
                DateTime issueDate = DateTime.Now; // Use current date and time  

                

                // SQL INSERT statement (without StudentID)  
                string insertQuery = "INSERT INTO Certificates (CourseID, CertificateName, IssueDate) " +
                                     "VALUES (@CourseID, @CertificateName, @IssueDate)";

                // Execute the SQL INSERT statement  
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Add parameters to prevent SQL injection  
                            command.Parameters.AddWithValue("@CourseID", courseID);
                            command.Parameters.AddWithValue("@CertificateName", certificateName);
                            command.Parameters.AddWithValue("@IssueDate", issueDate);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Certificate data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Certificate data insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting certificate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Open DoDegree Form and set the name  
                // In InformationStudents.cs - btn_DoDegree_Click method
                DoDegree doDegree = new DoDegree();
                doDegree.SetNameToPrint(studentName);
                doDegree.SetCertificateId(courseID); // Pass the ID
                doDegree.Show();
            }
            else
            {
                MessageBox.Show("Please select a student.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InformationStudents_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct your SQL query (adjust based on your table structures and desired join)  
                    string query = @"  
                    SELECT  
                        sc.Id,  
                        sc.Major,
                        (sc.FirstName + ' ' + sc.LastName) AS FullName,  -- Combine FirstName and LastName  
                        ss.SubjectName,  
                        ss.Score,  
                        ss.Status  
                    FROM  
                        StudentsCourses sc  
                    INNER JOIN  
                        StudentScores ss ON sc.Id = ss.StudentId;  
                    ";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            

                            // Read data and add rows manually
                            while (reader.Read())
                            {
                                table_select_create_certificate.Rows.Add(
                                    reader["Id"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Major"].ToString(),
                                    reader["SubjectName"].ToString(),
                                    reader["Score"].ToString(),
                                    reader["Status"].ToString()
                                );
                            }

                            // Adjust column width for better display
                            table_select_create_certificate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_exit_table_certificate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_delete_students_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (table_select_create_certificate.SelectedRows.Count > 0)
                {
                    // Get selected row
                    DataGridViewRow selectedRow = table_select_create_certificate.SelectedRows[0];

                    // Get Student ID (assuming ID is in the first column)
                    string studentId = selectedRow.Cells[0].Value.ToString();

                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this student?",
                                                          "Confirm Deletion",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete query
                            string query = "DELETE FROM StudentsCourses WHERE Id = @StudentId";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@StudentId", studentId);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Remove the row from DataGridView
                                    table_select_create_certificate.Rows.Remove(selectedRow);
                                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Search_Student_Name_and_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = Search_Student_Name_and_id.Text.Trim();

                table_select_create_certificate.Rows.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Corrected SQL Query  
                    string query = @"  
            SELECT  
                sc.Id,  
                sc.Major,  
                (sc.FirstName + ' ' + sc.LastName) AS FullName,  
                ss.SubjectName,  
                ss.Score,  
                ss.Status  
            FROM  
                StudentsCourses sc  
            INNER JOIN  
                StudentScores ss ON sc.Id = ss.StudentId  
            WHERE  
                CAST(sc.Id AS NVARCHAR) LIKE @SearchText OR  
                (sc.FirstName + ' ' + sc.LastName) COLLATE Khmer_100_CI_AS LIKE @SearchText COLLATE Khmer_100_CI_AS  
            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Correct Parameter Usage:  No 'N' prefix here!  
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                table_select_create_certificate.Rows.Add(
                                    reader["Id"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Major"].ToString(),
                                    reader["SubjectName"].ToString(),
                                    reader["Score"].ToString(),
                                    reader["Status"].ToString()
                                );
                            }
                        }
                    }
                }

                // Adjust column width *after* loading data  
                table_select_create_certificate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_update_name_major_subject_score_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Get the Selected Row and Data  
                if (table_select_create_certificate.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit if no row is selected  
                }

                DataGridViewRow selectedRow = table_select_create_certificate.SelectedRows[0];
                string studentId = selectedRow.Cells[0].Value.ToString(); // Assuming ID is in the first column  

                // Get the values directly from the DataGridView cells  
                string fullName = selectedRow.Cells[1].Value.ToString(); // Assuming FullName is in the second column  
                string newMajor = selectedRow.Cells[2].Value.ToString();   // Assuming Major is in the third column  
                string newSubjectName = selectedRow.Cells[3].Value.ToString(); // Assuming SubjectName is in the fourth column  
                string newScore = selectedRow.Cells[4].Value.ToString();   // Assuming Score is in the fifth column  

                // Split the FullName into FirstName and LastName (if needed)  
                string[] nameParts = fullName.Split(' ');
                string newFirstName = nameParts.Length > 0 ? nameParts[0] : "";
                string newLastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : ""; // Handles multiple last names  


                // 2. Validate Data (Important!)  
                if (string.IsNullOrEmpty(newFirstName) || string.IsNullOrEmpty(newLastName) ||
                    string.IsNullOrEmpty(newMajor) || string.IsNullOrEmpty(newSubjectName) ||
                    string.IsNullOrEmpty(newScore))
                {
                    MessageBox.Show("Please ensure all fields in the selected row are filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit if validation fails  
                }

                // Optionally, validate the score to ensure it's a valid number  
                if (!double.TryParse(newScore, out double scoreValue))
                {
                    MessageBox.Show("Invalid score. Please enter a valid number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3.  Database Update  
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a Transaction (Important for data consistency)  
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 3.1 Update StudentsCourses Table  
                        string updateStudentsCoursesQuery = @"  
                    UPDATE StudentsCourses  
                    SET FirstName = @FirstName,  
                        LastName = @LastName,  
                        Major = @Major  
                    WHERE Id = @StudentId";

                        using (SqlCommand updateStudentsCoursesCommand = new SqlCommand(updateStudentsCoursesQuery, connection, transaction))
                        {
                            updateStudentsCoursesCommand.Parameters.AddWithValue("@StudentId", studentId);
                            updateStudentsCoursesCommand.Parameters.AddWithValue("@FirstName", newFirstName);
                            updateStudentsCoursesCommand.Parameters.AddWithValue("@LastName", newLastName);
                            updateStudentsCoursesCommand.Parameters.AddWithValue("@Major", newMajor);

                            updateStudentsCoursesCommand.ExecuteNonQuery();
                        }

                        // 3.2 Update StudentScores Table  
                        string updateStudentScoresQuery = @"  
                    UPDATE StudentScores  
                    SET SubjectName = @SubjectName,  
                        Score = @Score  
                    WHERE StudentId = @StudentId AND SubjectName = @OriginalSubjectName"; // Add a WHERE clause  

                        using (SqlCommand updateStudentScoresCommand = new SqlCommand(updateStudentScoresQuery, connection, transaction))
                        {
                            updateStudentScoresCommand.Parameters.AddWithValue("@StudentId", studentId);
                            updateStudentScoresCommand.Parameters.AddWithValue("@SubjectName", newSubjectName);
                            updateStudentScoresCommand.Parameters.AddWithValue("@Score", scoreValue);
                            updateStudentScoresCommand.Parameters.AddWithValue("@OriginalSubjectName", selectedRow.Cells[3].Value.ToString()); // Assuming SubjectName is in the 4th column (index 3)  


                            updateStudentScoresCommand.ExecuteNonQuery();
                        }

                        // 4. Commit the Transaction  
                        transaction.Commit();
                        MessageBox.Show("Student information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        table_select_create_certificate.Rows.Clear();
                        // 5. Refresh the DataGridView (Optional)  
                        InformationStudents_Load(sender, e); // Reload data from the database  
                                                             // Or, update the DataGridView row directly (more efficient):  
                        selectedRow.Cells[1].Value = newFirstName + " " + newLastName; // Update FullName  
                        selectedRow.Cells[2].Value = newMajor;
                        selectedRow.Cells[3].Value = newSubjectName;
                        selectedRow.Cells[4].Value = newScore;

                    }
                    catch (Exception ex)
                    {
                        // 6. Rollback Transaction on Error  
                        transaction.Rollback();
                        MessageBox.Show("Error updating student information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

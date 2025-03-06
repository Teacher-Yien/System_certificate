using System;
using System.Configuration; // For ConfigurationManager  
using System.Data.SqlClient;
using System_certificate.Models;
using System_certificate.Views;

public class EnrollStudentsPresenter
{
    private readonly IEnrollstudentsView _view;
    private readonly string _connectionString;

    public EnrollStudentsPresenter(IEnrollstudentsView view)
    {
        _view = view;
        _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString; // Get the connection string  
    }

    public void AddStudent(Student student)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Students (FirstName, LastName, Major, CourseName, CourseDuration) VALUES (@FirstName, @LastName, @Major, @CourseName, @CourseDuration)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@Major", student.Major);
            command.Parameters.AddWithValue("@CourseName", student.CourseName);
            command.Parameters.AddWithValue("@CourseDuration", student.CourseDuration);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                _view.ShowMessage("Student successfully added.");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error: " + ex.Message);
            }
        }
    }
}
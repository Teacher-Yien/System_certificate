using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_certificate
{
    public partial class DoDegree : Form
    {
        // Get connection string
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public DoDegree()
        {
            InitializeComponent();
            // Subscribe to the DoubleClick event of the label  
            _label_Set_Name.DoubleClick += _label_Set_Name_DoubleClick;
        }

        // Get the page dimensions  
        private float pageWidth = 0.0f;
        private float pageHeight = 0.0f;
        // Calculate the position for the name (adjust as needed)  
        private float nameX = 0.0f;
        private float nameY = 0.0f;

        private void btn_close_degree_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }
        private void LoadCertificateTemplate(string templateName)
        {
            try
            {
                // 1. Get the base path from settings  
                string basePath = "C:\\Users\\Administrator\\Desktop\\c#\\System_certificate\\Resources\\";

                // 2. Determine the correct image file name based on the template name  
                string imageFileName = "";
                if (templateName == "Certificate1_Replace")
                {
                    imageFileName = "Certificate1_Replace.jpg";
                }
                else if (templateName == "Certificate2_Replace")
                {
                    imageFileName = "Certificate2_Replace.jpg";
                }
                else if (templateName == "Certificate3_Replace")
                {
                    imageFileName = "Certificate3_Replace.jpg";
                }
                else if (templateName == "Certificate4_Replace")
                {
                    imageFileName = "Certificate4_Replace.jpg";
                }
                else
                {
                    MessageBox.Show("Invalid template name: " + templateName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if the template name is invalid  
                }

                // 3. Combine the base path and file name to get the full image path  
                string imagePath = Path.Combine(basePath, imageFileName);

                // 4. Load the image  
                Image templateImage = Image.FromFile(imagePath);

                // 5. Update the main display PictureBox  
                Certificate_template_default.Image = templateImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading certificate template: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Certificate_template1_Click(object sender, EventArgs e)
        {
            LoadCertificateTemplate("Certificate1_Replace"); // Or any identifier you want to use
            // Calculate the position for the name (adjust as needed)  
            nameX = pageWidth / 2 - 50;  // Approximate X-coordinate (adjust as needed)  
            nameY = pageHeight / 2 - 120; // Approximate Y-coordinate (adjust as needed)  
        }

        private void Certificate_template2_Click(object sender, EventArgs e)
        {
            LoadCertificateTemplate("Certificate2_Replace"); // Or any identifier you want to use 
            // Calculate the position for the name (adjust as needed)  
            nameX = pageWidth / 2 - 60;  // Approximate X-coordinate (adjust as needed)  
            nameY = pageHeight / 2 - 400; // Approximate Y-coordinate (adjust as needed)  
        }

        private void Certificate_template3_Click(object sender, EventArgs e)
        {
            LoadCertificateTemplate("Certificate3_Replace"); // Or any identifier you want to use 
        }

        private void Certificate_template4_Click(object sender, EventArgs e)
        {
            LoadCertificateTemplate("Certificate4_Replace"); // Or any identifier you want to use 
        }
        private PrintDocument printDocument = new PrintDocument(); // Keep this as a class-level variable
        
        private Font printFont = new Font("Khmer OS Battambang", 36, FontStyle.Regular); // Use Khmer font   
        public void SetNameToPrint(string name)
        {
            _label_Set_Name.Text = name;
        }
        private void btn_print_certificate_Click(object sender, EventArgs e)
        {
            if (Certificate_template_default.Image == null)
            {
                MessageBox.Show("No certificate template loaded to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Configure the PrintDocument  
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage); // Assign event handler  
            printDocument.DocumentName = "Certificate"; // Optional: Set a document name  

            //  Set the paper size and orientation  
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // A4 size in hundredths of an inch (8.27 x 11.69 inches)  
            printDocument.DefaultPageSettings.Landscape = true;  // Set to landscape  

            // 2. Show the Print Preview Dialog (optional, but recommended)  
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();

            // 3. Show the Print Dialog  
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            // 4. Show the Print Dialog and start printing if the user clicks "Print"  
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print(); // Start the printing process  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error printing certificate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // PrintPage Event Handler  
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            // Get the image to print  
            Image image = Certificate_template_default.Image;

            // Get the page dimensions  
            pageWidth = e.PageBounds.Width;
            pageHeight = e.PageBounds.Height;

            // Print the image to fill the entire page  
            RectangleF printRect = new RectangleF(0, 0, pageWidth, pageHeight);
            e.Graphics.DrawImage(image, printRect);

            // Draw the Name  
            // Define the brush (color)  
            SolidBrush printBrush = new SolidBrush(Color.Navy);

            // Calculate the position for the name (adjust as needed)  
            nameX = pageWidth / 2 - 50;  // Approximate X-coordinate (adjust as needed)  
            nameY = pageHeight / 2 - 120; // Approximate Y-coordinate (adjust as needed)  

            // Set Text Rendering Hint for better quality  
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Draw the string  
            e.Graphics.DrawString(_label_Set_Name.Text, printFont, printBrush, nameX, nameY);

            // Clean up resources  
            printBrush.Dispose();
            //printFont.Dispose();  // Keep the font for the class  

            // Indicate that we have no more pages to print  
            e.HasMorePages = false;
        }

        private int _certificateId;

        public void SetCertificateId(int id)
        {
            _certificateId = id;
        }

        private void _label_Set_Name_DoubleClick(object sender, EventArgs e)
        {
            // Use the stored certificate ID instead of creating a new InformationStudents
            string newName = ShowInputDialog("Enter new name:", "Update Name");
            if (!string.IsNullOrEmpty(newName))
            {
                _label_Set_Name.Text = newName;
                UpdateNameInDatabase(_certificateId, newName);
            }
        }

        private string ShowInputDialog(string text, string title)
        {
            // Create a new input dialog for the user to enter a name
            UpdateNameCetificate updateNameCetificate = new UpdateNameCetificate();
            updateNameCetificate.Text = title;

            // Optionally, set the initial value in the dialog
            // updateNameCetificate.nameTextBox.Text = _label_Set_Name.Text;

            if (updateNameCetificate.ShowDialog() == DialogResult.OK)
            {
                return updateNameCetificate.NewName;
            }
            else
            {
                return null; // User cancelled the action
            }
        }

        private void UpdateNameInDatabase(int certificateId, string fullName)
        {


            // SQL Update Query: Update FirstName and LastName
            string query = "UPDATE StudentsCourses SET FirstName = @FirstName, LastName = @LastName WHERE Id = @CertificateId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Split FullName into FirstName and LastName
                        string[] nameParts = fullName.Split(' ');

                        // Handle cases where there might not be a last name
                        string firstName = nameParts.Length > 0 ? nameParts[0] : "";
                        string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts.Skip(1)) : "";

                        // Set parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@CertificateId", certificateId);

                        // Execute the UPDATE command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student's Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}

namespace System_certificate
{
    partial class InformationStudents
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.table_select_create_certificate = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CourseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.major = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search_Student_Name_and_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_delete_students = new Guna.UI2.WinForms.Guna2Button();
            this.btn_update_name_major_subject_score = new Guna.UI2.WinForms.Guna2Button();
            this.btn_DoDegree = new Guna.UI2.WinForms.Guna2Button();
            this.btn_exit_table_certificate = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_select_create_certificate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bayon", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "តារាងធ្វើសញ្ញាប័ត្រ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table_select_create_certificate);
            this.panel1.Location = new System.Drawing.Point(23, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1214, 465);
            this.panel1.TabIndex = 3;
            // 
            // table_select_create_certificate
            // 
            this.table_select_create_certificate.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.table_select_create_certificate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Hanuman", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_select_create_certificate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table_select_create_certificate.ColumnHeadersHeight = 43;
            this.table_select_create_certificate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.table_select_create_certificate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseId,
            this.StudentId,
            this.major,
            this.CourseName,
            this.score,
            this.Status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Hanuman", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table_select_create_certificate.DefaultCellStyle = dataGridViewCellStyle3;
            this.table_select_create_certificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_select_create_certificate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.table_select_create_certificate.Location = new System.Drawing.Point(0, 0);
            this.table_select_create_certificate.Name = "table_select_create_certificate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Hanuman", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_select_create_certificate.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.table_select_create_certificate.RowHeadersVisible = false;
            this.table_select_create_certificate.RowHeadersWidth = 51;
            this.table_select_create_certificate.RowTemplate.Height = 24;
            this.table_select_create_certificate.Size = new System.Drawing.Size(1214, 465);
            this.table_select_create_certificate.TabIndex = 4;
            this.table_select_create_certificate.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.table_select_create_certificate.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.table_select_create_certificate.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.table_select_create_certificate.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.table_select_create_certificate.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.table_select_create_certificate.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.table_select_create_certificate.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.table_select_create_certificate.ThemeStyle.HeaderStyle.Height = 43;
            this.table_select_create_certificate.ThemeStyle.ReadOnly = false;
            this.table_select_create_certificate.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.table_select_create_certificate.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.table_select_create_certificate.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_select_create_certificate.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.table_select_create_certificate.ThemeStyle.RowsStyle.Height = 24;
            this.table_select_create_certificate.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.table_select_create_certificate.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.table_select_create_certificate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // CourseId
            // 
            this.CourseId.FillWeight = 60F;
            this.CourseId.HeaderText = "លេខរាង";
            this.CourseId.MinimumWidth = 10;
            this.CourseId.Name = "CourseId";
            // 
            // StudentId
            // 
            this.StudentId.HeaderText = "ឈ្មោះ";
            this.StudentId.MinimumWidth = 6;
            this.StudentId.Name = "StudentId";
            // 
            // major
            // 
            this.major.FillWeight = 80F;
            this.major.HeaderText = "ជំនាញ";
            this.major.MinimumWidth = 6;
            this.major.Name = "major";
            // 
            // CourseName
            // 
            this.CourseName.HeaderText = "វគ្គសិក្សា";
            this.CourseName.MinimumWidth = 6;
            this.CourseName.Name = "CourseName";
            // 
            // score
            // 
            this.score.FillWeight = 80F;
            this.score.HeaderText = "ពិន្ទុសិស្ស";
            this.score.MinimumWidth = 6;
            this.score.Name = "score";
            // 
            // Status
            // 
            this.Status.FillWeight = 80F;
            this.Status.HeaderText = "ប្រតិបត្តិពិន្ទុ";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // Search_Student_Name_and_id
            // 
            this.Search_Student_Name_and_id.Animated = true;
            this.Search_Student_Name_and_id.AutoRoundedCorners = true;
            this.Search_Student_Name_and_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search_Student_Name_and_id.DefaultText = "";
            this.Search_Student_Name_and_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Search_Student_Name_and_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Search_Student_Name_and_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Student_Name_and_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search_Student_Name_and_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search_Student_Name_and_id.Font = new System.Drawing.Font("Hanuman", 10F);
            this.Search_Student_Name_and_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search_Student_Name_and_id.Location = new System.Drawing.Point(808, 27);
            this.Search_Student_Name_and_id.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Search_Student_Name_and_id.Name = "Search_Student_Name_and_id";
            this.Search_Student_Name_and_id.PlaceholderText = "  ស្វែងរក.....";
            this.Search_Student_Name_and_id.SelectedText = "";
            this.Search_Student_Name_and_id.Size = new System.Drawing.Size(429, 60);
            this.Search_Student_Name_and_id.TabIndex = 5;
            this.Search_Student_Name_and_id.TextChanged += new System.EventHandler(this.Search_Student_Name_and_id_TextChanged);
            // 
            // btn_delete_students
            // 
            this.btn_delete_students.Animated = true;
            this.btn_delete_students.AutoRoundedCorners = true;
            this.btn_delete_students.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete_students.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete_students.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete_students.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_delete_students.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_delete_students.Font = new System.Drawing.Font("Bayon", 12F);
            this.btn_delete_students.ForeColor = System.Drawing.Color.White;
            this.btn_delete_students.IndicateFocus = true;
            this.btn_delete_students.Location = new System.Drawing.Point(23, 601);
            this.btn_delete_students.Name = "btn_delete_students";
            this.btn_delete_students.Size = new System.Drawing.Size(232, 58);
            this.btn_delete_students.TabIndex = 9;
            this.btn_delete_students.Text = "លុប";
            this.btn_delete_students.Click += new System.EventHandler(this.btn_delete_students_Click);
            // 
            // btn_update_name_major_subject_score
            // 
            this.btn_update_name_major_subject_score.Animated = true;
            this.btn_update_name_major_subject_score.AutoRoundedCorners = true;
            this.btn_update_name_major_subject_score.BackColor = System.Drawing.Color.Transparent;
            this.btn_update_name_major_subject_score.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_update_name_major_subject_score.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_update_name_major_subject_score.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_update_name_major_subject_score.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_update_name_major_subject_score.Font = new System.Drawing.Font("Bayon", 12F);
            this.btn_update_name_major_subject_score.ForeColor = System.Drawing.Color.White;
            this.btn_update_name_major_subject_score.IndicateFocus = true;
            this.btn_update_name_major_subject_score.Location = new System.Drawing.Point(261, 601);
            this.btn_update_name_major_subject_score.Name = "btn_update_name_major_subject_score";
            this.btn_update_name_major_subject_score.Size = new System.Drawing.Size(232, 58);
            this.btn_update_name_major_subject_score.TabIndex = 10;
            this.btn_update_name_major_subject_score.Text = "កែប្រែ";
            this.btn_update_name_major_subject_score.Click += new System.EventHandler(this.btn_update_name_major_subject_score_Click);
            // 
            // btn_DoDegree
            // 
            this.btn_DoDegree.Animated = true;
            this.btn_DoDegree.AutoRoundedCorners = true;
            this.btn_DoDegree.BackColor = System.Drawing.Color.Transparent;
            this.btn_DoDegree.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DoDegree.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DoDegree.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DoDegree.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DoDegree.Font = new System.Drawing.Font("Bayon", 12F);
            this.btn_DoDegree.ForeColor = System.Drawing.Color.White;
            this.btn_DoDegree.IndicateFocus = true;
            this.btn_DoDegree.Location = new System.Drawing.Point(499, 601);
            this.btn_DoDegree.Name = "btn_DoDegree";
            this.btn_DoDegree.Size = new System.Drawing.Size(232, 58);
            this.btn_DoDegree.TabIndex = 11;
            this.btn_DoDegree.Text = "បោះពុម្ព";
            this.btn_DoDegree.Click += new System.EventHandler(this.btn_DoDegree_Click);
            // 
            // btn_exit_table_certificate
            // 
            this.btn_exit_table_certificate.Animated = true;
            this.btn_exit_table_certificate.AutoRoundedCorners = true;
            this.btn_exit_table_certificate.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit_table_certificate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit_table_certificate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_table_certificate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit_table_certificate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit_table_certificate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit_table_certificate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_exit_table_certificate.Font = new System.Drawing.Font("Bayon", 12F);
            this.btn_exit_table_certificate.ForeColor = System.Drawing.Color.White;
            this.btn_exit_table_certificate.IndicateFocus = true;
            this.btn_exit_table_certificate.Location = new System.Drawing.Point(737, 601);
            this.btn_exit_table_certificate.Name = "btn_exit_table_certificate";
            this.btn_exit_table_certificate.Size = new System.Drawing.Size(232, 58);
            this.btn_exit_table_certificate.TabIndex = 12;
            this.btn_exit_table_certificate.Text = "ចាកចេញ";
            this.btn_exit_table_certificate.Click += new System.EventHandler(this.btn_exit_table_certificate_Click);
            // 
            // InformationStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_exit_table_certificate);
            this.Controls.Add(this.btn_DoDegree);
            this.Controls.Add(this.btn_update_name_major_subject_score);
            this.Controls.Add(this.btn_delete_students);
            this.Controls.Add(this.Search_Student_Name_and_id);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "InformationStudents";
            this.Size = new System.Drawing.Size(1321, 765);
            this.Load += new System.EventHandler(this.InformationStudents_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table_select_create_certificate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView table_select_create_certificate;
        private Guna.UI2.WinForms.Guna2TextBox Search_Student_Name_and_id;
        private Guna.UI2.WinForms.Guna2Button btn_delete_students;
        private Guna.UI2.WinForms.Guna2Button btn_update_name_major_subject_score;
        private Guna.UI2.WinForms.Guna2Button btn_DoDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn major;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private Guna.UI2.WinForms.Guna2Button btn_exit_table_certificate;
    }
}

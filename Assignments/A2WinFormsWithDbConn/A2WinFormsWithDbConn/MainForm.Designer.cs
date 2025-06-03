namespace A2WinFormsWithDbConn
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(188, 173);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(98, 26);
            this.btnStudent.TabIndex = 60;
            this.btnStudent.Text = "Student Form";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jost", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 30);
            this.label1.TabIndex = 58;
            this.label1.Text = "Info Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Click the button you wish to open?";
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(188, 221);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(98, 26);
            this.btnTeacher.TabIndex = 62;
            this.btnTeacher.Text = "Teacher Form";
            this.btnTeacher.UseVisualStyleBackColor = true;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(188, 266);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(98, 26);
            this.btnCourse.TabIndex = 63;
            this.btnCourse.Text = "Course Form";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 362);
            this.Controls.Add(this.btnCourse);
            this.Controls.Add(this.btnTeacher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.Button btnCourse;
    }
}
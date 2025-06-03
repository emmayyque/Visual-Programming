namespace A3WinFormsThreeTier
{
    partial class CourseForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.txtCrHrs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrerequisites = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseFee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInstName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gridCourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(916, 447);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 26);
            this.btnBack.TabIndex = 57;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtCrHrs
            // 
            this.txtCrHrs.Location = new System.Drawing.Point(177, 168);
            this.txtCrHrs.Name = "txtCrHrs";
            this.txtCrHrs.Size = new System.Drawing.Size(162, 20);
            this.txtCrHrs.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Credit Hours:";
            // 
            // txtPrerequisites
            // 
            this.txtPrerequisites.Location = new System.Drawing.Point(177, 279);
            this.txtPrerequisites.Name = "txtPrerequisites";
            this.txtPrerequisites.Size = new System.Drawing.Size(162, 20);
            this.txtPrerequisites.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Prerequisites";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(177, 242);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(162, 20);
            this.txtLevel.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Course Level:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(177, 205);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(162, 20);
            this.txtDuration.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Duration:";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(177, 131);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(162, 20);
            this.txtCourseName.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Course Name:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(96, 409);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(98, 26);
            this.btnSubmit.TabIndex = 42;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Location = new System.Drawing.Point(177, 94);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(162, 20);
            this.txtCourseCode.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Course Code:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jost", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 39;
            this.label1.Text = "Course Form";
            // 
            // txtCourseFee
            // 
            this.txtCourseFee.Location = new System.Drawing.Point(177, 316);
            this.txtCourseFee.Name = "txtCourseFee";
            this.txtCourseFee.Size = new System.Drawing.Size(162, 20);
            this.txtCourseFee.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Course Fee:";
            // 
            // txtInstName
            // 
            this.txtInstName.Location = new System.Drawing.Point(177, 353);
            this.txtInstName.Name = "txtInstName";
            this.txtInstName.Size = new System.Drawing.Size(162, 20);
            this.txtInstName.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Instructor Name:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 447);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 26);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(210, 409);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 26);
            this.btnSearch.TabIndex = 65;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(96, 447);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 26);
            this.btnUpdate.TabIndex = 64;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Jost", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(601, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 30);
            this.label5.TabIndex = 63;
            this.label5.Text = "Courses Records";
            // 
            // gridCourses
            // 
            this.gridCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCourses.Location = new System.Drawing.Point(363, 94);
            this.gridCourses.Name = "gridCourses";
            this.gridCourses.Size = new System.Drawing.Size(651, 279);
            this.gridCourses.TabIndex = 62;
            // 
            // Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 490);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridCourses);
            this.Controls.Add(this.txtInstName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCourseFee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtCrHrs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrerequisites);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtCourseCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Course";
            this.Text = "Course";
            ((System.ComponentModel.ISupportInitialize)(this.gridCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtCrHrs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrerequisites;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourseFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInstName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridCourses;
    }
}
using A2WinFormsWithDbConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2WinFormsWithDbConn
{
    public partial class Course : Form
    {
        DbConn Connection = new DbConn();
        public Course()
        {
            InitializeComponent();
            LoadCourses();
        }

        // Function to Clear the Text Fields
        private void ClearFields()
        {
            txtCourseCode.Text = "";
            txtCourseName.Text = "";
            txtCrHrs.Text = "";                                
            txtDuration.Text = "";
            txtLevel.Text = "";
            txtPrerequisites.Text = "";
            txtCourseFee.Text = "";
            txtInstName.Text = "";

            txtCourseCode.Enabled = true;
            btnDelete.Enabled = true;
            btnSearch.Enabled = true;
            btnSubmit.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String CourseCode = txtCourseCode.Text;
            String CourseName = txtCourseName.Text;
            String CrHrs = txtCrHrs.Text;
            String Duration = txtDuration.Text;
            String Level = txtLevel.Text;
            String Prerequisites = txtPrerequisites.Text;
            String CourseFee = txtCourseFee.Text;
            String InstructorName = txtInstName.Text;


            DbConn Connection = new DbConn();
            String Qry = "INSERT INTO Courses (course_code, course_name, credit_hours, duration, course_level, prerequisites, course_fee, instructor_name) " +
                "VALUES ('" + CourseCode + "', '" + CourseName + "', '" + CrHrs + "', '" + Duration + "', '" + Level + "', '" + Prerequisites + "', '" + CourseFee + "', '" + InstructorName + "' )";
            

            if (Connection.UDI(Qry))
            {
                MessageBox.Show("Success !!\nCourse Added Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added courses record into Grid
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Error!!!\nIn Adding Course!!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form MainForm = new MainForm();
            MainForm.ShowDialog();
        }

        // Function to Load Courses From Database to DataGridView
        private void LoadCourses()
        {
            DbConn Connection = new DbConn();
            String Qry = "SELECT * FROM Courses";
            DataTable dt = Connection.Search(Qry);
            gridCourses.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String CourseCode = txtCourseCode.Text;

            if (CourseCode != "")
            {
                DbConn Connection = new DbConn();
                String Qry = "SELECT * FROM Courses WHERE course_code = '" + CourseCode + "'";
                DataTable dt = Connection.Search(Qry);

                if (dt.Rows.Count > 0)
                {
                    txtCourseName.Text = dt.Rows[0]["course_name"].ToString();
                    txtCrHrs.Text = dt.Rows[0]["credit_hours"].ToString();
                    txtDuration.Text = dt.Rows[0]["duration"].ToString();
                    txtLevel.Text = dt.Rows[0]["course_level"].ToString();
                    txtPrerequisites.Text = dt.Rows[0]["prerequisites"].ToString();
                    txtCourseFee.Text = dt.Rows[0]["course_fee"].ToString();
                    txtInstName.Text = dt.Rows[0]["instructor_name"].ToString();
                    txtCourseCode.Enabled = false;

                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error !!\nEnter a valid Course Code");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nCourse Code cannot be blank");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Form Data
            String CourseCode = txtCourseCode.Text;
            String CourseName = txtCourseName.Text;
            String CrHrs = txtCrHrs.Text;
            String Duration = txtDuration.Text;
            String Level = txtLevel.Text;
            String Prerequisites = txtPrerequisites.Text;
            String CourseFee = txtCourseFee.Text;
            String InstructorName = txtInstName.Text;

            DbConn Connection = new DbConn();
            String Qry = "UPDATE Courses SET course_name = '" + CourseName + "', credit_hours = '" + CrHrs + "', duration = '" + Duration + "', course_level = '" + Level + "', prerequisites = '" + Prerequisites + "', course_fee = '" + CourseFee + "', instructor_name = '" + InstructorName + "' WHERE course_code = '" + CourseCode + "'";

            if (Connection.UDI(Qry))
            {
                MessageBox.Show("Success !!\nCourse Updated Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added courses record into Grid
                LoadCourses();
            }
            else
            {
                MessageBox.Show("Error !!\nIn Updating Course !!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String CourseCode = txtCourseCode.Text;

            if (CourseCode != "")
            {               
                DbConn Connection = new DbConn();
                String Qry = "DELETE FROM Courses WHERE course_code = '" + CourseCode + "'";

                if (Connection.UDI(Qry))
                {
                    MessageBox.Show("Success !!\nCourse Deleted Successfully !!");

                    // To Clear the input fields for next record
                    ClearFields();

                    // To Update the Newly added courses record into Grid
                    LoadCourses();
                }
                else
                {
                    MessageBox.Show("Error !!\nIn Deleting Course !!");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nCourse Code cannot be blank");
            }
        }
    }
}

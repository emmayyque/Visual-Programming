using AppProps;
using BusinessLogicLayer;
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

namespace A3WinFormsThreeTier
{
    public partial class CourseForm : Form
    {
        public CourseForm()
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
            Course course = new Course()
            {
                CourseCode = txtCourseCode.Text,
                CourseName = txtCourseName.Text,
                CreditHours = txtCrHrs.Text,
                Duration = txtDuration.Text,
                CourseLevel = txtLevel.Text,
                Prerequisites = txtPrerequisites.Text,
                CourseFee = txtCourseFee.Text,
                InstructorName = txtInstName.Text
            };

            CourseBLL courseBLL = new CourseBLL();

            if (courseBLL.InsertCourseBLL(course))
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
            gridCourses.DataSource = new CourseBLL().GetAllCoursesBLL();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseCode = txtCourseCode.Text
            };

            if (course.CourseCode != "")
            {
                DataTable dt = new CourseBLL().GetCourseBLL(course);

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
            Course course = new Course()
            {
                CourseCode = txtCourseCode.Text,
                CourseName = txtCourseName.Text,
                CreditHours = txtCrHrs.Text,
                Duration = txtDuration.Text,
                CourseLevel = txtLevel.Text,
                Prerequisites = txtPrerequisites.Text,
                CourseFee = txtCourseFee.Text,
                InstructorName = txtInstName.Text
            };

            CourseBLL courseBLL = new CourseBLL();

            if (courseBLL.UpdateCourseBLL(course))
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
            Course course = new Course()
            {
                CourseCode = txtCourseCode.Text
            };

            if (course.CourseCode != "")
            {
                CourseBLL courseBLL = new CourseBLL();

                if (courseBLL.DeleteCourseBLL(course))
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

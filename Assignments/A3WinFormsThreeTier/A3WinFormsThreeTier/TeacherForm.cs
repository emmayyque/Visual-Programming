using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A3WinFormsThreeTier
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
            LoadTeachers();
        }

        // Function to Clear the Text Fields
        private void ClearFields()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtExp.Text = "";
            txtType.Text = "";
            txtAddress.Text = "";
            txtDob.Text = "";
            txtDateOfJoining.Text = "";

            txtId.Enabled = true;
            btnDelete.Enabled = true;
            btnSearch.Enabled = true;
            btnSubmit.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Id = txtId.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Experience = txtExp.Text,
                Type = txtType.Text,
                Address = txtAddress.Text,
                DateOfBirth = txtDateOfJoining.Text,
                DateOfJoining = txtDateOfJoining.Text
            };

            TeacherBLL teacherBLL = new TeacherBLL();

            if (teacherBLL.InsertTeacherBLL(teacher))
            {
                MessageBox.Show("Success !!\nTeacher Added Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added teacher record into Grid
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Error!!!\nIn Adding Teacher!!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form MainForm = new MainForm();
            MainForm.ShowDialog();
        }

        public void LoadTeachers()
        {
            gridTeachers.DataSource = new TeacherBLL().GetAllTachersBLL();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Id = txtId.Text,
            };

            if (teacher.Id != "")
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                DataTable dt = teacherBLL.GetTeacherBLL(teacher);

                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                    txtLastName.Text = dt.Rows[0]["last_name"].ToString();
                    txtExp.Text = dt.Rows[0]["experience"].ToString();
                    txtType.Text = dt.Rows[0]["type"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                    txtDob.Text = dt.Rows[0]["date_of_birth"].ToString();
                    txtDateOfJoining.Text = dt.Rows[0]["date_of_joining"].ToString();
                    
                    txtId.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error !!\nEnter a valid Teacher ID");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nTeacher ID cannot be blank");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Id = txtId.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Experience = txtExp.Text,
                Type = txtType.Text,
                Address = txtAddress.Text,
                DateOfBirth = txtDateOfJoining.Text,
                DateOfJoining = txtDateOfJoining.Text
            };

            TeacherBLL teacherBLL = new TeacherBLL();

            if (teacherBLL.UpdateTeacherBLL(teacher))
            {
                MessageBox.Show("Success !!\nTeacher Updated Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added teacher record into Grid
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Error!!!\nIn Updating Teacher!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Id = txtId.Text,
            };

            if (teacher.Id != "")
            {
                TeacherBLL teacherBLL = new TeacherBLL();

                if (teacherBLL.DeleteTeacherBLL(teacher))
                {
                    MessageBox.Show("Success !!\nTeacher Deleted Successfully !!");

                    // To Clear the input fields for next record
                    ClearFields();

                    // To Update the Newly added teacher record into Grid
                    LoadTeachers();
                }
                else
                {
                    MessageBox.Show("Error!!!\nIn Deleting Teacher!!");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nID cannot be blank");
            }
        }
    }
}

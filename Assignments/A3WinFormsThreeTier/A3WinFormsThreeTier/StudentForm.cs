using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A3WinFormsThreeTier
{
    public partial class StudentForm : Form
    {

        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        // Function to Clear the Text Fields
        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            txtRollNo.Text = "";
            txtSysId.Text = "";
            txtAddress.Text = "";
            txtDob.Text = "";
            txtDateOfAdmission.Text = "";

            txtRollNo.Enabled = true;
            btnDelete.Enabled = true;
            btnSearch.Enabled = true;
            btnSubmit.Enabled = true;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                RollNo = txtRollNo.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                FatherName = txtFatherName.Text,
                SysId = txtSysId.Text,
                Address = txtAddress.Text,
                DateOfBirth = txtDob.Text,
                DateOfAdmission = txtDateOfAdmission.Text,
            };

            StudentBLL studentBLL = new StudentBLL();

            if (studentBLL.InsertStudentBLL(student))
            {
                MessageBox.Show("Success !!\nStudent Added Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added student record into Grid
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Error!!!\nIn Adding Studentssssssss!!");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form MainForm = new MainForm();
            MainForm.ShowDialog();
        }

        // Function to Load Students From Database to DataGridView
        public void LoadStudents()
        {
            gridStudent.DataSource = new StudentBLL().GetAllStudentsBLL();                        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                RollNo = txtRollNo.Text
            };

            if (student.RollNo != "")
            {
                StudentBLL studentBLL = new StudentBLL();
                DataTable dt = studentBLL.GetStudentBLL(student);

                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                    txtLastName.Text = dt.Rows[0]["last_name"].ToString();
                    txtFatherName.Text = dt.Rows[0]["father_name"].ToString();
                    txtSysId.Text = dt.Rows[0]["sys_id"].ToString();
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                    txtDob.Text = dt.Rows[0]["date_of_birth"].ToString();
                    txtDateOfAdmission.Text = dt.Rows[0]["date_of_admission"].ToString();
                    txtRollNo.Enabled = false;

                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error !!\nEnter a valid Roll No");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nRoll No cannot be blank");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                RollNo = txtRollNo.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                FatherName = txtFatherName.Text,
                SysId = txtSysId.Text,
                Address = txtAddress.Text,
                DateOfBirth = txtDob.Text,
                DateOfAdmission = txtDateOfAdmission.Text,
            };

            StudentBLL studentBLL = new StudentBLL();
            
            if (studentBLL.UpdateStudentBLL(student))
            {
                MessageBox.Show("Success !!\nStudent Record Updated Successfully");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added student record into Grid
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Error !!\nIn Updating Student Record");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                RollNo = txtRollNo.Text
            };

            if (student.RollNo != "")
            {
                StudentBLL studentBLL = new StudentBLL();
                
                if (studentBLL.DeleteStudentBLL(student))
                {
                    MessageBox.Show("Success !!\nStudent Record Deleted Successfully");

                    // To Clear the input fields for next record
                    ClearFields();

                    // To Update the Newly added student record into Grid
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Error !!\nIn Deleting Student Record");
                }
            }
            else
            {
                MessageBox.Show("Error !!\nRoll No cannot be blank");
            }
        }
    }
}

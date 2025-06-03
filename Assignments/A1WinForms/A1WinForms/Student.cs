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

namespace A1WinForms
{
    public partial class Student : Form
    {
        public Student()
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
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String FatherName = txtFatherName.Text;
            String RollNo = txtRollNo.Text;
            String SysId = txtSysId.Text;
            String Address = txtAddress.Text;
            String DateOfBirth = txtDob.Text;
            String DateOfAdmission = txtDateOfAdmission.Text;

            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "INSERT INTO Students (first_name, last_name, father_name, roll_no, sys_id, address, date_of_birth, date_of_admission) " +
                "VALUES ('"+FirstName+"', '"+LastName+"', '"+FatherName+"', '"+RollNo+"', '"+SysId+"', '"+Address+"', '"+DateOfBirth+"', '"+DateOfAdmission+"' )";
            SqlCommand Cmd = new SqlCommand(Qry, Conn);

            if (Cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Success !!\nStudent Added Successfully !!");

                // To Clear the input fields for next record
                ClearFields();

                // To Update the Newly added student record into Grid
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Error!!!\nIn Adding Student!!");
            }

            Conn.Close();
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
            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "SELECT * FROM Students";
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            gridStudent.DataSource = dt;                        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String rollNo = txtRollNo.Text;
            if (rollNo != "")
            {
                String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                String Qry = "SELECT * FROM Students WHERE roll_no = " + rollNo;
                SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Conn.Close();

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
            String rollNo = txtRollNo.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String FatherName = txtFatherName.Text;
            String SysId = txtSysId.Text;
            String Address = txtAddress.Text;
            String DateOfBirth = txtDob.Text;
            String DateOfAdmission = txtDateOfAdmission.Text;

            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "UPDATE Students SET first_name = '"+FirstName+"', last_name = '"+LastName+"', father_name = '"+FatherName+"', sys_id = '"+SysId+"', address = '"+Address+"', date_of_birth = '"+DateOfBirth+"', date_of_admission = '"+DateOfAdmission+"' WHERE roll_no = " + rollNo;
            SqlCommand Cmd = new SqlCommand(Qry, Conn);

            if (Cmd.ExecuteNonQuery() > 0)
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

            Conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String rollNo = txtRollNo.Text;
            if (rollNo != "")
            {
                String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                String Qry = "DELETE FROM Students WHERE roll_no = " + rollNo;
                SqlCommand Cmd = new SqlCommand(Qry, Conn);
                
                if ( Cmd.ExecuteNonQuery() > 0 )
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

                Conn.Close();
            }
            else
            {
                MessageBox.Show("Error !!\nRoll No cannot be blank");
            }
        }
    }
}

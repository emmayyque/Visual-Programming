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
    public partial class Teacher : Form
    {
        public Teacher()
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
            String Id = txtId.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String Experience = txtExp.Text;
            String Type = txtType.Text;
            String Address = txtAddress.Text;
            String DateOfBirth = txtDob.Text;
            String DateOfJoining = txtDateOfJoining.Text;

            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "INSERT INTO Teachers (id, first_name, last_name, experience, type, address, date_of_birth, date_of_joining) VALUES ('" + Id + "', '" + FirstName + "', '" + LastName + "', '" + Experience + "', '" + Type + "', '" + Address + "', '" + DateOfBirth + "', '" + DateOfJoining + "' )";
            SqlCommand Cmd = new SqlCommand(Qry, Conn);

            if (Cmd.ExecuteNonQuery() > 0)
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

            Conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form MainForm = new MainForm();
            MainForm.ShowDialog();
        }

        public void LoadTeachers()
        {
            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "SELECT * FROM Teachers";
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gridTeachers.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String Id = txtId.Text;

            if (Id != "")
            {
                String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                String Qry = "SELECT * FROM Teachers WHERE id = '" + Id + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Conn.Close();
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
            String Id = txtId.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String Experience = txtExp.Text;
            String Type = txtType.Text;
            String Address = txtAddress.Text;
            String DateOfBirth = txtDob.Text;
            String DateOfJoining = txtDateOfJoining.Text;

            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            String Qry = "UPDATE Teachers SET first_name = '"+ FirstName +"', last_name = '"+ LastName + "', experience = '"+ Experience + "', type = '"+ Type + "', address = '"+ Address +"', date_of_birth = '"+ DateOfBirth +"', date_of_joining = '"+ DateOfJoining + "' WHERE id = '"+ Id +"'";
            SqlCommand Cmd = new SqlCommand(Qry, Conn);

            if (Cmd.ExecuteNonQuery() > 0)
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

            Conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String Id = txtId.Text;

            if (Id != "")
            {
                String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                String Qry = "DELETE FROM Teachers WHERE id = '" + Id + "'";
                SqlCommand Cmd = new SqlCommand(Qry, Conn);

                if (Cmd.ExecuteNonQuery() > 0)
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

                Conn.Close();
            }
            else
            {
                MessageBox.Show("Error !!\nID cannot be blank");
            }
            
        }
    }
}

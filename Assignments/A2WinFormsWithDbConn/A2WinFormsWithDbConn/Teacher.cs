using A2WinFormsWithDbConn;
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

namespace A2WinFormsWithDbConn
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

            DbConn Connection = new DbConn();
            String Qry = "INSERT INTO Teachers (id, first_name, last_name, experience, type, address, date_of_birth, date_of_joining) VALUES ('" + Id + "', '" + FirstName + "', '" + LastName + "', '" + Experience + "', '" + Type + "', '" + Address + "', '" + DateOfBirth + "', '" + DateOfJoining + "' )";            

            if (Connection.UDI(Qry))
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
            DbConn Connection = new DbConn();
            String Qry = "SELECT * FROM Teachers";
            DataTable dt = Connection.Search(Qry);
            gridTeachers.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String Id = txtId.Text;

            if (Id != "")
            {
                DbConn Connection = new DbConn();
                String Qry = "SELECT * FROM Teachers WHERE id = '" + Id + "'";
                DataTable dt = Connection.Search(Qry);

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
            String Id = txtId.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String Experience = txtExp.Text;
            String Type = txtType.Text;
            String Address = txtAddress.Text;
            String DateOfBirth = txtDob.Text;
            String DateOfJoining = txtDateOfJoining.Text;

            DbConn Connection = new DbConn();
            String Qry = "UPDATE Teachers SET first_name = '"+ FirstName +"', last_name = '"+ LastName + "', experience = '"+ Experience + "', type = '"+ Type + "', address = '"+ Address +"', date_of_birth = '"+ DateOfBirth +"', date_of_joining = '"+ DateOfJoining + "' WHERE id = '"+ Id +"'";

            if (Connection.UDI(Qry))
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
            String Id = txtId.Text;

            if (Id != "")
            {
                DbConn Connection = new DbConn();
                String Qry = "DELETE FROM Teachers WHERE id = '" + Id + "'";
                
                if (Connection.UDI(Qry))
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

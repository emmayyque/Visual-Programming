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

namespace FirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadStudentGrid();
        }

        
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            String Id = uId.Text;
            String FullName = uFullName.Text;
            String Email = uEmail.Text;

            //MessageBox.Show("Id: " + Id + "\nFull Name: " + FullName + "\nEmail: " + Email);

            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Connection = new SqlConnection(ConnectionString); 
            Connection.Open();
            String Qry = "INSERT INTO Users (id, full_name, email) VALUES ('"+Id+"', '"+FullName+"', '"+Email+"')";
            SqlCommand SqlCmd = new SqlCommand(Qry, Connection);

            if (SqlCmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record Added Successfully!!");
                LoadStudentGrid();
                uId.Text = "";
                uFullName.Text = "";
                uEmail.Text = "";
            }
            else
            {
                MessageBox.Show("Data Not Added Successfully!!");
            }

            Connection.Close();
        }

        public void LoadStudentGrid()
        {
            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            String Qry = "SELECT * FROM Users";
            SqlDataAdapter SDA = new SqlDataAdapter(Qry, Connection);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            GridStudent.DataSource = DT;
            Connection.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            String Id = uId.Text;

            if (Id != "")
            {
                String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                String Qry = "SELECT * FROM Users WHERE id = " + Id;
                SqlDataAdapter SDA = new SqlDataAdapter(Qry, Connection);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                Connection.Close();

                if (DT.Rows.Count > 0)
                {
                    uFullName.Text = DT.Rows[0]["full_name"].ToString();
                    uEmail.Text = DT.Rows[0]["email"].ToString();
                } 
                else
                {
                    MessageBox.Show("Error!!\nEnter a valid ID");
                }
            }
            else
            {
                MessageBox.Show("Error!!\nID Field can't be null or empty");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = uId.Text;
            String FullName = uFullName.Text;
            String Email = uEmail.Text;
            String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            String Qry = "UPDATE Users SET full_name = '"+ FullName +"', email = '"+Email+"' WHERE id = '"+id+"'";
            SqlCommand sqlCommand = new SqlCommand(Qry,Connection);
            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record Updated Successfully !!");
            }
            else
            {
                MessageBox.Show("Error!!\nIn Updating Record!!");
            }

            Connection.Close();
        }
    }
}

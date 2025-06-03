using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA3TA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void ClearFields()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtEmail.Text = "";
            TxtId.Enabled = true;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text,
                Name = TxtName.Text,
                Email = TxtEmail.Text
            };

            UserBLL userBLL = new UserBLL();
            if (userBLL.UserInsertBLL(user))
            {
                MessageBox.Show("User Inserted Successfully !!");
                LoadUsers();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nIn Inserting User !!");
            }

        }

        public void LoadUsers()
        {
            UserBLL userBLL = new UserBLL();
            GridUsers.DataSource = userBLL.GetUsersBLL();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text
            };

            UserBLL userBLL = new UserBLL();
            userBLL.GetUserByIDBLL(user);
            DataTable dt = userBLL.GetUserByIDBLL(user);
            if (dt.Rows.Count > 0)
            {
                TxtName.Text = dt.Rows[0]["full_name"].ToString();
                TxtEmail.Text = dt.Rows[0]["email"].ToString();

                TxtId.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error!!\nID Not Found");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text,
                Name = TxtName.Text,
                Email = TxtEmail.Text
            };

            UserBLL userBLL = new UserBLL();
            if (userBLL.UserUpdateBLL(user))
            {
                MessageBox.Show("User Updated Successfully !!");
                LoadUsers();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nIn Updating User !!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text
            };

            UserBLL userBLL = new UserBLL();
            if (userBLL.UserDeleteBLL(user))
            {
                MessageBox.Show("User Deleted Successfully !!");
                LoadUsers();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nIn Deleting User !!");
            }
        }
    }
}

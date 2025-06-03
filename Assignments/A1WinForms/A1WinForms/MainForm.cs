using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A1WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form student = new Student();
            student.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form teacher = new Teacher(); 
            teacher.ShowDialog();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form course = new Course();
            course.ShowDialog();
        }
    }
}

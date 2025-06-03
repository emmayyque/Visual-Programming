using AppProps;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StudentBLL
    {
        StudentDAL studentDAL = new StudentDAL();

        public bool InsertStudentBLL(Student student)
        {
            return studentDAL.InsertStudentDAL(student);
        }

        public bool UpdateStudentBLL(Student student)
        {
            return studentDAL.UpdateStudentDAL(student);
        }

        public bool DeleteStudentBLL(Student student)
        {
            return studentDAL.DeleteStudentDAL(student);
        }

        public DataTable GetAllStudentsBLL()
        {
            return studentDAL.GetAllStudentsDAL();
        }

        public DataTable GetStudentBLL(Student student)
        {
            return studentDAL.GetStudentDAL(student);
        }
    }
}

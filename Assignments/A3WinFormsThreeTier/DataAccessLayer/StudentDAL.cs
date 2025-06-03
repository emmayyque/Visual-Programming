using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentDAL
    {
        DbConn db = new DbConn();

        public bool InsertStudentDAL(Student student)
        {
            String Qry = "INSERT INTO Students (first_name, last_name, father_name, roll_no, sys_id, address, date_of_birth, date_of_admission) VALUES " +
                "('" + student.FirstName  + "', '" + student.LastName + "', '" + student.FatherName + "', '" + student.RollNo + "', '" + student.SysId + "', '" + student.Address + "', '" + student.DateOfBirth + "', '" + student.DateOfAdmission + "')";
            return db.UDI(Qry);
        }

        public bool UpdateStudentDAL(Student student)
        {
            String Qry = "UPDATE Students SET first_name = '" + student.FirstName + "', last_name = '" + student.LastName + "', father_name = '" + student.FatherName + "', sys_id = '" + student.SysId + "', address = '" + student.Address + "', date_of_birth = '" + student.DateOfBirth + "', date_of_admission = '" + student.DateOfAdmission + "' WHERE roll_no = '" + student.RollNo + "'";
            return db.UDI(Qry);
        }

        public bool DeleteStudentDAL(Student student)
        {
            String Qry = "DELETE FROM Students WHERE roll_no = '" + student.RollNo + "'";
            return db.UDI(Qry);
        }

        public DataTable GetAllStudentsDAL()
        {
            String Qry = "SELECT * FROM Students";
            return db.Search(Qry);
        }

        public DataTable GetStudentDAL(Student student)
        {
            String Qry = "SELECT * FROM Students WHERE roll_no = '" + student.RollNo + "'";
            return db.Search(Qry);
        }
    }
}

using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeacherDAL
    {
        DbConn db = new DbConn();

        public bool InsertTeacherDAL(Teacher teacher)
        {
            String Qry = "INSERT INTO Teachers (Id, first_name, last_name, experience, type, address, date_of_birth, date_of_joining) VALUES " +
                "('" + teacher.Id + "', '" + teacher.FirstName + "', '" + teacher.LastName + "', '" + teacher.Experience + "', '" + teacher.Type + "', '" + teacher.Address + "', '" + teacher.DateOfBirth + "', '" + teacher.DateOfJoining + "')";
            return db.UDI(Qry);
        }

        public bool UpdateTeacherDAL(Teacher teacher)
        {
            String Qry = "UPDATE Teachers SET Id='" + teacher.Id + "', first_name='" + teacher.FirstName + "', last_name='" + teacher.LastName + "', experience='" + teacher.Experience + "', type='" + teacher.Type + "', address='" + teacher.Address + "', date_of_birth='" + teacher.DateOfBirth + "', date_of_joining='" + teacher.DateOfJoining + "' WHERE Id = '" + teacher.Id + "'";
            return db.UDI(Qry);
        }

        public bool DeleteTeacherDAL(Teacher teacher)
        {
            String Qry = "DELETE FROM Teachers WHERE Id = '" + teacher.Id + "'";
            return db.UDI(Qry);
        }

        public DataTable GetAllTeachersDAL()
        {
            String Qry = "SELECT * FROM Teachers";
            return db.Search(Qry);
        }

        public DataTable GetTeacherDAL(Teacher teacher)
        {
            String Qry = "SELECT * FROM Teachers WHERE Id = '" + teacher.Id + "'";
            return db.Search(Qry);
        }
    }
}

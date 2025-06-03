using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        DbConn db = new DbConn();

        public bool UserInsertDAL(User user)
        {
            String Qry = "INSERT INTO Users (id, full_name, email) VALUES ('" + user.Id + "', '" + user.Name + "', '" + user.Email + "')";
            return db.UDI(Qry);
        }

        public bool UserUpdateDAL(User user)
        {
            String Qry = "UPDATE Users SET full_name = '" + user.Name + "', email = '" + user.Email + "' WHERE id = '" + user.Id + "'";
            return db.UDI(Qry);
        }

        public bool UserDeleteDAL(User user)
        {
            String Qry = "DELETE FROM Users WHERE id = '" + user.Id + "'";
            return db.UDI(Qry);
        }

        public DataTable GetUsersDAL()
        {
            String Qry = "SELECT * FROM Users";
            return db.Search(Qry);
        }

        public DataTable GetUserByID(User user)
        {
            String Qry = "SELECT * FROM Users WHERE id = '" + user.Id + "'";
            return db.Search(Qry);
        }
    }
}

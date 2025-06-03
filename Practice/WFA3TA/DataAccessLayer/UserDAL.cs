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
            return db.UDI("InsertUser", user);
        }

        public bool UserUpdateDAL(User user)
        {
            return db.UDI("UpdateUser", user);
        }

        public bool UserDeleteDAL(User user)
        {
            return db.UDI("DeleteUser", user);
        }

        public DataTable GetUsersDAL(User user)
        {
            return db.Search("GetUsers", user);
        }

        public DataTable GetUserByID(User user)
        {
            return db.Search("GetUser", user);
        }
    }
}

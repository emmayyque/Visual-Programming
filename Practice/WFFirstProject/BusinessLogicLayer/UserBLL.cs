using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();

        public bool InsertUserBLL(User user)
        {
            return userDAL.InsertUserDAL(user);
        }

        public bool UpdateUserBLL(User user)
        {
            return userDAL.UpdateUserDAL(user);
        }

        public bool DeleteUserBLL(User user)
        {
            return userDAL.DeleteUserDAL(user);
        }

        public DataTable GetUsers()
        {
            return userDAL.GetUsersDAL();
        }

        public DataTable GetUser(User user)
        {
            return userDAL.GetUserDAL(user);
        }
    }
}

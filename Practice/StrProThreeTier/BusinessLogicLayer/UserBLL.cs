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
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        
        public bool UserInsertBLL(User user)
        {
            return userDAL.UserInsertDAL(user);
        }

        public bool UserUpdateBLL(User user)
        {
            return userDAL.UserUpdateDAL(user);
        }

        public bool UserDeleteBLL(User user)
        {
            return userDAL.UserDeleteDAL(user);
        }

        public DataTable GetUsersBLL()
        {
            return userDAL.GetUsersDAL();
        }

        public DataTable GetUserByIDBLL(User user)
        {
            return userDAL.GetUserByID(user);
        }



    }
}

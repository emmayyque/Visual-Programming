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
    public class TeacherBLL
    {
        TeacherDAL teacherDAL = new TeacherDAL();

        public bool InsertTeacherBLL(Teacher teacher)
        {
            return teacherDAL.InsertTeacherDAL(teacher);
        }
        public bool UpdateTeacherBLL(Teacher teacher)
        {
            return teacherDAL.UpdateTeacherDAL(teacher);
        }

        public bool DeleteTeacherBLL(Teacher teacher)
        {
            return teacherDAL.DeleteTeacherDAL(teacher);
        }

        public DataTable GetAllTachersBLL()
        {
            return teacherDAL.GetAllTeachersDAL();
        }

        public DataTable GetTeacherBLL(Teacher teacher)
        {
            return teacherDAL.GetTeacherDAL(teacher);
        }
    }
}

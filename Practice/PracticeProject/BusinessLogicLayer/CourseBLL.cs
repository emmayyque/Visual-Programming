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
    public class CourseBLL
    {
        CourseDAL courseDAL = new CourseDAL();
        public bool InsertCourseBLL(Course course)
        {
            return courseDAL.InsertCourseDAL(course);
        }

        public bool UpdateCourseBLL(Course course)
        {
            return courseDAL.UpdateCourseDAL(course);
        }

        public bool DeleteCourseBLL(Course course)
        {
            return courseDAL.DeleteCourseDAL(course);
        }

        public DataTable GetAllCoursesBLL()
        {
            return courseDAL.GetAllCoursesDAL();
        }

        public DataTable GetCourseBLL(Course course)
        {
            return courseDAL.GetCourseDAL(course); ;
        }
    }
}

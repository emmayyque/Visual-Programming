using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseDAL
    {
        DbConn db = new DbConn();

        public bool InsertCourseDAL(Course course)
        {
            String Qry = "INSERT INTO Courses (course_code, course_name, credit_hours, duration, course_level, prerequisites, course_fee, instructor_name) VALUES ('" + course.CourseCode + "', '" + course.CourseName + "', '" + course.CreditHours + "', '" + course.Duration + "', '" + course.CourseLevel + "', '" + course.Prerequisites + "', '" + course.CourseFee + "', '" + course.InstructorName + "')";
            return db.UDI(Qry);
        }

        public bool UpdateCourseDAL(Course course)
        {
            String Qry = "UPDATE Courses SET course_name='" + course.CourseName + "', credit_hours='" + course.CreditHours + "', duration='" + course.Duration + "', course_level='" + course.CourseLevel + "', prerequisites='" + course.Prerequisites + "', course_fee='" + course.CourseFee + "', instructor_name='" + course.InstructorName + "' WHERE course_code = '" + course.CourseCode + "'";
            return db.UDI(Qry);
        }

        public bool DeleteCourseDAL(Course course)
        {
            String Qry = "DELETE FROM Courses WHERE course_code = '" + course.CourseCode + "'";
            return db.UDI(Qry);
        }

        public DataTable GetAllCoursesDAL()
        {
            String Qry = "SELECT * FROM Courses";
            return db.Search(Qry);
        }

        public DataTable GetCourseDAL(Course course)
        {
            String Qry = "SELECT * FROM Courses WHERE course_code = '" + course.CourseCode + "'";
            return db.Search(Qry);
        }
    }
}

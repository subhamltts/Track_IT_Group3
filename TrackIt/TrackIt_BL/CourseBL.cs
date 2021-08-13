using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class CourseBL
    {
        CourseDAL objCourse;
        public CourseBL()
        {
            objCourse = new CourseDAL();
        }
        public int AddNewCourse(CourseDTO newCourseDetails)
        {
            try
            {
                int returnvalue = objCourse.AddNewCourse(newCourseDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}


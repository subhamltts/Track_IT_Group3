using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DTO;

namespace TrackIt_DAL
{
    public class CourseDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public CourseDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public int AddNewCourse(CourseDTO ipCourse)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertCourse", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@CourseId", ipCourse.CourseId);
            sqlCmdObj.Parameters.AddWithValue("@CourseName", ipCourse.CourseName);

            try
            {
                sqlConObj.Open();
                SqlParameter returnManager = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                returnManager.Direction = ParameterDirection.ReturnValue;
                sqlCmdObj.ExecuteNonQuery();
                int returnValue = (int)returnManager.Value;
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}

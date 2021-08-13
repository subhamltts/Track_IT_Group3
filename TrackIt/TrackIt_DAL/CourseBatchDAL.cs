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
    public class CourseBatchDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public CourseBatchDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public int AddNewCourseBatch(CourseBatchDTO ipCourseBatch)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertCourseBatch", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            // sqlCmdObj.Parameters.AddWithValue("@CourseBatchId", ipCourseBatch.CourseBatchId);
            sqlCmdObj.Parameters.AddWithValue("@BatchId", ipCourseBatch.BatchId);
            sqlCmdObj.Parameters.AddWithValue("@CourseId", ipCourseBatch.CourseId);



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

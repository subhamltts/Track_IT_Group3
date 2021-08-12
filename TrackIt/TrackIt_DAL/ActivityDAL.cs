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
    public class ActivityDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public ActivityDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public int AddNewActivity(ActivityDTO ipActivity)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertActivity", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@Activity_Id", ipActivity.Activity_Id);
            sqlCmdObj.Parameters.AddWithValue("@CourseBatchId", ipActivity.CourseBatchId);
            sqlCmdObj.Parameters.AddWithValue("@Activity_Name", ipActivity.Activity_Name);

            sqlCmdObj.Parameters.AddWithValue("@Activity_SDT", ipActivity.Activity_SDT);
            sqlCmdObj.Parameters.AddWithValue("@Activity_EDT", ipActivity.Activity_EDT);
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
        public int AddNewActivityTracker(ActivityTrackerDTO ipActTracker)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertActivityTracker", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@Activity_Id", ipActTracker.Activity_Id);
            sqlCmdObj.Parameters.AddWithValue("@Activity_Name", ipActTracker.P_PSNo);
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

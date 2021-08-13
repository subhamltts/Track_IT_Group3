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
    public class BatchDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public BatchDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public int AddNewBatch(BatchDTO ipBatch)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertBatch", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            //sqlCmdObj.Parameters.AddWithValue("@Id", ipBatch.Id);
            sqlCmdObj.Parameters.AddWithValue("@BatchId", ipBatch.BatchId);
            sqlCmdObj.Parameters.AddWithValue("@F_PSNO", ipBatch.F_PSNO);
            sqlCmdObj.Parameters.AddWithValue("@P_PSNO", ipBatch.P_PSNO);


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

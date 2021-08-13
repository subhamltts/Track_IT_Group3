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
    public class ParticipantDAL
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;

        public ParticipantDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public int GetAllParticipantDetails(ParticipantDTO newParticipantDetails)
        {

            sqlCmdObj = new SqlCommand("dbo.uspInsertParticipantDetails", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@ParticipantId",newParticipantDetails.P_PSNo);
            sqlCmdObj.Parameters.AddWithValue("@ParticipantEmail", newParticipantDetails.P_EmailId);
            sqlCmdObj.Parameters.AddWithValue("@ParticipantName", newParticipantDetails.P_Name);

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

        public int AddNewParticipantDetails(ParticipantDTO newParticipantDetails)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertParticipant", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@ParticipantId", newParticipantDetails.P_PSNo);
            sqlCmdObj.Parameters.AddWithValue("@ParticipantEmail", newParticipantDetails.P_EmailId);
            sqlCmdObj.Parameters.AddWithValue("@ParticipantName", newParticipantDetails.P_Name);
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

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
        public List<ParticipantDTO> GetParticipant()
        {
            try
            {
                List<ParticipantDTO> lstFaculty = new List<ParticipantDTO>();
                TrackItConStr objContext = new TrackItConStr();
                var objPartDALList = objContext.Participants.ToList();
                foreach (var item in objPartDALList)
                {
                    lstFaculty.Add(
                        new ParticipantDTO
                        {
                            P_PSNo = item.P_PSNo,
                            P_EmailId = item.P_EmailId,
                            P_Name = item.P_Name
                        });
                }
                return lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
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

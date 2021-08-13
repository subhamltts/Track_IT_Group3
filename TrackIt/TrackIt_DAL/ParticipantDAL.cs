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
      
        public List<StatusDTO> GetActStatus(int participantId)
        {
            try
            {
                List<StatusDTO> lstActivityStatus = new List<StatusDTO>();
                TrackItConStr objContext = new TrackItConStr();

                var query = (from Part in objContext.Participants
                             join ActTkr in objContext.Activity_Tracker
                             on Part.P_PSNo equals ActTkr.P_PSNo
                             join Act in objContext.Activities
                             on ActTkr.Activity_Id equals Act.Activity_Id
                             where (Part.P_PSNo == participantId)
                             select new
                             {
                                 ParticipantId = Part.P_PSNo,
                                 ParticipantName = Part.P_Name,
                                 ActivityName = Act.Activity_Name,
                                 ActivityStatus = ActTkr.Activity_Status
                             }).ToList();


                foreach (var item in query)
                {
                    lstActivityStatus.Add(
                        new StatusDTO
                        {
                            P_PSNo = item.ParticipantId,
                            P_Name = item.ParticipantName,
                            Activity_Name = item.ActivityName,
                            Activity_Status = item.ActivityStatus
                        });
                }
                return lstActivityStatus;
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
            sqlCmdObj.Parameters.AddWithValue("@P_PSNo", newParticipantDetails.P_PSNo);
            sqlCmdObj.Parameters.AddWithValue("@P_EmailId", newParticipantDetails.P_EmailId);
            sqlCmdObj.Parameters.AddWithValue("@P_Name", newParticipantDetails.P_Name);
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

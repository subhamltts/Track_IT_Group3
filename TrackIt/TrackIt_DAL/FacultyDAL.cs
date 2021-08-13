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
    public class FacultyDAL
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;

        public FacultyDAL()
        {
           // sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public List<StatusDTO> GetStatus(string activityId,string activityStatus)
        {
            try
            {
                List<StatusDTO> lstPartByAct = new List<StatusDTO>();
                TrackItConStr objContext = new TrackItConStr();

                var query = (from Part in objContext.Participants
                            join ActTkr in objContext.Activity_Tracker
                            on Part.P_PSNo equals ActTkr.P_PSNo
                            join Act in objContext.Activities
                            on ActTkr.Activity_Id equals Act.Activity_Id
                            where (ActTkr.Activity_Id == activityId
                            && ActTkr.Activity_Status == activityStatus)
                            select new
                            {   ParticipantId = Part.P_PSNo, 
                                ParticipantName = Part.P_Name, 
                                ActivityName = Act.Activity_Name,
                                ActivityStatus = ActTkr.Activity_Status
                            }).ToList();

                
                foreach (var item in query)
                {
                    lstPartByAct.Add(
                        new StatusDTO
                        {
                            P_PSNo = item.ParticipantId,
                            P_Name = item.ParticipantName,
                            Activity_Name = item.ActivityName,
                            Activity_Status = item.ActivityStatus
                        });
                }
                return lstPartByAct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddNewFacultyDetails(FacultyDTO newFacultyDetails)
        {
            sqlCmdObj = new SqlCommand("dbo.uspInsertFaculty", sqlConObj);
            sqlCmdObj.CommandType = CommandType.StoredProcedure;
            sqlCmdObj.Parameters.AddWithValue("@F_PSNo", newFacultyDetails.F_PSNo);
            sqlCmdObj.Parameters.AddWithValue("@F_EmailId", newFacultyDetails.F_EmailId);
            sqlCmdObj.Parameters.AddWithValue("@F_Name", newFacultyDetails.F_Name);
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

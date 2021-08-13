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
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["TrackItDTConStr"].ToString());
        }
        public List<FacultyDTO> GetFaculties()
        {
            try
            {
                List<FacultyDTO> lstFaculty = new List<FacultyDTO>();
                TrackItConStr objContext = new TrackItConStr();
                var objFacDALList = objContext.Faculties.ToList();
                foreach (var item in objFacDALList)
                {
                    lstFaculty.Add(
                        new FacultyDTO
                        {
                            F_PSNo = item.F_PSNo,
                            F_EmailId = item.F_EmailId,
                            F_Name = item.F_Name
                        });
                }
                return lstFaculty;
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
            sqlCmdObj.Parameters.AddWithValue("@FacultyId", newFacultyDetails.F_PSNo);
            sqlCmdObj.Parameters.AddWithValue("@FacultyEmail", newFacultyDetails.F_EmailId);
            sqlCmdObj.Parameters.AddWithValue("@FacultyName", newFacultyDetails.F_Name);
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

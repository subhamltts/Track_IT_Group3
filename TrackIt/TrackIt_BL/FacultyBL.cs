using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class FacultyBL
    {
        FacultyDAL objFaculty;
        public FacultyBL()
        {
            objFaculty = new FacultyDAL();
        }
        public List<FacultyDTO> GetFaculties()
        {
            try
            {
                var lstFaculty = objFaculty.GetFaculties();
                return lstFaculty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewFacultyDetails(FacultyDTO newFacultyDetails)
        {
            try
            {
                int returnvalue = objFaculty.AddNewFacultyDetails(newFacultyDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

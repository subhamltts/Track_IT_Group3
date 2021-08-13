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
        public int GetAllFacultyDetails(FacultyDTO newFacultyDetails)
        {
            try
            {
                int returvalue = objFaculty.GetAllFacultyDetails(newFacultyDetails);
                return returvalue;
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

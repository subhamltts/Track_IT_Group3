using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class CourseBatchBL
    {
        CourseBatchDAL objCrcBatch;
        public CourseBatchBL()
        {
            objCrcBatch = new CourseBatchDAL();
        }
        public int AddNewCourseBatch(CourseBatchDTO newCourseBatchDetails)
        {
            try
            {
                int returnvalue = objCrcBatch.AddNewCourseBatch(newCourseBatchDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

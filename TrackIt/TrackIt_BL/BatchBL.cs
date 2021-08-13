using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class BatchBL
    {
        BatchDAL objBatch;
        public BatchBL()
        {
            objBatch = new BatchDAL();
        }
        public int AddNewBatch(BatchDTO newBatchDetails)
        {
            try
            {
                int returnvalue = objBatch.AddNewBatch(newBatchDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

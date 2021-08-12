using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class ActivityBL
    {
        ActivityDAL objActivity;
        public ActivityBL()
        {
            objActivity= new ActivityDAL();
        }
        public int AddNewActivity(ActivityDTO newActivityDetails)
        {
            try
            {
                int returnvalue = objActivity.AddNewActivity(newActivityDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewActivityTracker(ActivityTrackerDTO newActTrackerDetails)
        {
            try
            {
                int returnvalue = objActivity.AddNewActivityTracker(newActTrackerDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

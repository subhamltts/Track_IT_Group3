using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackIt_DAL;
using TrackIt_DTO;

namespace TrackIt_BL
{
    public class ParticipantBL
    {
        ParticipantDAL objParticipant;
        public ParticipantBL()
        {
            objParticipant = new ParticipantDAL();
        }

        public List<StatusDTO> GetActStatus(int participantId)
        {
            try
            {
                var lstActivityStatus = objParticipant.GetActStatus(participantId);
                return lstActivityStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewParticipantDetails(ParticipantDTO newParticipantDetails)
        {
            try
            {
                int returnvalue = objParticipant.AddNewParticipantDetails(newParticipantDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

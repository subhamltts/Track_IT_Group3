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
        public int GetAllParticipantDetails(ParticipantDTO newParticipantDetails)
        {
            try
            {
                int returvalue = objParticipant.GetAllParticipantDetails(newParticipantDetails);
                return returvalue;
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

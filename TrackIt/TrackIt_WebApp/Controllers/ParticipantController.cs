using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackIt_BL;
using TrackIt_DTO;

namespace TrackIt_WebApp.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpPost]
        [ActionName("AddParticipant")]
        public HttpResponseMessage AddParticipant(ParticipantDTO ipPartobj)
        {
            ParticipantBL objParticipant;
            try
            {

                if (ipPartobj != null && ipPartobj.P_PSNo != null && ipPartobj.P_EmailId != null && ipPartobj.P_Name != null)
                {
                    objParticipant = new ParticipantBL();
                    int retVal = objParticipant.AddNewParticipantDetails(ipPartobj);
                    if (retVal == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Data Added Successfully");
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Data Not Added");
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("Some Details are missing");
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Opppsssiiieee, SomeThing went wrong");
                return response;
            }
        }
    }
}

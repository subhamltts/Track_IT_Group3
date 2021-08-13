using Newtonsoft.Json;
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
        ParticipantBL objParticipant;
     
        [HttpGet]
        [ActionName("GetAllActStatus")]
        public HttpResponseMessage GetAllActivityStatus(int participantId)
        {

            try
            {
                objParticipant = new ParticipantBL();
                List<StatusDTO> lstActStatus = objParticipant.GetActStatus(participantId);
                if (lstActStatus != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lstActStatus));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("No Table Found");
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

        [HttpPost]
        [ActionName("AddParticipant")]
        public HttpResponseMessage AddParticipant(ParticipantDTO ipPartobj)
        {
            objParticipant = new ParticipantBL();
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

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
    public class FacultyController : ApiController
    {
        FacultyBL objFaculty;
        [HttpGet]
        [ActionName("GetPartStatusbyAct")]
        public HttpResponseMessage GetParticipantStatusByActivity(string activityId, string activityStatus)
        {
            
            try
            {
                objFaculty = new FacultyBL();
                List<StatusDTO> lstStatus = objFaculty.GetStatus(activityId, activityStatus); 
                if (lstStatus != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lstStatus));
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
        [ActionName("AddFaculty")]
        public HttpResponseMessage AddFaculties(FacultyDTO ipFacobj)
        {
           
            try
            {
                objFaculty = new FacultyBL();
                if (ipFacobj != null && ipFacobj.F_PSNo != null && ipFacobj.F_EmailId != null && ipFacobj.F_Name != null )
                {
                    objFaculty = new FacultyBL();
                    int retVal = objFaculty.AddNewFacultyDetails(ipFacobj);
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


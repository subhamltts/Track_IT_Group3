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
    public class ActivityTrackerController : ApiController
    {
        [HttpPost]
        [ActionName("UpdateActivityTracker")]
        public HttpResponseMessage UpdateActivityTracker(ActivityTrackerDTO ipActTrackerObj)
        {
            ActivityBL objActivity;
            try
            {

                if (ipActTrackerObj != null && ipActTrackerObj.Activity_Id != null && ipActTrackerObj.P_PSNo != null && ipActTrackerObj.Activity_Status != null && ipActTrackerObj.GitUrl != null)
                {
                    objActivity = new ActivityBL();
                    int retVal = objActivity.UpdateActivityTracker(ipActTrackerObj);
                    if (retVal == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Data Updated Successfully");
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

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
    public class ActivityController : ApiController
    {
        [HttpPost]
        [ActionName("AddActivities")]
        public HttpResponseMessage AddNewActivities(ActivityDTO ipActObj)
        {
            ActivityBL objActivity;
            try
            {

                if (ipActObj != null && ipActObj.Activity_Id != null && ipActObj.CourseBatchId != null && ipActObj.Activity_Name != null && ipActObj.Activity_SDT != null && ipActObj.Activity_EDT != null)
                {
                    objActivity = new ActivityBL();
                    int retVal = objActivity.AddNewActivity(ipActObj);
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
        [HttpPost]
        [ActionName("AddActivityTracker")]
        public HttpResponseMessage AddActivityTracker(ActivityTrackerDTO ipActTrackerObj)
        {
            ActivityBL objActivity;
            try
            {

                if (ipActTrackerObj != null && ipActTrackerObj.Activity_Id != null && ipActTrackerObj.P_PSNo != null)
                {
                    objActivity = new ActivityBL();
                    int retVal = objActivity.AddNewActivityTracker(ipActTrackerObj);
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

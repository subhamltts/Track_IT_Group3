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
    public class BatchController : ApiController
    {
        [HttpPost]
        [ActionName("AddBatch")]
        public HttpResponseMessage AddBatch(BatchDTO ipBatchObj)
        {
            BatchBL objBatch;
            try
            {

                if (ipBatchObj != null && ipBatchObj.BatchId != null && ipBatchObj.F_PSNO != null && ipBatchObj.P_PSNO != null)
                {
                    objBatch = new BatchBL();
                    int retVal = objBatch.AddNewBatch(ipBatchObj);
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

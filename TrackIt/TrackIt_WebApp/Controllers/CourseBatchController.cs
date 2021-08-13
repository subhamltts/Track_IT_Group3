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
    public class CourseBatchController : ApiController
    {
        [HttpPost]
        [ActionName("AddCourseBatch")]
        public HttpResponseMessage AddCourseBatch(CourseBatchDTO ipCrcBatchObj)
        {
            CourseBatchBL objCrcBatch;
            try
            {

                if (ipCrcBatchObj != null && ipCrcBatchObj.BatchId != null && ipCrcBatchObj.CourseId != null)
                {
                    objCrcBatch = new CourseBatchBL();
                    int retVal = objCrcBatch.AddNewCourseBatch(ipCrcBatchObj);
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

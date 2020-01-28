using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Threading.Tasks;
using Domain_Data.Data;
using Domain_Data.Models;

namespace WebAPI_Test_GAP.Controllers
{
    public class PolicyAssignmentController : ApiController
    {
        public IPolicyAssignmentRepository PolicyAssigmentRepository { get; set; }

        public PolicyAssignmentController(IPolicyAssignmentRepository policyAssigmentRepository)
        {
            this.PolicyAssigmentRepository = policyAssigmentRepository ?? throw new ArgumentNullException("policyAssigmentRepository");
        }

        [Route("api/PolicyAssignment/GetAssignedPolicies")]
        public async Task<HttpResponseMessage> GetAssignedPolicies()
        {
            var selectedAssignedPolicies = await this.PolicyAssigmentRepository.GetAssignedPoliciesAsync();

            if (selectedAssignedPolicies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(statusCode: HttpStatusCode.Created, selectedAssignedPolicies, Configuration.Formatters.JsonFormatter);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Assign data)
        {
            try
            {
                await this.PolicyAssigmentRepository.CreateAssignedPoliciesAsync(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await this.PolicyAssigmentRepository.DeleteAssignedPolicyAsync(id);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }
    }
}

using System;
using System.Net;
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
    public class PolicyController : ApiController
    {
        public IPolicyRepository PolicyRepository { get; set; }

        public PolicyController(IPolicyRepository policyRepository)
        {
            if (policyRepository == null)
            {
                throw new ArgumentNullException("policyRepository");
            }

            this.PolicyRepository = policyRepository;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var selectedPolicy = await this.PolicyRepository.GetPolicyByIdAsync(id);

            if (selectedPolicy == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Ok(selectedPolicy);
            }
        }

        [Route("api/Policy/GetPolicies")]
        public async Task<HttpResponseMessage> GetPolicies()
        {
            var selectedPolicies = await this.PolicyRepository.GetPoliciesAsync();

            if (selectedPolicies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(statusCode: HttpStatusCode.Created, selectedPolicies, Configuration.Formatters.JsonFormatter);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Policy data)
        {
            try
            {
                var isRiskHighResponse = this.ValidateRisk(data);
                if (isRiskHighResponse != null) 
                {
                    return isRiskHighResponse;
                }

                await this.PolicyRepository.CreatePolicyAsync(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] Policy data)
        {
            try
            {
                var isRiskHighResponse = this.ValidateRisk(data);
                if (isRiskHighResponse != null)
                {
                    return isRiskHighResponse;
                }

                await this.PolicyRepository.UpdatePolicyAsync(data);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK, data);
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
                await this.PolicyRepository.DeletePolicyAsync(id);
                return Request.CreateResponse(statusCode: HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(statusCode: HttpStatusCode.BadRequest, ex);
            }
        }

        private HttpResponseMessage ValidateRisk(Policy data) 
        {
            //Validates if Risk is high, we cannot assign more than 50 of coverage;
            if (data.Risktype == RiskType.High && data.CoverageType > 50)
            {
                return Request.CreateResponse(statusCode: HttpStatusCode.Unauthorized, "If Risk is high, we cannot assign more than 50 of coverage, Check the data out and try again.");
            }

            return null;
        }
    }
}

using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class PolicyAssignmentRepository : IPolicyAssignmentRepository
    {
        public IDataBaseConnector DatBaseConnector { get; set; }

        public PolicyAssignmentRepository(IDataBaseConnector datBaseConnector)
        {
            if (datBaseConnector == null)
            {
                throw new ArgumentNullException("datBaseConnector");
            }

            this.DatBaseConnector = datBaseConnector;
        }

        public async Task<IEnumerable<Assign>> GetAssignedPoliciesAsync()
        {
            var policiesAssigned = await this.DatBaseConnector.GetAssignedPoliciesAsync();

            var customersInfo = await this.DatBaseConnector.GetCustomersAsync();
            var policiesInfo = await this.DatBaseConnector.GetPoliciesAsync();

            foreach (var policyAssigned in policiesAssigned) 
            {
                foreach (var customer in customersInfo) 
                {
                    if(policyAssigned.CustomerId == customer.Id)
                        policyAssigned.CustomerName = customer.Name;
                }

                foreach (var policy in policiesInfo)
                {
                    if (policyAssigned.PolicyId == policy.Id)
                        policyAssigned.PolicyName = policy.Name;
                }
            }

            return policiesAssigned;
        }

        public async Task CreateAssignedPoliciesAsync(Assign data)
        {
            await this.DatBaseConnector.CreateAssignedPoliciesAsync(data);
        }
        
        public async Task DeleteAssignedPolicyAsync(int id)
        {
            await this.DatBaseConnector.DeleteAssignedPolicyAsync(id);
        }
    }
}

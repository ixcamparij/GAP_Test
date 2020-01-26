using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        public IDataBaseConnector DatBaseConnector { get; set; }

        public PolicyRepository(IDataBaseConnector datBaseConnector)
        {
            if (datBaseConnector == null)
            {
                throw new ArgumentNullException("datBaseConnector");
            }

            this.DatBaseConnector = datBaseConnector;
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            return await this.DatBaseConnector.GetPolicyByIdAsync(id);
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            return await this.DatBaseConnector.GetPoliciesAsync();
        }

        public async Task CreatePolicyAsync(Policy policy)
        {
            await this.DatBaseConnector.CreatePolicyAsync(policy);
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
            await this.DatBaseConnector.UpdatePolicyAsync(policy);
        }

        public async Task DeletePolicyAsync(int id)
        {
            await this.DatBaseConnector.DeletePolicyAsync(id);
        }
    }
}

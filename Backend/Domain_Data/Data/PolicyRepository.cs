using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        public IDataBaseConnector DataBaseConnector { get; set; }

        public PolicyRepository(IDataBaseConnector dataBaseConnector)
        {
            if (dataBaseConnector == null)
            {
                throw new ArgumentNullException("dataBaseConnector");
            }

            this.DataBaseConnector = dataBaseConnector;
        }

        public async Task<Policy> GetPolicyById(int id)
        {
            var policy = await this.DataBaseConnector.GetPolicyById(id);
            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            var policies = await this.DataBaseConnector.GetPolicies();
            return policies;
        }

        public async Task CreatePolicy(Policy user)
        {
            await this.DataBaseConnector.CreatePolicy(user);
        }

        public async Task UpdatePolicy(Policy user)
        {
            await this.DataBaseConnector.UpdatePolicy(user);
        }

        public async Task DeletePolicy(int id)
        {
            await this.DataBaseConnector.DeletePolicy(id);
        }
    }
}

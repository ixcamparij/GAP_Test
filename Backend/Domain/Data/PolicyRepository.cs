using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        public PolicyRepository()
        {

        }

        public async Task<Policy> GetPolicyById(string id)
        {
            await Task.CompletedTask;

            if (id == "1")
            {
                return new Policy()
                {
                    Id = "1",
                    Name = "policy1",
                    Description = "policy1",
                    CoverageType = 50,
                    EffectiveDate = DateTime.Now.AddMonths(1),
                    CoveragePeriod = 6,
                    Price = 2000,
                    Risktype = RiskType.Medium
                };
            }
            
            return null;           
        }

        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            await Task.CompletedTask;

            var policy1 = new Policy()
            {
                Id = "1",
                Name = "policy1",
                Description = "policy1",
                CoverageType = 50,
                EffectiveDate = DateTime.Now.AddMonths(1),
                CoveragePeriod = 6,
                Price = 2000,
                Risktype = RiskType.Medium
            };
            var policy2 = new Policy()
            {
                Id = "2",
                Name = "policy2",
                Description = "policy2",
                CoverageType = 35,
                EffectiveDate = DateTime.Now.AddMonths(2),
                CoveragePeriod = 9,
                Price = 7000,
                Risktype = RiskType.High
            };

            var policyList = new List<Policy>() { policy1, policy2 };

            return policyList;
        }

        public async Task CreatePolicy(Policy user)
        {
            await Task.CompletedTask;
        }

        public async Task UpdatePolicy(Policy user)
        {
            await Task.CompletedTask;
        }

        public async Task DeletePolicy(string id)
        {
            await Task.CompletedTask;
        }
    }
}

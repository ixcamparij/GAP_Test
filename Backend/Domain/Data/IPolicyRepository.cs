using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public interface IPolicyRepository
    {
        Task<Policy> GetPolicyById(string id);

        Task<IEnumerable<Policy>> GetPolicies();

        Task CreatePolicy(Policy user);

        Task UpdatePolicy(Policy user);

        Task DeletePolicy(string id);
    }
}

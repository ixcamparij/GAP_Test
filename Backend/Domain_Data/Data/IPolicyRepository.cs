using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public interface IPolicyRepository
    {
        Task<Policy> GetPolicyByIdAsync(int id);

        Task<IEnumerable<Policy>> GetPoliciesAsync();

        Task CreatePolicyAsync(Policy policy);

        Task UpdatePolicyAsync(Policy policy);

        Task DeletePolicyAsync(int id);
    }
}

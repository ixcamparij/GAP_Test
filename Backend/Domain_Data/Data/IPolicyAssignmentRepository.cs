using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public interface IPolicyAssignmentRepository
    {
        Task<IEnumerable<Assign>> GetAssignedPoliciesAsync();

        Task CreateAssignedPoliciesAsync(Assign data);

        Task DeleteAssignedPolicyAsync(int id);
    }
}

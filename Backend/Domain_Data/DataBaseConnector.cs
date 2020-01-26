using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Data.Models;
using NHibernate;
using NHibernate.Linq;

namespace Domain_Data
{
    public class DataBaseConnector : IDataBaseConnector
    {
        #region User

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                user = await session.GetAsync<User>(id);
            }

            return user;
        }

        public async Task<bool> GetUserAuthenticationAsync(User user)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var response = await session.Query<User>().Where(b => string.Equals(b.UserId, user.UserId, StringComparison.OrdinalIgnoreCase)).ToListAsync();
                if (response.Count >=1  && string.Equals(response.FirstOrDefault().Password, user.Password, StringComparison.Ordinal)) 
                {
                    return true;
                }
            }
            
            return false;
        }

        #endregion

        #region Customer
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                customer = await session.GetAsync<Customer>(id);
            }

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            IEnumerable<Customer> customer = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                customer = await session.Query<Customer>().ToListAsync();
            }

            return customer;
        }
        #endregion

        #region Policy
        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            Policy policy = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policy = await session.GetAsync<Policy>(id);
            }

            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            IEnumerable<Policy> policies = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policies = await session.Query<Policy>().ToListAsync();
            }

            return policies;
        }

        public async Task CreatePolicyAsync(Policy policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction()) 
                {
                    await session.SaveAsync(policy); 
                    await transaction.CommitAsync(); 
                }
            }
        }

        public async Task UpdatePolicyAsync(Policy policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveOrUpdateAsync(policy);
                    await transaction.CommitAsync();
                }
            }
        }

        public async Task DeletePolicyAsync(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Policy policy = await this.GetPolicyByIdAsync(id);

                using (ITransaction trans = session.BeginTransaction())
                {
                    await session.DeleteAsync(policy);
                    await trans.CommitAsync();
                }
            }
        }
        #endregion
    }
}

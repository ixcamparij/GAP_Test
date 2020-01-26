using Domain_Data.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Domain_Data
{
    public class DataBaseConnector : IDataBaseConnector
    {

        public DataBaseConnector()
        {

        }

        #region Customer
        public async Task<Customer> GetCustomerById(int id)
        {
            Customer customer = null;
            using (var session = NHibernateSession.OpenSession())
            {
                //customer = session.Query<Customer>().Where(b => b.Id == id).FirstOrDefault();
                customer = await session.GetAsync<Customer>(id);
            }

            await Task.CompletedTask;
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            IEnumerable<Customer> customers = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                customers = await session.Query<Customer>().ToListAsync();
            }

            await Task.CompletedTask;
            return customers;
        }
        #endregion

        #region User
        public async Task<User> GetUserById(int id)
        {
            User user = null;
            using (var session = NHibernateSession.OpenSession())
            {
                //user = session.Query<User>().Where(b => b.Id == id).FirstOrDefault();
                user = await session.GetAsync<User>(id);
            }

            return user;
        }
        #endregion

        #region Policy
        public async Task<Policy> GetPolicyById(int id)
        {
            Policy policy = null;
            using (var session = NHibernateSession.OpenSession())
            {
                policy = await session.GetAsync<Policy>(id);
            }

            //await Task.CompletedTask;
            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            IEnumerable<Policy> policies = null;
            using (ISession session = NHibernateSession.OpenSession())
            {
                policies = await session.Query<Policy>().ToListAsync();
            }

            return policies;
        }

        public async Task CreatePolicy(Policy policy)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveAsync(policy);
                    await transaction.CommitAsync();   //  Commit the changes to the database
                }
            }
        }

        public async Task UpdatePolicy(Policy policy)
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

        public async Task DeletePolicy(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Policy policy = session.Get<Policy>(id);

                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.DeleteAsync(policy);
                    await transaction.CommitAsync();
                }
            }
        }
        #endregion


    }
}
